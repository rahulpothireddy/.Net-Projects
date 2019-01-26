/* Pair Programming : Harshith Desamsetti(Z1829024), Rahul Pothireddy(Z1829984)
 * course : CSCSI 504
 * Assignment Number. : 5
 * Due Date : 15th November 2018 */

 /*importing the required and usefull packages*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*class SudokuPuzzle is being implemented*/
namespace SudokuPuzzle
{
    public partial class Form1 : Form
    {   
        //initialising the variables to be used
        public static string difficulty = "";
        public static string level = "";
        public static bool resume = false;
        private string fileDirectory = AppDomain.CurrentDomain.BaseDirectory;
        //calling function form1
        public Form1()
        {
            InitializeComponent();
        }
        //loading the form 1
        private void Form1_Load(object sender, EventArgs e)
        {
            cbDifficulty.SelectedIndex = 0;//selecting the difficulty level
        }

        private void cbDifficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDifficulty.SelectedIndex == 1) {
                cbLevel.Items.Clear(); //clear option
                cbLevel.Items.Add("Select"); //select option
                cbLevel.Items.Add("Easy-1"); //easy 1
                cbLevel.Items.Add("Easy-2"); //easy 2
                cbLevel.Items.Add("Easy-3"); //easy 3
                cbLevel.Items.Add("Easy-4");
                cbLevel.SelectedIndex = 0;
            }
            if (cbDifficulty.SelectedIndex == 2)//if diffuclty level is 2
            {
                cbLevel.Items.Clear(); //clear
                cbLevel.Items.Add("Select");//select option
                cbLevel.Items.Add("Medium-1");//medium 1 option
                cbLevel.Items.Add("Medium-2");//medium 2 option
                cbLevel.Items.Add("Medium-3");//medium 3 option
                cbLevel.Items.Add("Medium-4");//medium 4 option
                cbLevel.SelectedIndex = 0;
            }
            if (cbDifficulty.SelectedIndex == 3)//if difficult level is 3
            {
                cbLevel.Items.Clear(); //clear
                cbLevel.Items.Add("Select");//select option
                cbLevel.Items.Add("Hard-1");//hard option1
                cbLevel.Items.Add("Hard-2");//hard 2 option
                cbLevel.Items.Add("Hard-3");//hard 3 option
                cbLevel.Items.Add("Hard-4");//hard 4 option
                cbLevel.SelectedIndex = 0;//making selected index 0
            }
        }
        //changing the selected index functions
        private void cbLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if index is greater than 0
            if (cbLevel.SelectedIndex > 0) {
                btnNewPuzzle.Enabled = true;
            }
        }
        //calling the click function which implements new puzzle button
        private void btnNewPuzzle_Click(object sender, EventArgs e)
        {
        
            Puzzle gameForm = new Puzzle();//new puzzle
            difficulty = cbDifficulty.Text;//diffiuculty text
            level = cbLevel.Text;
            resume = false;
            gameForm.Show(); //showing the game form
            this.Hide();//hiding this
        }
        //implementing click which executes the resumebutton from paused state
        private void btnResume_Click(object sender, EventArgs e)
        {
            string ResumeFilePath = fileDirectory + "SavedGame.txt"; //resumes from saved state

            String newPuzzle; //new puzzle

            StreamReader sr = new StreamReader(ResumeFilePath);

            //Read the first line of text
            newPuzzle = sr.ReadToEnd();

            string[] ContentArray = newPuzzle.Split(new string[] { System.Environment.NewLine }, System.StringSplitOptions.RemoveEmptyEntries);

            sr.Close(); //close
            if (ContentArray.Length > 0) //content array's length greater than 0
            {
                Puzzle gameForm = new Puzzle();
                resume = true; //resume becomes true here
                gameForm.Show();
                this.Hide(); //hiding
            }
            else {
                //message box to display there is no saved error state
                MessageBox.Show("There is no any saved game", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
