namespace DAT602_Game_XanderC
{
    public partial class AdminConsoleForm : Form
    {
        private MainScreenForm _home;
        private AdminEditorForm _editor;
        private clsPlayerDAO _playerDAO;
        private RegistrationForm _registrationForm;

        public AdminConsoleForm()
        {
            _playerDAO = new clsPlayerDAO();
            InitializeComponent();
            PopulateCurrentUsersListbox();
        }

        // Populate the listbox with the current users
        private void PopulateCurrentUsersListbox()
        {
            // Get all players from the database
            List<Player> allPlayers = _playerDAO.GetAllPlayers();

            // Bind the list of players to the listbox
            playersDataGridView.DataSource = allPlayers;
            playersDataGridView.Columns["PlayerID"].Visible = false;
            playersDataGridView.Columns["CurrentTile"].Visible = false;
            playersDataGridView.Columns["TileID"].Visible = false;
            playersDataGridView.Columns["Score"].Visible = false;

            // Permissions denied by db (cant edit in gui)
            // Allow editing of IsAdmin, IsLocked, and Attempts columns
            playersDataGridView.Columns["IsAdmin"].ReadOnly = false;
            playersDataGridView.Columns["LockedOut"].ReadOnly = false;
            playersDataGridView.Columns["Attempts"].ReadOnly = false;

            playersDataGridView.Refresh();
        }

        // Close the form
        private void homebtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        // Create a new player button
        private void CreateButton_Click(object sender, EventArgs e)
        {
            Player player = new Player();
            _registrationForm = new RegistrationForm();
            _registrationForm.Show();
            this.Hide();
        }

        // Edit the selected player
        private void EditButton_Click(object sender, EventArgs e)
        {
            // Check if a player is selected
            if (playersDataGridView.SelectedRows.Count > 0)
            {
                // Get the selected player's username
                string selectedUsername = playersDataGridView.SelectedRows[0].Cells["Username"].Value.ToString();
                Player player = _playerDAO.GetAllPlayers().FirstOrDefault(p => p.Username == selectedUsername);
                // Check if the player exists
                if (player != null)
                {
                    _editor = new AdminEditorForm(player);
                    _editor.Show();
                }
                else
                {
                    MessageBox.Show("Selected user not found.");
                }
            }
            else
            {
                MessageBox.Show("Please select a user to edit.");
            }
        }

        // Delete the selected player
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (playersDataGridView.SelectedRows.Count > 0)
            {
                // Get the selected player's username
                string selectedUsername = playersDataGridView.SelectedRows[0].Cells["Username"].Value.ToString();
                try
                {
                    // Delete the player from the database
                    clsPlayerDAO playerDAO = new clsPlayerDAO();
                    playerDAO.DeletePlayer(selectedUsername);

                    MessageBox.Show("Account deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh the list of players
                    PopulateCurrentUsersListbox();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to delete account: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a user to delete.");
            }
        }

        // Refresh the list of players button
        private void RefreshUsersBtn_Click(object sender, EventArgs e)
        {
            PopulateCurrentUsersListbox();
        }

        // Save changes to the players
        private void SaveChangesBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Save changes to the players
                foreach (DataGridViewRow row in playersDataGridView.Rows)
                {
                    // Skip the new row
                    if (row.IsNewRow) continue;

                    // Get the player's details
                    string username = row.Cells["Username"].Value.ToString();
                    bool isAdmin = Convert.ToBoolean(row.Cells["IsAdmin"].Value);
                    bool isLocked = Convert.ToBoolean(row.Cells["LockedOut"].Value);
                    int attempts = Convert.ToInt32(row.Cells["Attempts"].Value);

                    // Update the player's details in the database
                    _playerDAO.UpdatePlayerAdminAndLockStatus(username, isAdmin, isLocked);
                    _playerDAO.UpdatePlayerAttempts(username, attempts);
                }

                MessageBox.Show("Changes saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Refresh the list of players
                PopulateCurrentUsersListbox();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save changes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}