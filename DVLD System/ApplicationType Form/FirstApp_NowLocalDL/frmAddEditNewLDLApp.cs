using DVLD_BusinessLayer;
using DVLD_System.People_Forms;
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

namespace DVLD_System.ApplicationType_Form.FirstApp_NowLocalDL
{
    public partial class frmAddEditNewLDLApp : Form
    {
        int _LocalDrivingLicenseApplicationsID;
        clsBLManagePeople _clsBLManagePerson = new clsBLManagePeople(); 
        clsBLManageUsers _clsBLManageUsers = new clsBLManageUsers();
        clsBLManageAllApplications _clsBLManageAll = new clsBLManageAllApplications();
        clsBLManageFirstApp_NLDL _clsBLManageFirstApp = new clsBLManageFirstApp_NLDL();

        enum enMode { Update = 0, Add = 1 }
        enMode Mode = enMode.Add;

        public frmAddEditNewLDLApp(int localDrivingLicenseApplications)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationsID = localDrivingLicenseApplications;

            if (_LocalDrivingLicenseApplicationsID == -1)
                Mode = enMode.Add;
            else
                Mode = enMode.Update;
        }


        
        private void _LoadPersonalInfo()
        {
            ctrlPeopleCardAsFilter1.LbPersonalId = _clsBLManagePerson.ID.ToString();
            ctrlPeopleCardAsFilter1.LbNationalNo = _clsBLManagePerson.NationalNo;
            ctrlPeopleCardAsFilter1.LbName = _clsBLManagePerson.FullName();
            ctrlPeopleCardAsFilter1.LbEmail = _clsBLManagePerson.Email;
            ctrlPeopleCardAsFilter1.LbPhone = _clsBLManagePerson.Phone;
            ctrlPeopleCardAsFilter1.LbBirth = _clsBLManagePerson.DateOfBirth.ToString();
            ctrlPeopleCardAsFilter1.LbAddress = _clsBLManagePerson.Address;
            if (_clsBLManagePerson.Gender == 0)
                ctrlPeopleCardAsFilter1.LbGender = "Male";
            else
                ctrlPeopleCardAsFilter1.LbGender = "Female";
            ctrlPeopleCardAsFilter1.LbCountryName = _clsBLManagePerson.CountryName;
            if (_clsBLManagePerson.ImagePath != "")
                ctrlPeopleCardAsFilter1.PbPersonalPicture.Load(_clsBLManagePerson.ImagePath);
            else
            {
                if (_clsBLManagePerson.Gender == 0)
                    ctrlPeopleCardAsFilter1.PbPersonalPicture.Image = Resources.Man;
                else
                    ctrlPeopleCardAsFilter1.PbPersonalPicture.Image = Resources.Woman;
            }
        }

        private void _LoadData()
        {

            if (Mode == enMode.Add)
            {
                lbTittel.Text = "New Local Driving License";
                return;
            }
            else
            {
                _clsBLManageFirstApp = clsBLManageFirstApp_NLDL.GetInfo(_LocalDrivingLicenseApplicationsID);
                _clsBLManageAll = clsBLManageAllApplications.GetInfo(_clsBLManageFirstApp.AppID);
                _clsBLManagePerson = clsBLManagePeople.GetPersonalInfo(_clsBLManageAll.ApplicantPersonID);
                _clsBLManageUsers = clsBLManageUsers.GetUserInfoByUserID(_clsBLManageAll.CreatedByUserID);

                ctrlPeopleCardAsFilter1.TxtDataEnterByUser = _clsBLManagePerson.ID.ToString();
                ctrlPeopleCardAsFilter1.TxTDataEnterByUser.Enabled = false;
                ctrlPeopleCardAsFilter1.CbFilter.Enabled = false;
                ctrlPeopleCardAsFilter1.BtnAddNew.Enabled = false;
                ctrlPeopleCardAsFilter1.BtnGetData.Enabled = false;
                _LoadPersonalInfo();

                lbDlAppID.Text = _clsBLManageAll.ApplicationID.ToString();
                lbApplicationDate.Text = _clsBLManageAll.ApplicationDate.ToString();

                cbLicenseClass.SelectedIndex = _clsBLManageFirstApp.ClassID - 1;

                lbApplicationFees.Text = _clsBLManageAll.PaidFees.ToString();
                lbCreatedBy.Text = _clsBLManageUsers._UserName.ToString();


            }

        }



        private void frmAddEditNewLDLApp_Load(object sender, EventArgs e)
        {
            _LoadData();

            Button btnGetData = ctrlPeopleCardAsFilter1.BtnGetData;
            if (btnGetData != null)
            {
                btnGetData.Click += btnGetData_Click1;
            }

            Button btnAddNew = ctrlPeopleCardAsFilter1.BtnAddNew;
            if (btnAddNew != null)
            {
                btnAddNew.Click += btnAddNew_Click1;
            }

            LinkLabel llEditPersonInfo = ctrlPeopleCardAsFilter1.LlEditPersonInfo;
            if (llEditPersonInfo != null)
            {
                llEditPersonInfo.Click += llEditPersonInfo_Click;
            }
        }


        private void btnGetData_Click1(object sender, EventArgs e)
        {
            bool isExist = false;
            string userInput = ctrlPeopleCardAsFilter1.TxtDataEnterByUser;

            try
            {
                if (ctrlPeopleCardAsFilter1.CbFilter.SelectedIndex == 0)
                {
                    if (int.TryParse(userInput, out int userId))
                    {
                        isExist = clsBLManagePeople.IsExist(userId);
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid numeric ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (ctrlPeopleCardAsFilter1.CbFilter.SelectedIndex == 1)
                {
                    isExist = clsBLManagePeople.IsExist(userInput);
                }

                if (isExist)
                {
                    if (ctrlPeopleCardAsFilter1.CbFilter.SelectedIndex == 0)
                    {
                        _clsBLManagePerson = clsBLManagePeople.GetPersonalInfo(int.Parse(userInput));
                    }
                    else
                    {
                        _clsBLManagePerson = clsBLManagePeople.GetPersonalInfo(userInput);
                    }
                    _LoadPersonalInfo();
                }
                else
                {
                    MessageBox.Show("The person you are looking for is not available.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddNew_Click1(object sender, EventArgs e)
        {
            try
            {
                frmAddEditPersonInfo frm = new frmAddEditPersonInfo(-1);
                frm.dataBack += frmDataBack_DataBack;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void llEditPersonInfo_Click(object sender, EventArgs e)
        {
            if (_clsBLManagePerson.ID >= 1)
            {
                frmAddEditPersonInfo frm = new frmAddEditPersonInfo(_clsBLManagePerson.ID);
                frm.ShowDialog();
                _LoadPersonalInfo();
            }
        }


        private void frmDataBack_DataBack(object sender, int PersonID)
        {
            ctrlPeopleCardAsFilter1.TxtDataEnterByUser = PersonID.ToString();
            _LoadData();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (_clsBLManagePerson.ID >= 1)
            {
                tbcLDLAppData.SelectedTab = tpApplicationInfo;
                btnSave.Enabled = true;


                lbApplicationDate.Text = DateTime.Now.Date.ToString();
                cbLicenseClass.SelectedIndex = 0;
                lbApplicationFees.Text = clsBLGlobalData.GetFeesApplication(1).ToString();
                lbCreatedBy.Text = clsBLGlobalData.SharedUserName.ToString();
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            _clsBLManageAll.ApplicantPersonID = int.Parse(ctrlPeopleCardAsFilter1.LbPersonalId);
            _clsBLManageAll.ApplicationTypeID = 1;
            _clsBLManageAll.ApplicationStatus = 1;
            _clsBLManageAll.LastStatusDate = DateTime.Now;
            _clsBLManageAll.ApplicationDate = Convert.ToDateTime(lbApplicationDate.Text);
            _clsBLManageAll.PaidFees = decimal.Parse(lbApplicationFees.Text);
            _clsBLManageUsers = clsBLManageUsers.GetUserInfoByUserName(lbCreatedBy.Text);
            _clsBLManageAll.CreatedByUserID = _clsBLManageUsers.UserID;
            int LicenseClass = int.Parse(cbLicenseClass.SelectedIndex.ToString()) + 1;
            _clsBLManageFirstApp.ClassID = LicenseClass;

            if (Mode == enMode.Add)
            {
                if (!clsBLManageAllApplications.IsExist(int.Parse(ctrlPeopleCardAsFilter1.LbPersonalId) , LicenseClass, 1))
                {
                    if (!clsBLManageAllApplications.IsExist(int.Parse(ctrlPeopleCardAsFilter1.LbPersonalId), LicenseClass, 3))
                    {
                        if (_clsBLManageAll.Add())
                        {
                            _clsBLManageFirstApp.AppID = clsBLManageAllApplications.GetLastID();
                            if (_clsBLManageFirstApp.AddLocalDrivingLicenseApplications())
                            {
                                if (MessageBox.Show("The Process Add is done Successfully .", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                                    this.Close();
                            }
                        }
                        else
                            MessageBox.Show("The Process Add is Not Worked !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Error: This person is already have license from this class.Please choose another class", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("Error: This person already has an active appointment in this class.Please choose another class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _clsBLManageFirstApp.AppID = int.Parse(lbDlAppID.Text.ToString());
                if (_clsBLManageAll.Update() && _clsBLManageFirstApp.UpdateLocalDrivingLicenseApplications())
                {
                    if (MessageBox.Show("The Process Edit is done Successfully .", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        this.Close();
                }
                else
                    MessageBox.Show("The Process Edit is Not Worked !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
