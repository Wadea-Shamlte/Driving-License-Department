using DVLD_BusinessLayer;
using DVLD_System.Properties;
using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_System.ApplicationType_Form.SixthApp_Release_DetentionLicense
{
    public partial class frmDetainLicense : Form
    {
        clsBLManageLicenses _clsManageLicenses;
        clsBLManageDriver _clsBLManageDriver;
        clsBLManagePeople _clsBLManagePeople;
        clsBLManageUsers _clsBLManageUsers;

        public frmDetainLicense()
        {
            InitializeComponent();
        }

        private void _LoadData()
        {
            _clsBLManageDriver = clsBLManageDriver.GetInfoByDriverID(_clsManageLicenses.DriverID);
            _clsBLManagePeople = clsBLManagePeople.GetPersonalInfo(_clsBLManageDriver.PersonID);


            ctrlLicenseCardInfoAsFilter1.LbClassName = clsBLManageFirstApp_NLDL.GetClassName(_clsManageLicenses.LicenseClass);
            ctrlLicenseCardInfoAsFilter1.LbName = _clsBLManagePeople.FullName();
            ctrlLicenseCardInfoAsFilter1.LbLicenseID = _clsManageLicenses.LicenseID.ToString();
            ctrlLicenseCardInfoAsFilter1.LbNationalNo = _clsBLManagePeople.NationalNo;
            ctrlLicenseCardInfoAsFilter1.LbGender = _clsBLManagePeople.Gender == 0 ? "Male" : "Female";
            ctrlLicenseCardInfoAsFilter1.LbIssueDate = _clsManageLicenses.IssueDate.Date.ToString("yyyy-MM-dd");
            ctrlLicenseCardInfoAsFilter1.LbIssueReason = _clsManageLicenses.IssueReason.ToString();
            ctrlLicenseCardInfoAsFilter1.LbIsActive = _clsManageLicenses.IsActive ? "Yes" : "No";
            ctrlLicenseCardInfoAsFilter1.LbDateOfBirth = _clsBLManagePeople.DateOfBirth.Date.ToString("yyyy-MM-dd");
            ctrlLicenseCardInfoAsFilter1.LbNote = _clsManageLicenses.Notes == "" ? "Not Found Notes." : _clsManageLicenses.Notes.ToString();
            ctrlLicenseCardInfoAsFilter1.LbDriverID = _clsBLManageDriver.DriverID.ToString();
            ctrlLicenseCardInfoAsFilter1.LbExpiryDate = _clsManageLicenses.ExpirationDate.Date.ToString("yyyy-MM-dd");

            if (_clsBLManagePeople.ImagePath != "")
                ctrlLicenseCardInfoAsFilter1.PbPersonalPic.Load(_clsBLManagePeople.ImagePath);
            else
            {
                if (_clsBLManagePeople.Gender == 0)
                    ctrlLicenseCardInfoAsFilter1.PbPersonalPic.Image = Resources.Man;
                else
                    ctrlLicenseCardInfoAsFilter1.PbPersonalPic.Image = Resources.Woman;
            }

        }


        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            textBox1.Text = 1.ToString();

            System.Windows.Forms.Button btnGetData = ctrlLicenseCardInfoAsFilter1.BtnGetData;
            btnGetData.Click += btnGetData_Click;
        }


        private void btnGetData_Click(object sender, EventArgs e)
        {
            int LicenseID = int.Parse(ctrlLicenseCardInfoAsFilter1.TxtLicenseID.Text);

            if (clsBLManageLicenses.IsExist(LicenseID))
            {
                _clsManageLicenses = clsBLManageLicenses.GetInfoLicenseID(LicenseID);
                if (_clsManageLicenses.IsActive == true)
                {
                    ctrlLicenseCardInfoAsFilter1.LbIsDetained = clsBLManageDetainLicense.IsDetained(LicenseID) ? "Yes" : "No";
                    if (!clsBLManageDetainLicense.IsDetained(LicenseID))
                    {

                        _LoadData();
                        btnDetainLicense.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Error: This license is already detained.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _LoadData();
                    }
                }
                else
                {
                    MessageBox.Show("Error: The license that License ID: [ " + LicenseID + " ] Is not Active.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _LoadData();
                }
            }
            else
                MessageBox.Show("The license you are looking for that License ID: [ " + LicenseID + " ] is not available.Please enter a another License ID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            _clsBLManageUsers = clsBLManageUsers.GetUserInfoByUserName(clsBLGlobalData.SharedUserName);

            if (MessageBox.Show($"Are you sure the Fine Fees is {textBox1.Text} .", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clsBLManageDetainLicense _clsBLManageDetainLicense = new clsBLManageDetainLicense();

                _clsBLManageDetainLicense.LicenseID = _clsManageLicenses.LicenseID;
                _clsBLManageDetainLicense.DetainDate = DateTime.Now;
                _clsBLManageDetainLicense.FineFees = decimal.Parse(textBox1.Text);
                _clsBLManageDetainLicense.CreatedByUserID = _clsBLManageUsers.UserID;
                _clsBLManageDetainLicense.IsReleased = false;
                _clsBLManageDetainLicense.ReleaseDate = null;
                _clsBLManageDetainLicense.ReleasedByUserID = null;
                _clsBLManageDetainLicense.ReleaseApplicationID = null;

                if (_clsBLManageDetainLicense.DetainedLicense())
                {
                    MessageBox.Show("The process of Detain License was completed successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnDetainLicense.Enabled = false;
                    textBox1.Enabled = false;

                    lbDetainID.Text = _clsBLManageDetainLicense.DetainID.ToString();
                    lbDetainDate.Text = _clsBLManageDetainLicense.DetainDate.ToString();
                    lbLicenseId.Text = _clsBLManageDetainLicense.LicenseID.ToString();
                    lbCreatedByName.Text = clsBLGlobalData.SharedUserName;
                }
                else
                    MessageBox.Show("Error: The process of Detain License is failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //btnDetainLicense.Enabled = !string.IsNullOrEmpty(btnDetainLicense.Text);
        }
    }

    

        
}
