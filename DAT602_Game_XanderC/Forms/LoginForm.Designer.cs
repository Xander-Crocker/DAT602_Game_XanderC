namespace DAT602_Game_XanderC
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
            lblConnectionStatus = new Label();
            LoginLoginButton = new Button();
            LoginRegistrationButton = new Button();
            LoginUsernameTextbox = new TextBox();
            LoginPasswordTextbox = new TextBox();
            LoginLable = new Label();
            SuspendLayout();
            // 
            // lblConnectionStatus
            // 
            lblConnectionStatus.AutoSize = true;
            lblConnectionStatus.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            lblConnectionStatus.Location = new Point(223, 301);
            lblConnectionStatus.Name = "lblConnectionStatus";
            lblConnectionStatus.Size = new Size(109, 28);
            lblConnectionStatus.TabIndex = 5;
            lblConnectionStatus.Text = "connection";
            lblConnectionStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LoginLoginButton
            // 
            LoginLoginButton.Location = new Point(353, 242);
            LoginLoginButton.Margin = new Padding(3, 2, 3, 2);
            LoginLoginButton.Name = "LoginLoginButton";
            LoginLoginButton.Size = new Size(82, 22);
            LoginLoginButton.TabIndex = 2;
            LoginLoginButton.Text = "Login";
            LoginLoginButton.UseVisualStyleBackColor = true;
            LoginLoginButton.Click += LoginLoginButton_Click;
            // 
            // LoginRegistrationButton
            // 
            LoginRegistrationButton.Location = new Point(250, 242);
            LoginRegistrationButton.Margin = new Padding(3, 2, 3, 2);
            LoginRegistrationButton.Name = "LoginRegistrationButton";
            LoginRegistrationButton.Size = new Size(82, 22);
            LoginRegistrationButton.TabIndex = 3;
            LoginRegistrationButton.Text = "Register";
            LoginRegistrationButton.UseVisualStyleBackColor = true;
            LoginRegistrationButton.Click += RegistrationButton_Click;
            // 
            // LoginUsernameTextbox
            // 
            LoginUsernameTextbox.Location = new Point(250, 146);
            LoginUsernameTextbox.Margin = new Padding(3, 2, 3, 2);
            LoginUsernameTextbox.Name = "LoginUsernameTextbox";
            LoginUsernameTextbox.Size = new Size(185, 23);
            LoginUsernameTextbox.TabIndex = 0;
            LoginUsernameTextbox.Text = "Username";
            // 
            // LoginPasswordTextbox
            // 
            LoginPasswordTextbox.Location = new Point(250, 190);
            LoginPasswordTextbox.Margin = new Padding(3, 2, 3, 2);
            LoginPasswordTextbox.Name = "LoginPasswordTextbox";
            LoginPasswordTextbox.Size = new Size(185, 23);
            LoginPasswordTextbox.TabIndex = 1;
            LoginPasswordTextbox.Text = "Password";
            // 
            // LoginLable
            // 
            LoginLable.AutoSize = true;
            LoginLable.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point);
            LoginLable.Location = new Point(223, 48);
            LoginLable.Name = "LoginLable";
            LoginLable.Size = new Size(219, 65);
            LoginLable.TabIndex = 4;
            LoginLable.Text = "Tile Wars";
            LoginLable.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(lblConnectionStatus);
            Controls.Add(LoginLable);
            Controls.Add(LoginPasswordTextbox);
            Controls.Add(LoginUsernameTextbox);
            Controls.Add(LoginRegistrationButton);
            Controls.Add(LoginLoginButton);
            Margin = new Padding(3, 2, 3, 2);
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
        private Label lblConnectionStatus;
    }
}