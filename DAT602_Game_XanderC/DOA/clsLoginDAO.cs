using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using MySql.Data.MySqlClient;

namespace DAT602_Game_XanderC
{
    // Enum to represent the state of the login attempt
    enum LoginState
    {
        Success,
        Locked_out,
        Fail
    }

    internal class clsLoginDAO : DatabaseAccessObject
    {
        // Property to store messages
        public string Message { get; private set; } = string.Empty;

        // Method to handle user login
        public LoginState Login(string pUserName, string pPassword)
        {
            LoginState lcResult = LoginState.Fail;
            List<MySqlParameter> p = new List<MySqlParameter>();

            // Add username parameter
            var aP = new MySqlParameter("@UserName", MySqlDbType.VarChar, 50);
            aP.Value = pUserName;
            p.Add(aP);

            // Add hashed password parameter
            var bP = new MySqlParameter("@Password", MySqlDbType.VarChar, 255);
            bP.Value = HashPassword(pPassword);
            p.Add(bP);

            try
            {
                Debug.WriteLine("Executing stored procedure with parameters:");
                Debug.WriteLine($"Username: {pUserName}");
                Debug.WriteLine($"Password: {HashPassword(pPassword)}");

                using (var connection = new MySqlConnection(mySqlConnection.ConnectionString))
                {
                    connection.Open();

                    // Check if the user is locked
                    var checkLockCommand = new MySqlCommand("SELECT IsLocked FROM Players WHERE Username = @UserName", connection);
                    checkLockCommand.Parameters.AddWithValue("@UserName", pUserName);
                    bool isLocked = Convert.ToBoolean(checkLockCommand.ExecuteScalar());

                    if (isLocked)
                    {
                        Debug.WriteLine($"User {pUserName} is locked out.");
                        Message = "Your account is locked. Please contact support.";
                        return LoginState.Locked_out;
                    }

                    // Execute the stored procedure for login
                    var aDataSet = MySqlHelper.ExecuteDataset(connection, "CALL PlayerLogin(@UserName, @Password)", p.ToArray());

                    if (aDataSet.Tables.Count > 0 && aDataSet.Tables[0].Rows.Count > 0)
                    {
                        DataRow arow = aDataSet.Tables[0].Rows[0];
                        string? rowValue = arow["Message"] as string;

                        Debug.WriteLine($"Stored procedure returned message: {rowValue}");

                        if (rowValue == "Login successful")
                        {
                            lcResult = LoginState.Success;
                            Player.CurrentPlayer = new Player
                            {
                                Username = pUserName,
                                Score = arow["Score"] != DBNull.Value ? Convert.ToInt32(arow["Score"]) : 0,
                                TileID = arow["CurrentTileID"] != DBNull.Value ? Convert.ToInt32(arow["CurrentTileID"]) : 0,
                                Update = true
                            };

                            // Reset failed login attempts
                            ResetFailedLoginAttempts(pUserName);
                            Message = "Login successful.";
                        }
                        else if (rowValue == "Locked Out")
                        {
                            lcResult = LoginState.Locked_out;
                            Message = "Your account is locked.";
                        }
                        else
                        {
                            // Increment failed login attempts
                            IncrementFailedLoginAttempts(pUserName);
                            Message = "Invalid username or password.";
                        }
                    }
                    else
                    {
                        Debug.WriteLine("No rows returned from stored procedure.");
                        Message = "Invalid username or password.";
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Login failed: {ex.Message}");
                Message = "An error occurred during login. Please try again later.";
            }

            return lcResult;
        }

        // Increment failed login attempts
        private void IncrementFailedLoginAttempts(string pUserName)
        {
            try
            {
                using (var connection = new MySqlConnection(mySqlConnection.ConnectionString))
                {
                    connection.Open();
                    var command = new MySqlCommand("CALL IncrementFailedLoginAttempts(@UserName, @LockedOut)", connection);
                    command.Parameters.AddWithValue("@UserName", pUserName);
                    var lockedOutParam = new MySqlParameter("@LockedOut", MySqlDbType.Bit);
                    lockedOutParam.Direction = ParameterDirection.Output;
                    command.Parameters.Add(lockedOutParam);
                    command.ExecuteNonQuery();

                    bool isLockedOut = Convert.ToBoolean(lockedOutParam.Value);
                    if (isLockedOut)
                    {
                        Debug.WriteLine($"User {pUserName} has been locked out due to too many failed login attempts.");
                        Message = "Your account has been locked due to too many failed login attempts.";
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to increment login attempts: {ex.Message}");
                Message = "An error occurred while processing your login attempts. Please try again later.";
            }
        }

        // Reset failed login attempts
        private void ResetFailedLoginAttempts(string pUserName)
        {
            try
            {
                using (var connection = new MySqlConnection(mySqlConnection.ConnectionString))
                {
                    connection.Open();
                    var command = new MySqlCommand("UPDATE Players SET FailedLoginAttempts = 3 WHERE Username = @UserName", connection);
                    command.Parameters.AddWithValue("@UserName", pUserName);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to reset login attempts: {ex.Message}");
                Message = "An error occurred while resetting login attempts. Please try again later.";
            }
        }

        // Hash the password using SHA256
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }

        // Register a new user
        public bool Register(string pUserName, string pPassword, string pEmail)
        {
            bool isRegistered = false;
            List<MySqlParameter> p = new List<MySqlParameter>();
            var aP = new MySqlParameter("@UserName", MySqlDbType.VarChar, 50);
            aP.Value = pUserName;
            p.Add(aP);

            var bP = new MySqlParameter("@Password", MySqlDbType.VarChar, 255);
            bP.Value = HashPassword(pPassword);
            p.Add(bP);

            var cP = new MySqlParameter("@Email", MySqlDbType.VarChar, 100);
            cP.Value = pEmail;
            p.Add(cP);

            try
            {
                Debug.WriteLine("Executing stored procedure with parameters:");
                Debug.WriteLine($"Username: {pUserName}");
                Debug.WriteLine($"Password: {HashPassword(pPassword)}");
                Debug.WriteLine($"Email: {pEmail}");

                using (var connection = new MySqlConnection(mySqlConnection.ConnectionString))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            MySqlHelper.ExecuteNonQuery(connection, "CALL RegisterPlayer(@UserName, @Password, @Email)", p.ToArray());
                            transaction.Commit();
                            isRegistered = true;
                            Debug.WriteLine("Registration successful and transaction committed.");
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            Debug.WriteLine($"Registration failed and transaction rolled back: {ex.Message}");
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 45000)
                {
                    Debug.WriteLine("Registration failed: Username already exists.");
                }
                else
                {
                    Debug.WriteLine($"Registration failed: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Registration failed: {ex.Message}");
            }

            return isRegistered;
        }

        // Get all users
        public List<Player> GetAllUsers()
        {
            List<Player> users = new List<Player>();

            try
            {
                using (var connection = new MySqlConnection(mySqlConnection.ConnectionString))
                {
                    connection.Open();
                    var aDataSet = MySqlHelper.ExecuteDataset(connection, "SELECT Username, Email, Score, CurrentTileID FROM Players");

                    if (aDataSet.Tables.Count > 0 && aDataSet.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in aDataSet.Tables[0].Rows)
                        {
                            users.Add(new Player
                            {
                                Username = row["Username"].ToString(),
                                Email = row["Email"].ToString(),
                                Score = Convert.ToInt32(row["Score"]),
                                TileID = Convert.ToInt32(row["CurrentTileID"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to retrieve users: {ex.Message}");
            }

            return users;
        }

        // Test the connection to the database
        public bool TestLoginConnection()
        {
            try
            {
                using (var connection = new MySqlConnection(mySqlConnection.ConnectionString))
                {
                    connection.Open();
                    Debug.WriteLine("Connection successful!");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Connection failed: {ex.Message}");
                return false;
            }
        }
    }
}