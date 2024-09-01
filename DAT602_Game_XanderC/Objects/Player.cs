namespace DAT602_Game_XanderC
{
    public class Player
    {
        public static Player CurrentPlayer { get; set; }
        public int PlayerID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Score { get; set; }
    }
}
