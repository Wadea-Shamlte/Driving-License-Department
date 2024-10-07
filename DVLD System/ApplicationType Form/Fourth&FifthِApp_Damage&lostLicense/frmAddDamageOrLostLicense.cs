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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD_System.ApplicationType_Form.fourth_fifthِApp_Damage_lostLicense
{
    public partial class frmAddDamageOrLostLicense : Form
    {
        clsBLManageLicenses _clsOldLicenses;
        clsBLManageDriver _clsBLManageDriver;
        clsBLManagePeople _clsBLManagePeople;
        clsBLManageUsers _clsBLManageUsers;
        clsBLManageAllApplications _clsBLManageAllApplications;

        public frmAddDamageOrLostLicense()
        {
            InitializeComponent();
        }

        private void _LoadData()
        {
            _clsBLManageDriver = clsBLManageDriver.GetInfoByDriverID(_clsOldLicenses.DriverID);
            _clsBLManagePeople = clsBLManagePeople.GetPersonalInfo(_clsBLManageDriver.PersonID);


            ctrlLicenseCardInfoAsFilter1.LbClassName = clsBLManageFirstApp_NLDL.GetClassName(_clsOldLicenses.LicenseClass);
            ctrlLicenseCardInfoAsFilter1.LbName = _clsBLManagePeople.FullName();
            ctrlLicenseCardInfoAsFilter1.LbLicenseID = _clsOldLicenses.LicenseID.ToString();
            ctrlLicenseCardInfoAsFilter1.LbNationalNo = _clsBLManagePeople.NationalNo;
            ctrlLicenseCardInfoAsFilter1.LbGender = _clsBLManagePeople.Gender == 0 ? "Male" : "Female";
            ctrlLicenseCardInfoAsFilter1.LbIssueDate = _clsOldLicenses.IssueDate.Date.ToString("yyyy-MM-dd");
            ctrlLicenseCardInfoAsFilter1.LbIssueReason = _clsOldLicenses.IssueReason.ToString();
            ctrlLicenseCardInfoAsFilter1.LbIsActive = _clsOldLicenses.IsActive ? "Yes" : "No";
            ctrlLicenseCardInfoAsFilter1.LbDateOfBirth = _clsBLManagePeople.DateOfBirth.Date.ToString("yyyy-MM-dd");
            ctrlLicenseCardInfoAsFilter1.LbNote = _clsOldLicenses.Notes == "" ? "Not Found Notes." : _clsOldLicenses.Notes.ToString();
            ctrlLicenseCardInfoAsFilter1.LbDriverID = _clsBLManageDriver.DriverID.ToString();
            ctrlLicenseCardInfoAsFilter1.LbExpiryDate = _clsOldLicenses.ExpirationDate.Date.ToString("yyyy-MM-dd");
            //ctrlLicenseCardInfoAsFilter1.LbIsDetained =

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

        private bool _CreateApp()
        {
            _clsBLManageAllApplications = new clsBLManageAllApplications();

            _clsBLManageAllApplications.ApplicantPersonID = _clsBLManagePeople.ID;
            _clsBLManageAllApplications.ApplicationDate = DateTime.Now;
            if(rbLostLicense.Checked)
                _clsBLManageAllApplications.ApplicationTypeID = 3;
            else
                _clsBLManageAllApplications.ApplicationTypeID = 4;
            _clsBLManageAllApplications.ApplicationStatus = 3;
            _clsBLManageAllApplications.LastStatusDate = DateTime.Now;
            _clsBLManageAllApplications.PaidFees = decimal.Parse(lbAppFees.Text);
            _clsBLManageAllApplications.CreatedByUserID = _clsBLManageUsers.UserID;

            if (_clsBLManageAllApplications.Add())
                return true;
            else return false;

        }


        private void frmAddDamageOrLostLicense_Load(object sender, EventArgs e)
        {
            ctrlLicenseCardInfoAsFilter1.TxtLicenseID.Text = 1.ToString();

            System.Windows.Forms.Button btnGetData = ctrlLicenseCardInfoAsFilter1.BtnGetData;
            btnGetData.Click += btnGetData_Click;
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            int LicenseID = int.Parse(ctrlLicenseCardInfoAsFilter1.TxtLicenseID.Text);

            if (clsBLManageLicenses.IsExist(LicenseID))
            {
                _clsOldLicenses = clsBLManageLicenses.GetInfoLicenseID(LicenseID);
                if (_clsOldLicenses.IsActive == true)
                {
                    if (_clsOldLicenses.ExpirationDate > DateTime.Now)
                    {
                        _LoadData();
                        btnSave.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Error: The license has not expired yet. The expiration date is [ " + _clsOldLicenses.ExpirationDate + " ].", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (rbLostLicense.Checked || rbDamagedLicense.Checked)
            {
                string Status = rbLostLicense.Checked ? "Lost License" : "Damaged License";
                _clsBLManageUsers = clsBLManageUsers.GetUserInfoByUserName(clsBLGlobalData.SharedUserName);

                clsBLManageLicenses clsNewLicenses = new clsBLManageLicenses();
                if(MessageBox.Show($"Do you want to confirm that the Replacement for {Status}!", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (_CreateApp())
                    {

                        clsNewLicenses.ApplicationID =_clsBLManageAllApplications.ApplicationID;
                        clsNewLicenses.DriverID = _clsOldLicenses.DriverID;
                        clsNewLicenses.LicenseClass = _clsOldLicenses.LicenseClass;
                        clsNewLicenses.IssueDate = DateTime.Now;
                        clsNewLicenses.ExpirationDate = clsNewLicenses.IssueDate.AddYears(clsBLManageFirstApp_NLDL.GetValidityLength(_clsOldLicenses.LicenseClass));
                        clsNewLicenses.Notes = "";
                        clsNewLicenses.PaidFees = decimal.Parse(lbAppFees.Text);
                        clsNewLicenses.IsActive = true;
                        clsNewLicenses.IssueReason = rbDamagedLicense.Checked ? 3 : 4; 
                        clsNewLicenses.CreatedByUserID = _clsBLManageUsers.UserID;


                        if (clsNewLicenses.AddLicense())
                        {
                            _clsOldLicenses.IsActive = clsBLManageLicenses.DeactivateLicense(int.Parse(ctrlLicenseCardInfoAsFilter1.TxtLicenseID.Text));
                            MessageBox.Show("The process of Replacement License was completed successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnSave.Enabled = false;

                            lbApplicationID.Text = clsNewLicenses.ApplicationID.ToString();
                            lbIssueDate.Text = clsNewLicenses.IssueDate.ToString();
                            lbOldLicenseId.Text = _clsOldLicenses.LicenseID.ToString();
                            lbNewLicenseId.Text = clsNewLicenses.LicenseID.ToString();
                            lbCreatedByName.Text = clsBLGlobalData.SharedUserName;
                        }
                        else
                            MessageBox.Show("Error: The process of Replacement License is failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Error: The process of Adding App is failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("The reason for the replacement case has not been selected. Is it Lost or Damage?", "Question", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            lbAppFees.Text = clsBLManageAppType.GetAppTypeFees(4).ToString();
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            lbAppFees.Text = clsBLManageAppType.GetAppTypeFees(3).ToString();
        }
    }
}
