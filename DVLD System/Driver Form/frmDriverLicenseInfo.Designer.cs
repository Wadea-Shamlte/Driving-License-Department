namespace DVLD_System.Drriver_Form
{
    partial class frmDriverLicenseInfo
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
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlLicenseCardInfo1 = new DVLD_System.My_Controls.ctrlLicenseCardInfo();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ebrima", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(237, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Driver License Info";
            // 
            // ctrlLicenseCardInfo1
            // 
            this.ctrlLicenseCardInfo1.LbClassName = "[????]";
            this.ctrlLicenseCardInfo1.LbDateOfBirth = "[????]";
            this.ctrlLicenseCardInfo1.LbDriverID = "[????]";
            this.ctrlLicenseCardInfo1.LbExpiryDate = "[????]";
            this.ctrlLicenseCardInfo1.LbGender = "[????]";
            this.ctrlLicenseCardInfo1.LbIsActive = "[????]";
            this.ctrlLicenseCardInfo1.LbIsDetained = "[????]";
            this.ctrlLicenseCardInfo1.LbIssueDate = "[????]";
            this.ctrlLicenseCardInfo1.LbIssueReason = "[????]";
            this.ctrlLicenseCardInfo1.LbLicenseID = "[????]";
            this.ctrlLicenseCardInfo1.LbName = "[????]";
            this.ctrlLicenseCardInfo1.LbNationalNo = "[????]";
            this.ctrlLicenseCardInfo1.LbNote = "[????]";
            this.ctrlLicenseCardInfo1.Location = new System.Drawing.Point(13, 149);
            this.ctrlLicenseCardInfo1.Name = "ctrlLicenseCardInfo1";
            this.ctrlLicenseCardInfo1.Size = new System.Drawing.Size(727, 342);
            this.ctrlLicenseCardInfo1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_System.Properties.Resources.LicenseCard;
            this.pictureBox1.Location = new System.Drawing.Point(310, -11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 134);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_System.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(646, 497);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 32);
            this.btnClose.TabIndex = 37;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmDriverLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(752, 539);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlLicenseCardInfo1);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDriverLicenseInfo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Driver License Info";
            this.Load += new System.EventHandler(this.frmDriverLicenseInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private My_Controls.ctrlLicenseCardInfo ctrlLicenseCardInfo1;
        private System.Windows.Forms.Button btnClose;
    }
}