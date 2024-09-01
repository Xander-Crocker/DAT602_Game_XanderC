namespace DAT602_TileWars_XanderC_2023
{
    partial class RegistrationForm
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
            label1 = new Label();
            PasswordTextbox = new TextBox();
            EmailTextbox = new TextBox();
            RegistrationButton = new Button();
            LoginButton = new Button();
            UsernameTextbox = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(217, 7);
            label1.Name = "label1";
            label1.Size = new Size(219, 65);
            label1.TabIndex = 9;
            label1.Text = "Tile Wars";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PasswordTextbox
            // 
            PasswordTextbox.Location = new Point(235, 183);
            PasswordTextbox.Margin = new Padding(3, 2, 3, 2);
            PasswordTextbox.Name = "PasswordTextbox";
            PasswordTextbox.Size = new Size(185, 23);
            PasswordTextbox.TabIndex = 4;
            PasswordTextbox.Text = "Password";
            // 
            // EmailTextbox
            // 
            EmailTextbox.Location = new Point(235, 101);
            EmailTextbox.Margin = new Padding(3, 2, 3, 2);
            EmailTextbox.Name = "EmailTextbox";
            EmailTextbox.Size = new Size(185, 23);
            EmailTextbox.TabIndex = 2;
            EmailTextbox.Text = "Email";
            // 
            // RegistrationButton
            // 
            RegistrationButton.Location = new Point(337, 226);
            RegistrationButton.Margin = new Padding(3, 2, 3, 2);
            RegistrationButton.Name = "RegistrationButton";
            RegistrationButton.Size = new Size(82, 22);
            RegistrationButton.TabIndex = 5;
            RegistrationButton.Text = "Register";
            RegistrationButton.UseVisualStyleBackColor = true;
            RegistrationButton.Click += RegistrationButton_Click;
            // 
            // LoginButton
            // 
            LoginButton.Location = new Point(235, 226);
            LoginButton.Margin = new Padding(3, 2, 3, 2);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(82, 22);
            LoginButton.TabIndex = 6;
            LoginButton.Text = "Login";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += LoginButton_Click;
            // 
            // UsernameTextbox
            // 
            UsernameTextbox.Location = new Point(235, 142);
            UsernameTextbox.Margin = new Padding(3, 2, 3, 2);
            UsernameTextbox.Name = "UsernameTextbox";
            UsernameTextbox.Size = new Size(185, 23);
            UsernameTextbox.TabIndex = 3;
            UsernameTextbox.Text = "Username";
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(UsernameTextbox);
            Controls.Add(label1);
            Controls.Add(PasswordTextbox);
            Controls.Add(EmailTextbox);
            Controls.Add(RegistrationButton);
            Controls.Add(LoginButton);
            Margin = new Padding(3, 2, 3, 2);
            Name = "RegistrationForm";
            Text = "Registration";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox PasswordTextbox;
        private TextBox EmailTextbox;
        private Button RegistrationButton;
        private Button LoginButton;
        private TextBox UsernameTextbox;
    }
}