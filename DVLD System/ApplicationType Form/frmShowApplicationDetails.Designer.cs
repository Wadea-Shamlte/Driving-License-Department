namespace DVLD_System.ApplicationType_Form
{
    partial class frmShowApplicationDetails
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
            this.ctrlInfoTestCard1 = new DVLD_System.My_Controls.ctrlInfoTestCard();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlInfoTestCard1
            // 
            this.ctrlInfoTestCard1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ctrlInfoTestCard1.LbAppID = "[????]";
            this.ctrlInfoTestCard1.LbApplicantName = "[????]";
            this.ctrlInfoTestCard1.LbAppTypeID = "[????]";
            this.ctrlInfoTestCard1.LbClassName = "[????]";
            this.ctrlInfoTestCard1.LbCreatedByName = "[????]";
            this.ctrlInfoTestCard1.LbDate = "[????]";
            this.ctrlInfoTestCard1.LbFees = "[????]";
            this.ctrlInfoTestCard1.LbPassedTest = "0/3";
            this.ctrlInfoTestCard1.LbStatus = "[????]";
            this.ctrlInfoTestCard1.LbStatusDate = "[????]";
            this.ctrlInfoTestCard1.LbType = "[????]";
            this.ctrlInfoTestCard1.Location = new System.Drawing.Point(12, 12);
            this.ctrlInfoTestCard1.Name = "ctrlInfoTestCard1";
            this.ctrlInfoTestCard1.Size = new System.Drawing.Size(686, 308);
            this.ctrlInfoTestCard1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_System.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(604, 336);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 27);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "         Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmShowApplicationDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(713, 375);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlInfoTestCard1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShowApplicationDetails";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Application Details";
            this.Load += new System.EventHandler(this.frmShowApplicationDetails_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private My_Controls.ctrlInfoTestCard ctrlInfoTestCard1;
        private System.Windows.Forms.Button btnClose;
    }
}