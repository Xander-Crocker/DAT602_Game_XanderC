namespace DAT602_Game_XanderC
{
    public delegate void Then();
    public class Player
    {
        // Class variables
        private string? _username;
        private string? _password;
        private string? _email;
        private int _attempts;
        private bool _locked_out;
        private int _tileid;
        private int _score;
        private bool _isAdmin;
        private bool _isLoggedIn;

        // Class objects
        public Tile? CurrentTile { get; set; }
        public object PlayerID { get; internal set; }

        // Class statics
        public static Player? CurrentPlayer { get; set; }
        public static List<Player> lcPlayers = new List<Player>();

        // Control
        public Boolean Update = false;
        public Then? then;

        // Properties
        public string? Username
        {
            get { return _username; }
            set
            {
                _username = value;
                if (Update) updateData();
            }
        }

        public string? Password
        {
            get { return _password; }
            set
            {
                _password = value;
                if (Update) updateData();
            }
        }

        public string? Email
        {
            get { return _email; }
            set
            {
                _email = value;
                if (Update) updateData();
            }
        }

        public int Score
        {
            get { return _score; }
            set
            {
                _score = value;
                if (Update) updateData();
            }
        }

        public int Attempts
        {
            get { return _attempts; }
            set
            {
                _attempts = value;
                if (Update) updateData();
            }
        }

        public bool LockedOut
        {
            get { return _locked_out; }
            set
            {
                _locked_out = value;
                if (Update) updateData();
            }
        }

        public int TileID
        {
            get { return _tileid; }
            set
            {
                _tileid = value;
                if (Update) updateData();
            }
        }

        public bool IsAdmin
        {
            get { return _isAdmin; }
            set
            {
                _isAdmin = value;
                if (Update) updateData();
            }
        }

        public bool IsLoggedIn
        {
            get { return _isLoggedIn; }
            set
            {
                _isLoggedIn = value;
                if (Update) updateData();
            }
        }

        // Editor GUI
        public void Edit(Then pRunNext)
        {
            then = pRunNext;
            AdminEditorForm editor = new AdminEditorForm(this);
            editor.Show();
        }

        // Constructor
        public void UpdateData()
        {
            if (this.Update == true)
            {
                this.updateData();
                if (Player.CurrentPlayer != null && this.Username == Player.CurrentPlayer.Username)
                {
                    Player.CurrentPlayer.Update = false;
                    Player.CurrentPlayer.Username = this.Username;
                    Player.CurrentPlayer.Password = this.Password;
                    Player.CurrentPlayer.Email = this.Email;
                    Player.CurrentPlayer.TileID = this.TileID;
                    Player.CurrentPlayer.LockedOut = this.LockedOut;
                    Player.CurrentPlayer.Score = this.Score;
                    Player.CurrentPlayer.Attempts = this.Attempts;
                    Player.CurrentPlayer.IsAdmin = this.IsAdmin;
                    Player.CurrentPlayer.IsLoggedIn = this.IsLoggedIn;
                }
                this.Update = false;
            }
        }

        // Private Methods
        private void updateData()
        {
            if (_username != null && _password != null && _email != null)
            {
                clsPlayerDAO dbAccess = new clsPlayerDAO();
                dbAccess.Update(_username, _password, _email, _score, _attempts, _locked_out, _tileid, _isAdmin, _isLoggedIn);
            }
        }
    }
}