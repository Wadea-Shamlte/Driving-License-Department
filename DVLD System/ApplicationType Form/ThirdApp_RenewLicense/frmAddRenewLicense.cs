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

namespace DVLD_System.ApplicationType_Form.ThirdApp_RenewLicense
{
    public partial class frmAddRenewLicense : Form
    {
        clsBLManageLicenses _clsOldLicenses;
        clsBLManageDriver _clsBLManageDriver;
        clsBLManagePeople _clsBLManagePeople;
        clsBLManageUsers _clsBLManageUsers;
        clsBLManageAllApplications _clsBLManageAllApplications;



        public frmAddRenewLicense()
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

            lbAppFees.Text = clsBLManageAppType.GetAppTypeFees(2).ToString();
            lbLicenseFees.Text = clsBLManageFirstApp_NLDL.GetClassFees(_clsOldLicenses.LicenseClass).ToString();
            lbTotale.Text = (clsBLManageAppType.GetAppTypeFees(2) + clsBLManageFirstApp_NLDL.GetClassFees(_clsOldLicenses.LicenseClass)).ToString();
        }

        private bool _CreateApp()
        {
            _clsBLManageAllApplications = new clsBLManageAllApplications();
            _clsBLManageAllApplications.ApplicantPersonID = _clsBLManagePeople.ID;
            _clsBLManageAllApplications.ApplicationDate = DateTime.Now;
            _clsBLManageAllApplications.ApplicationTypeID = 2;
            _clsBLManageAllApplications.ApplicationStatus = 3;
            _clsBLManageAllApplications.LastStatusDate = DateTime.Now;
            _clsBLManageAllApplications.PaidFees = decimal.Parse(lbTotale.Text);
            _clsBLManageAllApplications.CreatedByUserID = _clsBLManageUsers.UserID;

            if (_clsBLManageAllApplications.Add())
                return true;
            else return false;

        }



        private void frmAddRenewLicense_Load(object sender, EventArgs e)
        {
            ctrlLicenseCardInfoAsFilter1.TxtLicenseID.Text = 1.ToString();

            Button btnGetData = ctrlLicenseCardInfoAsFilter1.BtnGetData;
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
                    if (_clsOldLicenses.ExpirationDate < DateTime.Now)
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

            if (_clsOldLicenses.ExpirationDate < DateTime.Now)
            {
                _clsBLManageUsers = clsBLManageUsers.GetUserInfoByUserName(clsBLGlobalData.SharedUserName);

                clsBLManageLicenses clsNewLicenses = new clsBLManageLicenses();

                if (_CreateApp())
                {

                    clsNewLicenses.ApplicationID = _clsBLManageAllApplications.ApplicationID;
                    clsNewLicenses.DriverID = _clsOldLicenses.DriverID;
                    clsNewLicenses.LicenseClass = _clsOldLicenses.LicenseClass;
                    clsNewLicenses.IssueDate = DateTime.Now;
                    clsNewLicenses.ExpirationDate = clsNewLicenses.IssueDate.AddYears(clsBLManageFirstApp_NLDL.GetValidityLength(_clsOldLicenses.LicenseClass));
                    clsNewLicenses.Notes = txtNotes.Text;
                    clsNewLicenses.PaidFees = clsBLManageFirstApp_NLDL.GetClassFees(_clsOldLicenses.LicenseClass);
                    clsNewLicenses.IsActive = true;
                    clsNewLicenses.IssueReason = 2;
                    clsNewLicenses.CreatedByUserID = _clsBLManageUsers.UserID;


                    if (clsNewLicenses.AddLicense())
                    {
                        _clsOldLicenses.IsActive = clsBLManageLicenses.DeactivateLicense(int.Parse(ctrlLicenseCardInfoAsFilter1.TxtLicenseID.Text));
                        MessageBox.Show("The process of Renew License was completed successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnSave.Enabled = false;

                        lbLicenseID.Text = clsNewLicenses.LicenseID.ToString();
                        lbApplicationID.Text = clsNewLicenses.ApplicationID.ToString();
                        lbDriverID.Text = clsNewLicenses.DriverID.ToString();
                        lbIssueDate.Text = clsNewLicenses.IssueDate.ToString();
                        lbExpiryDate.Text = clsNewLicenses.ExpirationDate.ToString();
                        lbIssueReason.Text = clsNewLicenses.IssueReason.ToString();
                        lbCreatedByName.Text = clsBLGlobalData.SharedUserName;
                    }
                    else
                        MessageBox.Show("Error: The process of a Renew License is failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Error: The process of Adding App is failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Error: The license has not expired yet. The expiration date is [ " + _clsOldLicenses.ExpirationDate + " ].", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
