using DVLD_BusinessLayer;
using DVLD_System.My_Controls;
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

namespace DVLD_System.ApplicationType_Form.SixthApp_Release_DetentionLicense
{
    public partial class frmReleaseLicense : Form
    {
        clsBLManageLicenses _clsManageLicenses;
        clsBLManageDriver _clsBLManageDriver;
        clsBLManagePeople _clsBLManagePeople;
        clsBLManageUsers _clsBLManageUsers;
        clsBLManageAllApplications _clsBLManageAllApplications;
        clsBLManageDetainLicense _clsBLManageDetainLicense;

        public frmReleaseLicense()
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

        private bool _CreateApp()
        {
            _clsBLManageAllApplications = new clsBLManageAllApplications();

            _clsBLManageAllApplications.ApplicantPersonID = _clsBLManagePeople.ID;
            _clsBLManageAllApplications.ApplicationDate = DateTime.Now;
            _clsBLManageAllApplications.ApplicationTypeID = 5;
            _clsBLManageAllApplications.ApplicationStatus = 3;
            _clsBLManageAllApplications.LastStatusDate = DateTime.Now;
            _clsBLManageAllApplications.PaidFees = decimal.Parse(lbTotalFees.Text);
            _clsBLManageAllApplications.CreatedByUserID = _clsBLManageUsers.UserID;

            if (_clsBLManageAllApplications.Add())
                return true;
            else return false;

        }



        private void frmReleaseLicense_Load(object sender, EventArgs e)
        {
            ctrlLicenseCardInfoAsFilter1.TxtLicenseID.Text = (1).ToString();

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
                    if (clsBLManageDetainLicense.IsDetained(LicenseID))
                    {
                        _clsBLManageDetainLicense = clsBLManageDetainLicense.GetInfoByLicenseID(LicenseID);

                        lbDetainFees.Text = _clsBLManageDetainLicense.FineFees.ToString();
                        lbAppFees.Text = clsBLManageAppType.GetAppTypeFees(5).ToString();
                        lbTotalFees.Text = (_clsBLManageDetainLicense.FineFees + clsBLManageAppType.GetAppTypeFees(5)).ToString();

                        _LoadData();
                        btnReleaseLicense.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Error: There is no Detain on this license.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnReleaseLicense_Click(object sender, EventArgs e)
        {
            _clsBLManageUsers = clsBLManageUsers.GetUserInfoByUserName(clsBLGlobalData.SharedUserName);

            if (_CreateApp())
            {
                _clsBLManageDetainLicense.IsReleased = true;
                _clsBLManageDetainLicense.ReleaseDate = DateTime.Now;
                _clsBLManageDetainLicense.ReleasedByUserID = _clsBLManageUsers.UserID;
                _clsBLManageDetainLicense.ReleaseApplicationID = _clsBLManageAllApplications.ApplicationID;

                if (_clsBLManageDetainLicense.ReleaseLicense())
                {
                    MessageBox.Show("The process of Release License was completed successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnReleaseLicense.Enabled = false;

                    lbDetainID.Text = _clsBLManageDetainLicense.DetainID.ToString();
                    lbDetainDate.Text = _clsBLManageDetainLicense.DetainDate.ToString();
                    lbLicenseId.Text = _clsBLManageDetainLicense.LicenseID.ToString();
                    lbCreatedByName.Text = clsBLGlobalData.SharedUserName;
                }
                else
                    MessageBox.Show("Error: The process of Release License is failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
