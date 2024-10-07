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
    public partial class frmChangePassword : Form
    {
        int _ID;
        clsBLManagePeople _clsBLPerson;
        clsBLManageUsers clsBLUser;


        public frmChangePassword(int ID)
        {

            InitializeComponent();
            _ID = ID;
        }

        private void _LoadPersonData()
        {
            if (clsBLManagePeople.IsExist(_ID))
            {
                _clsBLPerson = clsBLManagePeople.GetPersonalInfo(_ID);

                ctrlUserCard1.LbPersonalId = _clsBLPerson.ID.ToString();
                ctrlUserCard1.LbNationalNo = _clsBLPerson.NationalNo;
                ctrlUserCard1.LbName = _clsBLPerson.FullName();
                ctrlUserCard1.LbEmail = _clsBLPerson.Email;
                ctrlUserCard1.LbPhone = _clsBLPerson.Phone;
                ctrlUserCard1.LbBirth = _clsBLPerson.DateOfBirth.ToString();
                ctrlUserCard1.LbAddress = _clsBLPerson.Address;
                if (_clsBLPerson.Gender == 0)
                    ctrlUserCard1.LbGender = "Male";
                else
                    ctrlUserCard1.LbGender = "Female";
                ctrlUserCard1.LbCountryName = _clsBLPerson.CountryName;
                if (_clsBLPerson.ImagePath != "")
                    ctrlUserCard1.PbPersonalPicture.Load(_clsBLPerson.ImagePath);
                else
                {
                    if (_clsBLPerson.Gender == 0)
                        ctrlUserCard1.PbPersonalPicture.Image = Resources.Man;
                    else
                        ctrlUserCard1.PbPersonalPicture.Image = Resources.Woman;
                }
            }
            else
                MessageBox.Show("The Person with the " + _ID + " has no Information .", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
        private void _LoadUserData()
        {
            clsBLUser = clsBLManageUsers.GetUserInfoByPersonID(_ID);
            if (clsBLManageUsers.IsExist(_ID))
            {
                ctrlUserCard1.LbID = clsBLUser.UserID.ToString();
                ctrlUserCard1.LbUserName = clsBLUser._UserName.ToString();
                ctrlUserCard1.LbIsActive = clsBLUser.IsActive.ToString();
            }
            else
                MessageBox.Show("The Person with the " + _ID + " has no Information .", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private bool _ValidatePassword()
        {
            bool hasError = false;

            if (txtCurrentPass.Text != clsBLUser._Password)
            {
                errorProvider1.SetError(txtCurrentPass, "Invalid Password . ");
                MessageBox.Show("Invalid Password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            else
            {
                if (txtNewPass.Text != txtConfirmPass.Text)
                {
                    MessageBox.Show("Password Is not Matched . ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    errorProvider1.SetError(txtNewPass, "Password Is not Matched . ");
                    return true;
                }
                else if (txtConfirmPass.Text != txtNewPass.Text)
                {
                    MessageBox.Show("Password Is not Matched . ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    errorProvider1.SetError(txtCurrentPass, "Password Is not Matched . ");
                    return true;
                }
            }

            if (!hasError)
                errorProvider1.Clear();

            return hasError;

        }


        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _LoadPersonData();
            _LoadUserData();

            LinkLabel llEditPersonInfo = ctrlUserCard1.LlEditPersonInfo;
            llEditPersonInfo.Click += llEditPersonInfo_Click;
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

        private void btnSaveDataForm_Click(object sender, EventArgs e)
        {
            if (_ValidatePassword())
                return;

            if (txtNewPass.Text == "" || txtConfirmPass.Text == "")
                MessageBox.Show("There is Empty text. !");
            else
            {
                clsBLUser._Password = txtCurrentPass.Text.ToString();
                if (clsBLUser._Update())
                    MessageBox.Show("The Process Change Password is Successfully .", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("The Process Change Password is Not Done .", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
