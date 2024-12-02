using DAT602_Game_XanderC.Forms;

namespace DAT602_Game_XanderC
{
    public partial class MainScreenForm : Form
    {
        private AdminConsoleForm _adminForm;
        private GameboardForm _gameboard;
        public Player _player;

        public MainScreenForm()
        {
            InitializeComponent();

            // Initialize the update account button and attach the click event handler
            this.updateAccBtn = new System.Windows.Forms.Button();
            this.updateAccBtn.Click += new System.EventHandler(this.updateAccBtn_Click);
        }

        // Show the dialog and set the player
        public bool ShowDialog(LoginForm login, Player player)
        {
            _player = player;
            AdminConsoleButton.Enabled = _player.IsAdmin;

            //MessageBox.Show($"Player set: {_player.Username}", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return ShowDialog() == DialogResult.OK;
        }

        // Override the OnShown method to enable or disable the update account button based on player login status
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (_player != null && _player.IsLoggedIn)
            {
                updateAccBtn.Enabled = true;
            }
            else
            {
                updateAccBtn.Enabled = false;
            }
        }

        // Event handler for the Admin Console button click
        private void AdminConsoleButton_Click(object sender, EventArgs e)
        {
            _adminForm = new AdminConsoleForm();
            _adminForm.ShowDialog();
        }

        // Event handler for the Log Out button click
        private void LogOutButton_Click(object sender, EventArgs e)
        {
            if (_player != null)
            {
                // Create an instance of the player data access object
                clsPlayerDAO playerDAO = new clsPlayerDAO();
                // Set the user's logged-in status to false in the database
                playerDAO.SetUserLoggedInStatus(_player.Username, false);
                // Update the player's logged-in status in the application
                _player.IsLoggedIn = false;
                MessageBox.Show("You have been logged out.");
                Application.Exit();
            }
            else
            {
                // Show an error message if the player is not initialized
                MessageBox.Show("Error: Player is not initialized.");
            }
        }

        // Event handler for the New Game button click
        private void NewGameButton_Click(object sender, EventArgs e)
        {
            if (_gameboard != null)
            {
                _gameboard.Dispose();
            }

            _gameboard = new GameboardForm(this);
            _gameboard.Show();
            this.Hide();
        }

        // Event handler for the Gameboard form closed event
        private void GameboardFormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        // Event handler for the update account button click
        private void updateAccBtn_Click(object sender, EventArgs e)
        {
            if (_player != null && _player.IsLoggedIn)
            {
                //MessageBox.Show($"Player: {_player.Username}", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateDetailsForm updateDetailsForm = new UpdateDetailsForm(_player);
                updateDetailsForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("You are logged out. Please log in again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}