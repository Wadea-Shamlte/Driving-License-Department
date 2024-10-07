using DVLD_System.My_Controls;

namespace DVLD_System.People_Forms
{
    partial class frmAddEditPersonInfo
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
            this.components = new System.ComponentModel.Container();
            this.lbTiteleFrm = new System.Windows.Forms.Label();
            this.lb1 = new System.Windows.Forms.Label();
            this.lbPersonID = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrlAddUpdatePerson1 = new DVLD_System.My_Controls.ctrlAddUpdatePerson();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTiteleFrm
            // 
            this.lbTiteleFrm.AutoSize = true;
            this.lbTiteleFrm.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTiteleFrm.ForeColor = System.Drawing.Color.Red;
            this.lbTiteleFrm.Location = new System.Drawing.Point(265, 22);
            this.lbTiteleFrm.Name = "lbTiteleFrm";
            this.lbTiteleFrm.Size = new System.Drawing.Size(208, 31);
            this.lbTiteleFrm.TabIndex = 0;
            this.lbTiteleFrm.Text = "Update Person";
            // 
            // lb1
            // 
            this.lb1.AutoSize = true;
            this.lb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb1.Location = new System.Drawing.Point(12, 79);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(100, 16);
            this.lb1.TabIndex = 2;
            this.lb1.Text = "Personal ID : ";
            // 
            // lbPersonID
            // 
            this.lbPersonID.AutoSize = true;
            this.lbPersonID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPersonID.Location = new System.Drawing.Point(160, 76);
            this.lbPersonID.Name = "lbPersonID";
            this.lbPersonID.Size = new System.Drawing.Size(18, 20);
            this.lbPersonID.TabIndex = 25;
            this.lbPersonID.Text = "?";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlAddUpdatePerson1
            // 
            this.ctrlAddUpdatePerson1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlAddUpdatePerson1.CbCountry = "None";
            this.ctrlAddUpdatePerson1.dateTimePicker = "4/30/2006";
            this.ctrlAddUpdatePerson1.Location = new System.Drawing.Point(12, 101);
            this.ctrlAddUpdatePerson1.Name = "ctrlAddUpdatePerson1";
            this.ctrlAddUpdatePerson1.Size = new System.Drawing.Size(730, 336);
            this.ctrlAddUpdatePerson1.TabIndex = 26;
            this.ctrlAddUpdatePerson1.TxtAddress = "";
            this.ctrlAddUpdatePerson1.TxtEmail = "";
            this.ctrlAddUpdatePerson1.TxtFirstName = "";
            this.ctrlAddUpdatePerson1.TxtFourthName = "";
            this.ctrlAddUpdatePerson1.TxtNationalNo = "";
            this.ctrlAddUpdatePerson1.TxtPhone = "";
            this.ctrlAddUpdatePerson1.TxtSecondName = "";
            this.ctrlAddUpdatePerson1.TxtThirdName = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_System.Properties.Resources.person_man;
            this.pictureBox1.Location = new System.Drawing.Point(118, 73);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 22);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // frmAddEditPersonInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(754, 496);
            this.Controls.Add(this.ctrlAddUpdatePerson1);
            this.Controls.Add(this.lbPersonID);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lb1);
            this.Controls.Add(this.lbTiteleFrm);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditPersonInfo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add / Edit Person Info";
            this.Load += new System.EventHandler(this.frmAddEditPersonInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTiteleFrm;
        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbPersonID;
        private ctrlAddUpdatePerson ctrlAddUpdatePerson1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}