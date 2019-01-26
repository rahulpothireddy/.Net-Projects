/********************************************************************
 * Name : Harshith Desamsetti (z1829024),
 *        Rahul Pothireddy (z1829984)
 *        
 * Section : CSCI 504
 * Purpose:  The purpose of this program is to design a 
 *           window which has four buttons which when clicked dispalys
 *           different graphs
 * ******************************************************************/
/*importing the required packages and functions*/
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

namespace Assignment_6 /*using a namespace-class*/
{
    public partial class AreaChart : Form
    {
        public AreaChart()  /*area of a chart */
        {
            InitializeComponent(); /*initialise component*/
            chart4.Visible = true; /*making it true*/
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();  /*dispose and close*/
            this.Close();
        }

        private void AreaChart_Load(object sender, EventArgs e)
        {
            chart4.Visible = true; 

            String line = "";
            using (StreamReader streamReader = new StreamReader(Directory.GetCurrentDirectory() + "\\input5.txt"))
            {
                while ((line = streamReader.ReadLine()) != null) /*until the contents in the null are over*/
                {
                    String[] splitString = line.Split(','); /*splitng the line data*/
                    foreach (var s in splitString)
                    {

                        chart4.Series["Computer Science"].Points.AddY(s); /*for computer science branch data points*/

                    }
                }
            }


            String line1 = "";
            using (StreamReader streamReader = new StreamReader(Directory.GetCurrentDirectory() + "\\input6.txt"))
            {
                while ((line1 = streamReader.ReadLine()) != null)
                {
                    String[] splitString = line1.Split(',');
                    foreach (var s in splitString) /*for every variable in string */
                    {
                        chart4.Series["Electrical"].Points.AddY(s); /*electrical engineering data points*/
                    }
                }
            }

            String line2 = "";
            using (StreamReader streamReader = new StreamReader(Directory.GetCurrentDirectory() + "\\input7.txt"))
            {
                while ((line2 = streamReader.ReadLine()) != null) /*reads until the data value is null*/
                {
                    String[] splitString = line2.Split(',');
                    foreach (var s in splitString)/*for every variable in string */
                    {
                        chart4.Series["Mechanical"].Points.AddY(s); /*Mechanical data points*/
                    }
                }
            }

            /*title of x and y axis, line width and grids checks are intialised*/
            chart4.ChartAreas[0].AxisX.Title = "2016-2017";
            chart4.ChartAreas[0].AxisX.Title = "Student Population";
            chart4.ChartAreas[0].AxisY.Title = "In Thousands";
            chart4.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart4.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart4.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            chart4.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart4.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

        }
    }
}