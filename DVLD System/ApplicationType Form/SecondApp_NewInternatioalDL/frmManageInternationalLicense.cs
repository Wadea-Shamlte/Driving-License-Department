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

namespace DVLD_System.ApplicationType_Form.SecondApp_NewInternatioalDL
{
    public partial class frmManageInternationalLicense : Form
    {
        public frmManageInternationalLicense()
        {
            InitializeComponent();
        }

        private void _Refresh()
        {
            DGListViewLInternationalLicense.DataSource = clsBLManageNewInternationalLicense.GetAllInternationalLicenseInfo();
            lbRecordCount.Text = Convert.ToString(DGListViewLInternationalLicense.RowCount);
            DGListViewLInternationalLicense.Columns[3].Width = 150;

            cbFilterData.SelectedIndex = 0;
        }

        private void frmManageInternationalLicense_Load(object sender, EventArgs e)
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
                    (DGListViewLInternationalLicense.DataSource as DataTable).DefaultView.RowFilter =
                        string.Format("Convert(InternationalLicenseID, 'System.String') LIKE '{0}%'", filterValue);
                }
                else
                    (DGListViewLInternationalLicense.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
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

        private void btnAddInternationalLicense_Click(object sender, EventArgs e)
        {
            frmAddNewInternationalDL frm = new frmAddNewInternationalDL();

            frm.ShowDialog();

            _Refresh();
        }

        private void showPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsBLManageDriver _clsBLManageDriver = clsBLManageDriver.GetInfoByDriverID((int)DGListViewLInternationalLicense.CurrentRow.Cells[2].Value);
            clsBLManagePeople _clsBLManagePeople = clsBLManagePeople.GetPersonalInfo(_clsBLManageDriver.PersonID);

            frmShowPersonDetails frm = new frmShowPersonDetails(_clsBLManagePeople.ID);
            frm.ShowDialog();

        }

    }
}
