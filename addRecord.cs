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
using System.Linq;
using System.IO;
using System.Windows.Forms;


namespace landmark_realty
{
    public partial class addRecord : Form
    {
        List<string> features = new List<string>();
        List<string> images = new List<string>();

        string featuresFileLocation;
        string databaseLocation;
        int imageIndex = 0;
        int currentImageIndex = 0;


        private readonly Random _random = new Random();

        public addRecord(string databaseLocation1)
        {
            InitializeComponent();
            databaseLocation = databaseLocation1;
        }

        //ON FORM LOAD
        private void addRecord_Load(object sender, EventArgs e)
        {
            clearAllFields();
            btnPreviousPhoto.Enabled = false;
            btnNextPhoto.Enabled = false;
        }

        //ADD INSERTED DATA TO FILE
        private void btnAdd_Click(object sender, EventArgs e) 
        {
            //add all boxes to database
            if (addPropertyDetails()) 
            {
                addOwnerDetails();

                addAgentDetails();

                //add checked features to database
                File.WriteAllLines(featuresFileLocation, features);

                //notify successfull add
                MessageBox.Show("Property has been successfully added to records!", "SUCCESS: Record added", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //reset form
                clearAllFields();
                lockButtons();

                btnNextPhoto.Enabled = false; btnPreviousPhoto.Enabled = false;
            }
        }

        //HANDLE PROPERTY DETAILS INPUT
        bool addPropertyDetails() 
        {
            bool formatCheck = int.TryParse(textBoxSize.Text, out _) && int.TryParse(textBoxRooms.Text, out _) && int.TryParse(textBoxBathrooms.Text, out _) && int.TryParse(textBoxFloor.Text, out _) && int.TryParse(textBoxPrice.Text, out _);
            bool isEmpty = textBoxAddress.Text != "";
            if (formatCheck && isEmpty)
            {
                property newProperty = new property(textBoxID.Text, Int32.Parse(textBoxSize.Text), Int32.Parse(textBoxRooms.Text), Int32.Parse(textBoxBathrooms.Text), textBoxAddress.Text, Int32.Parse(textBoxFloor.Text), comboBoxType.SelectedItem.ToString(), comboBoxStatus.SelectedItem.ToString(), Int32.Parse(textBoxPrice.Text));

                List<string> allLines = File.ReadAllLines(databaseLocation).ToList();

                allLines.InsertRange(allLines.Count, new List<string>
                {"***START OF RECORD***", newProperty.ID, newProperty.size.ToString(), newProperty.rooms.ToString(), newProperty.bathrooms.ToString(), newProperty.address, newProperty.floor.ToString(), newProperty.type, newProperty.status, newProperty.price.ToString()});

                File.WriteAllLines(databaseLocation, allLines);

                return true;
            }
            else 
            {
                MessageBox.Show("All property fields must be filled. Only use integers for all fields except the address", "ERROR: Property Information Invalid Input Detected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //HANDLE OWNER DETAILS INPUT
        void addOwnerDetails() 
        {
            owner newOwner = new owner(ownerName.Text, ownerBirthday.Text, ownerPhoneNumber.Text, ownerEmail.Text, ownerAddress.Text);

            List<string> allLines = File.ReadAllLines(databaseLocation).ToList();

            allLines.InsertRange(allLines.Count, new List<string>
            {"***OWNER DETAILS***", newOwner.fullName, newOwner.birthDay, newOwner.phoneNumber, newOwner.emailAddress, newOwner.address});

            File.WriteAllLines(databaseLocation, allLines);
        }

        //HANDLE AGENT DETAILS INPUT
        void addAgentDetails() 
        {
            agent newAgent = new agent(agentName.Text, agentBirthday.Text, agentPhoneNumber.Text, agentEmail.Text, agentAddress.Text, agentID.Text);

            List<string> allLines = File.ReadAllLines(databaseLocation).ToList();

            allLines.InsertRange(allLines.Count, new List<string>
            {"***AGENT DETAILS***", newAgent.fullName, newAgent.birthDay, newAgent.phoneNumber, newAgent.emailAddress, newAgent.address, newAgent.agentID});

            File.WriteAllLines(databaseLocation, allLines);
        }

        //WHAT HAPPENS WHEN A FEATURE CHECK BOX IS CHECKED/UNCHECKED
        private void checkBoxes_CheckStateChanged(object sender, EventArgs e)
        {
            CheckBox feature = (CheckBox)sender;

            if(feature.Checked == false) 
            { 
                features.Remove(feature.Text);
            }
            else 
            {
                features.InsertRange(features.Count, new List<string> { feature.Text });
            }
        }

        //FNC TO CLEAR ALL INPUT FIELDS
        void clearAllFields() 
        {
            foreach (var box in groupBox1.Controls.OfType<TextBox>()) { box.Text = ""; }
            foreach (var box in groupBox2.Controls.OfType<TextBox>()) { box.Text = ""; }
            foreach (var box in groupBox3.Controls.OfType<TextBox>()) { box.Text = ""; }

            foreach (var combo in groupBox1.Controls.OfType<ComboBox>()) { combo.SelectedItem = "Unspecified"; }
            textBoxID.Text = generateID();
            
            pictureBox1.Image = landmark_realty.Properties.Resources.no_image_available;
            lockButtons();
            images.Clear();
            imageIndex = 0;
            currentImageIndex = 0;

            btnNextPhoto.Enabled = false; btnPreviousPhoto.Enabled = false;

            featuresFileLocation = @".\databases\features\" + textBoxID.Text + "_features.txt";
            foreach (var checkbox in groupBox1.Controls.OfType<CheckBox>()) { checkbox.Checked = false; }
        }

        //GENERATE ID        
        string generateID() 
        {
            while (true)
            {
                int digits = _random.Next(100, 9999);
                char character = Convert.ToChar(_random.Next(65, 91));
                string generatedId = character + "-" + digits.ToString();
                if (checkIdExistence(generatedId)) 
                {
                    return generatedId;
                }
            }
        }

        //CHECK ID EXISTENCE (ID SHOULD BE UNIQUE)
        bool checkIdExistence(string id) 
        {
            List<string> allData = File.ReadAllLines(databaseLocation).ToList();
            int i = 0;
            while (i < allData.Count())
            {
                if (allData[i] == id)
                {
                    if ((i - 1) % 23 == 0)
                    {
                        return false;
                    }
                }
                i++;
            }
            return true;
        }
        
        //CLEAR BUTTON
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAllFields();
        }

        //MOVE BACK TO ACTION MENU FORM
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            actionMenu menu = new actionMenu(databaseLocation);
            menu.ShowDialog();
            this.Close();
        }

        //UPLOAD A PICTURE
        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                //pictureIndex = Int32.Parse(File.ReadLines(@".\imgIndex.txt").First());
                //pictureBox1.Image = new Bitmap(opnfd.FileName);
                //COPY UPLOADED IMAGE WITH INDEXED NAMES
                
                string imageLocation = @".\images\" + textBoxID.Text + "_" + imageIndex.ToString() + ".jpg";
                System.IO.File.Copy(opnfd.FileName, imageLocation);
                images.InsertRange(images.Count, new List<string> { imageLocation });
                currentImageIndex = imageIndex;
                pictureBox1.ImageLocation = images[currentImageIndex];
                imageIndex++;
                lockButtons();
            }
        }

        //NEXT PHOTO
        private void btnNextPhoto_Click(object sender, EventArgs e)
        {
            currentImageIndex++;
            pictureBox1.ImageLocation = images[currentImageIndex];
            lockButtons();
        }

        //PREVIOUS PHOTO
        private void btnPreviousPhoto_Click(object sender, EventArgs e)
        {
            currentImageIndex--;
            pictureBox1.ImageLocation = images[currentImageIndex];
            lockButtons();
        }

        //WHEN TO DISABLE NEXT/PREVIOUS PICTURE BUTTONS
        void lockButtons() 
        {
            if (currentImageIndex == 0) 
            {
                btnPreviousPhoto.Enabled = false;
            }
            else 
            {
                btnPreviousPhoto.Enabled = true;
            }

            if (currentImageIndex == (images.Count-1))
            {
                btnNextPhoto.Enabled = false;
            }
            else
            {
                btnNextPhoto.Enabled = true;
            }

        }
    }
}
