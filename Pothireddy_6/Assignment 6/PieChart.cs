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

namespace Assignment_6 /*class declaration*/
{
    public partial class PieChart : Form
    {
        public PieChart() /*pie chart function*/
        {
            InitializeComponent();
            chart2.Visible = true; /*intialising the component and making the chart visible true*/
        }

        private void PieChartLoad(object sender, EventArgs e)
        {
            String line = "";
            using (StreamReader streamReader = new StreamReader(Directory.GetCurrentDirectory() + "\\input2.txt"))
            {
                //while ((line = streamReader.ReadLine()) != null)
                //{
                line = streamReader.ReadLine();
                    String[] splitString = line.Split(',');
                         /*area for each brach's data valuees*/
                        chart2.Series["s1"].Points.AddXY("Computer Science", Convert.ToInt32(splitString[0]));
                        chart2.Series["s1"].Points.AddXY("Electrical", Convert.ToInt32(splitString[1]));
                        chart2.Series["s1"].Points.AddXY("Mechanical", Convert.ToInt32(splitString[2]));
                        chart2.Series["s1"].Points.AddXY("Nursing", Convert.ToInt32(splitString[3]));
                    
                //}
                chart2.Titles.Add("Pie Chart to Display Student Population"); /*title of the pie chart*/
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose(); /*dispose and close to end when entered exit*/
            this.Close();
        }
    }
}