namespace DVLD_System.User_Forms
{
    partial class frmChangePassword
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCurrentPass = new System.Windows.Forms.TextBox();
            this.txtConfirmPass = new System.Windows.Forms.TextBox();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnSaveDataForm = new System.Windows.Forms.Button();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.ctrlUserCard1 = new DVLD_System.My_Controls.ctrlUserCard();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 346);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current Password : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(59, 375);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "New Password : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 404);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Confirm Password : ";
            // 
            // txtCurrentPass
            // 
            this.txtCurrentPass.Location = new System.Drawing.Point(201, 347);
            this.txtCurrentPass.Name = "txtCurrentPass";
            this.txtCurrentPass.Size = new System.Drawing.Size(136, 20);
            this.txtCurrentPass.TabIndex = 4;
            this.txtCurrentPass.UseSystemPasswordChar = true;
            // 
            // txtConfirmPass
            // 
            this.txtConfirmPass.Location = new System.Drawing.Point(201, 404);
            this.txtConfirmPass.Name = "txtConfirmPass";
            this.txtConfirmPass.Size = new System.Drawing.Size(136, 20);
            this.txtConfirmPass.TabIndex = 5;
            this.txtConfirmPass.UseSystemPasswordChar = true;
            // 
            // txtNewPass
            // 
            this.txtNewPass.Location = new System.Drawing.Point(201, 376);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.Size = new System.Drawing.Size(136, 20);
            this.txtNewPass.TabIndex = 6;
            this.txtNewPass.UseSystemPasswordChar = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnSaveDataForm
            // 
            this.btnSaveDataForm.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSaveDataForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveDataForm.Image = global::DVLD_System.Properties.Resources.diskette;
            this.btnSaveDataForm.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveDataForm.Location = new System.Drawing.Point(611, 442);
            this.btnSaveDataForm.Name = "btnSaveDataForm";
            this.btnSaveDataForm.Size = new System.Drawing.Size(93, 34);
            this.btnSaveDataForm.TabIndex = 63;
            this.btnSaveDataForm.Text = "  Save";
            this.btnSaveDataForm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveDataForm.UseVisualStyleBackColor = false;
            this.btnSaveDataForm.Click += new System.EventHandler(this.btnSaveDataForm_Click);
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCloseForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseForm.Image = global::DVLD_System.Properties.Resources.close;
            this.btnCloseForm.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCloseForm.Location = new System.Drawing.Point(490, 442);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(93, 33);
            this.btnCloseForm.TabIndex = 62;
            this.btnCloseForm.Text = "  Close";
            this.btnCloseForm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseForm.UseVisualStyleBackColor = false;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
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
            this.ctrlUserCard1.Location = new System.Drawing.Point(3, 5);
            this.ctrlUserCard1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ctrlUserCard1.Name = "ctrlUserCard1";
            this.ctrlUserCard1.Size = new System.Drawing.Size(711, 323);
            this.ctrlUserCard1.TabIndex = 0;
            // 
            // frmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(716, 487);
            this.Controls.Add(this.btnSaveDataForm);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.txtNewPass);
            this.Controls.Add(this.txtConfirmPass);
            this.Controls.Add(this.txtCurrentPass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlUserCard1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChangePassword";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password";
            this.Load += new System.EventHandler(this.frmChangePassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private My_Controls.ctrlUserCard ctrlUserCard1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCurrentPass;
        private System.Windows.Forms.TextBox txtConfirmPass;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.Button btnSaveDataForm;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}