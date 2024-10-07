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

namespace DVLD_System.Drriver_Form
{
    public partial class frmDriverLicenseInfo : Form
    {
        int _LDLAppID;
        clsBLManageFirstApp_NLDL _clsBLManageFirstApp_NLDL;
        clsBLManageAllApplications _clsBLManageAllApplications;
        clsBLManagePeople _clsBLManagePeople;
        clsBLManageDriver _clsBLManageDriver;
        clsBLManageLicenses _clsBLManageLicenses;


        public frmDriverLicenseInfo(int LDLAppID)
        {
            InitializeComponent();
            _LDLAppID = LDLAppID;
        }

        private void _LoadData()
        {
            _clsBLManageFirstApp_NLDL = clsBLManageFirstApp_NLDL.GetInfo(_LDLAppID);
            _clsBLManageAllApplications = clsBLManageAllApplications.GetInfo(_clsBLManageFirstApp_NLDL.AppID);
            _clsBLManagePeople = clsBLManagePeople.GetPersonalInfo(_clsBLManageAllApplications.ApplicantPersonID);

            if(clsBLManageDriver.IsExistByPersonID(_clsBLManagePeople.ID))
            {
                _clsBLManageDriver = clsBLManageDriver.GetInfoByPersonID(_clsBLManagePeople.ID);
                _clsBLManageLicenses = clsBLManageLicenses.GetInfoLicenseIfExist(_clsBLManageDriver.DriverID, _clsBLManageFirstApp_NLDL.ClassID);
                if (_clsBLManageLicenses != null)
                {
                    ctrlLicenseCardInfo1.LbClassName = clsBLManageFirstApp_NLDL.GetClassName(_clsBLManageFirstApp_NLDL.ClassID);
                    ctrlLicenseCardInfo1.LbName = _clsBLManagePeople.FullName();
                    ctrlLicenseCardInfo1.LbLicenseID = _clsBLManageLicenses.LicenseID.ToString();
                    ctrlLicenseCardInfo1.LbNationalNo = _clsBLManagePeople.NationalNo;
                    ctrlLicenseCardInfo1.LbGender = _clsBLManagePeople.Gender == 0 ? "Male" : "Female";
                    ctrlLicenseCardInfo1.LbIssueDate = _clsBLManageLicenses.IssueDate.Date.ToString("yyyy-MM-dd");
                    ctrlLicenseCardInfo1.LbIssueReason = _clsBLManageLicenses.IssueReason.ToString();
                    ctrlLicenseCardInfo1.LbIsActive = _clsBLManageLicenses.IsActive ? "Yes" : "No";
                    ctrlLicenseCardInfo1.LbDateOfBirth = _clsBLManagePeople.DateOfBirth.Date.ToString("yyyy-MM-dd");
                    ctrlLicenseCardInfo1.LbNote = _clsBLManageLicenses.Notes == "" ? "Not Found Notes." : _clsBLManageLicenses.Notes.ToString();
                    ctrlLicenseCardInfo1.LbDriverID = _clsBLManageDriver.DriverID.ToString();
                    ctrlLicenseCardInfo1.LbExpiryDate = _clsBLManageLicenses.ExpirationDate.Date.ToString("yyyy-MM-dd");
                    //ctrlLicenseCardInfo1.LbIsDetained = 

                    if (_clsBLManagePeople.ImagePath != "")
                        ctrlLicenseCardInfo1.PbPersonalPic.Load(_clsBLManagePeople.ImagePath);
                    else
                    {
                        if (_clsBLManagePeople.Gender == 0)
                            ctrlLicenseCardInfo1.PbPersonalPic.Image = Resources.Man;
                        else
                            ctrlLicenseCardInfo1.PbPersonalPic.Image = Resources.Woman;
                    }
                }
                else
                {
                    if(MessageBox.Show("Error: This driver does not have a valid license in this " + clsBLManageFirstApp_NLDL.GetClassName(_clsBLManageFirstApp_NLDL.ClassID), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                        this.Close();
                }
            }
            else
            {
                if(MessageBox.Show("Error: This person is not a driver yet. " + clsBLManageFirstApp_NLDL.GetClassName(_clsBLManageFirstApp_NLDL.ClassID), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK )
                    this.Close();
            }
        }


        private void frmDriverLicenseInfo_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
