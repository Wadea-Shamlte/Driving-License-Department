using DVLD_BusinessLayer;
using DVLD_System.My_Controls;
using DVLD_System.People_Forms;
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

namespace DVLD_System.ApplicationType_Form.FirstApp_NowLocalDL
{
    public partial class frmIssueDrivingLicenseFirstTime : Form
    {
        int _LDLApp;
        int _PersonID;
        clsBLManageFirstApp_NLDL _clsBLManageFirstApp;
        clsBLManageAllApplications _clsBLManageAll;
        clsBLManageUsers _clsBLManageUsers;
        clsBLManagePeople _clsBLManagePeople;
        clsBLManageAppType _clsBLAppType;
        clsBLManageDriver _clsBLManageDriver;
        clsBLManageLicenses _clsBLManageLicenses;

        public frmIssueDrivingLicenseFirstTime(int LDLApp)
        {
            InitializeComponent();
            _LDLApp = LDLApp;
        }

        private void _LoadData()
        {
            try
            {
                _clsBLManageFirstApp = clsBLManageFirstApp_NLDL.GetInfo(_LDLApp);
                _clsBLManageAll = clsBLManageAllApplications.GetInfo(_clsBLManageFirstApp.AppID);
                _clsBLManageUsers = clsBLManageUsers.GetUserInfoByUserID(_clsBLManageAll.CreatedByUserID);
                _PersonID = _clsBLManageAll.ApplicantPersonID;
                _clsBLManagePeople = clsBLManagePeople.GetPersonalInfo(_PersonID);
                _clsBLAppType = clsBLManageAppType.GetInfoByID(_clsBLManageAll.ApplicationTypeID);


                ctrlInfoTestCard1.LbAppTypeID = _clsBLManageFirstApp.LocalDrivingLicenseApplicationID.ToString();
                ctrlInfoTestCard1.LbClassName = clsBLManageFirstApp_NLDL.GetClassName(_clsBLManageFirstApp.ClassID);
                ctrlInfoTestCard1.LbPassedTest = clsBLManageTests.GetNumOfPassedTests(_LDLApp).ToString() + "/3";

                ctrlInfoTestCard1.LbAppID = _clsBLManageAll.ApplicationID.ToString();
                ctrlInfoTestCard1.LbStatus = _clsBLManageAll.ApplicationStatus == 1 ? "New" : "Error";
                ctrlInfoTestCard1.LbType = _clsBLAppType.ApplicationTypeTitle;
                ctrlInfoTestCard1.LbFees = _clsBLManageAll.PaidFees.ToString();
                ctrlInfoTestCard1.LbApplicantName = _clsBLManagePeople.FullName();
                ctrlInfoTestCard1.LbDate = _clsBLManageAll.ApplicationDate.Date.ToString("yyyy-MM-dd");
                ctrlInfoTestCard1.LbStatusDate = _clsBLManageAll.LastStatusDate.Date.ToString("yyyy-MM-dd");
                ctrlInfoTestCard1.LbCreatedByName = _clsBLManageUsers._UserName;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool _AddDriver()
        {
            _clsBLManageDriver = new clsBLManageDriver();

            _clsBLManageDriver.PersonID = _PersonID;
            _clsBLManageDriver.CreatedByUserID = _clsBLManageUsers.UserID;
            _clsBLManageDriver.CreatedDate = DateTime.Now;

            return _clsBLManageDriver.Add();
        }

        private bool _AddLicense()
        {
            _clsBLManageLicenses = new clsBLManageLicenses();
            _clsBLManageDriver = clsBLManageDriver.GetInfoByPersonID(_PersonID);
            _clsBLManageUsers = clsBLManageUsers.GetUserInfoByUserName(clsBLGlobalData.SharedUserName);

            _clsBLManageLicenses.ApplicationID = _clsBLManageFirstApp.AppID;
            _clsBLManageLicenses.DriverID = _clsBLManageDriver.DriverID;
            _clsBLManageLicenses.LicenseClass = _clsBLManageFirstApp.ClassID;
            _clsBLManageLicenses.IssueDate = DateTime.Now;
            _clsBLManageLicenses.ExpirationDate = _clsBLManageLicenses.IssueDate.AddYears(clsBLManageFirstApp_NLDL.GetValidityLength(_clsBLManageFirstApp.ClassID));
            _clsBLManageLicenses.Notes = txtNotes.Text;
            _clsBLManageLicenses.PaidFees = clsBLManageFirstApp_NLDL.GetClassFees(_clsBLManageFirstApp.ClassID);
            _clsBLManageLicenses.IsActive = true;
            _clsBLManageLicenses.IssueReason = 1;
            _clsBLManageLicenses.CreatedByUserID = _clsBLManageUsers.UserID;

            
            return _clsBLManageLicenses.AddLicense();
        }


        private void frmIssueDrivingLicenseFirstTime_Load(object sender, EventArgs e)
        {
            _LoadData();

            LinkLabel llViewInfo = ctrlInfoTestCard1.LlViewInfo;
            llViewInfo.Click += llViewInfo_Click;
        }

        private void llViewInfo_Click(object sender, EventArgs e)
        {
            if (_PersonID > 0)
            {
                frmShowPersonDetails frm = new frmShowPersonDetails(_PersonID);

                frm.ShowDialog();
            }
            else
                MessageBox.Show("Person ID is not set.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (clsBLManageTests.GetNumOfPassedTests(_LDLApp) == 3)
            {
                if (!clsBLManageDriver.IsExistByPersonID(_PersonID))
                {
                    if(_AddDriver() && _AddLicense())
                    {
                        clsBLManageAllApplications.CompleteProgramAndHasLicense(_clsBLManageAll.ApplicationID);
                        if(MessageBox.Show("License Issue Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                            this.Close();
                    }
                    else
                        MessageBox.Show("Error: License Issue is not done , because has error in AddDriver() or AddLicense() Function.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (_AddLicense())
                    {
                        clsBLManageAllApplications.CompleteProgramAndHasLicense(_clsBLManageAll.ApplicationID);
                        if (MessageBox.Show("License Issue Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                            this.Close();
                    }
                    else
                        MessageBox.Show("Error: License Issue is not done , because has error in AddLicense() Function.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("This person did not pass all three tests.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
