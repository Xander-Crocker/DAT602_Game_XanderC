namespace DAT602_Game_XanderC
{
    public partial class GameboardForm : Form
    {

        private MainScreenForm _home;

        public GameboardForm()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            _home = new MainScreenForm();
            _home.Show();
            this.Hide();
        }
    }
}
