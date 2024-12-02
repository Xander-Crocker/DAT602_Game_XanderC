namespace DAT602_Game_XanderC
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
            AdminConsoleButton = new Button();
            LogOutButton = new Button();
            updateAccBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(242, 26);
            label1.Name = "label1";
            label1.Size = new Size(219, 65);
            label1.TabIndex = 4;
            label1.Text = "Tile Wars";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // NewGameButton
            // 
            NewGameButton.Location = new Point(282, 118);
            NewGameButton.Margin = new Padding(3, 2, 3, 2);
            NewGameButton.Name = "NewGameButton";
            NewGameButton.Size = new Size(126, 52);
            NewGameButton.TabIndex = 0;
            NewGameButton.Text = "Start Game";
            NewGameButton.UseVisualStyleBackColor = true;
            NewGameButton.Click += NewGameButton_Click;
            // 
            // AdminConsoleButton
            // 
            AdminConsoleButton.Location = new Point(607, 289);
            AdminConsoleButton.Margin = new Padding(3, 2, 3, 2);
            AdminConsoleButton.Name = "AdminConsoleButton";
            AdminConsoleButton.Size = new Size(82, 40);
            AdminConsoleButton.TabIndex = 2;
            AdminConsoleButton.Text = "Admin Controles";
            AdminConsoleButton.UseVisualStyleBackColor = true;
            AdminConsoleButton.Click += AdminConsoleButton_Click;
            // 
            // LogOutButton
            // 
            LogOutButton.Location = new Point(10, 289);
            LogOutButton.Margin = new Padding(3, 2, 3, 2);
            LogOutButton.Name = "LogOutButton";
            LogOutButton.Size = new Size(82, 40);
            LogOutButton.TabIndex = 9;
            LogOutButton.Text = "Log Out";
            LogOutButton.UseVisualStyleBackColor = true;
            LogOutButton.Click += LogOutButton_Click;
            // 
            // updateAccBtn
            // 
            updateAccBtn.Location = new Point(306, 286);
            updateAccBtn.Name = "updateAccBtn";
            updateAccBtn.Size = new Size(82, 40);
            updateAccBtn.TabIndex = 11;
            updateAccBtn.Text = "Update Account Details";
            updateAccBtn.UseVisualStyleBackColor = true;
            updateAccBtn.Click += updateAccBtn_Click;
            // 
            // MainScreenForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(updateAccBtn);
            Controls.Add(LogOutButton);
            Controls.Add(AdminConsoleButton);
            Controls.Add(NewGameButton);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainScreenForm";
            Text = "Main Window";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button NewGameButton;
        private Button AdminConsoleButton;
        private Button LogOutButton;
        private Button updateAccBtn;
    }
}