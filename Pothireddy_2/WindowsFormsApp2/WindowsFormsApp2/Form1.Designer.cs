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
            this.btnPrintCourse = new System.Windows.Forms.Button();
            this.txtMasterBox = new System.Windows.Forms.ListBox();
            this.textSearchStudent = new System.Windows.Forms.TextBox();
            this.txtFilterCourses = new System.Windows.Forms.TextBox();
            this.btnEnrollStudent = new System.Windows.Forms.Button();
            this.btnDropStudent = new System.Windows.Forms.Button();
            this.btnSearchCriteria = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbStudents = new System.Windows.Forms.ListBox();
            this.lbCourses = new System.Windows.Forms.ListBox();
            this.txtLastFirstName = new System.Windows.Forms.TextBox();
            this.txtZid = new System.Windows.Forms.TextBox();
            this.cbMajor = new System.Windows.Forms.ComboBox();
            this.cbAcademicYear = new System.Windows.Forms.ComboBox();
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.cbDeptCode = new System.Windows.Forms.ComboBox();
            this.txtCourseNumber = new System.Windows.Forms.TextBox();
            this.txtSectionNumber = new System.Windows.Forms.TextBox();
            this.btnAddCourse = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.numCapacity = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numCapacity)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrintCourse
            // 
            this.btnPrintCourse.Location = new System.Drawing.Point(38, 81);
            this.btnPrintCourse.Name = "btnPrintCourse";
            this.btnPrintCourse.Size = new System.Drawing.Size(140, 23);
            this.btnPrintCourse.TabIndex = 1;
            this.btnPrintCourse.Text = "Print Course Roster";
            this.btnPrintCourse.UseVisualStyleBackColor = true;
            this.btnPrintCourse.Click += new System.EventHandler(this.btnPrintCourse_Click);
            // 
            // txtMasterBox
            // 
            this.txtMasterBox.FormattingEnabled = true;
            this.txtMasterBox.Location = new System.Drawing.Point(34, 511);
            this.txtMasterBox.Name = "txtMasterBox";
            this.txtMasterBox.Size = new System.Drawing.Size(802, 160);
            this.txtMasterBox.TabIndex = 2;
            // 
            // textSearchStudent
            // 
            this.textSearchStudent.Location = new System.Drawing.Point(201, 104);
            this.textSearchStudent.Name = "textSearchStudent";
            this.textSearchStudent.Size = new System.Drawing.Size(122, 20);
            this.textSearchStudent.TabIndex = 3;
            this.textSearchStudent.TextChanged += new System.EventHandler(this.txtSearchStudent_TextChanged);
            // 
            // txtFilterCourses
            // 
            this.txtFilterCourses.Location = new System.Drawing.Point(201, 143);
            this.txtFilterCourses.Name = "txtFilterCourses";
            this.txtFilterCourses.Size = new System.Drawing.Size(122, 20);
            this.txtFilterCourses.TabIndex = 4;
            this.txtFilterCourses.TextChanged += new System.EventHandler(this.txtFilterCourses_TextChanged);
            // 
            // btnEnrollStudent
            // 
            this.btnEnrollStudent.Location = new System.Drawing.Point(38, 110);
            this.btnEnrollStudent.Name = "btnEnrollStudent";
            this.btnEnrollStudent.Size = new System.Drawing.Size(140, 23);
            this.btnEnrollStudent.TabIndex = 5;
            this.btnEnrollStudent.Text = "Enroll Student";
            this.btnEnrollStudent.UseVisualStyleBackColor = true;
            this.btnEnrollStudent.Click += new System.EventHandler(this.btnEnrollStudent_Click);
            // 
            // btnDropStudent
            // 
            this.btnDropStudent.Location = new System.Drawing.Point(38, 139);
            this.btnDropStudent.Name = "btnDropStudent";
            this.btnDropStudent.Size = new System.Drawing.Size(140, 23);
            this.btnDropStudent.TabIndex = 6;
            this.btnDropStudent.Text = "Drop Student";
            this.btnDropStudent.UseVisualStyleBackColor = true;
            this.btnDropStudent.Click += new System.EventHandler(this.btnDropStudent_Click);
            // 
            // btnSearchCriteria
            // 
            this.btnSearchCriteria.Location = new System.Drawing.Point(38, 168);
            this.btnSearchCriteria.Name = "btnSearchCriteria";
            this.btnSearchCriteria.Size = new System.Drawing.Size(140, 23);
            this.btnSearchCriteria.TabIndex = 7;
            this.btnSearchCriteria.Text = "Apply Search Criteria";
            this.btnSearchCriteria.UseVisualStyleBackColor = true;
            this.btnSearchCriteria.Click += new System.EventHandler(this.btnSearchCriteria_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(198, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Search Student (by Z-ID)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(197, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Filter Courses (by Dept)";
            // 
            // lbStudents
            // 
            this.lbStudents.FormattingEnabled = true;
            this.lbStudents.Location = new System.Drawing.Point(425, 81);
            this.lbStudents.Name = "lbStudents";
            this.lbStudents.Size = new System.Drawing.Size(190, 420);
            this.lbStudents.TabIndex = 10;
            this.lbStudents.SelectedIndexChanged += new System.EventHandler(this.lbStudents_SelectIndexChanged);
            // 
            // lbCourses
            // 
            this.lbCourses.FormattingEnabled = true;
            this.lbCourses.Location = new System.Drawing.Point(646, 81);
            this.lbCourses.Name = "lbCourses";
            this.lbCourses.Size = new System.Drawing.Size(190, 420);
            this.lbCourses.TabIndex = 11;
            this.lbCourses.SelectedIndexChanged += new System.EventHandler(this.lbCourses_SelectedIndexChanged);
            // 
            // txtLastFirstName
            // 
            this.txtLastFirstName.Location = new System.Drawing.Point(38, 229);
            this.txtLastFirstName.Name = "txtLastFirstName";
            this.txtLastFirstName.Size = new System.Drawing.Size(122, 20);
            this.txtLastFirstName.TabIndex = 12;
            // 
            // txtZid
            // 
            this.txtZid.Location = new System.Drawing.Point(200, 229);
            this.txtZid.Name = "txtZid";
            this.txtZid.Size = new System.Drawing.Size(122, 20);
            this.txtZid.TabIndex = 13;
            // 
            // cbMajor
            // 
            this.cbMajor.FormattingEnabled = true;
            this.cbMajor.Location = new System.Drawing.Point(38, 266);
            this.cbMajor.Name = "cbMajor";
            this.cbMajor.Size = new System.Drawing.Size(121, 21);
            this.cbMajor.TabIndex = 14;
            // 
            // cbAcademicYear
            // 
            this.cbAcademicYear.FormattingEnabled = true;
            this.cbAcademicYear.Items.AddRange(new object[] {
            "Freshman",
            "Sophomore",
            "Junior",
            "Senior",
            "PostBacc"});
            this.cbAcademicYear.Location = new System.Drawing.Point(201, 266);
            this.cbAcademicYear.Name = "cbAcademicYear";
            this.cbAcademicYear.Size = new System.Drawing.Size(121, 21);
            this.cbAcademicYear.TabIndex = 15;
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.Location = new System.Drawing.Point(140, 293);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(75, 23);
            this.btnAddStudent.TabIndex = 16;
            this.btnAddStudent.Text = "Add Student";
            this.btnAddStudent.UseVisualStyleBackColor = true;
            this.btnAddStudent.Click += new System.EventHandler(this.addStudentButton_Click);
            // 
            // cbDeptCode
            // 
            this.cbDeptCode.FormattingEnabled = true;
            this.cbDeptCode.Items.AddRange(new object[] {
            "CSCI",
            "MATH",
            "STAT",
            "THET",
            "ART",
            "ANTH",
            "PSYC",
            "MGMT",
            "PHYS",
            "FLGL",
            "ECON",
            "BISC",
            "CHEM"});
            this.cbDeptCode.Location = new System.Drawing.Point(38, 356);
            this.cbDeptCode.Name = "cbDeptCode";
            this.cbDeptCode.Size = new System.Drawing.Size(121, 21);
            this.cbDeptCode.TabIndex = 17;
            // 
            // txtCourseNumber
            // 
            this.txtCourseNumber.Location = new System.Drawing.Point(200, 357);
            this.txtCourseNumber.Name = "txtCourseNumber";
            this.txtCourseNumber.Size = new System.Drawing.Size(122, 20);
            this.txtCourseNumber.TabIndex = 18;
            // 
            // txtSectionNumber
            // 
            this.txtSectionNumber.Location = new System.Drawing.Point(38, 396);
            this.txtSectionNumber.Name = "txtSectionNumber";
            this.txtSectionNumber.Size = new System.Drawing.Size(122, 20);
            this.txtSectionNumber.TabIndex = 19;
            // 
            // btnAddCourse
            // 
            this.btnAddCourse.Location = new System.Drawing.Point(140, 422);
            this.btnAddCourse.Name = "btnAddCourse";
            this.btnAddCourse.Size = new System.Drawing.Size(75, 23);
            this.btnAddCourse.TabIndex = 20;
            this.btnAddCourse.Text = "Add Course";
            this.btnAddCourse.UseVisualStyleBackColor = true;
            this.btnAddCourse.Click += new System.EventHandler(this.btnAddCourse_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Last Name, First Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(198, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Z-ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Major";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(198, 252);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Academic Year";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 340);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Department Code";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(198, 341);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Course Number";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(35, 380);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Section Number";
            // 
            // numCapacity
            // 
            this.numCapacity.Location = new System.Drawing.Point(201, 396);
            this.numCapacity.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numCapacity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCapacity.Name = "numCapacity";
            this.numCapacity.Size = new System.Drawing.Size(120, 20);
            this.numCapacity.TabIndex = 28;
            this.numCapacity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(198, 380);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "Capacity";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(288, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(365, 25);
            this.label11.TabIndex = 32;
            this.label11.Text = "NIU Enrollment Management System";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 683);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.numCapacity);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAddCourse);
            this.Controls.Add(this.txtSectionNumber);
            this.Controls.Add(this.txtCourseNumber);
            this.Controls.Add(this.cbDeptCode);
            this.Controls.Add(this.btnAddStudent);
            this.Controls.Add(this.cbAcademicYear);
            this.Controls.Add(this.cbMajor);
            this.Controls.Add(this.txtZid);
            this.Controls.Add(this.txtLastFirstName);
            this.Controls.Add(this.lbCourses);
            this.Controls.Add(this.lbStudents);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearchCriteria);
            this.Controls.Add(this.btnDropStudent);
            this.Controls.Add(this.btnEnrollStudent);
            this.Controls.Add(this.txtFilterCourses);
            this.Controls.Add(this.textSearchStudent);
            this.Controls.Add(this.txtMasterBox);
            this.Controls.Add(this.btnPrintCourse);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numCapacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnPrintCourse;
        private System.Windows.Forms.ListBox txtMasterBox;
        private System.Windows.Forms.TextBox textSearchStudent;
        private System.Windows.Forms.TextBox txtFilterCourses;
        private System.Windows.Forms.Button btnEnrollStudent;
        private System.Windows.Forms.Button btnDropStudent;
        private System.Windows.Forms.Button btnSearchCriteria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbStudents;
        private System.Windows.Forms.ListBox lbCourses;
        private System.Windows.Forms.TextBox txtLastFirstName;
        private System.Windows.Forms.TextBox txtZid;
        private System.Windows.Forms.ComboBox cbMajor;
        private System.Windows.Forms.ComboBox cbAcademicYear;
        private System.Windows.Forms.Button btnAddStudent;
        private System.Windows.Forms.ComboBox cbDeptCode;
        private System.Windows.Forms.TextBox txtCourseNumber;
        private System.Windows.Forms.TextBox txtSectionNumber;
        private System.Windows.Forms.Button btnAddCourse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numCapacity;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}

