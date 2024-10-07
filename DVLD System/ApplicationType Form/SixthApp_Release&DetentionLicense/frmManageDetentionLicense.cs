using DVLD_System.People_Forms;
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

namespace DVLD_System.ApplicationType_Form.SixthApp_Release_DetentionLicense
{
    public partial class frmManageDetentionLicense : Form
    {
        public frmManageDetentionLicense()
        {
            InitializeComponent();
        }

        private void _Refresh()
        {
            DGListViewDetainLicense.DataSource = clsBLManageDetainLicense.GetAllDetainedLicenses();
            lbRecordCount.Text = Convert.ToString(DGListViewDetainLicense.RowCount);
            

            cbFilterData.SelectedIndex = 0;
        }

        private void frmManageDetentionLicense_Load(object sender, EventArgs e)
        {
            _Refresh();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFilterData_TextChanged(object sender, EventArgs e)
        {
            if (cbFilterData.SelectedIndex == 1)
            {
                int filterValue;
                if (int.TryParse(txtFilterData.Text, out filterValue))
                {
                    (DGListViewDetainLicense.DataSource as DataTable).DefaultView.RowFilter =
                        string.Format("Convert(LicenseID, 'System.String') LIKE '{0}%'", filterValue);
                }
                else
                    (DGListViewDetainLicense.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
        }

        private void txtFilterData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((cbFilterData.SelectedIndex == 1) && !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void cbFilterData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterData.SelectedIndex == 0)
            {
                txtFilterData.Visible = false;
            }
            else txtFilterData.Visible = true;
        }

        private void showPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsBLManageLicenses _clsBLManageLicenses = clsBLManageLicenses.GetInfoLicenseID((int)DGListViewDetainLicense.CurrentRow.Cells[1].Value);
            clsBLManageDriver _clsBLManageDriver = clsBLManageDriver.GetInfoByDriverID(_clsBLManageLicenses.DriverID);
            clsBLManagePeople _clsBLManagePeople = clsBLManagePeople.GetPersonalInfo(_clsBLManageDriver.PersonID);

            frmShowPersonDetails frm = new frmShowPersonDetails(_clsBLManagePeople.ID);
            frm.ShowDialog();
        }

        private void btnReleaseLicense_Click(object sender, EventArgs e)
        {
            frmReleaseLicense frm = new frmReleaseLicense();

            frm.ShowDialog();

            _Refresh();
        }

        private void btnDetainedLicense_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();

            frm.ShowDialog();

            _Refresh();
        }
    }
}
