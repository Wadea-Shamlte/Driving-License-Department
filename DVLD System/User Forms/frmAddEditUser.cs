using DVLD_BusinessLayer;
using DVLD_System.My_Controls;
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

namespace DVLD_System.User_Forms
{
    public partial class frmAddEditUser : Form
    {
        int _PersonId;
        clsBLManagePeople _clsBLPerson = new clsBLManagePeople();
        clsBLManageUsers _clsBLUser = new clsBLManageUsers();

        enum enMode { Update = 0, Add = 1 }
        enMode Mode = enMode.Add;

        public frmAddEditUser(int PersonId)
        {
            InitializeComponent();
            _PersonId = PersonId;

            if (PersonId == -1)
                Mode = enMode.Add;
            else
                Mode = enMode.Update;
        }

        private void _LoadPersonData()
        {
            ctrlPeopleCardAsFilter1.LbPersonalId = _clsBLPerson.ID.ToString();
            ctrlPeopleCardAsFilter1.LbNationalNo = _clsBLPerson.NationalNo;
            ctrlPeopleCardAsFilter1.LbName = _clsBLPerson.FullName();
            ctrlPeopleCardAsFilter1.LbEmail = _clsBLPerson.Email;
            ctrlPeopleCardAsFilter1.LbPhone = _clsBLPerson.Phone;
            ctrlPeopleCardAsFilter1.LbBirth = _clsBLPerson.DateOfBirth.ToString();
            ctrlPeopleCardAsFilter1.LbAddress = _clsBLPerson.Address;
            if (_clsBLPerson.Gender == 0)
                ctrlPeopleCardAsFilter1.LbGender = "Male";
            else
                ctrlPeopleCardAsFilter1.LbGender = "Female";
            ctrlPeopleCardAsFilter1.LbCountryName = _clsBLPerson.CountryName;
            if (_clsBLPerson.ImagePath != "")
                ctrlPeopleCardAsFilter1.PbPersonalPicture.Load(_clsBLPerson.ImagePath);
            else
            {
                if (_clsBLPerson.Gender == 0)
                    ctrlPeopleCardAsFilter1.PbPersonalPicture.Image = Resources.Man;
                else
                    ctrlPeopleCardAsFilter1.PbPersonalPicture.Image = Resources.Woman;
            }
        }
        private void _LoadUserPData()
        {
            txtUserName.Text = _clsBLUser._UserName.ToString();
            txtPassword.Text = _clsBLUser._Password.ToString();
            txtConfirmePassword.Text = _clsBLUser._Password.ToString();
        }
        private void _LoadData()
        {

            if (Mode == enMode.Add)
            {
                lbTittel.Text = "Add User";
                return;
            }
            else
            {
                _clsBLPerson = clsBLManagePeople.GetPersonalInfo(_PersonId);

                ctrlPeopleCardAsFilter1.TxtDataEnterByUser = _PersonId.ToString();
                ctrlPeopleCardAsFilter1.TxTDataEnterByUser.Enabled = false;
                ctrlPeopleCardAsFilter1.CbFilter.Enabled = false;
                ctrlPeopleCardAsFilter1.BtnAddNew.Enabled = false;
                ctrlPeopleCardAsFilter1.BtnGetData.Enabled = false;
                _LoadPersonData();

                _clsBLUser = clsBLManageUsers.GetUserInfoByPersonID(_PersonId);
                _LoadUserPData();


            }

        }


        private bool _ValidateUserNameTextBox()
        {
            DataTable table = clsBLManageUsers.GetAllUserName();
            bool HasError = false;

            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                errorProvider1.SetError(txtUserName, "Filling the field is required.");
                return true;
            }
            else
            {
                foreach (DataRow row in table.Rows)
                {
                    if (txtUserName.Text == row["UserName"].ToString())
                    {
                        errorProvider1.SetError(txtUserName, "The value you entered exists.\nPlease enter another value such as ");
                        return true;
                    }
                }
            }
            if (!HasError)
                errorProvider1.Clear();

            return HasError;
        }
        private bool _ValidatePasswordMatch()
        {
            bool hasError = false;

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "Filling the field is required.");
                return true;
            }
            else
            {
                if (txtPassword.Text != txtConfirmePassword.Text)
                {
                    errorProvider1.SetError(txtPassword, "Password Is not Matched . ");
                    return true;
                }
                else if (txtConfirmePassword.Text != txtPassword.Text)
                {
                    errorProvider1.SetError(txtConfirmePassword, "Password Is not Matched . ");
                    return true;
                }
            }

            if (!hasError)
                errorProvider1.Clear();
            return hasError;
        }




        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            _LoadData();
            Button btnGetData = ctrlPeopleCardAsFilter1.BtnGetData;
            btnGetData.Click += btnGetData_Click;
            Button btnAddNew = ctrlPeopleCardAsFilter1.BtnAddNew;
            btnAddNew.Click += btnAddNew_Click;

            LinkLabel llEditPersonInfo = ctrlPeopleCardAsFilter1.LlEditPersonInfo;
            llEditPersonInfo.Click += llEditPersonInfo_Click;
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            bool isExist = false;
            if (ctrlPeopleCardAsFilter1.CbFilter.SelectedIndex == 0)
                isExist = clsBLManagePeople.IsExist(int.Parse(ctrlPeopleCardAsFilter1.TxtDataEnterByUser));
            else if (ctrlPeopleCardAsFilter1.CbFilter.SelectedIndex == 1)
            {
                isExist = clsBLManagePeople.IsExist(ctrlPeopleCardAsFilter1.TxtDataEnterByUser.ToString());
            }

            if (isExist)
            {
                if (ctrlPeopleCardAsFilter1.CbFilter.SelectedIndex == 0)
                {
                    _clsBLPerson = clsBLManagePeople.GetPersonalInfo(int.Parse(ctrlPeopleCardAsFilter1.TxtDataEnterByUser));
                }
                else
                {
                    _clsBLPerson = clsBLManagePeople.GetPersonalInfo(ctrlPeopleCardAsFilter1.TxtDataEnterByUser);
                }
                _LoadPersonData();
            }
            else
            {
                MessageBox.Show("The person you are looking for is not available.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnAddNew_Click(object sender, EventArgs e)
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
        private void frmDataBack_DataBack(object sender, int PersonID)
        {
            ctrlPeopleCardAsFilter1.TxtDataEnterByUser = PersonID.ToString();
            _LoadData();
        }
        private void btnNextPage_Click(object sender, EventArgs e)
        {

            if (_clsBLPerson.ID >= 1 && ctrlPeopleCardAsFilter1.TxTDataEnterByUser.Enabled)
            {
                if (clsBLManageUsers.IsExist(int.Parse(ctrlPeopleCardAsFilter1.LbPersonalId)))
                {
                    MessageBox.Show("User already Exists .", "Message");
                    return;
                }

                tbcUserData.SelectedTab = tpLoginInfo;
                btnSave.Enabled = true;
                return;
            }
            tbcUserData.SelectedTab = tpLoginInfo;
            btnSave.Enabled = true;
        }
        private void llEditPersonInfo_Click(object sender, EventArgs e)
        {
            if (_clsBLPerson.ID >= 1)
            {
                frmAddEditPersonInfo frm = new frmAddEditPersonInfo(_clsBLPerson.ID);
                frm.ShowDialog();
                _LoadPersonData();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (_ValidateUserNameTextBox() && txtUserName.Text != _clsBLUser._UserName)
            {
                MessageBox.Show("Invalid UserName .", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (_ValidatePasswordMatch())
            {
                MessageBox.Show("The Password is Not Matched . ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                _clsBLUser.PersonID = Convert.ToInt32(ctrlPeopleCardAsFilter1.LbPersonalId);
                _clsBLUser._UserName = txtUserName.Text.Trim();
                _clsBLUser._Password = txtConfirmePassword.Text.Trim();
                _clsBLUser.IsActive = cbIsActive.Checked ? 1 : 0;

                if (Mode == enMode.Add)
                {
                    if (_clsBLUser._Add())
                    {
                        if (MessageBox.Show("User Add Process is done Successfully .", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                            this.Close();
                    }
                    else
                        MessageBox.Show("The Process Add is Not Worked !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (_clsBLUser._Update() && MessageBox.Show("User Update Process is done Successfully .", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        this.Close();
                    else
                        MessageBox.Show("The Process Update is Not Worked !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
