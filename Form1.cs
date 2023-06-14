/* - - - - * 
 May 2021, OOP Project 5
 * - - - - *
 Team: noble rubber duckies
 * - - - - * 
 Members:
 Emirhan Caliskan (56140)
 Nattawat Srisuriyaprateep (55499)
 * - - - - *
 Property management system for real estate agency - Landmark Realty Group.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace landmark_realty
{
    public partial class Form1 : Form
    {
        string databaseLocation;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDefaultDatabase_Click(object sender, EventArgs e)
        {
            databaseLocation = @".\databases\defaultDatabase.txt";
            if (!File.Exists(databaseLocation))
            {
                File.Create(databaseLocation).Close();
            }
            
            this.Hide();
            actionMenu menu = new actionMenu(databaseLocation);
            menu.ShowDialog();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
