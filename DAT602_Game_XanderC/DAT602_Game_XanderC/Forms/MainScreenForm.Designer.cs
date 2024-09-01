namespace DAT602_TileWars_XanderC_2023
{
    partial class MainScreenForm
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
            NewGameButton = new Button();
            JoinGameButton = new Button();
            AdminConsoleButton = new Button();
            LogOutButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(258, 35);
            label1.Name = "label1";
            label1.Size = new Size(274, 81);
            label1.TabIndex = 4;
            label1.Text = "Tile Wars";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // NewGameButton
            // 
            NewGameButton.Location = new Point(322, 158);
            NewGameButton.Name = "NewGameButton";
            NewGameButton.Size = new Size(144, 69);
            NewGameButton.TabIndex = 0;
            NewGameButton.Text = "New Game";
            NewGameButton.UseVisualStyleBackColor = true;
            // 
            // JoinGameButton
            // 
            JoinGameButton.Location = new Point(322, 264);
            JoinGameButton.Name = "JoinGameButton";
            JoinGameButton.Size = new Size(144, 69);
            JoinGameButton.TabIndex = 1;
            JoinGameButton.Text = "Join Game";
            JoinGameButton.UseVisualStyleBackColor = true;
            JoinGameButton.Click += JoinGameButton_Click;
            // 
            // AdminConsoleButton
            // 
            AdminConsoleButton.Location = new Point(694, 385);
            AdminConsoleButton.Name = "AdminConsoleButton";
            AdminConsoleButton.Size = new Size(94, 53);
            AdminConsoleButton.TabIndex = 2;
            AdminConsoleButton.Text = "Admin Controles";
            AdminConsoleButton.UseVisualStyleBackColor = true;
            AdminConsoleButton.Click += AdminConsoleButton_Click;
            // 
            // LogOutButton
            // 
            LogOutButton.Location = new Point(12, 385);
            LogOutButton.Name = "LogOutButton";
            LogOutButton.Size = new Size(94, 53);
            LogOutButton.TabIndex = 9;
            LogOutButton.Text = "Log Out";
            LogOutButton.UseVisualStyleBackColor = true;
            LogOutButton.Click += LogOutButton_Click;
            // 
            // MainWindowForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(LogOutButton);
            Controls.Add(AdminConsoleButton);
            Controls.Add(JoinGameButton);
            Controls.Add(NewGameButton);
            Controls.Add(label1);
            Name = "MainWindowForm";
            Text = "Main Window";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button NewGameButton;
        private Button JoinGameButton;
        private Button AdminConsoleButton;
        private Button LogOutButton;
    }
}