using MySql.Data.MySqlClient;

namespace DAT602_Game_XanderC
{
    internal class DatabaseAccessObject
    {
        // Connection string to the database
        private static string connectionString
        {
            get { return "Server=localhost;Port=3306;Database=DAT602TILES;Uid=root;password=@useVim97;"; }
        }

        // Static MySqlConnection object
        private static MySqlConnection? _mySqlConnection = null;

        // MySqlConnection object
        protected MySqlConnection mySqlConnection
        {
            get
            {
                if (_mySqlConnection == null)
                {
                    _mySqlConnection = new MySqlConnection(connectionString);
                }

                return _mySqlConnection;

            }
        }

        // Test the connection to the database
        public bool TestConnection()
        {
            try
            {
                // Open the connection
                using (var connection = new MySqlConnection(mySqlConnection.ConnectionString))
                {
                    connection.Open();
                    Console.WriteLine("Connection successful!");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Connection failed: {ex.Message}");
                return false;
            }
        }
    }
}
