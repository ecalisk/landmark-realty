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
using System.IO;
using System.Linq;

namespace landmark_realty
{
    public partial class viewRecords : Form
    {
        //RESERVED FOR GENERAL USE
        string databaseLocation; //DB LOCATION, AT ANY GIVEN TIME IT CAN POINT OUT EITHER TO DEFAULT FILE OR SEARCH RESULTS
        string searchResults; //DB LOCATION SEARCH RESULTS
        int recordIndex = 0; //INDEX OF THE CURRENTLY DISPLAYED RECORD
        int howManyRecords; //LIST SIZE OF ALL READ RECORDS
        int pictureIndex = 0; //INDEX OF CURRENTLY DISPLAYED PICTURE THAT BELONGS TO THE CURRENT RECORD
        int howManyPictures; //LIST SIZE OF ALL FETCHED PICTURES OF THE CURRENT RECORD
        
        //RESERVED FOR SEARCHING FEATURE
        List<int> matches = new List<int>(); //STORE AS INDEX WHICH RECORDS MATCH THE FILTER
        List<string> matchesFull = new List<string>(); //STORE AS FULL TEXT WHICH RECORDS MATCH THE FILTER
        List<string> allData = new List<string>(); //COPY OF UNFILTERED DATA RETRIEVED FROM DATABASE

        public viewRecords(string databaseLocation1)
        {
            InitializeComponent();
            databaseLocation = databaseLocation1;
        }

        //ON LOAD
        private void viewRecords_Load(object sender, EventArgs e)
        {
            howManyRecords = Class1.findHowManyRecords(databaseLocation);
            //NO RECORDS
            if (howManyRecords==0) 
            {
                MessageBox.Show("No records found!", "ERROR: Empty data base", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnNextPhoto.Enabled = false; btnPreviousPhoto.Enabled = false;
                btnNext.Enabled = false; btnPrevious.Enabled = false; btnDelete.Enabled = false;
                btnClear.Enabled = false; btnSearch.Enabled = false; btnShowAll.Enabled = false;
                labelImageIndex.Visible = false;
                labelRecordIndex.Text = "No records found!"; labelRecordIndex.ForeColor = Color.Red;
            }
            //SOME RECORDS AVAILABLE
            else 
            {
                readRecord();
                lockPictureButtons();
                lockButtons();
                labelRecordIndex.Text = "Record " + (recordIndex + 1).ToString() + " out of " + howManyRecords.ToString();
            }
        }

        //READ RECORDS FROM FILE AND DISPLAY ON APPROPRIATE FIELD
        void readRecord() 
        {
            List<string> allLines = File.ReadAllLines(databaseLocation).ToList();
            textBoxID.Text = allLines[recordIndex*23+1];
            textBoxSize.Text = allLines[recordIndex * 23 + 2];
            textBoxRooms.Text = allLines[recordIndex * 23 + 3];
            textBoxBathrooms.Text = allLines[recordIndex * 23 + 4];
            textBoxAddress.Text = allLines[recordIndex * 23 + 5];
            textBoxFloor.Text = allLines[recordIndex * 23 + 6];
            textBoxType.Text = allLines[recordIndex * 23 + 7];
            textBoxStatus.Text = allLines[recordIndex * 23 + 8];
            textBoxPrice.Text = allLines[recordIndex * 23 + 9];

            ownerName.Text = allLines[recordIndex * 23 + 11];
            ownerBirthday.Text = allLines[recordIndex * 23 + 12];
            ownerPhoneNumber.Text = allLines[recordIndex * 23 + 13];
            ownerEmail.Text = allLines[recordIndex * 23 + 14];
            ownerAddress.Text = allLines[recordIndex * 23 + 15];

            agentName.Text = allLines[recordIndex * 23 + 17];
            agentBirthday.Text = allLines[recordIndex * 23 + 18];
            agentPhoneNumber.Text = allLines[recordIndex * 23 + 19];
            agentEmail.Text = allLines[recordIndex * 23 + 20];
            agentAddress.Text = allLines[recordIndex * 23 + 21];
            agentID.Text = allLines[recordIndex * 23 + 22];

            //FETCH FEATURES OF THE CURRENTLY READ RECORD
            string featuresLocation = @".\databases\features\" + textBoxID.Text + "_features.txt"; 
            List<string> features = File.ReadAllLines(featuresLocation).ToList();
            listBoxFeatures.DataSource = features;
            fetchPictures();
        }

        //FETCH PICTURES OF THE CURRENTLY DISPLAYED RECORD
        void fetchPictures() 
        {
            List<string> pictures = Directory.GetFiles(@".\images\", textBoxID.Text+"*.jpg", SearchOption.AllDirectories).ToList();
            //NO PICTURES ASSOSICIATED TO THE CURRENT RECORD
            if (!pictures.Any()) 
            {
                pictureBox1.Image = landmark_realty.Properties.Resources.no_image_available;
                howManyPictures = 0;
                btnPreviousPhoto.Enabled = false; btnNextPhoto.Enabled = false;
                labelImageIndex.Visible = false; 
            }
            //SOME PICTURES FOUND ASSOCIATED TO THE CURRENT RECORD
            else 
            {
                howManyPictures = pictures.Count();
                lockPictureButtons();
                labelImageIndex.Visible = true;

                if (pictureIndex<howManyPictures && pictureIndex>=0) 
                {
                    pictureBox1.ImageLocation = pictures[pictureIndex];
                }
                
                labelImageIndex.Text = "Image " + (pictureIndex + 1).ToString() + " out of " + howManyPictures.ToString();
            }
        }

        //DELETE COMPLETELY THE CURRENTLY DISPLAYED RECORD
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //REMOVE LINES ASSOCIATED TO THIS RECORD FROM THE DATABASE
            List<string> allLines = File.ReadAllLines(databaseLocation).ToList();
            allLines.RemoveRange(recordIndex * 23, 23);
            File.WriteAllLines(databaseLocation, allLines);
            
            //DELETE SAVED FEATURES FILE
            string featuresLocation = @".\databases\features\" + textBoxID.Text + "_features.txt";
            File.Delete(featuresLocation);
            
            //DELETE SAVED PICTURES
            List<string> pictures = Directory.GetFiles(@".\images\", textBoxID.Text + "*.jpg", SearchOption.AllDirectories).ToList();
            for (int i = 0; i < pictures.Count(); i++) 
            {
                File.Delete(pictures[i]);
            }

            refreshPage();
        }

        //NEXT PHOTO BUTTON ACTION
        private void btnNextPhoto_Click(object sender, EventArgs e)
        {
            pictureIndex++;
            lockPictureButtons();
            fetchPictures();
        }

        //PREVIOUS PHOTO BUTTON ACTION
        private void btnPreviousPhoto_Click(object sender, EventArgs e)
        {
            pictureIndex--;
            lockPictureButtons();
            fetchPictures();
        }

        //DECISION MECHANISM: WHEN TO LOCK PREVIOUS/NEXT PICTURE BUTTONS
        void lockPictureButtons()
        {
            if (pictureIndex == 0)
            {
                btnPreviousPhoto.Enabled = false;
            }
            else
            {
                btnPreviousPhoto.Enabled = true;
            }

            if (pictureIndex + 1 == howManyPictures)
            {
                btnNextPhoto.Enabled = false;
            }
            else
            {
                btnNextPhoto.Enabled = true;
            }
        }

        //NEXT RECORD BUTTON
        private void btnNext_Click(object sender, EventArgs e)
        {
            pictureIndex = 0;
            recordIndex++;
            readRecord();
            lockButtons();
            labelRecordIndex.Text = "Record " + (recordIndex + 1).ToString() + " out of " + howManyRecords.ToString();
        }

        //PREVIOUS RECORD BUTTON
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            pictureIndex = 0;
            recordIndex--;
            readRecord();
            lockButtons();
            labelRecordIndex.Text = "Record " + (recordIndex + 1).ToString() + " out of " + howManyRecords.ToString();
        }

        //DECISION MECHANISM: WHEN TO LOCK PREVIOUS/NEXT RECORD BUTTONS
        void lockButtons()
        {
            if (recordIndex == 0)
            {
                btnPrevious.Enabled = false;
            }
            else
            {
                btnPrevious.Enabled = true;
            }

            if (recordIndex + 1 == howManyRecords)
            {
                btnNext.Enabled = false;
            }
            else
            {
                btnNext.Enabled = true;
            }

        }

        //MOVE BACK TO ACTION MENU FORM
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            actionMenu form = new actionMenu(databaseLocation);
            form.ShowDialog();
            this.Close();
        }

        //SEARCH BUTTON ACTION
        private void btnSearch_Click(object sender, EventArgs e)
        {
            databaseLocation = @".\databases\defaultDatabase.txt";
            allData = File.ReadAllLines(databaseLocation).ToList();
            //ID FILTERED SEARCH REQUEST
            if (radioButton2.Checked && textBoxSearchID.Text != "")
            {
                int i = 0;
                //ITERATE ALL DATA
                while (i < allData.Count())
                {
                    //IF ITERATED LINE MATCHES ID SEARCH REQUEST...
                    if (allData[i] == (textBoxSearchID.Text).ToUpper())
                    {
                        //IF MATCHED RESULT IS FROM ID FIELD
                        if ((i - 1) % 23 == 0)
                        {
                            //ADD INDEX OF THIS RECORD
                            matches.Add((i - 1) / 23);
                        }
                    }
                    i++;
                }
                //IF ANY MATHCES ARE FOUND..
                if (matches.Any())
                {
                    //ITERATE MATCHED RECORD INDEX
                    for (int j = 0; j < matches.Count(); j++)
                    {
                        //REGISTER THE 23 LINES THAT CORRENSPOND TO THAT INDEX
                        for (int k = matches[j] * 23; k <= ((matches[j] + 1) * 23) - 1; k++)
                        {
                            //ADD THOSE LINES TO A LIST
                            matchesFull.Add(allData[k]);
                        }
                    }
                    //ADD LIST TO FILE, PASS FILE LOCATION TO FORM, REFRESH THE FORM
                    searchResults = @".\databases\searchResults.txt";
                    File.WriteAllLines(searchResults, matchesFull);
                    databaseLocation = searchResults;
                    refreshPage();
                }
                //MATCHED RECORD INDEXES EMPTY
                else
                {
                    MessageBox.Show("No results were found!", "No match", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            //STATUS FILTERED SEARCH REQUEST
            else if (radioButton1.Checked && comboBoxStatus.Text != "")
            {
                int i = 0;
                //ITERATE ALL DATA
                while (i < allData.Count())
                {
                    //IF ITERATED LINE MATCHES ID SEARCH REQUEST...
                    if (allData[i] == comboBoxStatus.Text)
                    {
                        //IF MATCHED RESULT IS FROM STATUS FIELD
                        if ((i - 8) % 23 == 0)
                        {
                            //ADD INDEX OF THIS RECORD
                            matches.Add((i - 8) / 23);
                        }
                    }
                    i++;
                }
                //IF ANY MATHCES ARE FOUND..
                if (matches.Any())
                {
                    //ITERATE MATCHED RECORD INDEX
                    for (int j = 0; j < matches.Count(); j++) 
                    {
                        //REGISTER THE 23 LINES THAT CORRENSPOND TO THAT INDEX
                        for (int k = matches[j] * 23; k <= ((matches[j] + 1) * 23) - 1; k++) 
                        {
                            //ADD THOSE LINES TO A LIST
                            matchesFull.Add(allData[k]);
                        }
                    }
                    //ADD LIST TO FILE, PASS FILE LOCATION TO FORM, REFRESH THE FORM
                    searchResults = @".\databases\searchResults.txt";
                    File.WriteAllLines(searchResults, matchesFull);
                    databaseLocation = searchResults;
                    refreshPage();
                }
                //MATCHED RECORD INDEXES EMPTY
                else
                {
                    MessageBox.Show("No results were found!!", "No match", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            //RADIO BUTTON NOT CHOSEN OR INPUT IS NOT PROVIDED
            else
            {
                MessageBox.Show("Please choose a filter and enter/choose a value", "ERROR: Invalid Search Attempt", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //RELAUCH THE FORM
        void refreshPage() 
        {
            this.Hide();
            viewRecords form = new viewRecords(databaseLocation);
            form.ShowDialog();
            this.Close();
        }

        //DISABLE ONE RADIO BUTTON WHEN ANOTHER IS CHECKED
        void detectFilterChoice()
        {
            if (radioButton1.Checked == false)
            {
                comboBoxStatus.Enabled = false;
                textBoxSearchID.Enabled = true;
            }
            else
            {
                comboBoxStatus.Enabled = true;
                textBoxSearchID.Enabled = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            detectFilterChoice();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            detectFilterChoice();
        }

        //REMOVE FILTERED SEARCH AND SHOW ALL RECORDS
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            databaseLocation = @".\databases\defaultDatabase.txt";
            refreshPage();
        }
    }
}
