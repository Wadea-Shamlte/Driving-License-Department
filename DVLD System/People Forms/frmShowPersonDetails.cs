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

namespace DVLD_System.People_Forms
{
    public partial class frmShowPersonDetails : Form
    {
        int _PersonID;
        clsBLManagePeople _clsBL;

        public frmShowPersonDetails(int ID)
        {
            InitializeComponent();
            _PersonID = ID;
        }

        void _LoadToDataPerson()
        {
            if (!clsBLManagePeople.IsExist(_PersonID))
            {
                MessageBox.Show("This form will be closed because No Person with ID = " + _PersonID);
                return;
            }
            _clsBL = clsBLManagePeople.GetPersonalInfo(_PersonID);

            ctrlPeopleCard1.LbPersonalId = _PersonID.ToString();
            ctrlPeopleCard1.LbNationalNo = _clsBL.NationalNo;
            ctrlPeopleCard1.LbName = _clsBL.FullName();
            ctrlPeopleCard1.LbEmail = _clsBL.Email;
            ctrlPeopleCard1.LbPhone = _clsBL.Phone;
            ctrlPeopleCard1.LbAddress = _clsBL.Address;
            ctrlPeopleCard1.LbBirth = _clsBL.DateOfBirth.ToString();
            if (_clsBL.Gender == 0)
                ctrlPeopleCard1.LbGender = "Male";
            else
                ctrlPeopleCard1.LbGender = "Female";
            ctrlPeopleCard1.LbCountryName = _clsBL.CountryName;
            if (_clsBL.ImagePath != "")
                ctrlPeopleCard1.PbPersonalPicture.Load(_clsBL.ImagePath);
            else
            {
                if (_clsBL.Gender == 0)
                    ctrlPeopleCard1.PbPersonalPicture.Image = Resources.Man;
                else
                    ctrlPeopleCard1.PbPersonalPicture.Image = Resources.Woman;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmShowPersonDetails_Load(object sender, EventArgs e)
        {
            _LoadToDataPerson();

            LinkLabel llEditPerson = ctrlPeopleCard1.LlEditPersonInfo;
            llEditPerson.Click += llEditPerson_Click;
        }
        private void llEditPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPersonInfo frm = new frmAddEditPersonInfo(_PersonID);
            frm.ShowDialog();
            _LoadToDataPerson();
        }

        private void ctrlPeopleCard1_Load(object sender, EventArgs e)
        {

        }
    }
}
