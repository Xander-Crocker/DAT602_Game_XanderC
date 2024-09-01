namespace DAT602_Game_XanderC
{
    public partial class AdminConsoleForm : Form
    {
        private MainScreenForm _home;
        private AdminEditorForm _editor;

        public AdminConsoleForm()
        {
            InitializeComponent();
        }

        private void homebtn_Click(object sender, EventArgs e)
        {
            _home = new MainScreenForm();
            _home.Show();
            this.Hide();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            _editor = new AdminEditorForm();
            _editor.Show();
            this.Hide();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            _editor = new AdminEditorForm();
            _editor.Show();
            this.Hide();
        }
    }
}
