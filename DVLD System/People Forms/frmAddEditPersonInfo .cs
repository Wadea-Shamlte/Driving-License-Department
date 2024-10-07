using DVLD_System.My_Controls;
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

namespace DVLD_System.People_Forms
{
    public partial class frmAddEditPersonInfo : Form
    {
        
        int _PersonalID;
        clsBLManagePeople clsBL;

        enum enMode { Update = 0, Add = 1 }
        enMode Mode = enMode.Add; 

        public delegate void DataBack(object sender, int PersonID);
        public event DataBack dataBack;

        public frmAddEditPersonInfo(int ID)
        {
            InitializeComponent();
            _PersonalID = ID;

            if (ID == -1)
                Mode = enMode.Add;
            else
                Mode = enMode.Update;

        }


        private void _LoadModePage()
        {
            if (Mode == enMode.Add)
            {
                clsBL = new clsBLManagePeople();
                lbTiteleFrm.Text = "Add Person";
                return;
            }

            if (!clsBLManagePeople.IsExist(_PersonalID))
            {
                MessageBox.Show("This form will be closed because No Person with ID = " + _PersonalID);
                this.Close();
                return;
            }

            clsBL = clsBLManagePeople.GetPersonalInfo(_PersonalID);
            lbPersonID.Text = _PersonalID.ToString();
            ctrlAddUpdatePerson1.TxtFirstName = clsBL.FName;
            ctrlAddUpdatePerson1.TxtSecondName = clsBL.SName;
            ctrlAddUpdatePerson1.TxtThirdName = clsBL.ThName;
            ctrlAddUpdatePerson1.TxtFourthName = clsBL.LName;
            ctrlAddUpdatePerson1.TxtNationalNo = clsBL.NationalNo;
            if (clsBL.Gender == 0)
                ctrlAddUpdatePerson1.RbMale.Checked = true;
            else if (clsBL.Gender == 1)
                ctrlAddUpdatePerson1.RbFemale.Checked = true;
            ctrlAddUpdatePerson1.TxtEmail = clsBL.Email;
            ctrlAddUpdatePerson1.TxtPhone = clsBL.Phone;
            ctrlAddUpdatePerson1.TxtAddress = clsBL.Address;
            ctrlAddUpdatePerson1.dateTimePicker = clsBL.DateOfBirth.ToString();
            ctrlAddUpdatePerson1.CbCountry = clsBL.CountryName;
            if (clsBL.ImagePath != "")
                ctrlAddUpdatePerson1.PbImage.Load(clsBL.ImagePath);
        }
        private void _UpdateData(int CountryID)
        {
            clsBL.ID = _PersonalID;
            clsBL.FName = ctrlAddUpdatePerson1.TxtFirstName;
            clsBL.SName = ctrlAddUpdatePerson1.TxtSecondName;
            clsBL.ThName = ctrlAddUpdatePerson1.TxtThirdName;
            clsBL.LName = ctrlAddUpdatePerson1.TxtFourthName;
            clsBL.NationalNo = ctrlAddUpdatePerson1.TxtNationalNo;
            clsBL.Email = ctrlAddUpdatePerson1.TxtEmail;
            clsBL.Phone = ctrlAddUpdatePerson1.TxtPhone;
            clsBL.Address = ctrlAddUpdatePerson1.TxtAddress;
            clsBL.DateOfBirth = Convert.ToDateTime(ctrlAddUpdatePerson1.dateTimePicker);
            clsBL.CountryID = CountryID;
            clsBL.Gender = ctrlAddUpdatePerson1.RbMale.Checked ? 0 : 1;
            clsBL.ImagePath = ctrlAddUpdatePerson._ImagePath;

            if (clsBL._Save())
            {
                if (MessageBox.Show("The Process is Successfully . ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("The process save is not completed . ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        

        private void frmAddEditPersonInfo_Load(object sender, EventArgs e)
        {
            _LoadModePage();
            ComboBox cbCountry = ctrlAddUpdatePerson1.cbCountries;
            cbCountry.SelectedIndex = 89;

            Button btnCloseForm = ctrlAddUpdatePerson1.CloseForm;
            btnCloseForm.Click += btnCloseForm_Click;

            Button btnSave = ctrlAddUpdatePerson1.Save;
            btnSave.Click += btnSave_Click;
        }


        private string IncrementNationalNo(string nationalNo)
        {
            if (nationalNo.StartsWith("N") && int.TryParse(nationalNo.Substring(1), out int number))
            {
                return "N" + (number + 1).ToString();
            }

            if (int.TryParse(nationalNo, out number))
            {
                return (number + 1).ToString();
            }

            return nationalNo;
        }

        private bool ValidateNationalNo(string txtNo, DataTable table)
        {
            if (string.IsNullOrEmpty(txtNo))
            {
                errorProvider1.SetError(ctrlAddUpdatePerson1.TxTNationalNo, "Filling the field is required.");
                return false;
            }

            foreach (DataRow row in table.Rows)
            {
                if (txtNo == row["NationalNo"].ToString())
                {
                    string nextNationalNo = IncrementNationalNo(table.AsEnumerable().Last()["NationalNo"].ToString());
                    errorProvider1.SetError(ctrlAddUpdatePerson1.TxTNationalNo, $"The value you entered exists.\nPlease enter another value such as {nextNationalNo}");
                    return false;
                }
            }

            errorProvider1.Clear();
            return true;
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrEmpty(ctrlAddUpdatePerson1.TxtFirstName) ||
                string.IsNullOrEmpty(ctrlAddUpdatePerson1.TxtSecondName) ||
                string.IsNullOrEmpty(ctrlAddUpdatePerson1.TxtFourthName) ||
                string.IsNullOrEmpty(ctrlAddUpdatePerson1.TxtAddress) ||
                string.IsNullOrEmpty(ctrlAddUpdatePerson1.TxtPhone) ||
                string.IsNullOrEmpty(ctrlAddUpdatePerson1.TxtNationalNo))
            {
                MessageBox.Show("There is Empty text. !" , "Warning", MessageBoxButtons.OK , MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int CountryID = clsBLCountries.GetCountryID(ctrlAddUpdatePerson1.CbCountry);

            if (!ValidateFields())
            {
                return;
            }
            if (!ValidateNationalNo(ctrlAddUpdatePerson1.TxtNationalNo, clsBLManagePeople.GetAllNationalNo()))
            {
                if (clsBL.NationalNo == ctrlAddUpdatePerson1.TxtNationalNo)
                {
                    _UpdateData(CountryID);
                    return;
                }
                else
                {
                    MessageBox.Show("Invalid Input NationalNo Filled !" , "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
                _UpdateData(CountryID);

            _PersonalID = clsBLManagePeople.GetIDByNationalNo(clsBL.NationalNo);
            dataBack?.Invoke(this, _PersonalID);
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {

            this.Close();
        }
    }
}
