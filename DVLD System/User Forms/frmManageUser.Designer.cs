namespace DVLD_System.User_Forms
{
    partial class frmManageUser
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
            this.DGListIUser = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetialesTSM = new System.Windows.Forms.ToolStripMenuItem();
            this.S1TSM = new System.Windows.Forms.ToolStripSeparator();
            this.addTSM = new System.Windows.Forms.ToolStripMenuItem();
            this.editTSM = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteTSM = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordTSM = new System.Windows.Forms.ToolStripMenuItem();
            this.S2TSM = new System.Windows.Forms.ToolStripSeparator();
            this.sendEmailTSM = new System.Windows.Forms.ToolStripMenuItem();
            this.callPhoneTSM = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbRecordCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGListIUser)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(266, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manage Users";
            // 
            // DGListIUser
            // 
            this.DGListIUser.AllowUserToAddRows = false;
            this.DGListIUser.AllowUserToDeleteRows = false;
            this.DGListIUser.AllowUserToResizeColumns = false;
            this.DGListIUser.AllowUserToResizeRows = false;
            this.DGListIUser.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DGListIUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGListIUser.ContextMenuStrip = this.contextMenuStrip1;
            this.DGListIUser.GridColor = System.Drawing.SystemColors.ControlLight;
            this.DGListIUser.Location = new System.Drawing.Point(12, 232);
            this.DGListIUser.Name = "DGListIUser";
            this.DGListIUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGListIUser.Size = new System.Drawing.Size(700, 266);
            this.DGListIUser.TabIndex = 2;
            this.DGListIUser.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGListIUser_CellValueChanged);
            this.DGListIUser.CurrentCellDirtyStateChanged += new System.EventHandler(this.DGListIUser_CurrentCellDirtyStateChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetialesTSM,
            this.S1TSM,
            this.addTSM,
            this.editTSM,
            this.deleteTSM,
            this.changePasswordTSM,
            this.S2TSM,
            this.sendEmailTSM,
            this.callPhoneTSM});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStrip1.ShowCheckMargin = true;
            this.contextMenuStrip1.Size = new System.Drawing.Size(203, 170);
            // 
            // showDetialesTSM
            // 
            this.showDetialesTSM.Image = global::DVLD_System.Properties.Resources.ShowDetails;
            this.showDetialesTSM.Name = "showDetialesTSM";
            this.showDetialesTSM.Size = new System.Drawing.Size(202, 22);
            this.showDetialesTSM.Text = "Show Details";
            this.showDetialesTSM.Click += new System.EventHandler(this.showDetialsTSM_Click);
            // 
            // S1TSM
            // 
            this.S1TSM.Name = "S1TSM";
            this.S1TSM.Size = new System.Drawing.Size(199, 6);
            // 
            // addTSM
            // 
            this.addTSM.Image = global::DVLD_System.Properties.Resources.Add_User;
            this.addTSM.Name = "addTSM";
            this.addTSM.Size = new System.Drawing.Size(202, 22);
            this.addTSM.Text = "Add New User";
            this.addTSM.Click += new System.EventHandler(this.addTSM_Click);
            // 
            // editTSM
            // 
            this.editTSM.Image = global::DVLD_System.Properties.Resources.person_boy;
            this.editTSM.Name = "editTSM";
            this.editTSM.Size = new System.Drawing.Size(202, 22);
            this.editTSM.Text = "Edit";
            this.editTSM.Click += new System.EventHandler(this.editTSM_Click);
            // 
            // deleteTSM
            // 
            this.deleteTSM.Image = global::DVLD_System.Properties.Resources.person_boy__1_;
            this.deleteTSM.Name = "deleteTSM";
            this.deleteTSM.Size = new System.Drawing.Size(202, 22);
            this.deleteTSM.Text = "Delete";
            this.deleteTSM.Click += new System.EventHandler(this.deleteTSM_Click);
            // 
            // changePasswordTSM
            // 
            this.changePasswordTSM.Image = global::DVLD_System.Properties.Resources.password2;
            this.changePasswordTSM.Name = "changePasswordTSM";
            this.changePasswordTSM.Size = new System.Drawing.Size(202, 22);
            this.changePasswordTSM.Text = "Change Password";
            this.changePasswordTSM.Click += new System.EventHandler(this.changePasswordTSM_Click);
            // 
            // S2TSM
            // 
            this.S2TSM.Name = "S2TSM";
            this.S2TSM.Size = new System.Drawing.Size(199, 6);
            // 
            // sendEmailTSM
            // 
            this.sendEmailTSM.Image = global::DVLD_System.Properties.Resources.analize_email_sign;
            this.sendEmailTSM.Name = "sendEmailTSM";
            this.sendEmailTSM.Size = new System.Drawing.Size(202, 22);
            this.sendEmailTSM.Text = "Send Email";
            // 
            // callPhoneTSM
            // 
            this.callPhoneTSM.Image = global::DVLD_System.Properties.Resources.phone;
            this.callPhoneTSM.Name = "callPhoneTSM";
            this.callPhoneTSM.Size = new System.Drawing.Size(202, 22);
            this.callPhoneTSM.Text = "Call Phone";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(90, 206);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(169, 21);
            this.comboBox1.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Filter By :";
            // 
            // lbRecordCount
            // 
            this.lbRecordCount.AutoSize = true;
            this.lbRecordCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecordCount.Location = new System.Drawing.Point(92, 521);
            this.lbRecordCount.Name = "lbRecordCount";
            this.lbRecordCount.Size = new System.Drawing.Size(50, 16);
            this.lbRecordCount.TabIndex = 13;
            this.lbRecordCount.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 521);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "# Record :";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_System.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(618, 510);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 27);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "         Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = global::DVLD_System.Properties.Resources.Add_User;
            this.button2.Location = new System.Drawing.Point(638, 157);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 71);
            this.button2.TabIndex = 11;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = global::DVLD_System.Properties.Resources.Users;
            this.pictureBox1.Location = new System.Drawing.Point(304, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(161, 153);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmManageUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(724, 551);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbRecordCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DGListIUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManageUser";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage User";
            this.Load += new System.EventHandler(this.frmManageUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGListIUser)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGListIUser;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbRecordCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showDetialesTSM;
        private System.Windows.Forms.ToolStripMenuItem addTSM;
        private System.Windows.Forms.ToolStripMenuItem editTSM;
        private System.Windows.Forms.ToolStripMenuItem changePasswordTSM;
        private System.Windows.Forms.ToolStripMenuItem deleteTSM;
        private System.Windows.Forms.ToolStripSeparator S1TSM;
        private System.Windows.Forms.ToolStripSeparator S2TSM;
        private System.Windows.Forms.ToolStripMenuItem sendEmailTSM;
        private System.Windows.Forms.ToolStripMenuItem callPhoneTSM;
    }
}