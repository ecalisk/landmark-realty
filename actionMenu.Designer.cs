
namespace landmark_realty
{
    partial class actionMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(actionMenu));
            this.btnAddNewRecords = new System.Windows.Forms.Button();
            this.btnViewRecords = new System.Windows.Forms.Button();
            this.labelLoadNotify = new System.Windows.Forms.Label();
            this.logo = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddNewRecords
            // 
            this.btnAddNewRecords.BackColor = System.Drawing.Color.Transparent;
            this.btnAddNewRecords.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewRecords.Font = new System.Drawing.Font("Big John PRO", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddNewRecords.Location = new System.Drawing.Point(45, 178);
            this.btnAddNewRecords.Name = "btnAddNewRecords";
            this.btnAddNewRecords.Size = new System.Drawing.Size(123, 67);
            this.btnAddNewRecords.TabIndex = 5;
            this.btnAddNewRecords.Text = "add new records";
            this.btnAddNewRecords.UseVisualStyleBackColor = false;
            this.btnAddNewRecords.Click += new System.EventHandler(this.btnAddNewRecords_Click);
            // 
            // btnViewRecords
            // 
            this.btnViewRecords.BackColor = System.Drawing.Color.Transparent;
            this.btnViewRecords.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewRecords.Font = new System.Drawing.Font("Big John PRO", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnViewRecords.Location = new System.Drawing.Point(45, 105);
            this.btnViewRecords.Name = "btnViewRecords";
            this.btnViewRecords.Size = new System.Drawing.Size(123, 67);
            this.btnViewRecords.TabIndex = 4;
            this.btnViewRecords.Text = "view records";
            this.btnViewRecords.UseVisualStyleBackColor = false;
            this.btnViewRecords.Click += new System.EventHandler(this.btnViewRecords_Click);
            // 
            // labelLoadNotify
            // 
            this.labelLoadNotify.AutoSize = true;
            this.labelLoadNotify.BackColor = System.Drawing.Color.Transparent;
            this.labelLoadNotify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelLoadNotify.Font = new System.Drawing.Font("BankGothic Lt BT", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelLoadNotify.ForeColor = System.Drawing.Color.White;
            this.labelLoadNotify.Location = new System.Drawing.Point(12, 380);
            this.labelLoadNotify.Name = "labelLoadNotify";
            this.labelLoadNotify.Size = new System.Drawing.Size(417, 22);
            this.labelLoadNotify.TabIndex = 7;
            this.labelLoadNotify.Text = "Default database load successfull";
            // 
            // logo
            // 
            this.logo.BackColor = System.Drawing.Color.Transparent;
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.Location = new System.Drawing.Point(241, 12);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(282, 66);
            this.logo.TabIndex = 8;
            this.logo.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(195, 84);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(377, 247);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Big John PRO", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBack.Location = new System.Drawing.Point(45, 251);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(123, 67);
            this.btnBack.TabIndex = 10;
            this.btnBack.Text = "back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // actionMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(584, 411);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.labelLoadNotify);
            this.Controls.Add(this.btnAddNewRecords);
            this.Controls.Add(this.btnViewRecords);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "actionMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LRG Property Management System";
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAddNewRecords;
        private System.Windows.Forms.Button btnViewRecords;
        private System.Windows.Forms.Label labelLoadNotify;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnBack;
    }
}