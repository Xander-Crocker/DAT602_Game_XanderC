namespace DAT602_Game_XanderC
{
    public partial class MainScreenForm : Form
    {
        private RegistrationForm _register;
        private LoginForm _login;
        private AdminConsoleForm _adminForm;
        private GameboardForm _gameboard;
        public Player _player;

        public MainScreenForm()
        {
            InitializeComponent();
        }

        public bool ShowDialog(LoginForm login, Player player)
        {
            _login = login;
            _player = player;
            return ShowDialog() == DialogResult.OK;
        }

        private void AdminConsoleButton_Click(object sender, EventArgs e)
        {
            _adminForm = new AdminConsoleForm();
            this.Hide();
            _adminForm.ShowDialog();
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void deleteAccBtn_Click(object sender, EventArgs e)
        {

        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            _gameboard = new GameboardForm();
            _gameboard.Show();
            this.Hide();
        }
    }
}
