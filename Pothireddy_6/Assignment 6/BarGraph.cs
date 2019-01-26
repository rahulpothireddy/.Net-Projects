/********************************************************************
 * Name : Harshith Desamsetti (z1829024),
 *        Rahul Pothireddy (z1829984)
 *        
 * Section : CSCI 504
 * Purpose:  The purpose of this program is to design a 
 *           window which has four buttons which when clicked dispalys
 *           different graphs
 * ******************************************************************/
 /*importing packages and functions which are required*/
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

namespace Assignment_6
{
    public partial class BarGraph : Form  /*bar graph*/
    {
        public BarGraph()
        {
            InitializeComponent(); /*intialise component*/
        }

        private void BarGraphLoad(object sender, EventArgs e)
        {

            
            String line = "";
            using(StreamReader streamReader = new StreamReader(Directory.GetCurrentDirectory() + "\\input1.txt"))
            {
                while ((line = streamReader.ReadLine()) != null) /*until not equal to null*/
                {
                    String[] splitString = line.Split(','); /*split stirng*/
                    foreach (var s in splitString) /*until all the varibles in the string*/
                    {
            
                        chart1.Series["Computer Science"].Points.AddY(s);/*data points in cs*/                   
                    }
                }
            }


            String line1 = "";
            using (StreamReader streamReader = new StreamReader(Directory.GetCurrentDirectory() + "\\input5.txt"))
            {
                while ((line1 = streamReader.ReadLine()) != null)
                {
                    String[] splitString = line1.Split(',');
                    foreach (var s in splitString) /*reads every variable in splitstring*/
                    {

                        chart1.Series["Mechanical"].Points.AddY(s); /*mechanical data points*/
                    }
                }
            }



            String line2 = ""; /*for line 2*/
            using (StreamReader streamReader = new StreamReader(Directory.GetCurrentDirectory() + "\\input6.txt"))
            {
                while ((line2 = streamReader.ReadLine()) != null)/*until it is null*/
                {
                    String[] splitString = line2.Split(',');
                    foreach (var s in splitString)
                    {

                        chart1.Series["Electrical"].Points.AddY(s);/*mechanical data points*/
                    }
                }
            }





            /*chartareas for all the branches*/
                chart1.Series["Computer Science"].ChartArea = "ChartArea1";
                chart1.Series["Electrical"].ChartArea = "ChartArea1";                
                chart1.Series["Mechanical"].ChartArea = "ChartArea1";
               /*titles of x and y axis and grids with line width made 0*/ 
                chart1.ChartAreas[0].AxisX.Title = "2016-2017";
                chart1.ChartAreas[0].AxisX.Title = "Student Population";
                chart1.ChartAreas[0].AxisY.Title = "In Thousands";
                chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
                chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
                chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose(); /*to close the window , dispose and close are used*/
            this.Close();
        }
    }
    
}
