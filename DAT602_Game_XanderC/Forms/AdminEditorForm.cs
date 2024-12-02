namespace DAT602_Game_XanderC
{
    public partial class AdminEditorForm : Form
    {
        private Player _player;

        Player player;
        public AdminEditorForm(Player player)
        {
            InitializeComponent();

            this.player = player;
            ShowPlayer();

            _player = player;
        }

        // Show the player's details in the form
        private void ShowPlayer()
        {
            EmailTextbox.Text = player.Email;
            UsernameTextbox.Text = player.Username;
            PasswordTextbox.Text = player.Password;
            AttemptsTextbox.Text = Convert.ToString(player.Attempts);
            LockoutCheckbox.Checked = player.LockedOut;
        }

        // Update the player's details
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            // Get the new details
            string newUsername = UsernameTextbox.Text;
            string newPassword = PasswordTextbox.Text;
            string newEmail = EmailTextbox.Text;
            int newAttempts;
            bool newLockedOut = LockoutCheckbox.Checked;

            // Check if any of the fields are empty
            if (string.IsNullOrEmpty(newUsername) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(newEmail))
            {
                MessageBox.Show("All fields are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if the attempts field is a valid number
            if (!int.TryParse(AttemptsTextbox.Text, out newAttempts))
            {
                MessageBox.Show("Attempts must be a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if any of the details have changed
            if (newUsername == _player.Username && newPassword == _player.Password && newEmail == _player.Email && newAttempts == _player.Attempts && newLockedOut == _player.LockedOut)
            {
                MessageBox.Show("No changes detected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Update the player's details
            try
            {
                // Update the player's details in the database
                clsPlayerDAO playerDAO = new clsPlayerDAO();
                playerDAO.UpdatePlayerDetails(_player.Username, newUsername, newPassword, newEmail);
                playerDAO.UpdatePlayerAttempts(newUsername, newAttempts);
                playerDAO.UpdatePlayerAdminAndLockStatus(newUsername, _player.IsAdmin, newLockedOut);

                _player.Username = newUsername;
                _player.Password = newPassword;
                _player.Email = newEmail;
                _player.Attempts = newAttempts;
                _player.LockedOut = newLockedOut;

                MessageBox.Show("Details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Close the form
        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}