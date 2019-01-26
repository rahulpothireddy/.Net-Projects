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
    public partial class LineChart : Form
    {
        public LineChart()
        {
            InitializeComponent();
            chart3.Visible = true; /*about chart 3 making true*/
        }

        private void LineChart_Load(object sender, EventArgs e)
        {
            String line = ""; /*intialising line*/
            using (StreamReader streamReader = new StreamReader(Directory.GetCurrentDirectory() + "\\input1.txt"))
            {
                while ((line = streamReader.ReadLine()) != null) /*until line is null*/
                {
                    String[] splitString = line.Split(',');
                    foreach (var s in splitString) /*for each var in string*/
                    {
                        chart3.Series["Students"].Points.AddY(s); /*student data points*/
                        /*title names, grid checks and line width are declared*/
                        chart3.ChartAreas[0].AxisX.Title = "2016-2017";
                        chart3.ChartAreas[0].AxisX.Title = "Student Population";
                        chart3.ChartAreas[0].AxisY.Title = "In Thousands";
                        chart3.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
                        chart3.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                        chart3.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
                        chart3.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                        chart3.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
                    }
                }
            }
            String line1 = " ";
            using (StreamReader streamReader1 = new StreamReader(Directory.GetCurrentDirectory() + "\\input5.txt"))
            {
                /*reads data from the input file*/
                while ((line1 = streamReader1.ReadLine()) != null)/*loops until line is not null*/
                {
                    String[] splitString = line1.Split(',');
                    foreach (var s in splitString) /*for  every variable in string*/
                    {
                        chart3.Series["Families"].Points.AddY(s); /*family data value points*/
                        /*title names and all the grid checks are declared*/
                        chart3.ChartAreas[0].AxisX.Title = "2016-2017";
                        chart3.ChartAreas[0].AxisX.Title = "Student Population";
                        chart3.ChartAreas[0].AxisY.Title = "In Thousands";
                        chart3.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
                        chart3.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                        chart3.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
                        chart3.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                        chart3.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
                    }
                }
            }


            String line2 = " ";/*line 2 is declared*/
            using (StreamReader streamReader1 = new StreamReader(Directory.GetCurrentDirectory() + "\\input6.txt"))
            {
                while ((line2 = streamReader1.ReadLine()) != null) /*until line 2 is not equal to null*/
                {
                    String[] splitString = line2.Split(',');
                    foreach (var s in splitString) /*for every varible in string*/
                    {
                        chart3.Series["Pets"].Points.AddY(s);/*Pets data value points*/
                        /*title names and all the grid checks are declared*/
                        chart3.ChartAreas[0].AxisX.Title = "2016-2017";
                        chart3.ChartAreas[0].AxisX.Title = "Student Population";
                        chart3.ChartAreas[0].AxisY.Title = "In Thousands";
                        chart3.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
                        chart3.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                        chart3.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
                        chart3.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                        chart3.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
                    }
                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}