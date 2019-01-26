namespace SudokuPuzzle
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbDifficulty = new System.Windows.Forms.ComboBox();
            this.cbLevel = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnResume = new System.Windows.Forms.Button();
            this.btnNewPuzzle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(82, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sudoku Puzzle";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select Difficulty";
            // 
            // cbDifficulty
            // 
            this.cbDifficulty.DisplayMember = "0";
            this.cbDifficulty.FormattingEnabled = true;
            this.cbDifficulty.Items.AddRange(new object[] {
            "Select",
            "Easy",
            "Medium",
            "Hard"});
            this.cbDifficulty.Location = new System.Drawing.Point(119, 53);
            this.cbDifficulty.Name = "cbDifficulty";
            this.cbDifficulty.Size = new System.Drawing.Size(125, 21);
            this.cbDifficulty.TabIndex = 2;
            this.cbDifficulty.ValueMember = "0";
            this.cbDifficulty.SelectedIndexChanged += new System.EventHandler(this.cbDifficulty_SelectedIndexChanged);
            // 
            // cbLevel
            // 
            this.cbLevel.FormattingEnabled = true;
            this.cbLevel.Location = new System.Drawing.Point(119, 103);
            this.cbLevel.Name = "cbLevel";
            this.cbLevel.Size = new System.Drawing.Size(125, 21);
            this.cbLevel.TabIndex = 4;
            this.cbLevel.SelectedIndexChanged += new System.EventHandler(this.cbLevel_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Select Level";
            // 
            // btnResume
            // 
            this.btnResume.Location = new System.Drawing.Point(12, 156);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(149, 23);
            this.btnResume.TabIndex = 5;
            this.btnResume.Text = "Resume Last Puzzle";
            this.btnResume.UseVisualStyleBackColor = true;
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // btnNewPuzzle
            // 
            this.btnNewPuzzle.Enabled = false;
            this.btnNewPuzzle.Location = new System.Drawing.Point(169, 156);
            this.btnNewPuzzle.Name = "btnNewPuzzle";
            this.btnNewPuzzle.Size = new System.Drawing.Size(111, 23);
            this.btnNewPuzzle.TabIndex = 6;
            this.btnNewPuzzle.Text = "New Puzzle";
            this.btnNewPuzzle.UseVisualStyleBackColor = true;
            this.btnNewPuzzle.Click += new System.EventHandler(this.btnNewPuzzle_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 195);
            this.Controls.Add(this.btnNewPuzzle);
            this.Controls.Add(this.btnResume);
            this.Controls.Add(this.cbLevel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbDifficulty);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sudoku";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbDifficulty;
        private System.Windows.Forms.ComboBox cbLevel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnResume;
        private System.Windows.Forms.Button btnNewPuzzle;
    }
}

