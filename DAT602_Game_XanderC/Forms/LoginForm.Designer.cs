namespace DAT602_TileWars_XanderC_2023
{
    

    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LoginLoginButton = new Button();
            LoginRegistrationButton = new Button();
            LoginUsernameTextbox = new TextBox();
            LoginPasswordTextbox = new TextBox();
            LoginLable = new Label();
            SuspendLayout();
            // 
            // LoginLoginButton
            // 
            LoginLoginButton.Location = new Point(403, 322);
            LoginLoginButton.Name = "LoginLoginButton";
            LoginLoginButton.Size = new Size(94, 29);
            LoginLoginButton.TabIndex = 2;
            LoginLoginButton.Text = "Login";
            LoginLoginButton.UseVisualStyleBackColor = true;
            LoginLoginButton.Click += LoginLoginButton_Click;
            // 
            // LoginRegistrationButton
            // 
            LoginRegistrationButton.Location = new Point(286, 322);
            LoginRegistrationButton.Name = "LoginRegistrationButton";
            LoginRegistrationButton.Size = new Size(94, 29);
            LoginRegistrationButton.TabIndex = 3;
            LoginRegistrationButton.Text = "Register";
            LoginRegistrationButton.UseVisualStyleBackColor = true;
            LoginRegistrationButton.Click += RegistrationButton_Click;
            // 
            // LoginUsernameTextbox
            // 
            LoginUsernameTextbox.Location = new Point(286, 195);
            LoginUsernameTextbox.Name = "LoginUsernameTextbox";
            LoginUsernameTextbox.Size = new Size(211, 27);
            LoginUsernameTextbox.TabIndex = 0;
            LoginUsernameTextbox.Text = "Username";
            // 
            // LoginPasswordTextbox
            // 
            LoginPasswordTextbox.Location = new Point(286, 253);
            LoginPasswordTextbox.Name = "LoginPasswordTextbox";
            LoginPasswordTextbox.Size = new Size(211, 27);
            LoginPasswordTextbox.TabIndex = 1;
            LoginPasswordTextbox.Text = "Password";
            // 
            // LoginLable
            // 
            LoginLable.AutoSize = true;
            LoginLable.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point);
            LoginLable.Location = new Point(255, 64);
            LoginLable.Name = "LoginLable";
            LoginLable.Size = new Size(274, 81);
            LoginLable.TabIndex = 4;
            LoginLable.Text = "Tile Wars";
            LoginLable.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(LoginLable);
            Controls.Add(LoginPasswordTextbox);
            Controls.Add(LoginUsernameTextbox);
            Controls.Add(LoginRegistrationButton);
            Controls.Add(LoginLoginButton);
            Name = "LoginForm";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button LoginLoginButton;
        private Button LoginRegistrationButton;
        private TextBox LoginUsernameTextbox;
        private TextBox LoginPasswordTextbox;
        private Label LoginLable;
    }
}