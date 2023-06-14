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
using System.Text;
using System.Windows.Forms;

namespace landmark_realty
{
    public partial class actionMenu : Form
    {
        string databaseLocation;
        public actionMenu(string databaseLocation1)
        {
            InitializeComponent();
            databaseLocation = databaseLocation1;
        }

        //MOVE TO VIEW RECORDS FORM
        private void btnViewRecords_Click(object sender, EventArgs e)
        {
            this.Hide();
            viewRecords form = new viewRecords(databaseLocation);
            form.ShowDialog();
            this.Close();
        }

        //MOVE TO ADD NEW RECORDS FORM
        private void btnAddNewRecords_Click(object sender, EventArgs e)
        {
            this.Hide();
            addRecord form = new addRecord(databaseLocation);
            form.ShowDialog();
            this.Close();
        }

        //MOVE BACK TO LAUNCHER FORM
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.ShowDialog();
            this.Close();
        }
    }
}
