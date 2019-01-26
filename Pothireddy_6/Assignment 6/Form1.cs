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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace Assignment_6
{
    public partial class Form1 : Form
    {
        public Form1() /*form1 intialising component*/
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BarGraph chart1 = new BarGraph(); /*new bar graph*/
            chart1.ShowDialog(); /*dialog */
        }

        private void button2_Click(object sender, EventArgs e)
        {            
            PieChart c2 = new PieChart(); /*pie chart */
            c2.ShowDialog();  /*dialog*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LineChart c3 = new LineChart(); /*for line chart popup*/
            c3.ShowDialog(); /*dialog*/
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AreaChart c4 = new AreaChart(); /*new area chart */
            c4.ShowDialog(); /*dialog for area chart*/
        }
    }
}
