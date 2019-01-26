/****************************************************************************************************************************
 * Name : Harshith Desamsetti, Rahul Pothireddy
 * zid : z1829024, z1829984
 * Assignement no. :3
 * Due on : 11th october 2018
 * Purpose : In this program we will be using .NET's Language Integrated Query (LINQ) to perform some particularly 
 *           elegant manipulation and filtering of a large collection of related objects. Here we will be implementing 
 *           this through a Form again, where the user can provide input on how to filter the initial datasets.
 *****************************************************************************************************************************/


/*importing the required in-built packages*/
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

/*A class called WindowsFormsApp2 in initialized along with the variables that are to be used in the programming.*/
namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        /**Each one represents a list of values or attributes*/
        public static List<Course> coursePool = new List<Course>();
        public static List<Student> studentPool = new List<Student>();
        public static List<Grades> gradePool = new List<Grades>();

        Grades gradeClass = new Grades();



        /*F*****************************************************************************
         * Function :LoadList 
         * Use :contains the intialization of the attributes of a student and course
         ******************************************************************************/
        public static void LoadList()
        {
            string[] studentInput;
            string[] courseInput;
            string[] gradeInput;
            string studentContents = "";
            string courseContents = "";
            string gradeContents = "";

            using (StreamReader streamReader = new StreamReader(Directory.GetCurrentDirectory() + "\\Students.txt"))
            {
                studentContents = streamReader.ReadLine();
                while (studentContents != null)        
                {
                    /*checks for the condition until the contents of the student are null and reads the input into student pool */
                    studentInput = studentContents.Split(',');
                    studentPool.Add(new Student(Convert.ToUInt32(studentInput[0]), studentInput[1], studentInput[2], studentInput[3], (academicYear)Enum.Parse(typeof(academicYear), studentInput[4]), Convert.ToSingle(studentInput[5])));
                    studentContents = streamReader.ReadLine(); 
                }
            }


            using (StreamReader streamReader = new StreamReader(Directory.GetCurrentDirectory() + "\\Courses.txt"))
            {
                courseContents = streamReader.ReadLine();
                while (courseContents != null)
                {
                    /*checks for the condition until the contents of the course are null and reads the input into course pool */
                    courseInput = courseContents.Split(',');
                    coursePool.Add(new Course(courseInput[0], Convert.ToUInt16(courseInput[1]), courseInput[2], Convert.ToUInt16(courseInput[3]), Convert.ToUInt16(courseInput[4])));
                    courseContents = streamReader.ReadLine();
                }
            }

            using (StreamReader streamReader = new StreamReader(Directory.GetCurrentDirectory() + "\\Grades.txt"))
            {
                gradeContents = streamReader.ReadLine();
                while (gradeContents != null)
                {
                    /*checks for the condition until the grade contents of the student are null and reads the input into grade pool */
                    gradeInput = gradeContents.Split(',');                    
                    gradePool.Add(new Grades(Convert.ToUInt32(gradeInput[0]), gradeInput[1], gradeInput[2], gradeInput[3]));
                    gradeContents = streamReader.ReadLine();
                }
            }
        }



         /**************************************************************************************************
          * Function : readMajor
          * Use      :This function reads the major of a studenti.e, which major a student belongs to
          **************************************************************************************************/
        public void readMajor()
        {
            String major;

            string majorFilePath = fileDirectory + "\\Majors.txt";

            StreamReader sr = new StreamReader(majorFilePath);
            
            major = sr.ReadToEnd();

            string[] majorArray = major.Split(new String[] { System.Environment.NewLine }, System.StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < majorArray.Length; i++)
            {
                CBMajors.Items.Add(majorArray[i]);
            }
            sr.Close();
        }

        /*****************************************************************************************************************
         * Function: ReturnGradeVal
         * Use :This function returns the points according to the grades the student has secured using if else condition
         *******************************************************************************************************************/
        public int ReturnGradeVal(String grade)
        {
            if (grade.Equals("A"))
            {
                return 10;
            }
            else if (grade.Equals("A-"))
            {
                return 9;
            }
            else if (grade.Equals("B+"))
            {
                return 8;
            }
            else if (grade.Equals("B"))
            {
                return 7;
            }
            else if (grade.Equals("A-"))
            {
                return 6;
            }
            else if (grade.Equals("C++"))
            {
                return 5;
            }
            else if (grade.Equals("C"))
            {
                return 4;
            }
            else if (grade.Equals("C-"))
            {
                return 3;
            }
            else if (grade.Equals("D"))
            {
                return 2;
            }
            else if (grade.Equals("F"))
            {
                return 1;
            }
            return 0;
        }

    
        /******************************************************************************
         * Function: ReturnCourseDept
         * Use : This function returns the code of a department based on the subject given
         *******************************************************************************/
        public String ReturnCourseDept(String course)
        {
            try
            {
                string CourseNumber = "";
                if (course == "Computer Science")
                {
                    CourseNumber = "CSCI";
                }
                if (course == "Mathematics")
                {
                    CourseNumber = "MATH";
                }
                if (course == "Statistics")
                {
                    CourseNumber = "STAT";
                }
                if (course == "Theater")
                {
                    CourseNumber = "THET";
                }
                if (course == "Art")
                {
                    CourseNumber = "ART";
                }
                if (course == "Anthropology")
                {
                    CourseNumber = "ANTH";
                }
                if (course == "Psychology")
                {
                    CourseNumber = "PSYC";
                }
                if (course == "Marketing")
                {
                    CourseNumber = "MARK";
                }
                if (course == "Physics")
                {
                    CourseNumber = "PHYS"; /*suppose if the course is physics then the course number is PHYS*/
                }
                if (course == "Finance")
                {
                    CourseNumber = "FLGL";
                }
                if (course == "Economics")
                {
                    CourseNumber = "ECON";
                }
                if (course == "Biological Sciences")
                {
                    CourseNumber = "BISC";
                }
                if (course == "Chemistry")
                {
                    CourseNumber = "CHEM";
                }
                if (course == "Undecided - Any College")
                {
                    CourseNumber = "UNDD";
                }

                return CourseNumber;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
            /*This function is executed using a try catch block to handle exceptions*/
        }

        /************************************************************************************
         * Function: LoadGrade
         * Use :This function loads all the grades i.e, types of grades in the grade file*
         * ***********************************************************************************/
        public void LoadGrade()
        {
            try
            {
                String grade;

                string majorFilePath = fileDirectory + "\\Grades.txt";

                StreamReader sr = new StreamReader(majorFilePath);

                //Read the first line of text
                grade = sr.ReadToEnd();

                string[] gradeArray = grade.Split(new string[] { System.Environment.NewLine }, System.StringSplitOptions.RemoveEmptyEntries);
                List<String> tempList = new List<String>();
                for (int i = 0; i < gradeArray.Length; i++)
                {
                    string GradeValue = gradeArray[i].Split(',')[3].ToString();
                    if (!tempList.Contains(GradeValue))
                    {
                        tempList.Add(GradeValue.ToString()); /*if temporary list does not contains grade value , then the value is converted to string*/
                    }

                }
                tempList.Sort(); /*The list is then sorted*/
                foreach (String listVal in tempList)
                {
                    if (!cbGTOCGrade.Items.Contains(listVal))
                    {
                        cbGTOCGrade.Items.Add(listVal); 
                    }
                    if(!CBGrades1.Items.Contains(listVal))
                    {
                        CBGrades1.Items.Add(listVal);
                    }
                }
                sr.Close();   /*file close*/
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            /*Try catch blocks are used to handle with the exceptions*/
        }


        /*LoadCourse reads the courses.txt file (all its contents) and then closes the file*/
        public void LoadCourse()
        {
            try
            {
                String Course;

                string majorFilePath = fileDirectory + "\\Courses.txt";

                StreamReader sr = new StreamReader(majorFilePath);
                /*opens file and reads the contents till the end*/
                Course = sr.ReadToEnd();
                string[] courseArray = Course.Split(new string[] { System.Environment.NewLine }, System.StringSplitOptions.RemoveEmptyEntries);
                List<String> tempCourse = new List<String>();
                for (int i = 0; i < courseArray.Length; i++) /*loop iterates until the end of course array*/
                {
                    string iterateddeptCode = courseArray[i].Split(',')[0].ToString();
                    string courseNumber = courseArray[i].Split(',')[1].ToString();
                    string course = iterateddeptCode + " " + courseNumber;
                    tempCourse.Add(course);
                }
                tempCourse.Sort(); /*sorting is performed*/
                foreach(String listVal in tempCourse)
                {
                    cbGROCCourse.Items.Add(listVal); 
                    cbGTOCCourse.Items.Add(listVal); /*the updted values of each course of students are added */
                    cbGRFOCourse.Items.Add(listVal);
                }
                sr.Close(); /*file is closed*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } /*catch handles with the exceptions*/
        }

        /*form1 is initialised */
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            LoadList();  /*loads the list*/
            readMajor(); /*reads the major of the students*/
            LoadGrade(); /*loads the grades of the students*/
            LoadCourse(); /*loads the course values*/
        }

        /*************************************************************************************************
         * Name: readGradesListBox
         * Use : Concatenates the grade, coursename taken, course number and grade received into a list
         * **********************************************************************************************/
        public void readGradesListBox()
        {

            foreach (Grades grade1 in gradePool)
            {
                lbGrades.Items.Add(grade1.zid + " " + grade1.courseNameTaken + " " + grade1.courseNumberTaken + " " + grade1.gradeReceived);
            }
        }









        private string fileDirectory = AppDomain.CurrentDomain.BaseDirectory;
        /****************************************************************************
         * Function : checkRequiredExist
         * Use      : Checks if all the required files exists and if yes returns true
         * **************************************************************************/
        public bool checkRequriedExist()
        {
            string majorFile = fileDirectory + "\\Majors.txt";
            string StudentFile = fileDirectory + "\\Students.txt"; /*reads different files required*/
            string CourseFile = fileDirectory + "\\Courses.txt";
            string EnrollFile = fileDirectory + "\\EnrolledStudents.txt";
            bool fileExist = true;
            if (File.Exists(majorFile) && File.Exists(StudentFile) && File.Exists(CourseFile) && File.Exists(EnrollFile))
            {
                fileExist = true;  /*returns true if they exists*/
            }
            else
            {
                fileExist = false; /*returns false if they dont exists*/
            }
            return fileExist;
        }


        /********************************************************************************************
         * Function: generateGrades
         * Use     : This is used to generate the grades from the Grades file and then adding them to lbGrades listbox
         ********************************************************************************************/

        public void generateGrades()
        {
            String grades;

            List<String> gradeValues = new List<String>();

            string gradeFilePath = fileDirectory + "\\Grades.txt"; /*opens and reads the file grades.txt*/

            StreamReader sr2 = new StreamReader(gradeFilePath);

            grades = sr2.ReadToEnd();

            string[] gradesArray = grades.Split(new String[] { System.Environment.NewLine }, System.StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < gradesArray.Length; i++) /*iterates until end of the array list and generates grades adding them to grade list*/
            {
                string[] singleGrade = gradesArray[i].Split(',');

                string gradesList = singleGrade[0];

                string Others = singleGrade[0] + " " + singleGrade[1] + ", " + singleGrade[2] + "(0/" + singleGrade[3] + ")";

                gradeValues.Add(Others); /*adds the grades of others*/
            }
            lbGrades.ValueMember = "Grades";
            lbGrades.DisplayMember = "Others";
            lbGrades.DataSource = gradeValues;
            lbGrades.SelectedIndex = -1;
            sr2.Close(); /*closes the file*/
        }



        /********************************************************************************************
         * Function: btnShowResults
         * Use     : This is used to show the grades of the student based on the zid given
         ********************************************************************************************/
        private void btnShowResults(object sender, EventArgs e)
        {
            try
            { 
            lbGrades.Items.Clear();
            if (txtZID.Text == "") /*prompting the user to enter zid which is integer value*/
            {
                MessageBox.Show("Please enter ZID and it should be integer", "Show Results", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (txtZID.Text.Length < 7) /*prompts to enter a valid zid*/
                {
                    MessageBox.Show("Please enter 8 integer value with 'z' character in prefix", "Show Results", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            
            String searchZID = txtZID.Text.ToString().Trim('z').Trim('Z'); /*search zid by eliminating the value of z while searching*/

            var gradeQuery = from gradesQ in gradePool
                             where gradesQ.zid.ToString().Trim('z').Equals(searchZID) /*querry tp find grade of the student according to hi zid, and ordered by the course number taken*/
                             orderby gradesQ.courseNumberTaken
                             select gradesQ;

                /*if grade queery count is more than 0, then the following loop executes*/
            if (gradeQuery.Count() > 0)
            {
                
                lbGrades.Items.Clear(); /*first it clears the grades in the list box*/
                lbGrades.Items.Add("Single Student Grade Report ("+searchZID+")");
                lbGrades.Items.Add("------------------------------------------------------------------------------------");
                foreach (Grades grades in gradeQuery)  /*after executing the grades querry, the result is converted to string and added to list box*/
                {
                    lbGrades.Items.Add(grades.ToString());
                }
                lbGrades.Items.Add("### END RESULTS ###");

            }
            else
            {
                lbGrades.Items.Clear();   /*else if the count is less than zero, then no details are added*/
                lbGrades.Items.Add("No Details");
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }  /*try and catch blocks are used to handle exceptions*/
        }
        /********************************************************************************************
         * Function: btnGTOCShowResult
         * Use     : This is used to show the Grade threshold of one course based on the course input
         ********************************************************************************************/
        private void btnGTOCShowResult(object sender, EventArgs e)
        {
            try                 /*try and catch blocks are used to handle exceptions*/
            {
                string sign = "";
                if (radGTOCLessThan.Checked == true)   /*cheching if the radio button is less than or greater than to determine the sign*/
                {
                    sign = "less";
                }
                if (radGTOCGreaterThan.Checked == true)
                {
                    sign = "greater";
                }

                String[] courseSelected = cbGTOCCourse.SelectedItem.ToString().Split(' ');
                String courseDept = courseSelected[0];
                String courseNumber = courseSelected[1];

                String gradeSelected = cbGTOCGrade.SelectedItem.ToString();

                IEnumerable<Grades> gradeQuery = Enumerable.Empty<Grades>();

                if (sign == "less")
                {
                    /*when sign is less , the grade querry in grade pool executes returning the grade value taking grade selected and course number into consideration*/
                    gradeQuery = from gradesQ in gradePool
                                 orderby gradesQ.ZID ascending
                                 where ReturnGradeVal(gradesQ.gradeReceived.ToString()) <= ReturnGradeVal(gradeSelected) && gradesQ.courseNumberTaken.ToString().Equals(courseNumber)
                                 select gradesQ;
                }
                else if (sign == "greater")
                {
                    gradeQuery = from gradesQ in gradePool
                                 orderby gradesQ.ZID ascending
                                 where ReturnGradeVal(gradesQ.gradeReceived.ToString()) >= ReturnGradeVal(gradeSelected) && gradesQ.courseNumberTaken.ToString().Equals(courseNumber)
                                 select gradesQ;
                }

                /*if grade querry count is greater than 0, then the loop executes*/
                if (gradeQuery.Count() > 0)
                {
                    lbGrades.Items.Clear(); /*the grades in list box are cleared*/
                    lbGrades.Items.Add("Grade Report for (" + courseDept + ") in " + courseNumber);
                    lbGrades.Items.Add("------------------------------------------------------------------------------------");
                    foreach (Grades grades in gradeQuery) /*for all the grades in grade querry the values are converted to string*/
                    {
                        lbGrades.Items.Add(grades.ToString());
                    }
                    lbGrades.Items.Add("### END RESULTS ###"); /*end results message is shown*/

                }
                else
                {
                    lbGrades.Items.Clear();
                    lbGrades.Items.Add("No Details");
                }                
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } /*errors in message box buttons or message box icons are handled*/
        }
        /********************************************************************************************
         * Function: btnMSWFShowResults
         * Use     : This is used to show the Students of a major selected who failed in a course
         ********************************************************************************************/
        private void btnMSWFShowResults(object sender, EventArgs e)
        {


            try
            {
                String[] courseSelected = cbGROCCourse.SelectedItem.ToString().Split(' ');
                String courseDept = courseSelected[0];
                String courseNumber = courseSelected[1];
                String majorSelected = CBMajors.SelectedItem.ToString();
                /*The above performs execution of a grade querry from grade pool and students querry from students pool where all the attributes are taken into considration and the grade equals to F*/
                IEnumerable<Grades> gradeQuery = from gradesQ in gradePool
                                                 from studentsQ in studentPool
                                                 orderby gradesQ.ZID ascending
                                                 where gradesQ.GradeReceived.ToString().Equals("F") && gradesQ.CourseNumberTaken.ToString().Trim(' ').Equals(courseNumber.ToString().Trim(' ')) && gradesQ.courseNameTaken.ToString().Equals(courseDept) && (gradesQ.ZID.ToString().Trim('z').Trim(' ').Trim(',').Equals(studentsQ.zid.ToString().Trim('z').Trim(' ').Trim(','))) && studentsQ.major.ToString().Equals(CBMajors.SelectedItem.ToString())
                                                 select gradesQ;

                if (gradeQuery.Count() > 0)
                {
                    lbGrades.Items.Clear();
                    lbGrades.Items.Add("Fail Report of Majors (" + majorSelected + ") in " + courseDept + " " + courseNumber);/*fail report is generated if the gradequeery count is greater than 0*/
                    lbGrades.Items.Add("------------------------------------------------------------------------------------");
                    foreach (Grades grades in gradeQuery)
                    {
                        lbGrades.Items.Add(grades); /*grades are added to grade list box*/

                    }
                    lbGrades.Items.Add("### END RESULTS ###");

                }
                else
                {
                    lbGrades.Items.Clear();
                    lbGrades.Items.Add("No Details");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }  /*try and catch blocks are used for exception handling*/

        /********************************************************************************************
         * Function: btnGRFOCShowResults
         * Use     : This is used to display the Grade Report for One Course based on the course 
         *           selected which shows the grades of all students
         ********************************************************************************************/
        private void btnGRFOCShowResults(object sender, EventArgs e)
        {
            try
            {
                String[] courseSelected = cbGRFOCourse.SelectedItem.ToString().Split(' ');
                String courseDept = courseSelected[0];  /*department in which coure is taken*/
                String courseNumber = courseSelected[1]; /*the course number*/

                /*displays the end result of the below querry which is executed*/
                IEnumerable<Grades> gradeQuery = from gradesQ in gradePool
                                                 orderby gradesQ.ZID ascending
                                                 where gradesQ.courseNumberTaken.Equals(courseNumber) && gradesQ.courseNameTaken.ToString().Equals(courseDept)
                                                 select gradesQ;

                if (gradeQuery.Count() > 0)
                {
                    lbGrades.Items.Clear();  /*grade report for course department and number is generated*/
                    lbGrades.Items.Add("Grade Report for (" + courseDept + courseNumber + ") ");
                    lbGrades.Items.Add("------------------------------------------------------------------------------------");
                    foreach (Grades grades in gradeQuery)
                    {
                        lbGrades.Items.Add(grades);
                    }
                    lbGrades.Items.Add("### END RESULTS ###");
                }
                else
                {
                    lbGrades.Items.Clear();
                    lbGrades.Items.Add("No Details");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /********************************************************************************************
         * Function: btnFRACShowResults
         * Use     : This is used to display the Fail report of all courses based on the percentage
         ********************************************************************************************/
        private void btnFRACShowResults(object sender, EventArgs e)
        {
            try
            {
                var value = numericUpDown1.Value;

                lbGrades.Items.Clear();
                string sign = "";
                if (radFRACLessThan.Checked == true)
                {
                    sign = "less";
                }
                if (radFRACGreaterThan.Checked == true)
                {
                    sign = "greater";
                }
                int totalCount = 0;
                int fCount = 0;
                Double percentage = 0;
                string var = "";
                if (sign == "less")
                {
                    var = "<=";
                }
                else if (sign == "greater")
                {
                    var = ">=";
                }
                lbGrades.Items.Add("Fail Percentage (" + var + value + "%) Report for Classes");
                lbGrades.Items.Add("----------------------------------------------------------------------");
                /*the loop iterates for courses query in course pool and finds the total count and percentage*/
                foreach (Course coursesQ in coursePool)
                {
                    totalCount = (from gradesQ in gradePool
                                  where (coursesQ.courseNumber.ToString().Equals(gradesQ.courseNumberTaken)) && (coursesQ.deptCode.ToString().Equals(gradesQ.courseNameTaken.ToString()))
                                  select gradesQ).Count();
                    fCount = (from gradesQ in gradePool
                              where (coursesQ.courseNumber.ToString().Equals(gradesQ.courseNumberTaken)) && (coursesQ.deptCode.ToString().Equals(gradesQ.courseNameTaken.ToString())) && gradesQ.gradeReceived.Equals("F")
                              select gradesQ).Count();
                    percentage = (Convert.ToDouble(fCount) / totalCount) * 100;

                    if (sign == "less" && percentage <= Convert.ToDouble(value))
                    {
                        lbGrades.Items.Add("Out of " + totalCount.ToString() + " enrolled in " + coursesQ.deptCode + "-" + coursesQ.courseNumber + "," + fCount + " failed " + "(" + percentage.ToString("0.##") + "%)");
                        lbGrades.Items.Add(" "); /*items are added into the list box grades*/
                        fCount = 0;
                        totalCount = 0;
                    }
                    else if (sign == "greater" && percentage >= Convert.ToDouble(value))
                    {
                        lbGrades.Items.Add("Out of " + totalCount.ToString() + " enrolled in " + coursesQ.deptCode + "-" + coursesQ.courseNumber + "," + fCount + " failed " + "(" + percentage.ToString("0.##") + "%)");
                        lbGrades.Items.Add(" ");
                        fCount = 0;
                        totalCount = 0;
                    }

                }
                lbGrades.Items.Add("### END GRADES ###");
            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } /*try and catch blocks are used to handle exceptions*/
        }
        /********************************************************************************************
         * Function: btnPRFAShowResults
         * Use     : This is used to display the Pass Report for All Courses based on the grade selected
         ********************************************************************************************/

        private void btnPRFAShowResults(object sender, EventArgs e)
        {
            try
            {
                String gradeSelected = CBGrades1.SelectedItem.ToString();

                lbGrades.Items.Clear();
                string sign = "";
                if (radPRFALessThan.Checked == true) /*if the condition of the radio button checked is true */
                {
                    sign = "less";
                }
                if (radPRFAGreaterThan.Checked == true)/*if the condition of the radio button checked is false */
                {
                    sign = "greater";
                }

                int totalCount = 0;
                int pCount = 0;                  /*initialsing the variables to 0*/
                Double percentage = 0;
                string var = "";
                if (sign == "less")
                {
                    var = "<=";
                }
                else if (sign == "greater")
                {
                    var = ">=";
                }
                lbGrades.Items.Add("Pass Percentage (" + var + gradeSelected + "%) Report for Classes");
                lbGrades.Items.Add("----------------------------------------------------------------------");

                foreach (Course coursesQ in coursePool)
                {
                    totalCount = (from gradesQ in gradePool
                                  where (coursesQ.courseNumber.ToString().Equals(gradesQ.courseNumberTaken)) && (coursesQ.deptCode.ToString().Equals(gradesQ.courseNameTaken.ToString()))
                                  select gradesQ).Count();

                    if (sign == "less")   /*if the sign is less then the grade querry executed where course number eand department code is taken into consideration*/
                    {
                        pCount = (from gradesQ in gradePool
                                  where (coursesQ.courseNumber.ToString().Equals(gradesQ.courseNumberTaken)) && (coursesQ.deptCode.ToString().Equals(gradesQ.courseNameTaken.ToString())) && !gradesQ.gradeReceived.Equals("F") && ReturnGradeVal(gradesQ.gradeReceived) <= ReturnGradeVal(gradeSelected)
                                  select gradesQ).Count();
                    }
                    else if(sign=="greater")
                    {
                        pCount = (from gradesQ in gradePool
                                  where (coursesQ.courseNumber.ToString().Equals(gradesQ.courseNumberTaken)) && (coursesQ.deptCode.ToString().Equals(gradesQ.courseNameTaken.ToString())) && !gradesQ.gradeReceived.Equals("F") && ReturnGradeVal(gradesQ.gradeReceived) >= ReturnGradeVal(gradeSelected)
                                  select gradesQ).Count();
                    }
                    percentage = (Convert.ToDouble(pCount) / totalCount) * 100; /*converted into percentage*/
                    if(Double.IsNaN(percentage)) 
                    {
                        percentage = 0;
                    }
                    if (sign == "less")
                    {
                        lbGrades.Items.Add("Out of " + totalCount.ToString() + " enrolled in " + coursesQ.deptCode + "-" + coursesQ.courseNumber + "," + pCount + " passed at or below this threshold" + "(" + percentage.ToString("0.##") + "%)");
                        lbGrades.Items.Add(" ");
                        pCount = 0;
                        totalCount = 0;
                    }
                    else if (sign == "greater")
                    {
                        lbGrades.Items.Add("Out of " + totalCount.ToString() + " enrolled in " + coursesQ.deptCode + "-" + coursesQ.courseNumber + "," + pCount + " passed at or above this threshold" + "(" + percentage.ToString("0.##") + "%)");
                        lbGrades.Items.Add(" ");
                        pCount = 0;
                        totalCount = 0;
                    }
                }
                lbGrades.Items.Add("### END GRADES ###");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }  /*try and catch blocks are used for exception handling i.e, handling with errors*/



      
        /********************************************************************************************************
         Function : Grades
         Use      : setters and gettr methods are used for each variable used
         ********************************************************************************************************/
        

        public class Grades
        {
            public readonly uint? ZID;
            public String courseNameTaken;
            public String courseNumberTaken;
            public String gradeReceived;

            public uint? zid
            {
                get
                {
                    return ZID;           /*methods to return the zid*/
                }
            }

            public String CourseNameTaken
            {
                get
                {
                    return courseNameTaken;  /*method to return the course name*/
                }
                set
                {
                    courseNameTaken = value;
                }
            }


            public String CourseNumberTaken
            {
                get
                {
                    return courseNumberTaken; /*methods to return the course number*/
                }
                set
                {
                    courseNumberTaken = value;
                }
            }

            public String GradeReceived
            {
                get
                {
                    return gradeReceived;/*methods to return the grades received*/
                }
                set
                {
                    gradeReceived = value;
                }
            }

            public Grades()
            {
                courseNumberTaken = (string)null;
                courseNameTaken = (string)null;
                gradeReceived = (string)null;
            }

            /*constructor grades with four parameters being intialised*/
            public Grades(uint theZID, String theCourseNameTaken, String theCourseNumberTaken, String theGradeReceived)
            {
                ZID = theZID;
                courseNameTaken = theCourseNameTaken;
                courseNumberTaken = theCourseNumberTaken;
                gradeReceived = theGradeReceived;
            }

            public override string ToString()  /*x stores the value which is converted into a string*/
            {
                var x = "z" + ZID + " | " + courseNameTaken.PadLeft(10, ' ') + "-" + courseNumberTaken.PadRight(15, ' ') + "|" + gradeReceived.PadLeft(10, ' ');
                return x;
            }


            private string fileDirectory = AppDomain.CurrentDomain.BaseDirectory;
            public string[] LoadGradeFileContent()
            {
                try
                {
                    String grade;

                    string gradeFilePath = fileDirectory + "\\Grades.txt"; /*reads the grades file*/


                    StreamReader sr = new StreamReader(gradeFilePath);

                    grade = sr.ReadToEnd();

                    sr.Close();

                    string[] gradeArray = grade.Split(new string[] { System.Environment.NewLine }, System.StringSplitOptions.RemoveEmptyEntries);

                    return gradeArray; /*returns an array which contains grades*/
                }
                catch (Exception ex)  /*exception handling is performed*/
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    string[] empty = { };
                    return empty;
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
                var x = "z" + ZID + " -- " + lastName.PadLeft(11, ' ') + ", " + firstName.PadRight(13, ' ') + " " + "[" + acadYear.ToString().PadLeft(11, ' ').PadRight(13, ' ') + "]  " + "(" + major.PadLeft(7, ' ') + ") " + "|" + gpa.ToString("0.000").PadLeft(7, ' ').PadRight(9, ' ') + "|";
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

            public void PrintRoster()                     /*Print roster function*/
            {
                Console.WriteLine("Which course roaster would you like printed?");
                Console.Write("(DEPT COURSE_NUM-SECTION_NUM)");
                string variable = Console.ReadLine();
                string[] var1 = variable.Split(' ');
                string[] var2 = var1[1].Split('-');
                List<Student> roster = new List<Student>();
                Course course1 = new Course();
                foreach (Course co in Form1.coursePool)            /*to display the list of students and the courses they have been enrolled in*/
                {
                    if (co.courseNumber == (Convert.ToUInt16(var2[0])))
                    {
                        roster = co.zid_numberOfStudents;
                        course1 = co;
                    }
                }

                if (roster.Count == 0) /*checking the condition if roster is 0*/
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
            }

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
    }



}