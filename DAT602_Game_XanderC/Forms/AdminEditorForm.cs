namespace DAT602_Game_XanderC
{
    public partial class AdminEditorForm : Form
    {
        private AdminConsoleForm _console;

        public AdminEditorForm()
        {
            InitializeComponent();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            _console = new AdminConsoleForm();
            _console.Show();
            this.Hide();
        }
    }
}
