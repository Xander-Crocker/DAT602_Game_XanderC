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
            UpdateButton = new Button();
            AttemptsTextbox = new TextBox();
            AttemptsLabel = new Label();
            closeBtn = new Button();
            UpdateLabel = new Label();
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
            UsernameTextbox.TextChanged += UsernameTextbox_TextChanged;
            // 
            // PasswordTextbox
            // 
            PasswordTextbox.Location = new Point(252, 167);
            PasswordTextbox.Margin = new Padding(3, 2, 3, 2);
            PasswordTextbox.Name = "PasswordTextbox";
            PasswordTextbox.Size = new Size(185, 23);
            PasswordTextbox.TabIndex = 4;
            PasswordTextbox.Text = "Password";
            PasswordTextbox.TextChanged += PasswordTextbox_TextChanged;
            // 
            // EmailTextbox
            // 
            EmailTextbox.Location = new Point(252, 85);
            EmailTextbox.Margin = new Padding(3, 2, 3, 2);
            EmailTextbox.Name = "EmailTextbox";
            EmailTextbox.Size = new Size(185, 23);
            EmailTextbox.TabIndex = 2;
            EmailTextbox.Text = "Email";
            EmailTextbox.TextChanged += EmailTextbox_TextChanged;
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
            // AttemptsTextbox
            // 
            AttemptsTextbox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            AttemptsTextbox.Location = new Point(395, 212);
            AttemptsTextbox.Name = "AttemptsTextbox";
            AttemptsTextbox.Size = new Size(42, 23);
            AttemptsTextbox.TabIndex = 12;
            // 
            // AttemptsLabel
            // 
            AttemptsLabel.AutoSize = true;
            AttemptsLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            AttemptsLabel.Location = new Point(333, 216);
            AttemptsLabel.Name = "AttemptsLabel";
            AttemptsLabel.Size = new Size(56, 15);
            AttemptsLabel.TabIndex = 11;
            AttemptsLabel.Text = "Attempts";
            // 
            // closeBtn
            // 
            closeBtn.Location = new Point(252, 257);
            closeBtn.Margin = new Padding(3, 2, 3, 2);
            closeBtn.Name = "closeBtn";
            closeBtn.Size = new Size(82, 22);
            closeBtn.TabIndex = 13;
            closeBtn.Text = "Close";
            closeBtn.UseVisualStyleBackColor = true;
            closeBtn.Click += closeBtn_Click;
            // 
            // UpdateLabel
            // 
            UpdateLabel.AutoSize = true;
            UpdateLabel.Font = new Font("Segoe UI", 23F, FontStyle.Regular, GraphicsUnit.Point);
            UpdateLabel.Location = new Point(184, 24);
            UpdateLabel.Name = "UpdateLabel";
            UpdateLabel.Size = new Size(341, 42);
            UpdateLabel.TabIndex = 14;
            UpdateLabel.Text = "Update Account Details";
            // 
            // AdminEditorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(UpdateLabel);
            Controls.Add(closeBtn);
            Controls.Add(AttemptsTextbox);
            Controls.Add(AttemptsLabel);
            Controls.Add(UpdateButton);
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
        private Button UpdateButton;
        private TextBox AttemptsTextbox;
        private Label AttemptsLabel;

        private void UsernameTextbox_TextChanged(object sender, EventArgs e)
        {
            // Handle the event here
        }

        private void PasswordTextbox_TextChanged(object sender, EventArgs e)
        {
            // Handle the event here
        }

        private void EmailTextbox_TextChanged(object sender, EventArgs e)
        {
            // Handle the event here
        }

        private Button closeBtn;
        private Label UpdateLabel;
    }
}