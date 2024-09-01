namespace DAT602_Game_XanderC
{
    partial class AdminConsoleForm
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
            CurrentGamesListbox = new ListBox();
            KillGameButton = new Button();
            CurrentUsersListbox = new ListBox();
            CreateButton = new Button();
            EditButton = new Button();
            DeleteButton = new Button();
            homebtn = new Button();
            SuspendLayout();
            // 
            // CurrentGamesListbox
            // 
            CurrentGamesListbox.FormattingEnabled = true;
            CurrentGamesListbox.ItemHeight = 15;
            CurrentGamesListbox.Location = new Point(31, 32);
            CurrentGamesListbox.Margin = new Padding(3, 2, 3, 2);
            CurrentGamesListbox.Name = "CurrentGamesListbox";
            CurrentGamesListbox.Size = new Size(302, 244);
            CurrentGamesListbox.TabIndex = 0;
            // 
            // KillGameButton
            // 
            KillGameButton.Location = new Point(250, 289);
            KillGameButton.Margin = new Padding(3, 2, 3, 2);
            KillGameButton.Name = "KillGameButton";
            KillGameButton.Size = new Size(82, 22);
            KillGameButton.TabIndex = 1;
            KillGameButton.Text = "Kill Game";
            KillGameButton.UseVisualStyleBackColor = true;
            // 
            // CurrentUsersListbox
            // 
            CurrentUsersListbox.FormattingEnabled = true;
            CurrentUsersListbox.ItemHeight = 15;
            CurrentUsersListbox.Location = new Point(368, 32);
            CurrentUsersListbox.Margin = new Padding(3, 2, 3, 2);
            CurrentUsersListbox.Name = "CurrentUsersListbox";
            CurrentUsersListbox.Size = new Size(298, 244);
            CurrentUsersListbox.TabIndex = 2;
            // 
            // CreateButton
            // 
            CreateButton.Location = new Point(368, 289);
            CreateButton.Margin = new Padding(3, 2, 3, 2);
            CreateButton.Name = "CreateButton";
            CreateButton.Size = new Size(82, 22);
            CreateButton.TabIndex = 3;
            CreateButton.Text = "Create";
            CreateButton.UseVisualStyleBackColor = true;
            CreateButton.Click += CreateButton_Click;
            // 
            // EditButton
            // 
            EditButton.Location = new Point(475, 289);
            EditButton.Margin = new Padding(3, 2, 3, 2);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(82, 22);
            EditButton.TabIndex = 4;
            EditButton.Text = "Edit";
            EditButton.UseVisualStyleBackColor = true;
            EditButton.Click += EditButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(583, 289);
            DeleteButton.Margin = new Padding(3, 2, 3, 2);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(82, 22);
            DeleteButton.TabIndex = 5;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            // 
            // homebtn
            // 
            homebtn.Location = new Point(31, 289);
            homebtn.Name = "homebtn";
            homebtn.Size = new Size(75, 22);
            homebtn.TabIndex = 6;
            homebtn.Text = "Home";
            homebtn.UseVisualStyleBackColor = true;
            homebtn.Click += homebtn_Click;
            // 
            // AdminConsoleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(homebtn);
            Controls.Add(DeleteButton);
            Controls.Add(EditButton);
            Controls.Add(CreateButton);
            Controls.Add(CurrentUsersListbox);
            Controls.Add(KillGameButton);
            Controls.Add(CurrentGamesListbox);
            Margin = new Padding(3, 2, 3, 2);
            Name = "AdminConsoleForm";
            Text = "Admin Console";
            ResumeLayout(false);
        }

        #endregion

        private ListBox CurrentGamesListbox;
        private Button KillGameButton;
        private ListBox CurrentUsersListbox;
        private Button CreateButton;
        private Button EditButton;
        private Button DeleteButton;
        private Button homebtn;
    }
}