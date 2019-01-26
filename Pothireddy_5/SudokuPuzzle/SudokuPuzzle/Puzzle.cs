/* Pair Programming : Harshith Desamsetti(Z1829024), Rahul Pothireddy(Z1829984)
 * course : CSCSI 504
 * Assignment Number. : 5
 * Due Date : 15th November 2018 */


/*importing the required packages*/
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

/*creating a class sudoku puzzle using name space and there by implementing forms*/
namespace SudokuPuzzle
{
    public partial class Puzzle : Form
    {
       
        //declaration of variables used in programming sudoku and intialising them to 0
        private int durationSeconds = 0;
        private int durationMinute = 0;
        private string fileDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private int totalTextCount = 0;
        //error variable being initialised to 0
        private int ErrorTextCount = 0;
        public Puzzle()
        {
            //calling the function initializecomponet
            InitializeComponent();
        }
        
        //function for loading the puzzle into programm
        private void Puzzle_Load(object sender, EventArgs e)
        {           
            if (Form1.resume != true)
            {   //loading the puzzle based on the difficulty level chosen byt the user
                lblDifficulty.Text = Form1.difficulty;
                lblLevel.Text = Form1.level;
                string diffiCultyFile = SelectDifficultyFile(Form1.difficulty.ToLower(), Form1.level.Split('-')[1].ToString());
                ReadNewPuzzle(diffiCultyFile);
            }
            else {
                //loads the save game files in the directory
                string ResumeFilePath = fileDirectory + "SavedGame.txt";
                ReadResumeFile(ResumeFilePath);
            }
            int Totalcount = FindEmptyTextBox();

            TotalTextBoxCount = Totalcount;
            lblProgress.Text = "0/" + TotalTextBoxCount + " Box filled";
            lblProgress.BackColor = System.Drawing.Color.Transparent;
            pervcentage = 100 / Totalcount;
            progressBar1.Step = pervcentage;
            progressBar1.Maximum = pervcentage * FindEmptyTextBox();
        }


        private void ReadResumeFile(string ResumeFilePath)
        {

            String newPuzzle;
         
            StreamReader sr = new StreamReader(ResumeFilePath);

            //Read the first line of text
            newPuzzle = sr.ReadToEnd();
            //new puzzle come into implementation
            string[] ContentArray = newPuzzle.Split(new string[] { System.Environment.NewLine }, System.StringSplitOptions.RemoveEmptyEntries);

            string DiffLevel = ContentArray[0].ToLower();
            string diff = DiffLevel.Split('-')[0].ToString();
            string level = DiffLevel.Split('-')[1].ToString();


            //string[] ContentArray = newPuzzle.Split(new string[] { System.Environment.NewLine }, System.StringSplitOptions.RemoveEmptyEntries);
            if (diff == "easy") { diff = "Easy"; }
            if (diff == "medium") { diff = "Medium"; }
            if (diff == "hard") { diff = "Hard"; }

            lblDifficulty.Text = diff;
            lblLevel.Text = diff + "-" + level;

            // make textbox disabled
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    int contentI = i + 1;
                    TextBox txtBox = (TextBox)this.Controls.Find("txtInput" + i.ToString() + j.ToString(), true)[0];
                    string boxValue = ContentArray[contentI][j].ToString();
                    if (boxValue == "E")
                    {
                        txtBox.Enabled = false;
                    }
                }
            }
            //make textbox to be filled with the input values
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    int contentI = i + 10;
                    //declaring textbox with type of field to be entered
                    TextBox txtBox = (TextBox)this.Controls.Find("txtInput" + i.ToString() + j.ToString(), true)[0];
                    string boxValue = ContentArray[contentI][j].ToString();
                    if (boxValue != "0")
                    {
                        txtBox.Text = boxValue;
                    }
                    else
                    {   
                        //make textbox empty
                    
                        txtBox.Text = "";
                    }
                }
            }

            //close the file
            sr.Close();
        }
        /***************************************************************************
         * resetTime() is a function used to rest or clear the time taken by the user
         * to completed or work with the puzzle
         * *************************************************************************/
        public void resetTime() {
            durationMinute = 0;
            durationSeconds = 0;
            lblTime.Text = "00:00";
            timer1.Stop();
        }
        //timer_tick is is implmented that caluclated minutes and seconds that user has taken
        private void timer1_Tick(object sender, EventArgs e)
        {
            string Minute = "";
            string Seconds = "";
            durationSeconds++;
            if (durationMinute < 10)
            {
                Minute = "0" + durationMinute.ToString(); //if duration of minutes is less than 10
            }
            else {
                Minute = durationMinute.ToString(); //if minutes duration is greaater than 10
            }
            if (durationSeconds < 10)
            {
                Seconds = "0" + durationSeconds.ToString(); //if seconds duration is less than 0
            }
            else
            {
                Seconds = durationSeconds.ToString(); 
            }

            lblTime.Text = Minute + ":" + Seconds;
            if (durationSeconds == 59) {
                durationSeconds = 0;
                durationMinute++;
            }
        }
        //different levels of difficulty is choosen in the intial stages
        public string SelectDifficultyFile(string folder , string file) {
            if (folder == "easy") { file = "e" + file; } /*easy level*/
            if (folder == "medium") { file = "m" + file; } /*medium level*/
            if (folder == "hard") { file = "h" + file; }/*hard level*/
            string DifficultyFilePath = fileDirectory + folder + "\\" + file + ".txt";
            return DifficultyFilePath;
        }
        // reading new puzzle from the file directory
        public void ReadNewPuzzle(string filePath) {
            string FilePath = fileDirectory + "SavedGame.txt";
            StreamWriter sw = new StreamWriter(FilePath);
            sw.Write(""); //write to file
            sw.Close();//close the file
            String newPuzzle;
            //new file
            StreamReader sr = new StreamReader(filePath);

            //Read the first line of text
            newPuzzle = sr.ReadToEnd();

            string[] ContentArray = newPuzzle.Split(new string[] { System.Environment.NewLine }, System.StringSplitOptions.RemoveEmptyEntries);

            //string[] ContentArray = newPuzzle.Split(new string[] { System.Environment.NewLine }, System.StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    TextBox txtBox = (TextBox)this.Controls.Find("txtInput" + i.ToString() + j.ToString(), true)[0];
                    string boxValue = ContentArray[i][j].ToString();
                    if (boxValue != "0")
                    {
                        txtBox.Text = boxValue;
                        txtBox.Enabled = false;
                    }
                    else {
                        txtBox.Text = "";
                    }
                }
            }

            //close the file
            sr.Close();
        }
        //function to avoid input being either o or any other alphabet
        private void txtInput00_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            { 
                e.Handled = true;            
            }
        }
        //function for button pause, which intially stops thee game for sometime and resumes when pressed again
        private void btnPauseResume_Click(object sender, EventArgs e)
        {
            if (btnPauseResume.Text == "Pause") {
                timer1.Stop();
                btnPauseResume.Text = "Resume";
            }else{
                timer1.Start();
                btnPauseResume.Text = "Pause";
            }

        }
        //function for solution button which displays the solution of the sudoku game
        public void PuzzleSolution(string filePath) {
            String newPuzzle;

            StreamReader sr = new StreamReader(filePath);

            //Read the first line of text
            newPuzzle = sr.ReadToEnd();

            string[] ContentArray = newPuzzle.Split(new string[] { System.Environment.NewLine }, System.StringSplitOptions.RemoveEmptyEntries);

            //string[] ContentArray = newPuzzle.Split(new string[] { System.Environment.NewLine }, System.StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    TextBox txtBox = (TextBox)this.Controls.Find("txtInput" + i.ToString() + j.ToString(), true)[0];
                    int contentI = i + 9;
                    string boxValue = ContentArray[contentI][j].ToString();
                    txtBox.Text = boxValue;
                    txtBox.BackColor = Color.White;
                }
            }

            //close the file
            sr.Close();
        }
        
        /**********************************************************************************
         * button clear is used to clear all the contents of the game upto which the user 
         * has entered.
         * ********************************************************************************/
        private void btnClear_Click(object sender, EventArgs e)
        {   
            //for loop for all the boxes
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    TextBox txtBox = (TextBox)this.Controls.Find("txtInput" + i.ToString() + j.ToString(), true)[0];
                    if (txtBox.Enabled != true)
                    { }
                    else
                    {
                        txtBox.Text = "";
                    }
                }
            }
            resetTime(); //reset time after clearing
            timer1.Start();//start the timer button
        }

        /*************************************************************************************
        * button solutionclick implements the function calling solution of the sudoku puzzle
        * ************************************************************************************/
        private void btnSolution_Click(object sender, EventArgs e)
        {
            string level = lblLevel.Text.ToLower();
            string folder = level.Split('-')[0].ToString();
            string file = level.Split('-')[1].ToString();

            if (folder == "easy") { file = "e" + file; } /*easy level*/
            if (folder == "medium") { file = "m" + file; } /*medium level*/
            if (folder == "hard") { file = "h" + file; } /*hard level*/
            string DifficultyFilePath = fileDirectory + folder + "\\" + file + ".txt";
            PuzzleSolution(DifficultyFilePath);
            resetTime();//restting the time
            btnProgress.Enabled = false; //progress button
            btnSolve.Enabled = false; //solvebutton
            btnClear.Enabled = false; //clear button
            btnSave.Enabled = false; //save button
            btnPauseResume.Enabled = false; //resume button
            btnSolution.Enabled = false;//solution button
            MessageBox.Show("Game Over, Press New Game to start a New Game", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        /******************************************************************
         * button new game calles the function of iplementing a new or fresh
         * game for scratch closing the old one
         * ***************************************************************/
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();//shows form1
            this.Close();//close
        }
        private void button1_Click(object sender, EventArgs e)
        {
         
        }
        //finds the empty text box where no input is given by the user
        public int FindEmptyTextBox() {
            totalTextCount = 0;//text count being intialised to 0
            //for loop in the box
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    TextBox txtBox = (TextBox)this.Controls.Find("txtInput" + i.ToString() + j.ToString(), true)[0];
                    if (txtBox.Text == "")
                    {
                        //textcount being incremented to 1
                        totalTextCount += 1;
                    }
                }
            }
            //returns total text count
            return totalTextCount;

        }
        /************************************************************************************
         * progress button : this buttons lets you know the progress button, lke how many 
         * boxes are filled, how many are left over.
         * **********************************************************************************/
        private void btnProgress_Click(object sender, EventArgs e)
        {
            FindErrorBoxValues(); //errors boxes displayed in red colour
            string emptyText = FindEmptyTextBox().ToString();
            if (ErrorTextCount > 0) //if there are any errors encountered then the following executes
            {
                MessageBox.Show(emptyText + " boxes remaining to fill and you have " + ErrorTextCount + " error values", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                //else if everything worksfine then success oriented message is displayed
                MessageBox.Show("You are good to go and " + emptyText + " boxes remaining to fill", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /**************************************************************************************************
         * Finding the errors values implementes the matching process of the user input and the
         * solution file placed in the directory. The errors values are generally displayed in red boxes
         * ************************************************************************************************/
        public int FindErrorBoxValues()
        {
            string level = lblLevel.Text.ToLower();
            string folder = level.Split('-')[0].ToString();
            string file = level.Split('-')[1].ToString();

            if (folder == "easy") { file = "e" + file; } //easy
            if (folder == "medium") { file = "m" + file; }//medium
            if (folder == "hard") { file = "h" + file; } //hard
            //difficulty file path
            string DifficultyFilePath = fileDirectory + folder + "\\" + file + ".txt";
            ErrorTextCount = 0;

            String newPuzzle;

            StreamReader sr = new StreamReader(DifficultyFilePath);

            //Read the first line of text
            newPuzzle = sr.ReadToEnd();

            string[] ContentArray = newPuzzle.Split(new string[] { System.Environment.NewLine }, System.StringSplitOptions.RemoveEmptyEntries);

            //string[] ContentArray = newPuzzle.Split(new string[] { System.Environment.NewLine }, System.StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    TextBox txtBox = (TextBox)this.Controls.Find("txtInput" + i.ToString() + j.ToString(), true)[0];
                    int contentI = i + 9;
                    string SolutionValue = ContentArray[contentI][j].ToString();
                    if (txtBox.Text != SolutionValue && txtBox.Text != "") //if the textbox answer is not as same as the solution
                    {
                        ErrorTextCount += 1;//erro cout being incremented by 1
                        txtBox.BackColor = Color.Red;//errro box being displayed using red colour
                    }
                    else {
                        txtBox.BackColor = Color.White;                        
                    }
                }
            }

            //close the file
            sr.Close();
            //return the error count
            return ErrorTextCount;
        }
        /*************************************************************************************
         * It is the click which implements button solve
         * ***********************************************************************************/
        private void btnSolve_Click(object sender, EventArgs e)
        {
            if (FindEmptyTextBox() == 0)//if a box is empty
            {
                int err = FindErrorBoxValues();//if error is found

                if (err > 0)
                {
                    resetTime();//time is reset
                    btnProgress.Enabled = false; //progress button
                    btnSolve.Enabled = false;
                    btnClear.Enabled = false;//clear button
                    btnSave.Enabled = false;
                    btnPauseResume.Enabled = false;//pause button
                    btnSolution.Enabled = false;//solution button
                    MessageBox.Show("Sorry You lost the game with "  + err+  " error values, Press New Game to start a New Game", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }//message box to siplay a sorry -you lost the game information and asks the user to enter into a new game
                else {
                    resetTime();//reset time
                    btnProgress.Enabled = false;
                    btnSolve.Enabled = false;//solve button
                    btnClear.Enabled = false;
                    btnSave.Enabled = false;//save button
                    btnPauseResume.Enabled = false;
                    btnSolution.Enabled = false;
                    MessageBox.Show("You are awesome, you have finished the game in " + lblTime + " ,Press New Game to start a New Game", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }//displays the succesfull completion of the message

                
            }
            else {
                MessageBox.Show(FindEmptyTextBox().ToString() + " boxes remaining.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /*************************************************************************************
         * This click implements the button save which saves the state of the present game
         * ***********************************************************************************/
        private void btnSave_Click(object sender, EventArgs e)
        {
            string FilePath = fileDirectory + "SavedGame.txt"; //file path for saved game 
            StreamWriter sw = new StreamWriter(FilePath);
            StringBuilder str = new StringBuilder();
            sw.Write("");//write to file

            string level = lblLevel.Text.ToLower();

            sw.WriteLine(level);
            //save disbled textboxes
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    TextBox txtBox = (TextBox)this.Controls.Find("txtInput" + i.ToString() + j.ToString(), true)[0];
                    if (txtBox.Text != "")
                    {
                        if (txtBox.Enabled != true)//if textbox enabled is true
                        {
                            //appnding
                            str.Append("E");
                        }
                        else
                        {
                            str.Append(txtBox.Text);//appending to the textbox
                        }
                        
                    }
                    else {
                        str.Append("0");
                    }
                }
                sw.WriteLine(str);//write line 
                str.Clear();//clear
            }

            sw.WriteLine("");//witeline

            //for loop for 
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    TextBox txtBox = (TextBox)this.Controls.Find("txtInput" + i.ToString() + j.ToString(), true)[0];
                    if (txtBox.Text != "")//if the textbox content is empty
                    {
                        str.Append(txtBox.Text);//appending
                    }
                    else
                    {
                        str.Append("0");
                    }
                }
                sw.WriteLine(str);//write line
                str.Clear();//clears the string
            }

            sw.Close();//closes the streamwriter
            //message box to display a message that indicates the successfull saved message
            MessageBox.Show("Game Saved Succesfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void txtInput00_Leave(object sender, EventArgs e)
        {
            int count = TotalTextBoxCount - FindEmptyTextBox();
            lblProgress.Text = count + "/" + TotalTextBoxCount + " Box filled";
            progressBar1.Value = pervcentage * count;
        }
    }
}
