namespace DAT602_Game_XanderC
{
    public partial class RegistrationForm : Form
    {
        private RegistrationForm _register;
        private LoginForm _login;
        private MainScreenForm _home;

        public RegistrationForm()
        {
            InitializeComponent();
        }

        // Event handler for the registration button click
        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            // Retrieve user input from textboxes
            string username = UsernameTextbox.Text;
            string password = PasswordTextbox.Text;
            string email = EmailTextbox.Text;

            // Create an instance of the login data access object
            clsLoginDAO loginDAO = new clsLoginDAO();
            // Attempt to register the user with the provided details
            bool isRegistered = loginDAO.Register(username, password, email);

            // Check if registration was successful
            if (isRegistered)
            {
                MessageBox.Show("Registration successful!");
                this.Hide();
                // Show the login form after successful registration
                LoginForm _login = new LoginForm();
                _login.ShowDialog();
            }
            else
            {
                MessageBox.Show("Registration failed. Please try again.");
            }
        }

        // Event handler for the login button click
        private void LoginButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show the login form when the login button is clicked
            LoginForm _login = new LoginForm();
            _login.ShowDialog();
        }
    }
}
