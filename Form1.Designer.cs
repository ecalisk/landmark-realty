
namespace landmark_realty
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnDefaultDatabase = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.logo = new System.Windows.Forms.PictureBox();
            this.labelCredit = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDefaultDatabase
            // 
            this.btnDefaultDatabase.BackColor = System.Drawing.Color.Transparent;
            this.btnDefaultDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDefaultDatabase.Font = new System.Drawing.Font("Big John PRO", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDefaultDatabase.ForeColor = System.Drawing.Color.Black;
            this.btnDefaultDatabase.Location = new System.Drawing.Point(434, 147);
            this.btnDefaultDatabase.Name = "btnDefaultDatabase";
            this.btnDefaultDatabase.Size = new System.Drawing.Size(109, 58);
            this.btnDefaultDatabase.TabIndex = 1;
            this.btnDefaultDatabase.Text = "launch";
            this.btnDefaultDatabase.UseVisualStyleBackColor = false;
            this.btnDefaultDatabase.Click += new System.EventHandler(this.btnDefaultDatabase_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Big John PRO", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(434, 211);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(109, 58);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // logo
            // 
            this.logo.BackColor = System.Drawing.Color.Transparent;
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.Location = new System.Drawing.Point(58, 12);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(282, 66);
            this.logo.TabIndex = 3;
            this.logo.TabStop = false;
            // 
            // labelCredit
            // 
            this.labelCredit.AutoSize = true;
            this.labelCredit.BackColor = System.Drawing.Color.Transparent;
            this.labelCredit.Font = new System.Drawing.Font("BankGothic Lt BT", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCredit.Location = new System.Drawing.Point(58, 382);
            this.labelCredit.Name = "labelCredit";
            this.labelCredit.Size = new System.Drawing.Size(475, 25);
            this.labelCredit.TabIndex = 4;
            this.labelCredit.Text = "developed by noble rubber duckies";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 84);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(377, 247);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(584, 411);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelCredit);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDefaultDatabase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LRG Property Management System";
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDefaultDatabase;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.Label labelCredit;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

