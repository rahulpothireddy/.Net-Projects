namespace WindowsFormsApp2
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
            this.lbGrades = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtZID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radGTOCGreaterThan = new System.Windows.Forms.RadioButton();
            this.radGTOCLessThan = new System.Windows.Forms.RadioButton();
            this.cbGTOCGrade = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.cbGTOCCourse = new System.Windows.Forms.ComboBox();
            this.cbGROCCourse = new System.Windows.Forms.ComboBox();
            this.CBMajors = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cbGRFOCourse = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radFRACGreaterThan = new System.Windows.Forms.RadioButton();
            this.radFRACLessThan = new System.Windows.Forms.RadioButton();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button5 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.CBGrades1 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radPRFAGreaterThan = new System.Windows.Forms.RadioButton();
            this.radPRFALessThan = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbGrades
            // 
            this.lbGrades.FormattingEnabled = true;
            this.lbGrades.Location = new System.Drawing.Point(524, 58);
            this.lbGrades.Name = "lbGrades";
            this.lbGrades.Size = new System.Drawing.Size(390, 550);
            this.lbGrades.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Grade Report For One Student";
            // 
            // txtZID
            // 
            this.txtZID.Location = new System.Drawing.Point(46, 39);
            this.txtZID.Name = "txtZID";
            this.txtZID.Size = new System.Drawing.Size(100, 20);
            this.txtZID.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Z-ID";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(171, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Show Results";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnShowResults);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(275, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Grade Threshold For One Course";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radGTOCGreaterThan);
            this.groupBox1.Controls.Add(this.radGTOCLessThan);
            this.groupBox1.Location = new System.Drawing.Point(13, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 77);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // radGTOCGreaterThan
            // 
            this.radGTOCGreaterThan.AutoSize = true;
            this.radGTOCGreaterThan.Location = new System.Drawing.Point(6, 43);
            this.radGTOCGreaterThan.Name = "radGTOCGreaterThan";
            this.radGTOCGreaterThan.Size = new System.Drawing.Size(146, 17);
            this.radGTOCGreaterThan.TabIndex = 8;
            this.radGTOCGreaterThan.Text = "Greater Than or Equal To";
            this.radGTOCGreaterThan.UseVisualStyleBackColor = true;
            // 
            // radGTOCLessThan
            // 
            this.radGTOCLessThan.AutoSize = true;
            this.radGTOCLessThan.Checked = true;
            this.radGTOCLessThan.Location = new System.Drawing.Point(6, 19);
            this.radGTOCLessThan.Name = "radGTOCLessThan";
            this.radGTOCLessThan.Size = new System.Drawing.Size(133, 17);
            this.radGTOCLessThan.TabIndex = 7;
            this.radGTOCLessThan.TabStop = true;
            this.radGTOCLessThan.Text = "Less Than or Equal To";
            this.radGTOCLessThan.UseVisualStyleBackColor = true;
            // 
            // cbGTOCGrade
            // 
            this.cbGTOCGrade.FormattingEnabled = true;
            this.cbGTOCGrade.Location = new System.Drawing.Point(219, 125);
            this.cbGTOCGrade.Name = "cbGTOCGrade";
            this.cbGTOCGrade.Size = new System.Drawing.Size(81, 21);
            this.cbGTOCGrade.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(219, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Grade";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(314, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Course";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(423, 127);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Show Results";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnGTOCShowResult);
            // 
            // cbGTOCCourse
            // 
            this.cbGTOCCourse.FormattingEnabled = true;
            this.cbGTOCCourse.Location = new System.Drawing.Point(317, 127);
            this.cbGTOCCourse.Name = "cbGTOCCourse";
            this.cbGTOCCourse.Size = new System.Drawing.Size(100, 21);
            this.cbGTOCCourse.TabIndex = 13;
            // 
            // cbGROCCourse
            // 
            this.cbGROCCourse.FormattingEnabled = true;
            this.cbGROCCourse.Location = new System.Drawing.Point(166, 229);
            this.cbGROCCourse.Name = "cbGROCCourse";
            this.cbGROCCourse.Size = new System.Drawing.Size(100, 21);
            this.cbGROCCourse.TabIndex = 15;
            // 
            // CBMajors
            // 
            this.CBMajors.FormattingEnabled = true;
            this.CBMajors.Location = new System.Drawing.Point(10, 229);
            this.CBMajors.Name = "CBMajors";
            this.CBMajors.Size = new System.Drawing.Size(121, 21);
            this.CBMajors.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Major";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(166, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Course";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 190);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(305, 20);
            this.label8.TabIndex = 21;
            this.label8.Text = "Major Students Who Failed A Course";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(273, 229);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(109, 23);
            this.button3.TabIndex = 22;
            this.button3.Text = "Show Results";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnMSWFShowResults);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(10, 281);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(251, 20);
            this.label9.TabIndex = 23;
            this.label9.Text = "Grade Report For One Course";
            // 
            // cbGRFOCourse
            // 
            this.cbGRFOCourse.FormattingEnabled = true;
            this.cbGRFOCourse.Location = new System.Drawing.Point(13, 308);
            this.cbGRFOCourse.Name = "cbGRFOCourse";
            this.cbGRFOCourse.Size = new System.Drawing.Size(121, 21);
            this.cbGRFOCourse.TabIndex = 24;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(140, 306);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(115, 23);
            this.button4.TabIndex = 25;
            this.button4.Text = "Show Results";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnGRFOCShowResults);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(10, 343);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(226, 20);
            this.label10.TabIndex = 26;
            this.label10.Text = "Fail Report For All Courses";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radFRACGreaterThan);
            this.groupBox2.Controls.Add(this.radFRACLessThan);
            this.groupBox2.Location = new System.Drawing.Point(16, 364);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 71);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            // 
            // radFRACGreaterThan
            // 
            this.radFRACGreaterThan.AutoSize = true;
            this.radFRACGreaterThan.Location = new System.Drawing.Point(7, 43);
            this.radFRACGreaterThan.Name = "radFRACGreaterThan";
            this.radFRACGreaterThan.Size = new System.Drawing.Size(148, 17);
            this.radFRACGreaterThan.TabIndex = 1;
            this.radFRACGreaterThan.Text = "Greater Than Or Equal To";
            this.radFRACGreaterThan.UseVisualStyleBackColor = true;
            // 
            // radFRACLessThan
            // 
            this.radFRACLessThan.AutoSize = true;
            this.radFRACLessThan.Checked = true;
            this.radFRACLessThan.Location = new System.Drawing.Point(7, 20);
            this.radFRACLessThan.Name = "radFRACLessThan";
            this.radFRACLessThan.Size = new System.Drawing.Size(135, 17);
            this.radFRACLessThan.TabIndex = 0;
            this.radFRACLessThan.TabStop = true;
            this.radFRACLessThan.Text = "Less Than Or Equal To";
            this.radFRACLessThan.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(222, 404);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(78, 20);
            this.numericUpDown1.TabIndex = 28;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(307, 404);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(94, 23);
            this.button5.TabIndex = 29;
            this.button5.Text = "Show Results";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.btnFRACShowResults);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(520, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(122, 20);
            this.label11.TabIndex = 30;
            this.label11.Text = "Query Results";
            // 
            // CBGrades1
            // 
            this.CBGrades1.FormattingEnabled = true;
            this.CBGrades1.Location = new System.Drawing.Point(220, 518);
            this.CBGrades1.Name = "CBGrades1";
            this.CBGrades1.Size = new System.Drawing.Size(60, 21);
            this.CBGrades1.TabIndex = 31;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(10, 460);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(236, 20);
            this.label12.TabIndex = 32;
            this.label12.Text = "Pass Report For All Courses";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radPRFAGreaterThan);
            this.groupBox3.Controls.Add(this.radPRFALessThan);
            this.groupBox3.Location = new System.Drawing.Point(14, 484);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 88);
            this.groupBox3.TabIndex = 33;
            this.groupBox3.TabStop = false;
            // 
            // radPRFAGreaterThan
            // 
            this.radPRFAGreaterThan.AutoSize = true;
            this.radPRFAGreaterThan.Location = new System.Drawing.Point(9, 52);
            this.radPRFAGreaterThan.Name = "radPRFAGreaterThan";
            this.radPRFAGreaterThan.Size = new System.Drawing.Size(148, 17);
            this.radPRFAGreaterThan.TabIndex = 1;
            this.radPRFAGreaterThan.Text = "Greater Than Or Equal To";
            this.radPRFAGreaterThan.UseVisualStyleBackColor = true;
            // 
            // radPRFALessThan
            // 
            this.radPRFALessThan.AutoSize = true;
            this.radPRFALessThan.Checked = true;
            this.radPRFALessThan.Location = new System.Drawing.Point(9, 19);
            this.radPRFALessThan.Name = "radPRFALessThan";
            this.radPRFALessThan.Size = new System.Drawing.Size(135, 17);
            this.radPRFALessThan.TabIndex = 0;
            this.radPRFALessThan.TabStop = true;
            this.radPRFALessThan.Text = "Less Than Or Equal To";
            this.radPRFALessThan.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(219, 386);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 13);
            this.label13.TabIndex = 34;
            this.label13.Text = "Percentage";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(220, 499);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 13);
            this.label14.TabIndex = 35;
            this.label14.Text = "Grade";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(287, 515);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(95, 23);
            this.button6.TabIndex = 36;
            this.button6.Text = "Show Results";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.btnPRFAShowResults);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 614);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.CBGrades1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.cbGRFOCourse);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CBMajors);
            this.Controls.Add(this.cbGROCCourse);
            this.Controls.Add(this.cbGTOCCourse);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbGTOCGrade);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtZID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbGrades);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbGrades;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtZID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radGTOCGreaterThan;
        private System.Windows.Forms.RadioButton radGTOCLessThan;
        private System.Windows.Forms.ComboBox cbGTOCGrade;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbGTOCCourse;
        private System.Windows.Forms.ComboBox cbGROCCourse;
        private System.Windows.Forms.ComboBox CBMajors;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbGRFOCourse;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radFRACGreaterThan;
        private System.Windows.Forms.RadioButton radFRACLessThan;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox CBGrades1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radPRFAGreaterThan;
        private System.Windows.Forms.RadioButton radPRFALessThan;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button6;
    }
}

