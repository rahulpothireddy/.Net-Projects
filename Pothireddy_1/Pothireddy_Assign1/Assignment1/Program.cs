/* Pair Programming : Harshith Desamsetti(Z1829024), Rahul Pothireddy(Z1829984)
 * course : CSCSI 504
 * Assignment Number. : 1 
 * Due Date : 13th September 2018 */

using System;
using System.IO;
using System.Collections.Generic; /*packages that includes all the important classes needed for programming*/
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1 /* namespace is created*/
{
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
            if (this.deptCode.CompareTo(course.deptCode)<0)
            {
                if(this.courseNumber<course.courseNumber)
                {
                    return 1;
                }
            }
            else if(this.deptCode.CompareTo(course.deptCode) > 0)
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
            foreach (Course co in Program.coursePool)            /*to display the list of students and the courses they have been enrolled in*/
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


    static class Program
    {
        /*Defining the Static variables coursePool and studentPool and initializing them */
        public static List<Course> coursePool = new List<Course>();
        public static List<Student> studentPool = new List<Student>();


        static void Main(string[] args)  /*main function implementations starts here*/
        {
            string studentContents = "";
            string courseContents = "";
            string[] studentInput;
            string[] courseInput;

            using (StreamReader streamReader = new StreamReader(Directory.GetCurrentDirectory() + "\\2188_a1_input01.txt"))
            {
                studentContents = streamReader.ReadLine();
                while (studentContents != null)         /*if student contents are null*/
                {
                    studentInput = studentContents.Split(',');
                    studentPool.Add(new Student(Convert.ToUInt32(studentInput[0]), studentInput[1], studentInput[2], studentInput[3], (academicYear)Enum.Parse(typeof(academicYear), studentInput[4]), Convert.ToSingle(studentInput[5])));
                    studentContents = streamReader.ReadLine();   /*conversion takes place which then displays the attributes in a particular order*/
                }
            }



            using (StreamReader streamReader = new StreamReader(Directory.GetCurrentDirectory() + "\\2188_a1_input02.txt"))
            {
                courseContents = streamReader.ReadLine();
                while (courseContents != null)
                {
                    courseInput = courseContents.Split(','); /*display the contents of course*/
                    coursePool.Add(new Course(courseInput[0], Convert.ToUInt16(courseInput[1]), courseInput[2], Convert.ToUInt16(courseInput[3]), Convert.ToUInt16(courseInput[4])));
                    courseContents = streamReader.ReadLine();
                }
            }

            Console.WriteLine("");         /*printing the required statements*/
            Console.WriteLine("Please choose from the following options");
            Console.WriteLine("");
            Console.WriteLine("1.Print Student List(All)");      /*printing the options menu*/
            Console.WriteLine("2.Print Student List(Major)");
            Console.WriteLine("3.Print Student List(Academic Year)");
            Console.WriteLine("4.Print Course List");
            Console.WriteLine("5.Print Course Roster");
            Console.WriteLine("6.Enroll Student");
            Console.WriteLine("7.Drop Student");
            Console.WriteLine("8.Quit");
            Console.WriteLine("");
            Console.WriteLine("");
            char option;

            option = Console.ReadKey().KeyChar; /*new object creation*/

            Console.WriteLine();
            while (option != '8') /*while condition to check if its within given 8 options*/
            {
                switch (option)
                {
                    case '1':                /*option 1 gets executed*/
                        studentPool.Sort();
                        coursePool.Sort();
                        Console.WriteLine("Student List (All Students): \n");
                        Console.WriteLine("----------------------------------------------------------------------------");

                        foreach (Student stud in studentPool)
                        {
                            /*Foreach is used to display details for each student object in studentPool using ToString() method*/
                            Console.WriteLine(stud.ToString());
                        }
                        break;

                    case '2':
                        studentPool.Sort();  /*option 2 gets executed*/
                        coursePool.Sort();
                        Console.WriteLine("Which major list would you like printed?"); /*students major list is printed*/
                        String s = Console.ReadLine();
                        Console.WriteLine("Student List (" + s + "Majors):\n");
                        Console.WriteLine("----------------------------------------------------------------------------");
                        int size = 0;
                        foreach (Student stud1 in studentPool)
                        {
                            if (stud1.Major.ToLower().Equals(s.ToLower()))
                            {
                                /*Foreach is used to display details for each student object in studentPool using ToString() method
                                 If condition is used to check if the major entered is equal to the major of students in studentPool
                                 and displaying them using ToString()*/

                                Console.WriteLine(stud1.ToString());
                                size++;
                            }
                        }
                        if (size == 0)
                            Console.WriteLine("There doesn't appear to be any student majoring in " + s);
                            //Displaying the message if there is no student majoring in the entered major
                        break;

                    case '3':
                        studentPool.Sort(); /*option 3 gets executed*/
                        coursePool.Sort();
                        Console.WriteLine("Which academic year would you like printed?"); /*the academic year of the student is printed*/
                        Console.WriteLine("Freshman,Sophomore,Junior,Senior,PostBacc"); /*options of the student years*/
                        string s1 = Console.ReadLine();
                        Console.WriteLine("student List (" + s1 + " Majors): ");   /*conditions to check or validate*/
                        Console.WriteLine("----------------------------------------------------------------------------");
                        int size1 = 0;

                        foreach (Student stu in studentPool)
                        {
                            if (stu.setAndGetYear.ToString().ToLower().Equals(s1.ToLower()))
                            {
                                /*Foreach is used to display details for each student object in studentPool using ToString() method
                                 If condition to check if the academic year entered is equal to academic year of any student and displaying
                                 them using ToString()*/
                                Console.WriteLine(stu.ToString());
                                size1++;
                            }
                        }

                        if (size1 == 0)
                        {
                            Console.WriteLine("No Student in the specified academic year\n");
                        }
                        break;

                    case '4':
                        studentPool.Sort(); /*option 4 gets executed*/
                        coursePool.Sort();
                        Console.WriteLine("Course List (All Courses)");
                        Console.WriteLine("----------------------------------------------------------------------------");
                        foreach (Course c in coursePool)
                        {
                            /*Foreach is used to display details for each course object in coursePool using ToString() method*/
                            Console.WriteLine(c.ToString()); /*list all the courses*/
                        }
                        break;

                    case '5':
                        studentPool.Sort(); /*option 5 gets executed*/
                        coursePool.Sort();
                        //Calling the PrintRoster() method
                        coursePool[0].PrintRoster();
                        break;

                    case '6':
                        studentPool.Sort();  /*option 6 gets executed*/
                        coursePool.Sort();
                        Console.WriteLine("Please enter the ZID (Omitting the Z character) of the student you like to enroll into a course.");
                        var zid = Console.ReadLine(); /*prints the zid of a student without z character*/
                        Console.WriteLine("Which course will this student be enrolled into?");
                        Console.WriteLine("( DEPT COURSE_NUM-SECTION_NUM )");
                        string courseName = Console.ReadLine();
                        string[] splitName = courseName.Split(' ');        /* enrolling a particular student in a particular course and a particular department*/
                        string[] courseNum = splitName[1].Split('-');
                        Course co1 = new Course();
                        foreach (Course courseEnroll in coursePool)
                        {
                            if (Convert.ToString(courseEnroll.courseNumber).Equals(courseNum[0]))
                            {
                                //If condition to check if the courseNumber equals to any course number
                                co1 = courseEnroll;
                                Console.WriteLine(co1.ToString());
                            }
                        }

                        foreach (Student student22 in studentPool)
                        {
                            if (student22.ZID == Int32.Parse(zid))
                            {
                                if (student22.Enroll(co1) == 0)                 /*enrolls a student into a given course using zid, course no. and dept code*/
                                {
                                    Console.WriteLine("z" + zid + " has successfully been enrolled into " + courseName);
                                }
                            }
                        }

                        break;
                    case '7':
                        studentPool.Sort(); /*option 7 gets executed*/
                        coursePool.Sort();
                        Console.WriteLine("Please enter the ZID (Omitting the Z character) of the student you like to drop from a course.");
                        var zidToDrop = Console.ReadLine();
                        Console.WriteLine("Which course will this student be dropped from?"); /*dropping of course by student function executes*/
                        Console.WriteLine("( DEPT COURSE_NUM-SECTION_NUM )");
                        string courseName1 = Console.ReadLine();
                        string[] splitName1 = courseName1.Split(' ');  /*split method*/
                        string[] courseNum1 = splitName1[1].Split('-');
                        Course co1_2 = new Course();

                        foreach (Course courseDrop in coursePool) /*for each course that is being dropped*/
                        {
                            if (Convert.ToString(courseDrop.courseNumber).Equals(courseNum1[0]))
                            {
                                //If condition to check if the courseNumber equals to any course number
                                co1_2 = courseDrop;
                                Console.WriteLine(co1_2.ToString());
                            }
                        }

                        foreach (Student student22_2 in studentPool)
                        {
                            if (student22_2.ZID == Int32.Parse(zidToDrop))
                            {
                                if (student22_2.Drop(co1_2) == 0)
                                {
                                    Console.WriteLine("z" + zidToDrop + " has successfully dropped from " + courseName1); /*successfully dropped courses*/
                                }
                            }
                        }
                        break; /*break the switch case here*/
                    case '8':
                    case 'q':
                    case 'Q':
                        return;
                    default:
                        break;
                }
                Console.WriteLine("");
                Console.WriteLine("We have " + studentPool.Count() + " students and " + coursePool.Count() + " courses.");
                Console.WriteLine("");
                Console.WriteLine("Please choose from the following options");
                Console.WriteLine("");
                Console.WriteLine("1.Print Student List(All)");   /** print statemets of all  the options menu after all the processes are executed **/
                Console.WriteLine("2.Print Student List(Major)");
                Console.WriteLine("3.Print Student List(Academic Year)");
                Console.WriteLine("4.Print Course List");
                Console.WriteLine("5.Print Course Roster");
                Console.WriteLine("6.Enroll Student");
                Console.WriteLine("7.Drop Student");
                Console.WriteLine("8.Quit");
                Console.WriteLine("");
                Console.WriteLine("");
                option = Console.ReadKey().KeyChar;
                Console.WriteLine();
            }
        }
    }
}