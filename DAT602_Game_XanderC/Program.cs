namespace DAT602_Game_XanderC
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());

            clsLoginDAO loginDAO = new clsLoginDAO();
            bool isConnected = loginDAO.TestConnection();
            bool loginIsConnected = loginDAO.TestLoginConnection();
            Console.WriteLine($"Database connection status: {isConnected}");
            Console.WriteLine($"Database connection status: {loginIsConnected}");
        }
    }
}