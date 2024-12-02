using System.Data;
using MySql.Data.MySqlClient;
using DAT602_Game_XanderC.Objects;
using System.Text;
using System.Security.Cryptography;
using System.Diagnostics;

namespace DAT602_Game_XanderC
{
    class clsPlayerDAO : DatabaseAccessObject
    {
        // Hash the password
        public static class PasswordHelper
        {
            public static string HashPassword(string password)
            {
                // Create a SHA256 hash of the password
                using (var sha256 = SHA256.Create())
                {
                    // Convert the password to a byte array
                    var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                    // Convert the byte array to a string
                    return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                }
            }
        }

        // Set the user's logged in status
        public void SetUserLoggedInStatus(string username, bool isLoggedIn)
        {
            // Check if the connection is initialized
            if (mySqlConnection == null)
            {
                throw new InvalidOperationException("Connection is not initialized.");
            }

            // Open the connection if it is not open
            if (mySqlConnection.State != System.Data.ConnectionState.Open)
            {
                mySqlConnection.Open();
            }

            // Create the parameters for the stored procedure
            List<MySqlParameter> sqlParameters = new List<MySqlParameter>
            {
                new MySqlParameter()
                {
                    ParameterName = "@Username",
                    MySqlDbType = MySqlDbType.VarChar,
                    Size = 255,
                    Value = username
                },
                new MySqlParameter()
                {
                    ParameterName = "@IsLoggedIn",
                    MySqlDbType = MySqlDbType.Bit,
                    Value = isLoggedIn
                }
            };

            // Call the stored procedure to set the user's logged in status
            String SqlCall = "CALL SetUserLoggedInStatus(@Username, @IsLoggedIn)";
            // Execute the stored procedure
            MySqlHelper.ExecuteNonQuery(mySqlConnection, SqlCall, sqlParameters.ToArray());
        }


        // Get all players
        public List<Player> GetAllPlayers()
        {
            // Create a list of users
            List<Player> lcPlayers = new List<Player>();

            // Check if the connection is initialized
            var aDataSet = MySqlHelper.ExecuteDataset(mySqlConnection, "call GetAllPlayers()");
            lcPlayers = (from aResult in System.Data.DataTableExtensions.AsEnumerable(aDataSet.Tables[0])
                         select new Player
                         {
                             // Set the player properties
                             Username = Convert.ToString(aResult["Username"]),
                             Password = Convert.ToString(aResult["PasswordHash"]),
                             Email = Convert.ToString(aResult["Email"]),
                             Score = aResult["Score"] != DBNull.Value ? Convert.ToInt32(aResult["Score"]) : 0,
                             Attempts = aResult["FailedLoginAttempts"] != DBNull.Value ? Convert.ToInt32(aResult["FailedLoginAttempts"]) : 0,
                             LockedOut = Convert.ToBoolean(aResult["IsLocked"]),
                             TileID = aResult["CurrentTileID"] != DBNull.Value ? Convert.ToInt32(aResult["CurrentTileID"]) : 0,
                             IsAdmin = Convert.ToBoolean(aResult["IsAdmin"]),
                             IsLoggedIn = Convert.ToBoolean(aResult["IsLoggedIn"])
                         }).ToList();

            // Update the current player
            foreach (Player player in lcPlayers)
            {
                if (Player.CurrentPlayer != null && player.Username == Player.CurrentPlayer.Username)
                {
                    Player.CurrentPlayer = player;
                }
            }
            return lcPlayers;
        }

        // Get a player by username
        public Player GetPlayerByUsername(string username)
        {
            // Create a list of users
            List<MySqlParameter> sqlParameters = new List<MySqlParameter>
                {
                    new MySqlParameter()
                    {
                        ParameterName = "@pUsername",
                        MySqlDbType = MySqlDbType.VarChar,
                        Size = 255,
                        Value = username
                    }
                };

            var aDataSet = MySqlHelper.ExecuteDataset(mySqlConnection, "call GetPlayerByUsername(@pUsername)", sqlParameters.ToArray());

            if (aDataSet.Tables[0].Rows.Count > 0)
            {
                var aResult = aDataSet.Tables[0].Rows[0];
                return new Player
                {
                    // Set the player properties
                    Username = Convert.ToString(aResult["Username"]),
                    Password = Convert.ToString(aResult["Password"]),
                    Email = Convert.ToString(aResult["Email"]),
                    Score = aResult["Score"] != DBNull.Value ? Convert.ToInt32(aResult["Score"]) : 0,
                    Attempts = aResult["Attempts"] != DBNull.Value ? Convert.ToInt32(aResult["Attempts"]) : 0,
                    LockedOut = Convert.ToBoolean(aResult["LockedOut"]),
                    TileID = aResult["TileID"] != DBNull.Value ? Convert.ToInt32(aResult["TileID"]) : 0,
                    IsAdmin = Convert.ToBoolean(aResult["IsAdmin"]),
                    IsLoggedIn = Convert.ToBoolean(aResult["IsLoggedIn"])
                };
            }

            return null;
        }

        // Get list of all tiles
        public List<Tile> GetAllTiles(GameboardForm theForm)
        {
            List<Tile> lcTiles;

            var aDataSet = MySqlHelper.ExecuteDataset(mySqlConnection, "call GetAllTiles()");
            var enumTiles = System.Data.DataTableExtensions.AsEnumerable(aDataSet.Tables[0]);

            if (Tile.lcTiles.Count == 0)
            {
                lcTiles = new List<Tile>();

                lcTiles = (from aResult in enumTiles
                           select new Tile
                           {
                               id = Convert.ToInt32(aResult["id"]),
                               row = Convert.ToInt32(aResult["row"]),
                               col = Convert.ToInt32(aResult["col"]),
                               sword = aResult.Table.Columns.Contains("sword") ? Convert.ToInt32(aResult["sword"]) : 0,
                               shield = aResult.Table.Columns.Contains("shield") ? Convert.ToInt32(aResult["shield"]) : 0,
                               armor = aResult.Table.Columns.Contains("armor") ? Convert.ToInt32(aResult["armor"]) : 0,
                               potion = aResult.Table.Columns.Contains("potion") ? Convert.ToInt32(aResult["potion"]) : 0,
                               tile_form = theForm,
                               IsLegal = true
                           }).ToList();
                Tile.lcTiles = lcTiles;
            }
            else
            {
                foreach (var aResult in enumTiles)
                {
                    int id_offset = Convert.ToInt32(aResult["id"]) - 1;
                    Tile.lcTiles[id_offset].sword = aResult.Table.Columns.Contains("sword") ? Convert.ToInt32(aResult["sword"]) : 0;
                    Tile.lcTiles[id_offset].shield = aResult.Table.Columns.Contains("shield") ? Convert.ToInt32(aResult["shield"]) : 0;
                    Tile.lcTiles[id_offset].armor = aResult.Table.Columns.Contains("armor") ? Convert.ToInt32(aResult["armor"]) : 0;
                    Tile.lcTiles[id_offset].potion = aResult.Table.Columns.Contains("potion") ? Convert.ToInt32(aResult["potion"]) : 0;
                    Tile.lcTiles[id_offset].IsLegal = true;
                }
            }
            return Tile.lcTiles;
        }

        // Get all items
        public List<Item> GetAllItems()
        {
            List<Item> lcItems;

            var aDataSet = MySqlHelper.ExecuteDataset(mySqlConnection, "call GetAllItems()");
            var dataTable = aDataSet.Tables[0];

            // Required columns
            if (!dataTable.Columns.Contains("ItemID") ||
                !dataTable.Columns.Contains("TileID") ||
                !dataTable.Columns.Contains("Description") ||
                !dataTable.Columns.Contains("Points"))
            {
                throw new Exception("One or more required columns are missing from the result set.");
            }

            lcItems = (from aResult in System.Data.DataTableExtensions.AsEnumerable(dataTable)
                       select new Item
                       {
                           ItemID = Convert.ToInt32(aResult["ItemID"]),
                           TileID = Convert.ToInt32(aResult["TileID"]),
                           Description = Convert.ToString(aResult["Description"]),
                           Points = Convert.ToInt32(aResult["Points"])
                       }).ToList();

            return lcItems;
        }

        // Delete a player by username
        public void DeletePlayer(string username)
        {
            List<MySqlParameter> sqlParameters = new List<MySqlParameter>
                {
                    new MySqlParameter()
                    {
                        ParameterName = "@pUsername",
                        MySqlDbType = MySqlDbType.VarChar,
                        Size = 255,
                        Value = username
                    }
                };

            try
            {
                // Connection to the database
                using (var connection = new MySqlConnection("Server=localhost;Port=3306;Database=DAT602TILES;Uid=root;password=@useVim97"))
                {
                    connection.Open();
                    // Execute the stored procedure to delete the player
                    MySqlHelper.ExecuteNonQuery(connection, "CALL DeletePlayer(@pUsername)", sqlParameters.ToArray());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to delete player: {ex.Message}");
                throw;
            }
        }

        // Move the player to a new tile
        public bool MovePlayer(int playerId, int newTileId)
        {
            using (var connection = new MySqlConnection("Server=localhost;Port=3306;Database=DAT602TILES;Uid=root;password=@useVim97"))
            {
                using (var command = new MySqlCommand("MovePlayer", connection))
                {
                    // Call the stored procedure to move the player
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_player_id", playerId);
                    command.Parameters.AddWithValue("p_tile_id", newTileId);
                    var successParam = new MySqlParameter("p_success", MySqlDbType.Bit);
                    successParam.Direction = ParameterDirection.Output;
                    command.Parameters.Add(successParam);

                    connection.Open();
                    command.ExecuteNonQuery();

                    return Convert.ToBoolean(successParam.Value);
                }
            }
        }

        // Update the player's tile
        public void UpdatePlayerTile(int playerId, int tileId)
        {
            try
            {
                using (var connection = new MySqlConnection("Server=localhost;Port=3306;Database=DAT602TILES;Uid=root;password=@useVim97;"))
                {
                    connection.Open();
                    // Update the player's current tile in the database 
                    using (var command = new MySqlCommand("UPDATE Players SET CurrentTileID = @tileId WHERE PlayerID = @playerId", connection))
                    {
                        command.Parameters.AddWithValue("@tileId", tileId);
                        command.Parameters.AddWithValue("@playerId", playerId);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error updating player tile: {ex.Message}");
            }
        }


        // Permissions denied by db (cant edit in gui)
        public void UpdateAdminPermissions()
        {
            using (var connection = new MySqlConnection(mySqlConnection.ConnectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand("CALL UpdateAdminPermissions()", connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        // Permissions denied by db (cant edit in gui)
        public void UpdatePlayerDetails(string oldUsername, string newUsername, string newPassword, string newEmail)
        {
            using (var connection = new MySqlConnection(mySqlConnection.ConnectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand("UPDATE Players SET Username = @NewUsername, Password = @NewPassword, Email = @NewEmail WHERE Username = @OldUsername", connection))
                {
                    command.Parameters.AddWithValue("@NewUsername", newUsername);
                    command.Parameters.AddWithValue("@NewPassword", newPassword);
                    command.Parameters.AddWithValue("@NewEmail", newEmail);
                    command.Parameters.AddWithValue("@OldUsername", oldUsername);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Permissions denied by db (cant edit in gui)
        public void UpdatePlayerAttempts(string username, int attempts)
        {
            using (var connection = new MySqlConnection(mySqlConnection.ConnectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand("UPDATE Players SET FailedLoginAttempts = @Attempts WHERE Username = @Username", connection))
                {
                    command.Parameters.AddWithValue("@Attempts", attempts);
                    command.Parameters.AddWithValue("@Username", username);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Permissions denied by db (cant edit in gui)
        public void UpdatePlayerAdminAndLockStatus(string username, bool isAdmin, bool isLocked)
        {
            using (var connection = new MySqlConnection(mySqlConnection.ConnectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand("UPDATE Players SET IsAdmin = @IsAdmin, IsLocked = @IsLocked WHERE Username = @Username", connection))
                {
                    command.Parameters.AddWithValue("@IsAdmin", isAdmin);
                    command.Parameters.AddWithValue("@IsLocked", isLocked);
                    command.Parameters.AddWithValue("@Username", username);
                    command.ExecuteNonQuery();
                }

                // Call the stored procedure to update admin permissions
                UpdateAdminPermissions();
            }
        }

        public void Update(String pUsername, String pPassword, String pEmail, int pScore, int pAttempts, bool pLockedOut, int pTile, bool pIsAdmin, bool pIsLoggedIn)
        {
            List<MySqlParameter> sqlParameters = new List<MySqlParameter>{
                   new MySqlParameter(){
                                    ParameterName = "@Username",
                                    MySqlDbType = MySqlDbType.VarChar,
                                    Size = 255,
                                    Value = pUsername
                   },
                   new MySqlParameter(){
                                    ParameterName = "@Password",
                                    MySqlDbType = MySqlDbType.VarChar,
                                    Size = 255,
                                    Value = pPassword
                   },
                   new MySqlParameter(){
                                    ParameterName = "@Email",
                                    MySqlDbType = MySqlDbType.VarChar,
                                    Size = 255,
                                    Value = pEmail
                   },
                   new MySqlParameter(){
                                    ParameterName = "@Score",
                                    MySqlDbType = MySqlDbType.Int32,
                                    Value = pScore
                   },
                   new MySqlParameter(){
                                    ParameterName = "@Attempts",
                                    MySqlDbType = MySqlDbType.Int32,
                                    Value = pAttempts
                   },
                   new MySqlParameter(){
                                    ParameterName = "@LockedOut",
                                    MySqlDbType = MySqlDbType.Bit,
                                    Value = pLockedOut
                   },
                   new MySqlParameter(){
                                    ParameterName = "@TileID",
                                    MySqlDbType = MySqlDbType.Int32,
                                    Value = pTile
                   },
                   new MySqlParameter(){
                                    ParameterName = "@IsAdmin",
                                    MySqlDbType = MySqlDbType.Bit,
                                    Value = pIsAdmin
                   },
                   new MySqlParameter(){
                                    ParameterName = "@IsLoggedIn",
                                    MySqlDbType = MySqlDbType.Bit,
                                    Value = pIsLoggedIn
                   },
                };
            String SqlCall = "CALL UpdatePlayer(@Username, @Password, @Email, @Score, @Attempts, @LockedOut, @TileID, @IsAdmin, @IsLoggedIn)";

            var aDataSet = MySqlHelper.ExecuteDataset(mySqlConnection, SqlCall, sqlParameters.ToArray());
        }
    }
}