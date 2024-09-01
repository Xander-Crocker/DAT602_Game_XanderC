namespace DAT602_TileWars_XanderC_2023
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
            this.CurrentGamesListbox = new System.Windows.Forms.ListBox();
            this.KillGameButton = new System.Windows.Forms.Button();
            this.CurrentUsersListbox = new System.Windows.Forms.ListBox();
            this.CreateButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CurrentGamesListbox
            // 
            this.CurrentGamesListbox.FormattingEnabled = true;
            this.CurrentGamesListbox.ItemHeight = 20;
            this.CurrentGamesListbox.Location = new System.Drawing.Point(35, 43);
            this.CurrentGamesListbox.Name = "CurrentGamesListbox";
            this.CurrentGamesListbox.Size = new System.Drawing.Size(345, 324);
            this.CurrentGamesListbox.TabIndex = 0;
            // 
            // KillGameButton
            // 
            this.KillGameButton.Location = new System.Drawing.Point(286, 385);
            this.KillGameButton.Name = "KillGameButton";
            this.KillGameButton.Size = new System.Drawing.Size(94, 29);
            this.KillGameButton.TabIndex = 1;
            this.KillGameButton.Text = "Kill Game";
            this.KillGameButton.UseVisualStyleBackColor = true;
            // 
            // CurrentUsersListbox
            // 
            this.CurrentUsersListbox.FormattingEnabled = true;
            this.CurrentUsersListbox.ItemHeight = 20;
            this.CurrentUsersListbox.Location = new System.Drawing.Point(420, 43);
            this.CurrentUsersListbox.Name = "CurrentUsersListbox";
            this.CurrentUsersListbox.Size = new System.Drawing.Size(340, 324);
            this.CurrentUsersListbox.TabIndex = 2;
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(420, 385);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(94, 29);
            this.CreateButton.TabIndex = 3;
            this.CreateButton.Text = "Create";
            this.CreateButton.UseVisualStyleBackColor = true;
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(543, 385);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(94, 29);
            this.EditButton.TabIndex = 4;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(666, 385);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(94, 29);
            this.DeleteButton.TabIndex = 5;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            // 
            // AdminConsoleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.CurrentUsersListbox);
            this.Controls.Add(this.KillGameButton);
            this.Controls.Add(this.CurrentGamesListbox);
            this.Name = "AdminConsoleForm";
            this.Text = "Admin Console";
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox CurrentGamesListbox;
        private Button KillGameButton;
        private ListBox CurrentUsersListbox;
        private Button CreateButton;
        private Button EditButton;
        private Button DeleteButton;
    }
}