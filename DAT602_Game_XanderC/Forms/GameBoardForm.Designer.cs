namespace DAT602_Game_XanderC
{
    partial class GameboardForm
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
            backBtn = new Button();
            YourScoreboard = new Label();
            boardPanel = new Panel();
            NewGameBtn = new Button();
            richTextBox1 = new RichTextBox();
            timeLabel = new Label();
            StopGameBtn = new Button();
            SuspendLayout();
            // 
            // backBtn
            // 
            backBtn.Location = new Point(34, 587);
            backBtn.Margin = new Padding(3, 2, 3, 2);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(117, 40);
            backBtn.TabIndex = 5;
            backBtn.Text = "Back to Home";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // YourScoreboard
            // 
            YourScoreboard.AutoSize = true;
            YourScoreboard.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            YourScoreboard.Location = new Point(12, 27);
            YourScoreboard.Name = "YourScoreboard";
            YourScoreboard.Size = new Size(106, 20);
            YourScoreboard.TabIndex = 7;
            YourScoreboard.Text = "Your Score: 0";
            // 
            // boardPanel
            // 
            boardPanel.BackColor = Color.White;
            boardPanel.BorderStyle = BorderStyle.FixedSingle;
            boardPanel.Location = new Point(191, 27);
            boardPanel.Name = "boardPanel";
            boardPanel.Size = new Size(600, 600);
            boardPanel.TabIndex = 10;
            // 
            // NewGameBtn
            // 
            NewGameBtn.Location = new Point(34, 500);
            NewGameBtn.Name = "NewGameBtn";
            NewGameBtn.Size = new Size(117, 38);
            NewGameBtn.TabIndex = 13;
            NewGameBtn.Text = "New Game";
            NewGameBtn.UseVisualStyleBackColor = true;
            NewGameBtn.Click += NewGameBtn_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(12, 171);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(168, 249);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "How to play:\n\nClick to move.\n\nYou can move in any direction one tile away.\n\nCollect as many items as possible before the time is up.\n\nPoints Key:\n\nRed = 20\nBlue = 15\nGreen = 10\nYellow = 5";
            // 
            // timeLabel
            // 
            timeLabel.AutoSize = true;
            timeLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            timeLabel.Location = new Point(12, 70);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(47, 20);
            timeLabel.TabIndex = 14;
            timeLabel.Text = "Time:";
            // 
            // StopGameBtn
            // 
            StopGameBtn.Location = new Point(34, 544);
            StopGameBtn.Name = "StopGameBtn";
            StopGameBtn.Size = new Size(117, 38);
            StopGameBtn.TabIndex = 15;
            StopGameBtn.Text = "Stop Game";
            StopGameBtn.UseVisualStyleBackColor = true;
            StopGameBtn.Click += StopGameBtn_Click;
            // 
            // GameboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(818, 649);
            Controls.Add(StopGameBtn);
            Controls.Add(timeLabel);
            Controls.Add(richTextBox1);
            Controls.Add(NewGameBtn);
            Controls.Add(boardPanel);
            Controls.Add(YourScoreboard);
            Controls.Add(backBtn);
            Margin = new Padding(3, 2, 3, 2);
            Name = "GameboardForm";
            Text = "Game Board";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label YourScoreboard;
        private System.Windows.Forms.Panel boardPanel;
        private Button NewGameBtn;
        private RichTextBox richTextBox1;
        private Label timeLabel;
        private Button StopGameBtn;
    }
}