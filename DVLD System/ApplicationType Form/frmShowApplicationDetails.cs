using DVLD_BusinessLayer;
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

namespace DVLD_System.ApplicationType_Form
{
    public partial class frmShowApplicationDetails : Form
    {
        int _LDLApp;
        int _PersonID;
        clsBLManageFirstApp_NLDL _clsBLManageFirstApp;
        clsBLManageAllApplications _clsBLManageAll;
        clsBLManageUsers _clsBLManageUsers;
        clsBLManagePeople _clsBLManagePeople;
        clsBLManageAppType _clsBLAppType;

        public frmShowApplicationDetails(int LDLApp)
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



        private void frmShowApplicationDetails_Load(object sender, EventArgs e)
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
