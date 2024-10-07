using DVLD_BusinessLayer;
using DVLD_System.ApplicationType_Form;
using DVLD_System.ApplicationType_Form.FirstApp_NowLocalDL;
using DVLD_System.ApplicationType_Form.fourth_fifthِApp_Damage_lostLicense;
using DVLD_System.ApplicationType_Form.SecondApp_NewInternatioalDL;
using DVLD_System.ApplicationType_Form.SixthApp_Release_DetentionLicense;
using DVLD_System.ApplicationType_Form.ThirdApp_RenewLicense;
using DVLD_System.Driver_Form;
using DVLD_System.People_Forms;
using DVLD_System.TestType_Form;
using DVLD_System.User_Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD_System
{
    public partial class frmMainScreen : Form
    {
        string _UserName;
        clsBLManageUsers clsBLUser;

        public frmMainScreen()
        {
            InitializeComponent();
        }
        public frmMainScreen(string userName)
        {
            InitializeComponent();

            _UserName = userName;
            clsBLUser = clsBLManageUsers.GetUserInfoByUserName(userName);
        }

        private void CenterPictureBox()
        {
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            int pbWidth = pictureBox1.Width;
            int pbHeight = pictureBox1.Height;

            int newX = (formWidth - pbWidth) / 2;
            int newY = (formHeight - pbHeight) / 2;

            pictureBox1.Location = new Point(newX, newY);
        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            CenterPictureBox();
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            CenterPictureBox();
        }


        private void accountingSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManagePeople frm = new frmManagePeople();
            frm.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUser frm = new frmManageUser();
            frm.ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowDetails frm = new frmShowDetails(clsBLUser.PersonID);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsBLUser.PersonID);
            frm.ShowDialog();

        }

        private void singOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoginScreen frm = new frmLoginScreen();

            frm.Show();

            this.Hide();

            frm.FormClosed += (s, args) => this.Close();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditNewLDLApp frm = new frmAddEditNewLDLApp(-1);
            frm.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewInternationalDL frm = new frmAddNewInternationalDL();
            frm.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddRenewLicense frm = new frmAddRenewLicense();
            frm.ShowDialog();
        }

        private void replacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddDamageOrLostLicense frm = new frmAddDamageOrLostLicense();
            frm.ShowDialog();
        }

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseLicense frm = new frmReleaseLicense();
            frm.ShowDialog();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageNewLDLApp frm = new frmManageNewLDLApp();
            frm.ShowDialog();
        }

        private void internationalLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageInternationalLicense frm = new frmManageInternationalLicense();
            frm.ShowDialog();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDetentionLicense frm = new frmManageDetentionLicense();
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseLicense frm = new frmReleaseLicense();
            frm.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplicationType frm = new frmManageApplicationType();
            frm.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestType frm = new frmManageTestType();
            frm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDriver frm = new frmManageDriver();
            frm.ShowDialog();
        }
    }
}
