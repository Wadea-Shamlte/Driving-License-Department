namespace DVLD_System.User_Forms
{
    partial class frmShowDetails
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
            this.ctrlUserCard1 = new DVLD_System.My_Controls.ctrlUserCard();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlUserCard1
            // 
            this.ctrlUserCard1.LbAddress = "[ ???? ]";
            this.ctrlUserCard1.LbBirth = "[ ???? ]";
            this.ctrlUserCard1.LbCountryName = "[ ???? ]";
            this.ctrlUserCard1.LbEmail = "[ ???? ]";
            this.ctrlUserCard1.LbGender = "[ ???? ]";
            this.ctrlUserCard1.LbID = "label2";
            this.ctrlUserCard1.LbIsActive = "label6";
            this.ctrlUserCard1.LbName = "????";
            this.ctrlUserCard1.LbNationalNo = "[ ???? ]";
            this.ctrlUserCard1.LbPersonalId = "[ ???? ]";
            this.ctrlUserCard1.LbPhone = "[ ???? ]";
            this.ctrlUserCard1.LbUserName = "label4";
            this.ctrlUserCard1.Location = new System.Drawing.Point(0, 0);
            this.ctrlUserCard1.Name = "ctrlUserCard1";
            this.ctrlUserCard1.Size = new System.Drawing.Size(710, 326);
            this.ctrlUserCard1.TabIndex = 0;
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCloseForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseForm.Image = global::DVLD_System.Properties.Resources.close;
            this.btnCloseForm.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCloseForm.Location = new System.Drawing.Point(608, 332);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(93, 33);
            this.btnCloseForm.TabIndex = 63;
            this.btnCloseForm.Text = "  Close";
            this.btnCloseForm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseForm.UseVisualStyleBackColor = false;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // frmShowDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(713, 375);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.ctrlUserCard1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShowDetails";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Show Details";
            this.Load += new System.EventHandler(this.frmShowUserDetails_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private My_Controls.ctrlUserCard ctrlUserCard1;
        private System.Windows.Forms.Button btnCloseForm;
    }
}