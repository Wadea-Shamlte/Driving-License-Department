using DVLD_BusinessLayer;
using DVLD_System.My_Controls;
using DVLD_System.Properties;
using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_System.ApplicationType_Form.FirstApp_NowLocalDL.Test_Forms
{
    public partial class frmSchedulingTest : Form
    {
        int _LDLApp;
        int _AppointmentID; int _TestTypeID;

        clsBLManageFirstApp_NLDL _clsBL_NLDL = new clsBLManageFirstApp_NLDL();
        clsBLManageAllApplications _clsBLManageAll = new clsBLManageAllApplications();
        clsBLManagePeople _clsBLManagePeople = new clsBLManagePeople();
        clsBLManageTestType _clsBLManageTestType = new clsBLManageTestType();
        clsBLManageTestAppointments _clsBLManageTestAppointments = new clsBLManageTestAppointments();


        enum enMode { Add = 0 , Update = 1 }
        enMode _Mode;

        public frmSchedulingTest(int AppointmentID, int TestTypeID , int LDLApp)
        {
            InitializeComponent();

            _AppointmentID = AppointmentID;
            _TestTypeID = TestTypeID;
            _LDLApp = LDLApp;
            

            if( AppointmentID == -1 )
                _Mode = enMode.Add;
            else 
                _Mode = enMode.Update;
        }


        private void IsFailed()
        {
            if (clsBLManageTestAppointments.IsFailed(_LDLApp, _TestTypeID))
            {
                gbRetakeTest.Enabled = true;
                lbRAppFees.Text = clsBLManageAppType.GetFeesRetakeTestApp().ToString();
                lbTotalFees.Text = (decimal.Parse(lbFees.Text) + decimal.Parse(lbRAppFees.Text)).ToString();
            }
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

            _clsBL_NLDL = clsBLManageFirstApp_NLDL.GetInfo(_LDLApp);
            _clsBLManageAll = clsBLManageAllApplications.GetInfo(_clsBL_NLDL.AppID);
            _clsBLManagePeople = clsBLManagePeople.GetPersonalInfo(_clsBLManageAll.ApplicantPersonID);

            lbAppID.Text = _clsBL_NLDL.LocalDrivingLicenseApplicationID.ToString();
            lbClassName.Text = clsBLManageFirstApp_NLDL.GetClassName(_clsBL_NLDL.ClassID);
            lbFullName.Text = _clsBLManagePeople.FullName();

            if (_Mode == enMode.Add)
            {
                
                _clsBLManageTestType = clsBLManageTestType.GetTestTypeInfo(_TestTypeID);
                lbFees.Text = _clsBLManageTestType.TestTypeFees.ToString();
                IsFailed();
            }
            else
            {
                
                _clsBLManageTestAppointments = clsBLManageTestAppointments.GetInfo(_AppointmentID);
                dateTimePicker1.Value = _clsBLManageTestAppointments.AppointmentDate;
                lbFees.Text = _clsBLManageTestAppointments.PaidFees.ToString();

                if (_clsBLManageTestAppointments.IsLocked == true)
                {
                    lbLooked.Visible = true;
                    dateTimePicker1.Enabled = false;
                    btnSave.Enabled = false;
                }

                IsFailed();
            }

        }

        private void frmTestScheduling_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            clsBLManageUsers _clsBLManageUsers = clsBLManageUsers.GetUserInfoByUserName(clsBLGlobalData.SharedUserName);
            _clsBLManageTestAppointments.TestTypeID = _TestTypeID;
            _clsBLManageTestAppointments.LDLAppID = _LDLApp;
            _clsBLManageTestAppointments.AppointmentDate = dateTimePicker1.Value;
            
            _clsBLManageTestAppointments.CreatedByUserID = _clsBLManageUsers.UserID;


            if (_Mode == enMode.Add)
            {
                if(gbRetakeTest.Enabled)
                    _clsBLManageTestAppointments.PaidFees = decimal.Parse(lbTotalFees.Text);
                else
                    _clsBLManageTestAppointments.PaidFees = decimal.Parse(lbFees.Text);
                _clsBLManageTestAppointments.IsLocked = false;

                if (_clsBLManageTestAppointments._Add())
                {
                    if (MessageBox.Show("The Process Add is done Successfully .", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        this.Close();
                }
                else
                    MessageBox.Show("The Process Add is Not Worked !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _clsBLManageTestAppointments.TestAppointmentID = _AppointmentID;
                if (_clsBLManageTestAppointments._Update())
                {
                    if (MessageBox.Show("The Process Edit is done Successfully .", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        this.Close();
                }
                else
                    MessageBox.Show("The Process Edit is Not Worked !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
