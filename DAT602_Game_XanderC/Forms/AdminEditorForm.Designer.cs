namespace DAT602_Game_XanderC
{
    partial class AdminEditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            UsernameTextbox = new TextBox();
            PasswordTextbox = new TextBox();
            EmailTextbox = new TextBox();
            LockoutCheckbox = new CheckBox();
            AdminCheckbox = new CheckBox();
            UpdateButton = new Button();
            SuspendLayout();
            // 
            // UsernameTextbox
            // 
            UsernameTextbox.Location = new Point(252, 126);
            UsernameTextbox.Margin = new Padding(3, 2, 3, 2);
            UsernameTextbox.Name = "UsernameTextbox";
            UsernameTextbox.Size = new Size(185, 23);
            UsernameTextbox.TabIndex = 3;
            UsernameTextbox.Text = "Username";
            // 
            // PasswordTextbox
            // 
            PasswordTextbox.Location = new Point(252, 167);
            PasswordTextbox.Margin = new Padding(3, 2, 3, 2);
            PasswordTextbox.Name = "PasswordTextbox";
            PasswordTextbox.Size = new Size(185, 23);
            PasswordTextbox.TabIndex = 4;
            PasswordTextbox.Text = "Password";
            // 
            // EmailTextbox
            // 
            EmailTextbox.Location = new Point(252, 85);
            EmailTextbox.Margin = new Padding(3, 2, 3, 2);
            EmailTextbox.Name = "EmailTextbox";
            EmailTextbox.Size = new Size(185, 23);
            EmailTextbox.TabIndex = 2;
            EmailTextbox.Text = "Email";
            // 
            // LockoutCheckbox
            // 
            LockoutCheckbox.AutoSize = true;
            LockoutCheckbox.Location = new Point(253, 216);
            LockoutCheckbox.Margin = new Padding(3, 2, 3, 2);
            LockoutCheckbox.Name = "LockoutCheckbox";
            LockoutCheckbox.Size = new Size(64, 19);
            LockoutCheckbox.TabIndex = 5;
            LockoutCheckbox.Text = "Locked";
            LockoutCheckbox.UseVisualStyleBackColor = true;
            // 
            // AdminCheckbox
            // 
            AdminCheckbox.AutoSize = true;
            AdminCheckbox.Location = new Point(360, 216);
            AdminCheckbox.Margin = new Padding(3, 2, 3, 2);
            AdminCheckbox.Name = "AdminCheckbox";
            AdminCheckbox.Size = new Size(73, 19);
            AdminCheckbox.TabIndex = 6;
            AdminCheckbox.Text = "Is Admin";
            AdminCheckbox.UseVisualStyleBackColor = true;
            // 
            // UpdateButton
            // 
            UpdateButton.Location = new Point(355, 257);
            UpdateButton.Margin = new Padding(3, 2, 3, 2);
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(82, 22);
            UpdateButton.TabIndex = 7;
            UpdateButton.Text = "Update";
            UpdateButton.UseVisualStyleBackColor = true;
            UpdateButton.Click += UpdateButton_Click;
            // 
            // AdminEditorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(UpdateButton);
            Controls.Add(AdminCheckbox);
            Controls.Add(LockoutCheckbox);
            Controls.Add(UsernameTextbox);
            Controls.Add(PasswordTextbox);
            Controls.Add(EmailTextbox);
            Margin = new Padding(3, 2, 3, 2);
            Name = "AdminEditorForm";
            Text = "Admin Editor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox UsernameTextbox;
        private TextBox PasswordTextbox;
        private TextBox EmailTextbox;
        private CheckBox LockoutCheckbox;
        private CheckBox AdminCheckbox;
        private Button UpdateButton;
    }
}