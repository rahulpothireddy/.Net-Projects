/* Pair Programming : Harshith Desamsetti(Z1829024), Rahul Pothireddy(Z1829984)
 * course : CSCSI 504
 * Assignment Number. : 4 
 * Due Date : 1st November 2018 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MsPaint
{
    public partial class Form1 : Form
    {
		//Creating an Imagefile of type image, newBitmap of type Bitmap
		//Creating Points current and old
		//Creating pencil and brush of type Pen
		//Creating Brush b and Graphics g
		//Creating List<KeyValuePair<Point,Point>> undoRedoList to take the points drawn and add them to the list
		//Creating List<object> Editlist and EditRedolist to make undo and redo
        Image imageFile;
        Bitmap newBitmap;
        public Point current = new Point();
        public Point old = new Point();
        public Pen pencil = new Pen(Color.Black, 1);
        public Pen brush = new Pen(Color.Black, 1);
        public string fileName = "";
        public Brush b;
        public Graphics g;
        private string fileDirectory = AppDomain.CurrentDomain.BaseDirectory;
        List<KeyValuePair<Point, Point>> undoRedoList = new List<KeyValuePair<Point, Point>>();
        List<object> Editlist = new List<object>();
        List<object> EditRedolist = new List<object>();

        public Form1()
        {
            InitializeComponent();
            pencil.SetLineCap(System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.DashCap.Round);
            brush.SetLineCap(System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.DashCap.Round);
            this.WindowState = FormWindowState.Maximized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
			
            newBitmap = new Bitmap(panel1.Width, panel1.Height);
			//Initializing the newBitmap to Bitmap of size panel1.Width and panel1.Height
            
			g = panel1.CreateGraphics();
			//Assigning g as panel1.CreateGraphics()

            string[] recentArray = loadRecent();
			//Assigning the recentArray to loadRecent()

            for (int i = 0; i < recentArray.Length; i++)
            {
				//For loop to load the values from recentArray till it reaches 5 files
                ToolStripMenuItem menuItem = createmenuStrip(recentArray[i], i);

                recentFileList.DropDownItems.Add(menuItem);
				//Adding the files to the dropdownitems of recentFileList

                if (i == 4) { break; }
            }

        }

        public ToolStripMenuItem createmenuStrip(string text, int i)
        {
            ToolStripMenuItem item = new ToolStripMenuItem();
            item.Text = text;
            item.Name = "recentMenuItem" + i;
            item.Click += new System.EventHandler(this.recentmenuitem_click);
            return item;

        }

        public void recentmenuitem_click(object sender, EventArgs e)
        {
            if (Editlist.Count > 0)
            {
				//Checking if EditList count is greater than 0
                DialogResult dlgRes = MessageBox.Show("Do you want to save changes to current file ?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
				//Displaying the DialogResult as a MessageBOX
				
                if (dlgRes == System.Windows.Forms.DialogResult.Yes)
                {
					//Checking if the selected option is Yes
                    SaveFile();
					//Calling the saveFile() method
                }
                if (dlgRes == System.Windows.Forms.DialogResult.No)
                {
					//Checking if the selected option is No
                    string path = ((ToolStripMenuItem)sender).Text;
                    panel1.Load(path);
					//Loading the panel1 to the path

                    Editlist.Clear();
					//Clearing the EditList
                    EditRedolist.Clear();
					//Clearing the EditRedoList
                }
            }
            else {
                string path = ((ToolStripMenuItem)sender).Text;

                panel1.Load(path);
                Editlist.Clear();
                EditRedolist.Clear();
            }
          

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            old = e.Location;
			//Assigning the old as the location of the point
            
			undoRedoList = new List<KeyValuePair<Point, Point>>();
			
            if(pencilMenu.Checked==true)
            { 
			//Checking if the pencilMenu is checked
                g.FillCircle(brush.Brush, e.X, e.Y,brush.Width);
                g.DrawCircle(pencil, e.X, e.Y, pencil.Width);
				//Then drawing a point
            }
            else if (brushMenu.Checked == true)
            {
				//Checking if the brushMenu is checked
                g.FillCircle(brush.Brush, e.X, e.Y, brush.Width);
                g.DrawCircle(pencil, e.X, e.Y, brush.Width);
				//Then drawing a point
            }
            else
            {
				//Else drawing a point
                g.FillCircle(brush.Brush, e.X, e.Y, brush.Width);
                g.DrawCircle(pencil, e.X, e.Y, pencil.Width);
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
				//Checking if the button clicked is mouse left button
                current = e.Location;
				//Assigning the current as the location of the point

                if (straightLineToolStripMenuItem.Checked == false)
                {
					//If the straightLineToolStripMenuItem is checked as false
                    if (pencilMenu.Checked == true)
                    {
						//Checking if the pencilMenu is checked as true
                        pencil.Color = panelForeColor.BackColor;
						//Pencil color is set as panelForeColor.BackColor
                        g.DrawLine(pencil, old, current);
						//Calling the g.DrawLine to draw the line based on the points
                        undoRedoList.Add(new KeyValuePair<Point, Point>(old, current));
						//Adding the new keyvalue pair of points to the undoRedoList
                    }
                    else if (pxToolStripMenuItem3.Checked == true || pxToolStripMenuItem4.Checked == true || pxToolStripMenuItem5.Checked == true || pxToolStripMenuItem6.Checked == true || pxToolStripMenuItem7.Checked == true)
                    {
						//Else if the pencilMenu is not checked
                        brush.Color = panelBackColor.BackColor;
						//Brush.color is assigned as panelBackColor.BackColor
                        g.DrawLine(brush, old, current);
						//Calling the g.DrawLine to draw the line based on the points
                        undoRedoList.Add(new KeyValuePair<Point, Point>(old, current));
						//Adding the new keyvalue pair of points to the undoRedoList
                    }
                    else
                    {
						//Else drawing the line based on the points
                        brush.Color = panelForeColor.BackColor;
                        g.DrawLine(brush, old, current);
                        undoRedoList.Add(new KeyValuePair<Point, Point>(old, current));

                    }
					//Assigning old = current at the end
                    old = current;
                }

            }
        }

       
		//intializing the tools menu required to paint
        private void pxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pencil.Width = 1;
            pxToolStripMenuItem.Checked = true;
            pxToolStripMenuItem1.Checked = false;
            pxToolStripMenuItem2.Checked = false;
            pencilMenu.Checked = true;
            brushMenu.Checked = false;
        }
        //intializing pencil with width 3 with properties defined with boolean values
        private void pxToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pencil.Width = 2;
            pxToolStripMenuItem.Checked = false;
            pxToolStripMenuItem1.Checked = true;
            pxToolStripMenuItem2.Checked = false;
            pencilMenu.Checked = true;
            brushMenu.Checked = false;
        }
        //intializing pencil with width 3
        private void pxToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            pencil.Width = 3;
            pxToolStripMenuItem.Checked = false;
            pxToolStripMenuItem1.Checked = false;
            pxToolStripMenuItem2.Checked = true;
            pencilMenu.Checked = true;
            brushMenu.Checked = false;
        }
        //solid tool strip to define a solid brush.
        private void solidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pencil.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            solidToolStripMenuItem.Checked = true;
            dottedLinesToolStripMenuItem.Checked = false;
            pencilMenu.Checked = true;
            brushMenu.Checked = false;
        }
        //solid tool strip to define a dotted brush and its types
        private void dottedLinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pencil.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            dottedLinesToolStripMenuItem.Checked = true;
            solidToolStripMenuItem.Checked = false;
            pencilMenu.Checked = true;
            brushMenu.Checked = false;
        }

        private void brushThickFive_Click(object sender, EventArgs e)
        {
            brush.Width = 5;
            brushThickFive.Checked = true;
            brushThickSix.Checked = false;
            brushThickSeven.Checked = false;
            brushThickEight.Checked = false;
            pencilMenu.Checked = false;
            brushMenu.Checked = true;
        }
        //brush with width as 6
        private void brushThickSix_Click(object sender, EventArgs e)
        {
            brush.Width = 6;
            brushThickFive.Checked = false;
            brushThickSix.Checked = true;
            brushThickSeven.Checked = false;
            brushThickEight.Checked = false;
            pencilMenu.Checked = false;
            brushMenu.Checked = true;
        }
        //brush with width as 7
        private void brushThickSeven_Click(object sender, EventArgs e)
        {
            brush.Width = 7;
            //certain brushes required are made true
            brushThickFive.Checked = false;
            brushThickSix.Checked = false;
            brushThickSeven.Checked = true;
            brushThickEight.Checked = false;
            pencilMenu.Checked = false;
            brushMenu.Checked = true;
        }
        //brush with width as 8
        private void brushThickEight_Click(object sender, EventArgs e)
        {
            brush.Width = 8;
            brushThickFive.Checked = false;
            brushThickSix.Checked = false;
            brushThickSeven.Checked = false;
            brushThickEight.Checked = true;
            pencilMenu.Checked = false;
            brushMenu.Checked = true;
        }

        private void brushSolid_Click(object sender, EventArgs e)
        {
            brush.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            brushSolid.Checked = true;
            brushDotted.Checked = false;
            pencilMenu.Checked = false;
            brushMenu.Checked = true;
        }

        private void brushDotted_Click(object sender, EventArgs e)
        {
            brush.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            brushSolid.Checked = false;
            brushDotted.Checked = true;
            pencilMenu.Checked = false;
            brushMenu.Checked = true;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
			//openFileDialog1.Filter assigned as "PNG(*.PNG)|*.png"
            openFileDialog1.Filter = "PNG(*.PNG)|*.png";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
				//If the dialog box is selected as OK
				
                imageFile = Image.FromFile(openFileDialog1.FileName);
				//Image file is assigned the value of Image.FromFile(openFileDialog1.FileName)
				
                panel1.Image = imageFile;
				//Setting the panel image to imageFile
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
			//Calling the SaveFile() method
            SaveFile();
        }

        public void SaveFile()
        {
            if (fileName == "")
            {
				//Checking if the fileName is empty
                newBitmap = new Bitmap(panel1.Width, panel1.Height, PixelFormat.Format32bppArgb);
				//Initializing the newBitmap
				
                // Create a graphics object from the bitmap
                g = Graphics.FromImage(newBitmap);

                g.CopyFromScreen(PointToScreen(panel1.Location), new Point(-5, -25), new Size(panel1.Width, panel1.Height + 25));
				//Calling the CopyFromScreen to get the image from the screen

                saveFileDialog1.Filter = "PNG(*.PNG)|*.png";
				//Assigning the saveFileDialog1.Filter as "PNG(*.PNG)|*.png"

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
					//Checking if the saveFileDialog1.ShowDialog() is selected as OK

                    using (Bitmap bmp = new Bitmap(panel1.Width, panel1.Height))
                    {
						//newBitmap.Save() method to save the file
                        newBitmap.Save(saveFileDialog1.FileName, ImageFormat.Png);
                        fileName = saveFileDialog1.FileName;
                        writeToFile(fileName);
                        MessageBox.Show("File Saved Successfully in location " + fileName);
                    }
                }
            }
            else
            {
				//Else the newBitmap is initialized
                newBitmap = new Bitmap(panel1.Width, panel1.Height, PixelFormat.Format32bppArgb);
                // Create a graphics object from the bitmap
                g = Graphics.FromImage(newBitmap);

                g.CopyFromScreen(PointToScreen(panel1.Location), new Point(-5, -25), new Size(panel1.Width, panel1.Height + 25));
				//Calling the CopyFromScreen to get the image from the screen

                using (Bitmap bmp = new Bitmap(panel1.Width, panel1.Height))
                {
					//Saving the image using newBitmap.Save() method
                    newBitmap.Save(saveFileDialog1.FileName, ImageFormat.Png);
                }
            }
            g = panel1.CreateGraphics();
        }
        //function to write to file and append the text
        public void writeToFile(string content)
        {

            string writeFile = fileDirectory + "\\recent.txt";
            string appendText = content;
            

            using (StreamWriter writer = new StreamWriter(writeFile, true))
            {
                writer.WriteLine(appendText);
            }
        }
        //to load recent file
        public string[] loadRecent()
        {
            try
            {
                String recent;

                string recentFilePath = fileDirectory + "\\recent.txt";


                StreamReader sr = new StreamReader(recentFilePath);
				//Creating sr which is of type StreamReader 

                //Read the first line of text
                recent = sr.ReadToEnd();

                sr.Close();

                string[] recentList = recent.Split(new string[] { System.Environment.NewLine }, System.StringSplitOptions.RemoveEmptyEntries);
				//Array recentList is assigned the recent.Split() to get the values of the file names
                return recentList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                string[] empty = { };
                return empty;
            }
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
			//Calling the g.Clear to clear the image
        }

        private void panelForeColor_MouseClick(object sender, MouseEventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            // See if user pressed ok.
            if (result == DialogResult.OK)
            {
                // Set form background to the selected color.
                panelForeColor.BackColor = colorDialog1.Color;
                panelForeColor.BringToFront();
            }
        }

        private void panelBackColor_MouseClick(object sender, MouseEventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            // See if user pressed ok.
            if (result == DialogResult.OK)
            {
                // Set form background to the selected color.
                panelBackColor.BackColor = colorDialog1.Color;
                panel1.BackColor = colorDialog1.Color;
                panelBackColor.BringToFront();
            }
        }
        //function to erase color
        private void eraseColor_Click(object sender, EventArgs e)
        {
        }
        //function to declare a straight line tool box
        private void straightLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (straightLineToolStripMenuItem.Checked == true)
            {
                straightLineToolStripMenuItem.Checked = false;
            }
            else
            {
                straightLineToolStripMenuItem.Checked = true;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {

            pencil.Color = panelForeColor.BackColor;
			//Taking the pencil.Color to panelForeColor.BackColor
            current = e.Location;
			//Taking the current point as the location of the point the mouse is up

            if (straightLineToolStripMenuItem.Checked == true)
            {
                g.DrawLine(pencil, old.X, old.Y, current.X, current.Y);
				//Using the g.DrawLine to draw the line based on the points
                undoRedoList.Add(new KeyValuePair<Point, Point>(old, current));
				//Add the new KeyValuePair<Point,Point>(old,current) to the undoRedoList
            }
            Editlist.Add(undoRedoList);
			//Adding the undoRedoList to the EditList
        }

    

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newBitmap = new Bitmap(panel1.Width, panel1.Height, PixelFormat.Format32bppArgb);
            //Initializing the newBitmap
			
            g = Graphics.FromImage(newBitmap);
			//Calling the Graphics.FromImage(newBitmap)

            g.CopyFromScreen(PointToScreen(panel1.Location), new Point(-5, -25), new Size(panel1.Width, panel1.Height + 25));
			//Calling the CopyFromScreen to get the image

            saveFileDialog1.Filter = "PNG(*.PNG)|*.png";
			//saveFileDialog1 filter set as "PNG(*.PNG)|*.png"

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
				//Checking if the saveFileDialog1l is selected as OK

                using (Bitmap bmp = new Bitmap(panel1.Width, panel1.Height))
                {
                    newBitmap.Save(saveFileDialog1.FileName, ImageFormat.Png);
					//Calling the newBitmap.Save() method to save the image
                    fileName = saveFileDialog1.FileName;
                    writeToFile(fileName);
                    MessageBox.Show("File Saved Successfully in location " + fileName);
                }
            }

            g = panel1.CreateGraphics();
        }
        //new tool strip menu with undo and redo functions
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            Editlist.Clear();
            EditRedolist.Clear();
            undoRedoList.Clear();
        }
        //fuction for erasing tools strip
        private void eraseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //intialising tool strip menu3
        private void pxToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            brush.Color = panelBackColor.BackColor;
            brush.Width = 1;
            pxToolStripMenuItem3.Checked = true;
            pxToolStripMenuItem4.Checked = false;
            pxToolStripMenuItem5.Checked = false;
            pxToolStripMenuItem6.Checked = false;
            pxToolStripMenuItem7.Checked = false;
        }
        //intialising tool strip with brush width 4
        private void pxToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            brush.Color = panelBackColor.BackColor;
            brush.Width = 3;
            pxToolStripMenuItem3.Checked = false;
            pxToolStripMenuItem4.Checked = true;
            pxToolStripMenuItem5.Checked = false;
            pxToolStripMenuItem6.Checked = false;
            pxToolStripMenuItem7.Checked = false;
        }
        //intialising tool strip with width 5
        private void pxToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            brush.Color = panelBackColor.BackColor;
            brush.Width = 5;
            //all the items initialised to false
            pxToolStripMenuItem3.Checked = false;
            pxToolStripMenuItem4.Checked = false;
            pxToolStripMenuItem5.Checked = true;
            pxToolStripMenuItem6.Checked = false;
            pxToolStripMenuItem7.Checked = false;
        }
        //intialising tool strip with brush width 7
        private void pxToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            brush.Color = panelBackColor.BackColor;
            brush.Width = 7;
            // all the items initialised to false
            pxToolStripMenuItem3.Checked = false;
            pxToolStripMenuItem4.Checked = false;
            pxToolStripMenuItem5.Checked = false;
            pxToolStripMenuItem6.Checked = true;
            pxToolStripMenuItem7.Checked = false;
        }
        //intialising tool strip with brush width 9
        private void pxToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            brush.Color = panelBackColor.BackColor;
            brush.Width = 9;
            //all the items initialised to false
            pxToolStripMenuItem3.Checked = false;
            pxToolStripMenuItem4.Checked = false;
            pxToolStripMenuItem5.Checked = false;
            pxToolStripMenuItem6.Checked = false;
            pxToolStripMenuItem7.Checked = true;
        }

        private void editUndoItem_Click(object sender, EventArgs e)
        {
            if (Editlist.Count > 0)
            {
				//Checking if the Editlist is greater than 0
                object undoList;
				//Creating undoList of type object
				
                int undoNumber = Editlist.Count - 1;
				//Creating undoNumber which is editList Count-1

                undoList = Editlist[undoNumber];
				//Assigning the undoList as Editlist[undoNumber]

                EditRedolist.Add(undoList);
				//Adding the undoList to the EditRedoList

                Editlist.RemoveAt(undoNumber);
				//Removing from EditList at undoNumber

                IList collection = (IList)undoList;
				//collection of type IList is assigned the value of undoList

                brush.Color = panelBackColor.BackColor;
				//brush.Color assigned the value of panelBackColor.BackColor
				
                pencil.Color = panelBackColor.BackColor;
				//pencil.Color assigned the value of panelBackColor.BackColor

                for (int i = 0; i <= collection.Count - 1; i++)
                {
					//For loop till the collection.Count
					
                    Point newOld = new Point();
                    Point newCur = new Point();
					//Creating new points
					
                    string Values = collection[i].ToString().Replace("{", "").Replace("}", "").Replace("[", "").Replace("]", "").Replace("X=", "").Replace("Y=", "");
					//Values of type string assigned the collection[i].ToString().Replace("{", "").Replace("}", "").Replace("[", "").Replace("]", "").Replace("X=", "").Replace("Y=", "");
					
                    newOld.X = Convert.ToInt32(Values.Split(',')[0]);
                    newOld.Y = Convert.ToInt32(Values.Split(',')[1]);
                    newCur.X = Convert.ToInt32(Values.Split(',')[2]);
                    newCur.Y = Convert.ToInt32(Values.Split(',')[3]);

					
                    
                    if (straightLineToolStripMenuItem.Checked == false)
                    {
						//Checking the if straightLineToolStripMenuItem is checked to false
                        if (pencilMenu.Checked == true)
                        {
							//Checking if the pencilMenu is checked to true
                            g.DrawLine(pencil, newOld, newCur);
							//Calling the g.DrawLine() method to draw the line based on the points
                        }
                        else if (pxToolStripMenuItem3.Checked == true || pxToolStripMenuItem4.Checked == true || pxToolStripMenuItem5.Checked == true || pxToolStripMenuItem6.Checked == true || pxToolStripMenuItem7.Checked == true)
                        {
							//Else if calling the g.DrawLine() method to draw based on the points with the brush
                            g.DrawLine(brush, newOld, newCur);
                        }
                        else
                        {
							//Else calling the g.DrawLine() method to draw based on the points with the brush
                            g.DrawLine(brush, newOld, newCur);
                        }
                    }
                    else
                    {
						//Else calling the g.DrawLine() method to draw based on the points with the pencil
                        g.DrawLine(pencil, newOld.X, newOld.Y, newCur.X, newCur.Y);
                    }
                }
            }
        }

        private void editRedoItem_Click(object sender, EventArgs e)
        {
            if (EditRedolist.Count > 0)
            {
				//Checking if the EditRedoList is greater than zero
                object redoList;
				//Creating a redoList of type object
				
                int redoNumber = EditRedolist.Count - 1;
				//Variable of type int assigned the value of EdtRedolist.Count - 1

                redoList = EditRedolist[redoNumber];
				//redoList assigned the EditRedolist[redoNumber]

                Editlist.Add(redoList);
				//Adding the redoList to the Editlist by calling the Editlist.Add(redoList)

                EditRedolist.RemoveAt(redoNumber);
				//Removing from EditRedoList by calling the EditRedolist.RemoveAt(redoNumber)

                IList collection = (IList)redoList;
				//Collection of type IList is assigned the value redoList

                brush.Color = panelForeColor.BackColor;
				//brush.Color assigned the value panelForeColor.BackColor
				
                pencil.Color = panelForeColor.BackColor;
				//pencil.Color assigned the value panelForeColor.BackColor

                for (int i = 0; i <= collection.Count - 1; i++)
                {
					//For loop till the end of collection.Count
					
                    Point newOld = new Point();
                    Point newCur = new Point();
					//Creating new Points
					
                    string Values = collection[i].ToString().Replace("{", "").Replace("}", "").Replace("[", "").Replace("]", "").Replace("X=", "").Replace("Y=", "");
					//Values of type string assigned collection[i].ToString().Replace("{", "").Replace("}", "").Replace("[", "").Replace("]", "").Replace("X=", "").Replace("Y=", "");
                    newOld.X = Convert.ToInt32(Values.Split(',')[0]);
                    newOld.Y = Convert.ToInt32(Values.Split(',')[1]);
                    newCur.X = Convert.ToInt32(Values.Split(',')[2]);
                    newCur.Y = Convert.ToInt32(Values.Split(',')[3]);

                    
                    if (straightLineToolStripMenuItem.Checked == false)
                    {
						//Checking if the straightLineToolStripMenuItem is checked to false
                        if (pencilMenu.Checked == true)
                        {
							//Checking if the pencilMenu is checked to true
                            g.DrawLine(pencil, newOld, newCur);
							//Calling the g.DrawLine to draw based on the points with pencil
                        }
                        else if (pxToolStripMenuItem3.Checked == true || pxToolStripMenuItem4.Checked == true || pxToolStripMenuItem5.Checked == true || pxToolStripMenuItem6.Checked == true || pxToolStripMenuItem7.Checked == true)
                        {
							//Else if calling the g.DrawLine to draw based on the points with brush
                            g.DrawLine(brush, newOld, newCur);
                        }
                        else
                        {
							//Else calling the g.DrawLine to draw based on the points with brush
                            g.DrawLine(brush, newOld, newCur);
                        }
                    }
                    else
                    {
						//Else calling the g.DrawLine to draw based on the points with pencil
                        g.DrawLine(pencil, newOld.X, newOld.Y, newCur.X, newCur.Y);
                    }
                }
            }
        }

        private void Paint_Click(object sender, EventArgs e)
        {
			//Paint_Click method to get the color selected
            string ctrlName = ((Control)sender).Name;
			//ctrlName of type string which will take the sender name
			
            Color clrColor = Color.FromName(ctrlName);
			//clrColor of type Color is assigned the value Color.FromName(ctrlName)
			
            panelForeColor.BackColor = clrColor;
			//panelForeColor.BackColor assigned the value clrColor

        }
    }

    public static class GraphicsExtensions
    {
		//DrawCirlce and FillCircle methods to draw a point when the mouse is clicked
        public static void DrawCircle(this Graphics g, Pen pen,
                                      float centerX, float centerY, float radius)
        {
			//Calling the g.DrawEllipse to draw an ellipse based on the points
            g.DrawEllipse(pen, centerX - radius, centerY - radius,
                          radius + radius, radius + radius);
        }

        public static void FillCircle(this Graphics g, Brush brush,
                                      float centerX, float centerY, float radius)
        {
			//Calling the g.FillCircle to fill the circle based on the points
            g.FillEllipse(brush, centerX - radius, centerY - radius,
                          radius + radius, radius + radius);
        }
    }
}
