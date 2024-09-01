namespace DAT602_Game_XanderC
{
    public partial class LoginForm : Form
    {
        private LoginForm _login;
        private MainScreenForm _home;
        private Player _player;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationForm _Register = new RegistrationForm();
            _Register.ShowDialog();
        }

        private void LoginLoginButton_Click(object sender, EventArgs e)
        {
            DataAccessObject dbLogin = new DataAccessObject();
            MessageBox.Show(dbLogin.Login("Mary101", "Password1234"));

            _home = new MainScreenForm();
            _home.Show();
            this.Hide();
        }
    }
}