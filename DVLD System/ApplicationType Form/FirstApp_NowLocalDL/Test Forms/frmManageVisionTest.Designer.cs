namespace DVLD_System.ApplicationType_Form.FirstApp_NowLocalDL.Test_Fomes
{
    partial class frmManageVisionTest
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
            this.label1 = new System.Windows.Forms.Label();
            this.DGListTestAppointment = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lbRecordCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrlInfoTestCard1 = new DVLD_System.My_Controls.ctrlInfoTestCard();
            this.btnClose = new System.Windows.Forms.Button();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddNewAppointment = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGListTestAppointment)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ebrima", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(145, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(406, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vision Test Appointments";
            // 
            // DGListTestAppointment
            // 
            this.DGListTestAppointment.AllowUserToAddRows = false;
            this.DGListTestAppointment.AllowUserToDeleteRows = false;
            this.DGListTestAppointment.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DGListTestAppointment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGListTestAppointment.ContextMenuStrip = this.contextMenuStrip1;
            this.DGListTestAppointment.GridColor = System.Drawing.SystemColors.Control;
            this.DGListTestAppointment.Location = new System.Drawing.Point(11, 509);
            this.DGListTestAppointment.Name = "DGListTestAppointment";
            this.DGListTestAppointment.ReadOnly = true;
            this.DGListTestAppointment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGListTestAppointment.Size = new System.Drawing.Size(686, 101);
            this.DGListTestAppointment.TabIndex = 4;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.takeTestToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(146, 64);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // lbRecordCount
            // 
            this.lbRecordCount.AutoSize = true;
            this.lbRecordCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecordCount.Location = new System.Drawing.Point(88, 627);
            this.lbRecordCount.Name = "lbRecordCount";
            this.lbRecordCount.Size = new System.Drawing.Size(15, 16);
            this.lbRecordCount.TabIndex = 16;
            this.lbRecordCount.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 627);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "# Record :";
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
            this.ctrlInfoTestCard1.Location = new System.Drawing.Point(11, 156);
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
            this.btnClose.Location = new System.Drawing.Point(603, 622);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 27);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "         Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::DVLD_System.Properties.Resources.edit;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(145, 30);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // takeTestToolStripMenuItem
            // 
            this.takeTestToolStripMenuItem.Image = global::DVLD_System.Properties.Resources.next;
            this.takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            this.takeTestToolStripMenuItem.Size = new System.Drawing.Size(145, 30);
            this.takeTestToolStripMenuItem.Text = "Take Test";
            this.takeTestToolStripMenuItem.Click += new System.EventHandler(this.takeTestToolStripMenuItem_Click);
            // 
            // btnAddNewAppointment
            // 
            this.btnAddNewAppointment.BackgroundImage = global::DVLD_System.Properties.Resources.Add;
            this.btnAddNewAppointment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddNewAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewAppointment.Location = new System.Drawing.Point(660, 470);
            this.btnAddNewAppointment.Name = "btnAddNewAppointment";
            this.btnAddNewAppointment.Size = new System.Drawing.Size(37, 33);
            this.btnAddNewAppointment.TabIndex = 3;
            this.btnAddNewAppointment.UseVisualStyleBackColor = true;
            this.btnAddNewAppointment.Click += new System.EventHandler(this.btnAddNewAppointment_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_System.Properties.Resources.eye;
            this.pictureBox1.Location = new System.Drawing.Point(291, -13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 118);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // frmManageVisionTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(709, 659);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbRecordCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DGListTestAppointment);
            this.Controls.Add(this.btnAddNewAppointment);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlInfoTestCard1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManageVisionTest";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Vision Test";
            this.Load += new System.EventHandler(this.frmManageVisionTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGListTestAppointment)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private My_Controls.ctrlInfoTestCard ctrlInfoTestCard1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAddNewAppointment;
        private System.Windows.Forms.DataGridView DGListTestAppointment;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbRecordCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem;
    }
}