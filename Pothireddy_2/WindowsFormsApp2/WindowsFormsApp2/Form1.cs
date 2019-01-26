/* Pair Programming : Harshith Desamsetti(Z1829024), Rahul Pothireddy(Z1829984)
 * course : CSCSI 504
 * Assignment Number. : 2 
 * Due Date : 27th September 2018 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {

        public static List<Course> coursePool = new List<Course>();
        public static List<Student> studentPool = new List<Student>();
        //Creating two global variables coursePool and studentPool of type Student and Course
        

        public static void LoadList()
        {
            /**
             * Function Name : LoadList()
             * Use : To load the listboxes with content from the input files
             * */
            string[] studentInput;
            string[] courseInput;
            string studentContents = "";
            string courseContents = "";
            //Creating variables to read the student data
            using (StreamReader streamReader = new StreamReader(Directory.GetCurrentDirectory() + "\\Students.txt"))
            {
                studentContents = streamReader.ReadLine();
                while (studentContents != null)
                {
                    //Reading the contents of the student file till the end using stream reader
                    studentInput = studentContents.Split(',');
                    //Splitting the contents of the student file using split function
                    studentPool.Add(new Student(Convert.ToUInt32(studentInput[0]), studentInput[1], studentInput[2], studentInput[3], (academicYear)Enum.Parse(typeof(academicYear), studentInput[4]), Convert.ToSingle(studentInput[5])));
                    //Using the studentPool global variable and adding each student by using the Student class constructor
                    studentContents = streamReader.ReadLine();
                    //Reading the next line
                }
                studentPool.Sort();
                //Sorting the studentPool
            }



            using (StreamReader streamReader = new StreamReader(Directory.GetCurrentDirectory() + "\\Courses.txt"))
            {
                courseContents = streamReader.ReadLine();
                while (courseContents != null)
                {
                    //Reading the contents of the course input file using stream reader
                    courseInput = courseContents.Split(','); /*display the contents of course*/
                    //Splitting the contents of the course file by using the split function
                    coursePool.Add(new Course(courseInput[0], Convert.ToUInt16(courseInput[1]), courseInput[2], Convert.ToUInt16(courseInput[3]), Convert.ToUInt16(courseInput[4])));
                    //Adding new courses to the coursePool global variable by using the Course class constructor
                    courseContents = streamReader.ReadLine();
                    //Reading the next line
                }
                coursePool.Sort();
                //Sorting the studentPool
            }
            
        }

        public Form1()
        {        InitializeComponent();
        }

        /**
         * Function Name : Form1_Load(object sender, EventArgs e)
         * Use : To call all the required functions when the form is loaded.
         * */
        private void Form1_Load(object sender,EventArgs e)
        {
            readMajor();
            generateCourses();
            generateStudents();
            LoadList();
            lbStudents.ClearSelected();
            lbCourses.ClearSelected();
            txtMasterBox.Text = "";
        }

        /**
             * Function Name : readMajor()
             * Use : To read the majors from the major file and add them to the combo box
             * */
        public void readMajor()
        {

            String major;

            string majorFilePath = fileDirectory + "\\Majors.txt";

            StreamReader sr = new StreamReader(majorFilePath);

            //Read the first line of text
            major = sr.ReadToEnd();

            //Using stream reader to read the contents of the file
            string[] majorArray = major.Split(new String[] { System.Environment.NewLine }, System.StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < majorArray.Length; i++)
            {
                //All the majors are added to the combo box
                cbMajor.Items.Add(majorArray[i]);
            }
            sr.Close();
        }


        /**
             * Function Name : readStudentsListBox()
             * Use : To read the contents from the studentPool global variable to the listbox
             * */
        public void readStudentsListBox()
        {
            lbStudents.Items.Clear();
            foreach (Student student1 in studentPool)
            {
                //Foreach student in studentPool, adding each student to the listBox
                lbStudents.Items.Add("z"+student1.zid+" -- "+student1.firstName+", "+student1.lastName);
            }
            
        }

        /**
             * Function Name : readCoursesListBox()
             * Use : To read the contents from the coursePool global variable to the listbox
             * */
        public void readCoursesListBox()
        {
            lbCourses.Items.Clear();
            foreach(Course course1 in coursePool)
            {
                //Foreach course in the coursePool, adding each course to the listbox
                lbCourses.Items.Add(course1.deptCode + " " + course1.courseNumber + "-" + course1.sectionNumber + "(" + course1.numberOfStudentsEnrolled + "/" + course1.maximumCapacity + ")");
            }
        }

        /**
             * Function Name : addStudentButton_Click(object sender,EventArgs e)
             * Use : To add a student based on the details entered and when the add student button is clicked.
             * */
        private void addStudentButton_Click(object sender, EventArgs e)
        {
            
            string zID = txtZid.Text.ToString();

            //Checking if zID is empty and if it is equal to 7 digits and if it exists already
            if(zID == "" )
            {
                MessageBox.Show("Please enter zID and it should be integer", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                int parsedValue;
                if(!int.TryParse(txtZid.Text,out parsedValue))
                {
                    MessageBox.Show("Please enter integer value", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
              }
                else
                {
                    if(txtZid.Text.Length!=7)
                    {
                        MessageBox.Show("Please enter 7 integer value", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            bool isZidExist = isZidExistAlready();
            if(isZidExist == true)
            {
                MessageBox.Show("zID already exist, Please enter different zID", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            { 
            //Checking if firstName, lastName are not empty and adding them
            string name = txtLastFirstName.Text.ToString();
            string[] lastNameFirstName = name.Split(',');
            string lastName = lastNameFirstName[0];
            string firstName = lastNameFirstName[1];

            if(name=="")
            {
                MessageBox.Show("Please enter the name", "Add student", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Checking if the major is selected
            if(cbMajor.SelectedIndex==-1)
            {
                MessageBox.Show("Please select any major", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string Major = cbMajor.SelectedItem.ToString();

            //Checking if the academic year is selected
            if(cbAcademicYear.SelectedIndex==-1)
            {
                MessageBox.Show("Please select Academic Year", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string NewAcademicYear = cbAcademicYear.SelectedItem.ToString();

            string gpa = "0.0000";

            //Adding a new student based on the details entered and by using the Student class constructor
            studentPool.Add(new Student(Convert.ToUInt32(zID), lastName, firstName, Major, (academicYear)Enum.Parse(typeof(academicYear), NewAcademicYear), Convert.ToSingle(gpa)));

            MessageBox.Show("Successfully added student", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtZid.Text = "";
            txtLastFirstName.Text ="";
            cbMajor.SelectedIndex = -1;
            cbAcademicYear.SelectedIndex = -1;
            }
            readStudentsListBox();
        }

        /**
             * Function Name : isZidExistAlready()
             * Use : Checking if the zid is already existing
             * */
        public bool isZidExistAlready()
        {
            bool isExist = false;

            foreach(Student stud1 in studentPool)
            {
                //Foreach student in studentPool, checking the student's zid to the zid entered in the textbox
                string zID = stud1.zid.ToString().Trim('z');

                if (Convert.ToString(zID).Equals(txtZid.Text.ToString()))
                {
                    isExist = true;
                    return isExist;
                }
                else
                {
                    isExist = false;
                }
            }            
            return isExist;
        }



        
        private string fileDirectory = AppDomain.CurrentDomain.BaseDirectory;
        /**
             * Function Name : checkRequiredExist()
             * Use : For all the files checking if they are existing or not
             * */
        public bool checkRequriedExist()
        {
            string majorFile = fileDirectory + "\\Majors.txt";
            string StudentFile = fileDirectory + "\\Students.txt";
            string CourseFile = fileDirectory + "\\Courses.txt";
            
            bool fileExist = true;
            if(File.Exists(majorFile) && File.Exists(StudentFile) && File.Exists(CourseFile))
            {
                fileExist = true;
            }
            else
            {
                fileExist = false;
            }
            return fileExist;
        }




        /**
             * Function Name : addCourse()
             * Use : To add the course based on the details given in the textbox
             * */
        public void addCourse()
        {
            string courseFilePath = fileDirectory + "\\Courses.txt";

            //Checking if the department code is selected
            if(cbDeptCode.SelectedIndex==-1)
            {
                MessageBox.Show("Please sleect any department code", "Add student", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string deptCode = cbDeptCode.SelectedItem.ToString();

            //Getting the department code and course number
            string courseNumber = txtCourseNumber.Text.ToString();
            
            //Checking if the course number entered is not empty and is already existing
            if(courseNumber == "")
            {
                MessageBox.Show("Please enter course number and it should be integer", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                int parsedValue;
                if(!int.TryParse(txtCourseNumber.Text,out parsedValue))
                {
                    MessageBox.Show("Please enter integer value", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    if(txtCourseNumber.Text.Length!=3)
                    {
                        MessageBox.Show("Please enter 3 integer value", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            bool isCourseExist = isCourseNumberExistAlready();

            if(isCourseExist == true)
            {
                MessageBox.Show("Course Number already exists, Please enter different course number", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Checking if the section number is not empty and is already existing
            bool isSectionExist = isSectionExistAlready();

            if(isSectionExist==true)
            {
                MessageBox.Show("Section Number already exists,Please enter different section number", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sectionNumber = txtSectionNumber.Text.ToUpper().ToString();
            if(sectionNumber=="")
            {
                MessageBox.Show("Please enter tje section number and it can be alpha numeric characters", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if(txtSectionNumber.Text.Length!=4)
                {
                    MessageBox.Show("Please enter 4 characters", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string capacity = numCapacity.Value.ToString();

            string gp = "20";

            coursePool.Add(new Course(deptCode, Convert.ToUInt16(courseNumber), sectionNumber, Convert.ToUInt16(gp), Convert.ToUInt16(capacity)));
            //Adding the course to the coursePool by using the Course class constructor

            MessageBox.Show("Successfully added course", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Information);

            cbDeptCode.SelectedIndex = -1;
            txtCourseNumber.Text = "";
            txtSectionNumber.Text = "";
            readCoursesListBox();
        }
        /**
             * Function Name : isCourseNumberExistAlready()
             * Use : To check if the course number is already existing
             * */
        private bool isCourseNumberExistAlready()
        {
            bool isExist = false;

            foreach (Course course1 in coursePool)
            {
                //Foreach course in coursePool checking the courseNumber to the course number entered in the text box
                string courseNum = course1.courseNumber.ToString();

                //txtMasterBox.Items.Add(zID);
                if (Convert.ToString(courseNum).Equals(txtCourseNumber.Text.ToString()))
                {
                    //  txtMasterBox.Items.Add("True");
                    isExist = true;
                    return isExist;
                }
                else
                {
                    //  txtMasterBox.Items.Add("False");
                    isExist = false;
                }
            }

            return isExist;
        }



        /**
             * Function Name : isSectionExistAlready()
             * Use : To check if the section number is existing already
             * */
        private bool isSectionExistAlready()
        {
            bool isExist = false;

            foreach (Course course1 in coursePool)
            {
                //Foreach course in coursePool, checking its sectionNumber with the section number entered
                string sectionNum = course1.sectionNumber.ToString();

                //txtMasterBox.Items.Add(zID);
                if (Convert.ToString(sectionNum).Equals(txtSectionNumber.Text.ToString()))
                {
                    //  txtMasterBox.Items.Add("True");
                    isExist = true;
                    return isExist;
                }
                else
                {
                    //  txtMasterBox.Items.Add("False");
                    isExist = false;
                }
            }

            return isExist;
        }

        /**
             * Function Name : btnAddCourse_Click(object sender,EventArgs e)
             * Use : Calls the addCourse function
             * */
        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            addCourse(); 
        }

        /**
             * Function Name : btnPrintCourse_Click(object sender,EventArgs e)
             * Use : To print the Course Roster based on the course selected from the list box
             * */
        private void btnPrintCourse_Click(object sender, EventArgs e)
        {
            try
            {
                txtMasterBox.Items.Clear();
                readMajor();
                this.Controls.Add(txtMasterBox);
                string selectedCourse = lbCourses.GetItemText(lbCourses.SelectedItem);
                string[] courseNameSplit = selectedCourse.Split(' ');
                string courseDept = courseNameSplit[0];
                string courseNumberComma = courseNameSplit[1];
                string[] courseNumberCommaSplit = courseNumberComma.Split(',');
                string courseNumber = courseNumberCommaSplit[0];
                string[] sectionNumberSplit = courseNameSplit[2].Split('(');
                string sectionNumber = sectionNumberSplit[0];
                //Getting the course department, course number, section number from the item selected in the list box



                /*txtMasterBox.Items.Add(courseDept);
                txtMasterBox.Items.Add(courseNumber);
                txtMasterBox.Items.Add(sectionNumber);*/

                List<Student> roster = new List<Student>();
                Course course1 = new Course();
                foreach (Course co in Form1.coursePool)            /*to display the list of students and the courses they have been enrolled in*/
                {
                    //Foreach Course in coursePool, checking its courseNumber to the course number selected in the list box
                    if (co.courseNumber == (Convert.ToUInt16(courseNumber)))
                    {
                        //txtMasterBox.Items.Add("Inside the if statement");
                        roster = co.zid_numberOfStudents;
                        course1 = co;
                    }
                }

                if (roster.Count == 0) /*checking the condition if roster is 0*/
                {
                    txtMasterBox.Items.Add("Course: " + courseDept + " " + courseNumber + " " + sectionNumber + "(0/" + course1.maximumCapacity + ")");
                    txtMasterBox.Items.Add("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                    txtMasterBox.Items.Add("There isn't anyone enrolled into " + courseDept + " " + courseNumber + " " + sectionNumber);
                }

                else
                {
                    //Printing the course along with its department, course number, section number
                    txtMasterBox.Items.Add("Course: " + courseDept + " " + courseNumber + " " + sectionNumber + "(" + course1.numberOfStudentsEnrolled +"/" + course1.maximumCapacity + ")");
                    txtMasterBox.Items.Add("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                    foreach (Student student1 in roster)
                    {
                        //Printing the students enrolled in the course
                        txtMasterBox.Items.Add(student1.ToString1());
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }


        /**
             * Function Name : btnEnrollStudent_Click(object sender, EventArgs e)
             * Use : Enrolling a student to a course based on the student and course selected from the list boxes
             * */
        private void btnEnrollStudent_Click(object sender, EventArgs e)
        {
            if(lbStudents.SelectedIndex>-1 && lbCourses.SelectedIndex>-1)
            {
                string selectedStudent = lbStudents.GetItemText(lbStudents.SelectedItem);

                string selectedCourse = lbCourses.GetItemText(lbCourses.SelectedItem);

                string[] selectedStudentSplit = selectedStudent.Split(' ');

                string zid = selectedStudentSplit[0].Trim('z');
                //Getting the student zid

                string[] courseNameSplit = selectedCourse.Split(' ');

                string courseDept = courseNameSplit[0];

                string courseNumberComma = courseNameSplit[1];

                string[] courseNumberCommaSplit = courseNumberComma.Split(',');

                string courseNumber = courseNumberCommaSplit[0];

                string[] sectionNumberSplit = courseNameSplit[2].Split('(');

                string sectionNumber = sectionNumberSplit[0];
                //Getting the course department, course number, section number
                


                Course co1 = new Course();
                foreach (Course courseEnroll in coursePool)
                {
                    //Foreach course in the coursePool, checking if the courseNumber is equal to the course number of selected course
                    if (Convert.ToString(courseEnroll.courseNumber).Equals(courseNumber))
                    {
                        //If condition to check if the courseNumber equals to any course number
                        co1 = courseEnroll;
                    }
                }
                
                foreach (Student student22 in studentPool)
                {
                    //Foreach student in studentPool, checking if the zid is equal to the zid of the student selected
                    if (student22.ZID == Int32.Parse(zid))
                    {
                        if (student22.Enroll(co1) == 0)    
                        {
                            //Calling the Enroll method and giving the course selected as the argument

                            MessageBox.Show("The selected student enrolled successfully into the course", "Enroll Student", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }


            }
        }

        /**
             * Function Name : btnDropStudent_Click(object sender, EventArgs e)
             * Use : Dropping a student from a course based on the student and course selected from the list boxes
             * */
        private void btnDropStudent_Click(object sender, EventArgs e)
        {
            if(lbStudents.SelectedIndex>-1 && lbCourses.SelectedIndex>-1)
            {
                string selectedStudent = lbStudents.GetItemText(lbStudents.SelectedItem);

                string selectedCourse = lbCourses.GetItemText(lbCourses.SelectedItem);

                string[] selectedStudentSplit = selectedStudent.Split(' ');

                string zid = selectedStudentSplit[0].Trim('z');
                //Getting the zid of the selected student


                string[] courseNameSplit = selectedCourse.Split(' ');

                string courseDept = courseNameSplit[0];

                string courseNumberComma = courseNameSplit[1];

                string[] courseNumberCommaSplit = courseNumberComma.Split(',');

                string courseNumber = courseNumberCommaSplit[0];

                string[] sectionNumberSplit = courseNameSplit[2].Split('(');

                string sectionNumber = sectionNumberSplit[0];
                //Getting the course department, course number, section number of the course selected
                
                
                    Course co1_2 = new Course();

                    foreach (Course courseDrop in coursePool) /*for each course that is being dropped*/
                    {
                    //Foreach course in the coursePool, checking if the course number is equal to the course number of the course selected from the list box
                        if (Convert.ToString(courseDrop.courseNumber).Equals(courseNumber))
                        {
                            //If condition to check if the courseNumber equals to any course number
                            co1_2 = courseDrop;
                        }
                    }

                    foreach (Student student22_2 in studentPool)
                    {
                    //Foreach student in the studentPool, checking if the zid is equal to the zid of the student selected
                        if (student22_2.ZID == Int32.Parse(zid))
                        {
                        //Calling the drop method of the student and giving the course selected as argument
                            if (student22_2.Drop(co1_2) == 0)
                            {
                                //Console.WriteLine("z" + zid + " has successfully dropped from " + courseNumber); /*successfully dropped courses*/
                                MessageBox.Show("Student has been dropped from the course", "Drop Student", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                
            }
        }

        /**
             * Function Name : btnSearchCriteria_Click(object sender, EventArgs e)
             * Use : Displaying the students and courses in the list boxes based on the values entered in the text boxes
             * */
        private void btnSearchCriteria_Click(object sender, EventArgs e)
        {
            try
            {
                if (textSearchStudent.Text.Length > 0 && txtFilterCourses.Text.Length == 0)
                //Checking if only textSearchStudent textbox is given a value
                {//Filter students
                    if (textSearchStudent.Text.Length > 0)
                    {

                        //lbStudents.DataSource = null;
                        lbStudents.Items.Clear();

                        //foreach (string str in Students.studentItems)
                        foreach (Student stud1 in studentPool)
                        {
                            //Foreach student in studentPool, checking if the zid StartsWith the text entered
                            //if (str.StartsWith(txtSearchStudent.Text, StringComparison.CurrentCultureIgnoreCase))
                            if (stud1.zid.ToString().StartsWith(textSearchStudent.Text.ToString().Trim('z').Trim('Z'), StringComparison.CurrentCultureIgnoreCase))
                            {
                                //Adding the students to the listbox
                                lbStudents.Items.Add(stud1);
                            }
                        }

                        if (lbStudents.Items.Count == 0)
                        {
                            txtMasterBox.Text = "No data found for your search criteria.";
                        }
                        else
                        {
                            txtMasterBox.Text = "";
                        }
                    }
                    else
                    {
                        lbStudents.Items.Clear();

                        foreach (Student stud12 in studentPool)
                        {
                            lbStudents.Items.Add(stud12.zid.ToString());
                        }
                    }

                }
                else if (txtFilterCourses.Text.Length > 0 && textSearchStudent.Text.Length == 0)
                //If only txtFilterCourses is given a value
                {
                    //lbCourses.Items.Clear();
                    //lbCourses.DataSource = null;
                    lbCourses.Items.Clear();

                    //foreach (string str in Courses.courseItems)
                    foreach (Course course1 in coursePool)
                    {
                        //Foreach course in coursePool, checking if the deptCode is equal to the department code of the course selected in the list box
                        //if (str.Equals(txtFilterCourses.Text, StringComparison.CurrentCultureIgnoreCase))
                        if (course1.deptCode.ToString().Equals(txtFilterCourses.Text, StringComparison.CurrentCultureIgnoreCase))
                        {
                            {
                                //Adding the courses to the list box
                                lbCourses.Items.Add(course1);
                            }
                        }
                    }
                    if (lbCourses.Items.Count == 0)
                    {
                        txtMasterBox.Text = "No data found for your search criteria.";
                    }
                    else
                    {
                        txtMasterBox.Text = "";
                    }
                }


                else if(textSearchStudent.Text.Length>0 && txtFilterCourses.Text.Length>0)
                {
                    //If botht textSearchStudent and txtFilterCourses are given a value
                    lbStudents.Items.Clear();
                    lbCourses.Items.Clear();
                    foreach (Student stud1 in studentPool)
                    {
                        //Foreach student in studentPool, checking if the zid StartsWith the text entered
                        //if (str.StartsWith(txtSearchStudent.Text, StringComparison.CurrentCultureIgnoreCase))
                        if (stud1.zid.ToString().StartsWith(textSearchStudent.Text.ToString().Trim('z').Trim('Z'), StringComparison.CurrentCultureIgnoreCase))
                        {
                            //Adding the students to the listbox
                            lbStudents.Items.Add(stud1);
                        }
                    }

                    foreach (Course course1 in coursePool)
                    { 
                        //Foreach course in coursePool, checking if the departmentCode is equal to the department code of the course selected in the list box
                        //if (str.Equals(txtFilterCourses.Text, StringComparison.CurrentCultureIgnoreCase))
                        if (course1.deptCode.ToString().Equals(txtFilterCourses.Text.ToString(), StringComparison.CurrentCultureIgnoreCase))
                        {
                            {
                                //Adding the courses to the listbox
                                lbCourses.Items.Add(course1);
                            }
                        }
                    }


                }

                else
                {
                    //If the value for both the text boxes is not present
                    lbCourses.Items.Clear();
                    //foreach (string str in Courses.courseOtherItems)
                    foreach (Student stud12 in studentPool)
                    {
                        //Foreach student in the studentPool, adding the student to the listbox
                        lbStudents.Items.Add(stud12.ToString());
                    }

                    foreach (Course course12 in coursePool)
                    {
                        //Foreach course in the coursePool, adding the course to the listbox
                        lbCourses.Items.Add(course12.ToString());
                    }

                    
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        private void txtSearchStudent_TextChanged(object sender, EventArgs e)
        {
            if(textSearchStudent.Text.Length == 0)
            {
                readStudentsListBox();
                txtMasterBox.Text = "";
            }
        }

        private void txtFilterCourses_TextChanged(object sender, EventArgs e)
        {
            if(txtFilterCourses.Text.Length == 0)
            {
                readCoursesListBox();
                txtMasterBox.Text = "";

            }
        }

        /**
             * Function Name : generateStudents()
             * Use : Generating the students from the input file to the listbox
             * */

        public void generateStudents()
        {
            String student;

            List<String> studentValues = new List<String>();

            string studentFilePath = fileDirectory + "\\Students.txt";

            StreamReader sr = new StreamReader(studentFilePath);

            //First line of text
            student = sr.ReadToEnd();

            string[] studentArray = student.Split(new String[] { System.Environment.NewLine }, System.StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < studentArray.Length; i++)
            {
                string[] singleStudent = studentArray[i].Split(',');

                string studentList = "z" + singleStudent[0] + " -- " + singleStudent[1] + ", " + singleStudent[2];


                studentValues.Add(studentList);

            }

            for (int i = 0; i < studentValues.Count; i++)
            {
                lbStudents.Items.Add(studentValues.ElementAt(i));
            }


            //lbStudents.DataSource = studentValues;
            //lbStudents.Items.Add(studentValues);
            lbStudents.SelectedIndex = -1;
            sr.Close();
        }


        /**
             * Function Name : generateCourses()
             * Use : Generating the courses from the input file to the list box
             * */
        public void generateCourses()
        {
            String courses;

            List<String> courseValues = new List<String>();

            string courseFilePath = fileDirectory + "\\Courses.txt";

            StreamReader sr1 = new StreamReader(courseFilePath);

            //First line of text
            courses = sr1.ReadToEnd();

            string[] coursesArray = courses.Split(new String[] { System.Environment.NewLine }, System.StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < coursesArray.Length; i++)
            {
                string[] singleCourse = coursesArray[i].Split(',');

                string courseList = singleCourse[0];

                string Others = singleCourse[0] + " " + singleCourse[1] + ", " + singleCourse[2] + "(0/" + singleCourse[4] + ")";

                courseValues.Add(Others);
            }


            lbCourses.ValueMember = "Courses";
            //lbStudents.DisplayMember = "Student"
            lbCourses.DisplayMember = "Others";
            //lbCourses.DataSource = courseValues;
            for (int i=0;i<courseValues.Count;i++)
            {
                lbCourses.Items.Add(courseValues.ElementAt(i));
            }

            lbCourses.SelectedIndex = -1;
            sr1.Close();
        }


        /**
             * Function Name : lbStudents_SelectIndexChanged(object sender, EventArgs e)
             * Use : Displaying the details of the student and courses the student has enrolled into whenever a student is selected in the listbox
             * */
        private void lbStudents_SelectIndexChanged(object sender, EventArgs e)
        {
            txtMasterBox.Items.Clear();
            //txtMasterBox.Items.Add(lbStudents.GetItemText(lbStudents.SelectedItem));
            string selectedStudent = lbStudents.GetItemText(lbStudents.SelectedItem);
            string[] selectedStudentSplit = selectedStudent.Split();
            //txtMasterBox.Items.Add(selectedStudentSplit[0]);
            string zid = selectedStudentSplit[0].Trim('z');
            Student studVar = new Student();
            foreach(Student stud1 in studentPool)
            {
                //Foreach student in studentPool,checking if the zid is equal to the zid of the student selected
                if(stud1.zid.ToString().Trim('z').Equals(zid.ToString()))
                {
                    studVar = stud1;
                    txtMasterBox.Items.Add(stud1.ToString());
                }
            }
            txtMasterBox.Items.Add("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            foreach (Course co1 in coursePool)
            {
                //Foreach course in coursePool, checking if the course contains the student
                for (int i=0;i<co1.ZIDofStudentsEnrolled.Count;i++)
                {
                   // if(zid.ToString().Trim('z').Equals(co1.ZIDofStudentsEnrolled[i].ToString().Trim('z')))
                    if(co1.ZIDofStudentsEnrolled.Contains(studVar))
                    {
                 
                        //txtMasterBox.Items.Add("Inside if");
                        txtMasterBox.Items.Add(co1);
                    }
                    else
                    {
                        //txtMasterBox.Items.Add("Not selected");
                    }
                }
            }
            
        }
        /**
             * Function Name : lbCourses_SelectedIndexChanged(object sender, EventArgs e)
             * Use : Displaying the details of the course and the students enrolled in the course whenever a course is selected in the listbox
             * */
        private void lbCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMasterBox.Items.Clear();
            //txtMasterBox.Items.Add(lbStudents.GetItemText(lbStudents.SelectedItem));
            string selectedCourse = lbCourses.GetItemText(lbCourses.SelectedItem);
            string[] selectedCourseSplit = selectedCourse.Split();
            //txtMasterBox.Items.Add(selectedStudentSplit[0]);
            string deptCode = selectedCourseSplit[0];
            string[] courseNumComma = selectedCourseSplit[1].Split(',');
            string courseNum = courseNumComma[0];
            Course co = new Course();
            foreach (Course course2 in coursePool)
            {
                //Foreach course in coursePool, checking if the deptCode is equal to the department code of the course selected
                if ((course2.deptCode.ToString().Equals(deptCode.ToString())) && (course2.courseNumber.ToString().Equals(courseNum)))
                {
                    co = course2;
                    txtMasterBox.Items.Add(course2.ToString());
                }
            }


            txtMasterBox.Items.Add("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");

            
            foreach (Student s in co.ZIDofStudentsEnrolled)
            {
                //Foreach student in course selected, adding the student to the listbox
                txtMasterBox.Items.Add(s.ToString());    
            }

        }

        
    }
    }





    public enum academicYear { Freshman, Sophomore, Junior, Senior, PostBacc };  /*types of student is declared under the academicYear function*/
    public class Student : IComparable
    {
        public readonly uint? ZID;                   /*all the instances or attibutes*/
        public String firstName;
        public String lastName;
        public String major;
        public academicYear acadYear;
        public float GPA;
        public ushort? creditHours;

        /* accessor methods*/
        public uint? zid            /*methods for getting the value of zid*/
        {
            get
            {
                return ZID;
            }
        }
        public String FirstName
        {
            get
            {
                return firstName;         /*  method that returns the firtstname*/
            }
            set
            {
                firstName = value;
            }
        }
        public String LastName
        {
            get
            {
                return lastName;   /*methods to return the lastname*/
            }
            set
            {
                lastName = value;
            }
        }
        public String Major
        {
            get
            {
                return major;        /*methods to get the major in which student is enrolled*/
            }
            set
            {
                major = value;
            }
        }

        public float gpa
        {
            get
            {
                return GPA;          /*methods written to get the GPA of the student*/
            }
            set
            {

                {
                    GPA = value;
                }
            }
        }

        public academicYear setAndGetYear
        {
            get
            {
                return this.acadYear;
            }
            set
            {
                this.acadYear = value;
            }
        }


        /*************************************************************************************************************
         Function : Default constructor student
         Use: This is used intialize the values of the class properties to null or blank
        *************************************************************************************************************/
        public Student()
        {
            firstName = (string)null;
            lastName = (string)null;
            major = (string)null;
            acadYear = 0;
            GPA = 0;
            creditHours = null;
        }

        /*************************************************************************************
          Fnction : constructor student is created 
          Use : Initialzing the attributes of student using this keyword
          ***********************************************************************************/

        public Student(uint theZID, String theLastName, String theFirstName, String theMajor, academicYear theAcademicYear, float theGPA)
        {
            if (theZID > 1000000)
            {
                this.ZID = theZID;
            }
            this.firstName = theFirstName; /* this keyword refers to current instance of the class*/
            this.lastName = theLastName;
            this.major = theMajor;
            this.acadYear = theAcademicYear;
            if (theGPA >= 0 && theGPA <= 4)       /*if gpa is greater than or equal to zero or less than or equal to 4 condition is checked*/
            {
                this.GPA = theGPA;
            }
            this.creditHours = 0;
        }


        /************************************************************************************
          Function :  CompareTo
          Use :       Compares the zid of the student objects and sorting them 
         ***************************************************************************************/

        public int CompareTo(object alpha)
        {
            Student student = (Student)alpha;
            if (this.ZID > student.ZID)
            {
                return 1;
            }
            else if (this.ZID < student.ZID)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        /************************************************************************************
         Function : Enroll Function
         Use      : conditions that checks and validates enrolling of a student into the course
         ***********************************************************************************/
        public int Enroll(Course newCourse) /* function enroll is written here which involved the process of student being enrolled in a class*/
        {
            if (newCourse.numberOfStudentsEnrolled + 1 < newCourse.maximumCapacity) /* checking the condition that number of students enrolled wont exceed the maximum capaciity*/
            {
                if (!newCourse.zid_numberOfStudents.Contains(this))
                {
                    if (!(newCourse.creditHours + this.creditHours > 18))   /*credits hours greater than 18 condition is validated*/
                    {
                        newCourse.ZIDofStudentsEnrolled.Add(this);
                        newCourse.numberOfStudentsEnrolled++;
                        this.creditHours += newCourse.creditHours;
                        return 0;
                    }                          /* else different conditions are checked or vaidated*/
                    else
                    {
                        Console.WriteLine("THIRD CONDITION");
                        return 15;
                    }
                }
                else
                {
                    Console.WriteLine("SECOND CONDITION");
                    return 10;
                }
            }
            else
            {
                Console.WriteLine("FIRST CONDITION");
                return 5;
            }
        }

        /***********************************************************************
         Function  : Drop
         Use: takes the zid ofa student,checks all the conditions and drops a particular course based on the given course number
         *************************************************************************************/

        public int Drop(Course newCourse)   /*drop classes function is written*/
        {
            if (newCourse.zid_numberOfStudents.Contains(this))
            {
                newCourse.zid_numberOfStudents.Remove(this);  /*removing the student from the list*/
                this.creditHours -= newCourse.creditHours;  /*removing the credit hours when the student drops a particular course*/
                newCourse.numberOfStudentsEnrolled--;
            return 0;
            }
            else
            {
                Console.WriteLine("Student not dropped");
                return 20;
            }
        }


        /***********************************************************************************************
            Function  : ToString
            Use : displaying the ouput text in a particular format
        ***********************************************************************************************/

        public override string ToString()
        {
            var x = "z" + ZID + " -- " + lastName.PadLeft(15, ' ') + ", " + firstName.PadRight(20, ' ') + " " + "  [" + acadYear.ToString().PadLeft(11, ' ').PadRight(16, ' ') + "]  " + "(" + major.PadLeft(7, ' ') + ") " + "|" + gpa.ToString("0.000").PadLeft(7, ' ').PadRight(9, ' ') + "|";
            return x;
        }

        public string ToString1()
        {
            var x = "z" + ZID + "     " + lastName.PadLeft(15, ' ') + ", " + firstName.PadRight(35, ' ') + " "  + "(" + major.PadLeft(10, ' ') + ") ";
            return x;
        }

    }

    public class Course : IComparable            /*course function with icomparable interface is written*/
    {
        public String deptCode;               /*instance of a course are being initiated*/
        public uint? courseNumber;
        public String sectionNumber;
        public ushort? creditHours;
        public List<Student> ZIDofStudentsEnrolled;
        public ushort? numberOfStudentsEnrolled;
        public ushort? maximumCapacity;

        /*accessor methods for instances of the course*/
        public String DeptCode
        {
            get
            {
                return deptCode;
            }
            set
            {
                deptCode = value; /* values of department code are fetched*/
            }
        }

        public uint? CourseNumber
        {

            get
            {
                return courseNumber; /* values of course numbers are fetched*/
            }
            set
            {
                courseNumber = value;
            }
        }


        public String SectionNumber
        {
            get
            {
                return sectionNumber;   /* values of section number are fetched*/
            }
            set
            {
                sectionNumber = value;
            }
        }

        public uint? CreditHours
        {
            get
            {
                return creditHours;      /* values of credit hours are fetched*/
            }
            set
            {
                creditHours = (ushort)value;
            }
        }

        public List<Student> zid_numberOfStudents
        {
            get
            {
                return ZIDofStudentsEnrolled; /* values of zid of students enrolled are fetched*/
            }
            set
            {
                ZIDofStudentsEnrolled = value;
            }
        }

        public ushort? NumberOfStudentsEnrolled
        {
            get
            {
                return numberOfStudentsEnrolled; /* values of number of students enrolled are fetched*/
            }
            set
            {
                numberOfStudentsEnrolled = value;
            }
        }

        public ushort? MaximumCapacity
        {
            get
            {
                return maximumCapacity;        /* values of maximum capacity are fetched*/
            }
            set
            {
                maximumCapacity = value;
            }
        }


        /**********************************************************************
         Function :  Course Constructor
         Use :  Initailizing the instance with some default vales
         *********************************************************************/

        public Course()          /*course function is created*/
        {
            deptCode = "";                       /*instance or attributed of course are created*/
            courseNumber = null;
            sectionNumber = "";
            creditHours = null;
            maximumCapacity = null;
            numberOfStudentsEnrolled = null;
        }

        /**********************************************************************
         Function :  Course Constructor
         Use :  Initailizing the instance using this keyword
         *********************************************************************/
        public Course(String DeptCode, uint theCourseNumber, String theSectionNumber, ushort theCreditHours, ushort theMaximumCapacity) /*course constructor is created*/
        {
            this.deptCode = DeptCode;
            this.courseNumber = theCourseNumber;
            this.sectionNumber = theSectionNumber;
            this.creditHours = theCreditHours;
            this.maximumCapacity = theMaximumCapacity;
            this.numberOfStudentsEnrolled = 0;
            this.ZIDofStudentsEnrolled = new List<Student>();
        }

        /************************************************************************************
          Function :  CompareTo
          Use :       Compares the deptCode of the Course objects and sorting them 
         ***************************************************************************************/
        public int CompareTo(object alpha) /*compare function to validate the course and department number*/
        {
            Course course = (Course)alpha;
            if (this.deptCode.CompareTo(course.deptCode) < 0)
            {
                if (this.courseNumber < course.courseNumber)
                {
                    return 1;
                }
            }
            else if (this.deptCode.CompareTo(course.deptCode) > 0)
            {
                if (this.courseNumber > course.courseNumber)
                {
                    return -1;
                }
            }
            else
            {
                return 0;
            }
            return 1;
        }














        /**********************************************************************
         Function : PrintRoster
         Use :  print the course roster based on the course details given
         *********************************************************************/

        /*public void PrintRoster()                    
        {
            Console.WriteLine("Which course roaster would you like printed?");
            Console.Write("(DEPT COURSE_NUM-SECTION_NUM)");
            string variable = Console.ReadLine();
            string[] var1 = variable.Split(' ');
            string[] var2 = var1[1].Split('-');
            List<Student> roster = new List<Student>();
            Course course1 = new Course();
            foreach (Course co in Form1.coursePool)    
            {
                if (co.courseNumber == (Convert.ToUInt16(var2[0])))
                {
                    roster = co.zid_numberOfStudents;
                    course1 = co;
                }
            }

            if (roster.Count == 0) /*checking the condition if roster is 0
            {
                Console.WriteLine("Course: " + variable + "(0/" + course1.maximumCapacity + ")");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("There isn't anyone enrolled into " + variable);
            }
            else
            {
                foreach (Student student1 in roster)
                {
                    Console.WriteLine(student1.ToString());
                }
            }
        }*/

        /***********************************************************************************************
         Function  : ToString
         Use : displaying the ouput text in this format
         ***********************************************************************************************/
        public override string ToString()        /*overrirding*/
        {
            int size = ZIDofStudentsEnrolled.Count;
            var x = deptCode + " " + courseNumber + "-" + sectionNumber + " " + "( " + size.ToString() + "/" + maximumCapacity.ToString() + ")";
            return x;
        }

    }




