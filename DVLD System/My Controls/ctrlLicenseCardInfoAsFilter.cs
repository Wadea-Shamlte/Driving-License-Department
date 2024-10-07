using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_System.My_Controls
{
    public partial class ctrlLicenseCardInfoAsFilter : UserControl
    {
        public ctrlLicenseCardInfoAsFilter()
        {
            InitializeComponent();
        }

        public string LbClassName
        {
            set { lbClassName.Text = value; }
            get { return lbClassName.Text.ToString(); }
        }

        public string LbName
        {
            set { lbName.Text = value; }
            get { return lbName.Text.ToString(); }
        }

        public string LbLicenseID
        {
            set { lbLicenseID.Text = value; }
            get { return lbLicenseID.Text.ToString(); }
        }

        public string LbNationalNo
        {
            set { lbNationalNo.Text = value; }
            get { return lbNationalNo.Text.ToString(); }
        }

        public string LbGender
        {
            set { lbGender.Text = value; }
            get { return lbGender.Text.ToString(); }
        }

        public string LbIssueDate
        {
            set { lbIssueDate.Text = value; }
            get { return lbIssueDate.Text.ToString(); }
        }

        public string LbIssueReason
        {
            set { lbIssueReason.Text = value; }
            get { return lbIssueReason.Text.ToString(); }
        }

        public string LbNote
        {
            set { lbNote.Text = value; }
            get { return lbNote.Text.ToString(); }
        }

        public string LbIsActive
        {
            set { lbIsActive.Text = value; }
            get { return lbIsActive.Text.ToString(); }
        }

        public string LbDateOfBirth
        {
            set { lbDateOfBirth.Text = value; }
            get { return lbDateOfBirth.Text.ToString(); }
        }

        public string LbDriverID
        {
            set { lbDriverID.Text = value; }
            get { return lbDriverID.Text.ToString(); }
        }

        public string LbExpiryDate
        {
            set { lbExpiryDate.Text = value; }
            get { return lbExpiryDate.Text.ToString(); }
        }

        public string LbIsDetained
        {
            set { lbIsDetained.Text = value; }
            get { return lbIsDetained.Text.ToString(); }
        }

        public PictureBox PbPersonalPic
        {
            get { return pbPersonalPic; }
        }

        public TextBox TxtLicenseID
        {
            get { return txtLicenseID; }
        }

        public Button BtnGetData
        {
            get { return btnGetData; }
        }

        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtLicenseID_TextChanged(object sender, EventArgs e)
        {
            BtnGetData.Enabled = !string.IsNullOrEmpty(txtLicenseID.Text);
        }
    }
}
