using MySql.Data.MySqlClient;

namespace DAT602_Game_XanderC.Forms
{
    public partial class UpdateDetailsForm : Form
    {
        private Player _player;

        public UpdateDetailsForm(Player player)
        {
            InitializeComponent();
            // Check if the player object is null
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player), "Player cannot be null");
            }
            
            _player = player;

            // Set the textboxes to the player's current details
            UsernameTextbox.Text = _player.Username;
            PasswordTextbox.Text = _player.Password;
            EmailTextbox.Text = _player.Email;
            
            //CheckDatabaseConnection();
        }

        // Check if the database connection is successful
        //private bool CheckDatabaseConnection()
        //{
        //    try
        //    {
        //        MessageBox.Show("Connection to the database was successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return true;
        //    }
        //    catch (MySqlException ex)
        //    {
        //        MessageBox.Show($"A database error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }
        //}

        // Update the player's details
        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            // Get the new details
            string newUsername = UsernameTextbox.Text;
            string newPassword = PasswordTextbox.Text;
            string newEmail = EmailTextbox.Text;

            // Check if any of the fields are empty
            if (string.IsNullOrEmpty(newUsername) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(newEmail))
            {
                MessageBox.Show("All fields are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if any of the details have changed
            if (newUsername == _player.Username && newPassword == _player.Password && newEmail == _player.Email)
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

                _player.Username = newUsername;
                _player.Password = newPassword;
                _player.Email = newEmail;

                MessageBox.Show("Details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Delete the player's account
        private void DeleteAccBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Delete the player's account
                clsPlayerDAO playerDAO = new clsPlayerDAO();
                playerDAO.DeletePlayer(_player.Username);

                MessageBox.Show("Account deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to delete account: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Close the form
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        // private void updateData()
        private void InitializeComponent()
        {
            UpdateLabel = new Label();
            DeleteAccBtn = new Button();
            CloseBtn = new Button();
            UpdateBtn = new Button();
            EmailTextbox = new TextBox();
            UsernameTextbox = new TextBox();
            PasswordTextbox = new TextBox();
            SuspendLayout();
            // 
            // UpdateLabel
            // 
            UpdateLabel.AutoSize = true;
            UpdateLabel.Font = new Font("Segoe UI", 23F, FontStyle.Regular, GraphicsUnit.Point);
            UpdateLabel.Location = new Point(144, 35);
            UpdateLabel.Name = "UpdateLabel";
            UpdateLabel.Size = new Size(341, 42);
            UpdateLabel.TabIndex = 16;
            UpdateLabel.Text = "Update Account Details";
            // 
            // DeleteAccBtn
            // 
            DeleteAccBtn.Location = new Point(217, 291);
            DeleteAccBtn.Name = "DeleteAccBtn";
            DeleteAccBtn.Size = new Size(185, 22);
            DeleteAccBtn.TabIndex = 17;
            DeleteAccBtn.Text = "Delete Account";
            DeleteAccBtn.UseVisualStyleBackColor = true;
            DeleteAccBtn.Click += DeleteAccBtn_Click;
            // 
            // CloseBtn
            // 
            CloseBtn.Location = new Point(217, 234);
            CloseBtn.Name = "CloseBtn";
            CloseBtn.Size = new Size(72, 26);
            CloseBtn.TabIndex = 18;
            CloseBtn.Text = "Close";
            CloseBtn.UseVisualStyleBackColor = true;
            CloseBtn.Click += CloseBtn_Click;
            // 
            // UpdateBtn
            // 
            UpdateBtn.Location = new Point(328, 234);
            UpdateBtn.Name = "UpdateBtn";
            UpdateBtn.Size = new Size(74, 26);
            UpdateBtn.TabIndex = 19;
            UpdateBtn.Text = "Update";
            UpdateBtn.UseVisualStyleBackColor = true;
            UpdateBtn.Click += UpdateBtn_Click;
            // 
            // EmailTextbox
            // 
            EmailTextbox.Location = new Point(217, 109);
            EmailTextbox.Name = "EmailTextbox";
            EmailTextbox.Size = new Size(185, 23);
            EmailTextbox.TabIndex = 20;
            EmailTextbox.Text = "Email";
            // 
            // UsernameTextbox
            // 
            UsernameTextbox.Location = new Point(217, 148);
            UsernameTextbox.Name = "UsernameTextbox";
            UsernameTextbox.Size = new Size(185, 23);
            UsernameTextbox.TabIndex = 21;
            UsernameTextbox.Text = "Username";
            // 
            // PasswordTextbox
            // 
            PasswordTextbox.Location = new Point(217, 188);
            PasswordTextbox.Name = "PasswordTextbox";
            PasswordTextbox.Size = new Size(185, 23);
            PasswordTextbox.TabIndex = 22;
            PasswordTextbox.Text = "Password";
            // 
            // UpdateDetailsForm
            // 
            ClientSize = new Size(662, 392);
            Controls.Add(PasswordTextbox);
            Controls.Add(UsernameTextbox);
            Controls.Add(EmailTextbox);
            Controls.Add(UpdateBtn);
            Controls.Add(CloseBtn);
            Controls.Add(DeleteAccBtn);
            Controls.Add(UpdateLabel);
            Name = "UpdateDetailsForm";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}