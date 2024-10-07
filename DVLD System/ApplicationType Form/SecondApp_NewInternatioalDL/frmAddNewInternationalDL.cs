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

namespace DVLD_System.ApplicationType_Form.SecondApp_NewInternatioalDL
{
    public partial class frmAddNewInternationalDL : Form
    {
        clsBLManageLicenses _clsBLManageLicenses;
        clsBLManageDriver _clsBLManageDriver;
        clsBLManagePeople _clsBLManagePeople;
        clsBLManageNewInternationalLicense _clsBLManageNewInternationalLicense;
        clsBLManageUsers _clsBLManageUsers;


        public frmAddNewInternationalDL()
        {
            InitializeComponent();
        }

        private void _LoadData()
        {
            _clsBLManageDriver = clsBLManageDriver.GetInfoByDriverID(_clsBLManageLicenses.DriverID);
            _clsBLManagePeople = clsBLManagePeople.GetPersonalInfo(_clsBLManageDriver.PersonID);


            ctrlLicenseCardInfoAsFilter1.LbClassName = clsBLManageFirstApp_NLDL.GetClassName(_clsBLManageLicenses.LicenseClass);
            ctrlLicenseCardInfoAsFilter1.LbName = _clsBLManagePeople.FullName();
            ctrlLicenseCardInfoAsFilter1.LbLicenseID = _clsBLManageLicenses.LicenseID.ToString();
            ctrlLicenseCardInfoAsFilter1.LbNationalNo = _clsBLManagePeople.NationalNo;
            ctrlLicenseCardInfoAsFilter1.LbGender = _clsBLManagePeople.Gender == 0 ? "Male" : "Female";
            ctrlLicenseCardInfoAsFilter1.LbIssueDate = _clsBLManageLicenses.IssueDate.Date.ToString("yyyy-MM-dd");
            ctrlLicenseCardInfoAsFilter1.LbIssueReason = _clsBLManageLicenses.IssueReason.ToString();
            ctrlLicenseCardInfoAsFilter1.LbIsActive = _clsBLManageLicenses.IsActive ? "Yes" : "No";
            ctrlLicenseCardInfoAsFilter1.LbDateOfBirth = _clsBLManagePeople.DateOfBirth.Date.ToString("yyyy-MM-dd");
            ctrlLicenseCardInfoAsFilter1.LbNote = _clsBLManageLicenses.Notes == "" ? "Not Found Notes." : _clsBLManageLicenses.Notes.ToString();
            ctrlLicenseCardInfoAsFilter1.LbDriverID = _clsBLManageDriver.DriverID.ToString();
            ctrlLicenseCardInfoAsFilter1.LbExpiryDate = _clsBLManageLicenses.ExpirationDate.Date.ToString("yyyy-MM-dd");
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

            lbFees.Text = clsBLManageAppType.GetAppTypeFees(6).ToString();
        }

        private bool _CreateApp()
        {
            clsBLManageAllApplications _clsBLManageAllApplications = new clsBLManageAllApplications();
            _clsBLManageAllApplications.ApplicantPersonID = _clsBLManagePeople.ID;
            _clsBLManageAllApplications.ApplicationDate = DateTime.Now;
            _clsBLManageAllApplications.ApplicationTypeID = 6;
            _clsBLManageAllApplications.ApplicationStatus = 3;
            _clsBLManageAllApplications.LastStatusDate = DateTime.Now;
            _clsBLManageAllApplications.PaidFees = clsBLManageAppType.GetAppTypeFees(6);
            _clsBLManageAllApplications.CreatedByUserID = _clsBLManageUsers.UserID;

            if(_clsBLManageAllApplications.Add())
                return true;
            else return false;

        }


        private void frmAddNewInternationalDL_Load(object sender, EventArgs e)
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
                _clsBLManageLicenses = clsBLManageLicenses.GetInfoLicenseID(LicenseID);
                if (_clsBLManageLicenses.IsActive == true)
                {
                    if (_clsBLManageLicenses.LicenseClass == 3)
                    {
                        _LoadData();
                        btnSave.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Error: This license is not a Class 3 license.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("The license you are looking for that License ID: [ " + LicenseID + " ] is not available.Please enter a another License ID." , "Warning", MessageBoxButtons.OK , MessageBoxIcon.Warning);

            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!clsBLManageNewInternationalLicense.IsExist(_clsBLManageDriver.DriverID))
            {
                _clsBLManageUsers = clsBLManageUsers.GetUserInfoByUserName(clsBLGlobalData.SharedUserName);
                _clsBLManageNewInternationalLicense = new clsBLManageNewInternationalLicense();



                _clsBLManageNewInternationalLicense.ApplicationID = _clsBLManageLicenses.ApplicationID;
                _clsBLManageNewInternationalLicense.DriverID = _clsBLManageDriver.DriverID;
                _clsBLManageNewInternationalLicense.IssuedUsingLocalLicenseID = _clsBLManageLicenses.LicenseID;
                _clsBLManageNewInternationalLicense.IssueDate = DateTime.Now;
                _clsBLManageNewInternationalLicense.ExpirationDate = _clsBLManageNewInternationalLicense.IssueDate.AddYears(clsBLManageFirstApp_NLDL.GetValidityLength(_clsBLManageLicenses.LicenseClass));
                _clsBLManageNewInternationalLicense.IsActive = true;
                _clsBLManageNewInternationalLicense.CreatedByUserID = _clsBLManageUsers.UserID;

                lbApplicationID.Text = _clsBLManageLicenses.ApplicationID.ToString();
                lbDriverID.Text = _clsBLManageDriver.DriverID.ToString();
                lbLocalLicenseID.Text = _clsBLManageLicenses.LicenseID.ToString();
                lbIssueDate.Text = DateTime.Now.Date.ToString();
                lbExpiryDate.Text = _clsBLManageNewInternationalLicense.ExpirationDate.ToString();
                lbCreatedByName.Text = clsBLGlobalData.SharedUserName;
                

                if(_CreateApp())
                {
                    if (_clsBLManageNewInternationalLicense.AddInternationalLicense())
                        MessageBox.Show("The process of adding a International license was completed successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Error: The process of adding is failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Error: This person that ID [ " + _clsBLManagePeople.ID + " ] is already have international license active.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
