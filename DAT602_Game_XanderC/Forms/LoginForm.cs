using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace DAT602_Game_XanderC
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            CheckConnectionStatus();
        }

        // Check the connection status to the database
        private void CheckConnectionStatus()
        {
            try
            {
                lblConnectionStatus.Text = "Connected to the database.";
                lblConnectionStatus.ForeColor = Color.Green;
            }
            catch (MySqlException ex)
            {
                lblConnectionStatus.Text = $"Database connection error: {ex.Message}";
                lblConnectionStatus.ForeColor = Color.Red;
            }
            catch (Exception ex)
            {
                lblConnectionStatus.Text = $"Error: {ex.Message}";
                lblConnectionStatus.ForeColor = Color.Red;
            }
        }

        // Open the registration form
        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationForm _Register = new RegistrationForm();
            _Register.ShowDialog();
        }

        // Login button
        private void LoginLoginButton_Click(object sender, EventArgs e)
        {
            // Get the username and password
            string username = LoginUsernameTextbox.Text;
            string password = LoginPasswordTextbox.Text;

            // Check if the username and password are empty
            clsLoginDAO loginDAO = new clsLoginDAO();
            LoginState loginState = loginDAO.Login(username, password);

            // Check the login state
            switch (loginState)
            {
                case LoginState.Success:
                    Debug.WriteLine("hit success");
                    MessageBox.Show(loginDAO.Message);
                    // Set the user as logged in
                    clsPlayerDAO playerDAO = new clsPlayerDAO();
                    playerDAO.SetUserLoggedInStatus(username, true);
                    // Get the player object
                    Player loggedInPlayer = playerDAO.GetPlayerByUsername(username);
                    // Check if the player object is not null
                    if (loggedInPlayer != null)
                    {
                        this.Hide();
                        MainScreenForm mainScreen = new MainScreenForm();
                        mainScreen.ShowDialog(this, loggedInPlayer);
                    }
                    else
                    {
                        MessageBox.Show("Failed to retrieve player details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                // If the login is incorrect
                case LoginState.Locked_out:
                    Debug.WriteLine("hit lock");
                    MessageBox.Show(loginDAO.Message);
                    break;
                // If the login is incorrect
                default:
                    Debug.WriteLine("hit default");
                    MessageBox.Show(loginDAO.Message);
                    break;
            }
        }
    }
}