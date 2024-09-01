using MySql.Data.MySqlClient;

namespace DAT602_Game_XanderC
{
    class DataAccessObject
    {
        public static string connectionString
        {
            get { return "Server=localhost;Port=3306;Database=DAT602_A1_XanderC_2024;Uid=root;password=Archenemy042;"; }
        }

        private static MySqlConnection _mySqlConnection = null;
        public static MySqlConnection mySqlConnection
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

        public string Login(string pUsername, string pPassword)
        {
            List<MySqlParameter> p = new List<MySqlParameter>();

            var aP = new MySqlParameter("@username", MySqlDbType.VarChar, 50);
            aP.Value = pUsername;
            p.Add(aP);

            var bP = new MySqlParameter("@password", MySqlDbType.VarChar, 50);
            bP.Value = pPassword;
            p.Add(bP);

            var aDataSet = MySqlHelper.ExecuteDataset(mySqlConnection, "call Login(@username, @password)", p.ToArray());

            return (aDataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
        }

    }
}
