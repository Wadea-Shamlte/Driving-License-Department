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

namespace DVLD_System.ApplicationType_Form.FirstApp_NowLocalDL.Test_Forms
{
    public partial class frmTakeTest : Form
    {
        int _AppointmentID; int _TestTypeID;
        clsBLManageTestAppointments _clsBLManageTestAppointments;
        clsBLManageFirstApp_NLDL _clsBL_NLDL;
        clsBLManageAllApplications _clsBLManageAll;
        clsBLManagePeople _clsBLManagePeople;
        clsBLManageTests _clsBLManageTests;
        clsBLManageUsers _clsBLManageUsers;


        public frmTakeTest(int AppointmentID, int TestTypeID)
        {
            InitializeComponent();

            _AppointmentID = AppointmentID;
            _TestTypeID = TestTypeID;
        }

        private void _LoadData()
        {
            if (_TestTypeID == 2)
            {
                gbContener.Text = "Written Test";
                pbTopPage.Image = Resources.WrittenTest;
            }
            else if (_TestTypeID == 3)
            {
                gbContener.Text = "Street Test";
                pbTopPage.Image = Resources.StreetTest;
            }

            _clsBLManageTestAppointments = clsBLManageTestAppointments.GetInfo(_AppointmentID);
            _clsBL_NLDL = clsBLManageFirstApp_NLDL.GetInfo(_clsBLManageTestAppointments.LDLAppID);
            _clsBLManageAll = clsBLManageAllApplications.GetInfo(_clsBL_NLDL.AppID);
            _clsBLManagePeople = clsBLManagePeople.GetPersonalInfo(_clsBLManageAll.ApplicantPersonID);


            lbAppID.Text = _clsBLManageTestAppointments.LDLAppID.ToString();
            lbClassName.Text = clsBLManageFirstApp_NLDL.GetClassName(_clsBL_NLDL.ClassID);
            lbFullName.Text = _clsBLManagePeople.FullName();
            lbDate.Text = _clsBLManageTestAppointments.AppointmentDate.Date.ToString();
            lbFees.Text = _clsBLManageTestAppointments.PaidFees.ToString();

            int testID = clsBLManageTests.GetTestIDIfExist(_AppointmentID);
            if (testID != -1)
            {
                lbTestID.Text = testID.ToString();
            }
        }


        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _clsBLManageTests = new clsBLManageTests();
            _clsBLManageUsers = clsBLManageUsers.GetUserInfoByUserName(clsBLGlobalData.SharedUserName);

            _clsBLManageTests.TestAppointmentID = _AppointmentID;
            _clsBLManageTests.TestResult = rbPass.Checked ? (byte) 1: (byte) 0;
            _clsBLManageTests.Notes = txtNotes.Text;
            _clsBLManageTests.CreatedByUserID = _clsBLManageUsers.UserID;

            if(MessageBox.Show("Are you sure you want to save?After that you can't change the result Pass/Fail after save!", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsBLManageTestAppointments.UpdateStatusLooked(_AppointmentID, (byte)1))
                {
                    if(_clsBLManageTests.SaveResultTest())
                    {
                        if (MessageBox.Show("Data Saved Successfully . ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                            this.Close();
                    }
                    else
                        MessageBox.Show("Error: data save is failed . ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Error: data save in Test Appointments table is failed . ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
