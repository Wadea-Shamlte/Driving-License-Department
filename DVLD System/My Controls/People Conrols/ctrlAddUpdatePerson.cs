using DVLD_System.Properties;
using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_System.My_Controls
{
    public partial class ctrlAddUpdatePerson : UserControl
    {
        public ctrlAddUpdatePerson()
        {
            InitializeComponent();
        }

        static public string _ImagePath = "";
        private void _SetDateTimePicker()
        {
            DateTime today = DateTime.Today;
            DateTime maxDate = today.AddYears(-18);
            dateTimePicker1.MaxDate = maxDate;
        }
        private void _LoadToCountryData()
        {
            DataTable dataTable = clsBLCountries.GetAllCountries();
            cbCountry.Text = "None";
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                string countryName = dataTable.Rows[i]["CountryName"].ToString();
                cbCountry.Items.Add(countryName);
            }
        }
        private void _ImageSetting()
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _ImagePath = openFileDialog1.FileName;

                pbPersonalPic.Load(_ImagePath);
                llRemoveImage.Visible = true;
            }
        }




        public string TxtFirstName
        {
            set { txtFirstName.Text = value; }
            get { return txtFirstName.Text.ToString(); }
        }
        public string TxtSecondName
        {
            set { txtSecondName.Text = value; }
            get { return txtSecondName.Text.ToString(); }
        }
        public string TxtThirdName
        {
            set { txtThirdName.Text = value; }
            get { return txtThirdName.Text.ToString(); }
        }
        public string TxtFourthName
        {
            set { txtFourthName.Text = value; }
            get { return txtFourthName.Text.ToString(); }
        }
        public string TxtNationalNo
        {
            set { txtNationalNo.Text = value; }
            get { return txtNationalNo.Text.ToString(); }
        }
        public TextBox TxTNationalNo
        {
            get { return txtNationalNo; }
        }
        public string TxtEmail
        {
            set { txtEmail.Text = value; }
            get { return txtEmail.Text.ToString(); }
        }
        public DateTimePicker MyDateTimePicker
        {
            get { return dateTimePicker1; }
        }
        public RadioButton RbMale
        {
            get { return rbMale; }
        }
        public RadioButton RbFemale
        {
            get { return rbFemale; }
        }
        public string TxtPhone
        {
            set { txtPhone.Text = value; }
            get { return txtPhone.Text.ToString(); }
        }
        public string TxtAddress
        {
            set { txtAddress.Text = value; }
            get { return txtAddress.Text.ToString(); }
        }
        public string CbCountry
        {
            get { return cbCountry.Text; }
            set { cbCountry.Text = value; }
        }
        public ComboBox cbCountries
        {
            get { return cbCountry; }
        }
        public string dateTimePicker
        {
            get { return dateTimePicker1.Text; }
            set { dateTimePicker1.Text = value; }
        }
        public PictureBox PbImage
        {
            get { return pbPersonalPic; }
        }
        public Button CloseForm
        {
            get { return btnCloseForm; }
        }
        public Button Save
        {
            get { return btnSaveDataForm; }
        }



        
        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Filling the field is required .");
            }
            else if (!Regex.IsMatch(txtEmail.Text, emailPattern))
            {
                errorProvider1.SetError(txtEmail, "Please enter a valid email address.");
            }
        }


        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (_ImagePath == "")
                pbPersonalPic.Image = Resources.Man;
        }
        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (_ImagePath == "")
                pbPersonalPic.Image = Resources.Woman;
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ImageSetting();
        }
        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonalPic.Image = null;
            _ImagePath = "";
            if (rbMale.Checked)
                pbPersonalPic.Image = Resources.Man;
            else
                pbPersonalPic.Image = Resources.Woman;

        }

        private void ctrlAddUpdatePerson_Load(object sender, EventArgs e)
        {
            _SetDateTimePicker();
            _LoadToCountryData();
        }

    }
}
