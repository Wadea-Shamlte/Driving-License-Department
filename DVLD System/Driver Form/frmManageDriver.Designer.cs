namespace DVLD_System.Driver_Form
{
    partial class frmManageDriver
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DGListViewLDriver = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbRecordCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFilterData = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFilterData = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGListViewLDriver)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_System.Properties.Resources.Driver1;
            this.pictureBox1.Location = new System.Drawing.Point(334, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(123, 132);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ebrima", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(318, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "Driver List";
            // 
            // DGListViewLDriver
            // 
            this.DGListViewLDriver.AllowUserToAddRows = false;
            this.DGListViewLDriver.AllowUserToDeleteRows = false;
            this.DGListViewLDriver.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGListViewLDriver.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DGListViewLDriver.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGListViewLDriver.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.DGListViewLDriver.Location = new System.Drawing.Point(12, 222);
            this.DGListViewLDriver.Name = "DGListViewLDriver";
            this.DGListViewLDriver.ReadOnly = true;
            this.DGListViewLDriver.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGListViewLDriver.Size = new System.Drawing.Size(771, 205);
            this.DGListViewLDriver.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_System.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(689, 436);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 27);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "         Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbRecordCount
            // 
            this.lbRecordCount.AutoSize = true;
            this.lbRecordCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecordCount.Location = new System.Drawing.Point(92, 441);
            this.lbRecordCount.Name = "lbRecordCount";
            this.lbRecordCount.Size = new System.Drawing.Size(50, 16);
            this.lbRecordCount.TabIndex = 16;
            this.lbRecordCount.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 441);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "# Record :";
            // 
            // cbFilterData
            // 
            this.cbFilterData.BackColor = System.Drawing.SystemColors.Window;
            this.cbFilterData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterData.FormattingEnabled = true;
            this.cbFilterData.Items.AddRange(new object[] {
            "  All",
            "  Driver ID",
            "  Person ID",
            "  National ID",
            "  Full Name"});
            this.cbFilterData.Location = new System.Drawing.Point(98, 192);
            this.cbFilterData.Name = "cbFilterData";
            this.cbFilterData.Size = new System.Drawing.Size(157, 21);
            this.cbFilterData.TabIndex = 19;
            this.cbFilterData.SelectedIndexChanged += new System.EventHandler(this.cbFilterData_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 21);
            this.label4.TabIndex = 18;
            this.label4.Text = "Filter By :";
            // 
            // txtFilterData
            // 
            this.txtFilterData.Location = new System.Drawing.Point(261, 193);
            this.txtFilterData.Multiline = true;
            this.txtFilterData.Name = "txtFilterData";
            this.txtFilterData.Size = new System.Drawing.Size(160, 20);
            this.txtFilterData.TabIndex = 20;
            this.txtFilterData.TextChanged += new System.EventHandler(this.txtFilterData_TextChanged);
            this.txtFilterData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterData_KeyPress);
            // 
            // frmManageDriver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(795, 475);
            this.Controls.Add(this.txtFilterData);
            this.Controls.Add(this.cbFilterData);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbRecordCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DGListViewLDriver);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManageDriver";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Driver";
            this.Load += new System.EventHandler(this.frmManageDriver_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGListViewLDriver)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGListViewLDriver;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbRecordCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFilterData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFilterData;
    }
}