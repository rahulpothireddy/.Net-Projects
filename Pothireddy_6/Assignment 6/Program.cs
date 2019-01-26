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
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_6
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() /*main functions*/
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
