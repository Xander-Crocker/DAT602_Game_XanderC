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
            KillGameButton = new Button();
            CreateButton = new Button();
            EditButton = new Button();
            DeleteButton = new Button();
            homebtn = new Button();
            playersDataGridView = new DataGridView();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            RefreshUsersBtn = new Button();
            SaveChangesBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)playersDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // KillGameButton
            // 
            KillGameButton.Location = new Point(885, 601);
            KillGameButton.Margin = new Padding(3, 2, 3, 2);
            KillGameButton.Name = "KillGameButton";
            KillGameButton.Size = new Size(82, 22);
            KillGameButton.TabIndex = 1;
            KillGameButton.Text = "Kill Game";
            KillGameButton.UseVisualStyleBackColor = true;
            // 
            // CreateButton
            // 
            CreateButton.Location = new Point(677, 283);
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
            EditButton.Location = new Point(782, 283);
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
            DeleteButton.Location = new Point(885, 283);
            DeleteButton.Margin = new Padding(3, 2, 3, 2);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(82, 22);
            DeleteButton.TabIndex = 5;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // homebtn
            // 
            homebtn.Location = new Point(36, 601);
            homebtn.Name = "homebtn";
            homebtn.Size = new Size(82, 22);
            homebtn.TabIndex = 6;
            homebtn.Text = "Close";
            homebtn.UseVisualStyleBackColor = true;
            homebtn.Click += homebtn_Click;
            // 
            // playersDataGridView
            // 
            playersDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            playersDataGridView.Location = new Point(36, 49);
            playersDataGridView.Name = "playersDataGridView";
            playersDataGridView.RowTemplate.Height = 25;
            playersDataGridView.Size = new Size(931, 229);
            playersDataGridView.TabIndex = 7;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(36, 363);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(931, 233);
            dataGridView1.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(27, 9);
            label1.Name = "label1";
            label1.Size = new Size(213, 37);
            label1.TabIndex = 9;
            label1.Text = "Registered Users";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(27, 323);
            label2.Name = "label2";
            label2.Size = new Size(204, 37);
            label2.TabIndex = 10;
            label2.Text = "Running Games";
            // 
            // RefreshUsersBtn
            // 
            RefreshUsersBtn.Location = new Point(154, 283);
            RefreshUsersBtn.Name = "RefreshUsersBtn";
            RefreshUsersBtn.Size = new Size(113, 22);
            RefreshUsersBtn.TabIndex = 11;
            RefreshUsersBtn.Text = "Refresh Users List";
            RefreshUsersBtn.UseVisualStyleBackColor = true;
            RefreshUsersBtn.Click += RefreshUsersBtn_Click;
            // 
            // SaveChangesBtn
            // 
            SaveChangesBtn.Location = new Point(36, 283);
            SaveChangesBtn.Name = "SaveChangesBtn";
            SaveChangesBtn.Size = new Size(97, 22);
            SaveChangesBtn.TabIndex = 12;
            SaveChangesBtn.Text = "Save Changes";
            SaveChangesBtn.UseVisualStyleBackColor = true;
            SaveChangesBtn.Click += SaveChangesBtn_Click;
            // 
            // AdminConsoleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1001, 634);
            Controls.Add(SaveChangesBtn);
            Controls.Add(RefreshUsersBtn);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(playersDataGridView);
            Controls.Add(homebtn);
            Controls.Add(DeleteButton);
            Controls.Add(EditButton);
            Controls.Add(CreateButton);
            Controls.Add(KillGameButton);
            Margin = new Padding(3, 2, 3, 2);
            Name = "AdminConsoleForm";
            Text = "Admin Console";
            ((System.ComponentModel.ISupportInitialize)playersDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button KillGameButton;
        private Button CreateButton;
        private Button EditButton;
        private Button DeleteButton;
        private Button homebtn;
        private DataGridView playersDataGridView;
        private DataGridView dataGridView1;
        private Label label1;
        private Label label2;
        private Button RefreshUsersBtn;
        private Button SaveChangesBtn;
    }
}