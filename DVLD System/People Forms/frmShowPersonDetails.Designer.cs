namespace DVLD_System.People_Forms
{
    partial class frmShowPersonDetails
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
            this.ctrlPeopleCard1 = new DVLD_System.My_Controls.ctrlPeopleCard();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(240, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "Person Details";
            // 
            // ctrlPeopleCard1
            // 
            this.ctrlPeopleCard1.LbAddress = "???";
            this.ctrlPeopleCard1.LbBirth = "???";
            this.ctrlPeopleCard1.LbCountryName = "???";
            this.ctrlPeopleCard1.LbEmail = "???";
            this.ctrlPeopleCard1.LbGender = "???";
            this.ctrlPeopleCard1.LbName = "???";
            this.ctrlPeopleCard1.LbNationalNo = "???";
            this.ctrlPeopleCard1.LbPersonalId = "Personal ID : ";
            this.ctrlPeopleCard1.LbPhone = "???";
            this.ctrlPeopleCard1.Location = new System.Drawing.Point(13, 124);
            this.ctrlPeopleCard1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlPeopleCard1.Name = "ctrlPeopleCard1";
            this.ctrlPeopleCard1.Size = new System.Drawing.Size(705, 225);
            this.ctrlPeopleCard1.TabIndex = 0;
            this.ctrlPeopleCard1.Load += new System.EventHandler(this.ctrlPeopleCard1_Load);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::DVLD_System.Properties.Resources.close;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(620, 356);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 31);
            this.button1.TabIndex = 1;
            this.button1.Text = "             Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmShowPersonDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(729, 406);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ctrlPeopleCard1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShowPersonDetails";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Show Person Details";
            this.Load += new System.EventHandler(this.frmShowPersonDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private My_Controls.ctrlPeopleCard ctrlPeopleCard1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}