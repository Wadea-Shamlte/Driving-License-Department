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

namespace DVLD_System.Driver_Form
{
    public partial class frmManageDriver : Form
    {
        public frmManageDriver()
        {
            InitializeComponent();
        }


        private void frmManageDriver_Load(object sender, EventArgs e)
        {
            DGListViewLDriver.DataSource = clsBLManageDriver.GetAllDrivers();
            lbRecordCount.Text = Convert.ToString(DGListViewLDriver.RowCount);
            DGListViewLDriver.Columns[0].Width = 80;
            DGListViewLDriver.Columns[1].Width = 80;
            DGListViewLDriver.Columns[2].Width = 80;
            DGListViewLDriver.Columns[3].Width = 200;

            cbFilterData.SelectedIndex = 0;
        }


        private void txtFilterData_TextChanged(object sender, EventArgs e)
        {
            if(cbFilterData.SelectedIndex == 0)
            { (DGListViewLDriver.DataSource as DataTable).DefaultView.RowFilter = string.Empty; }
            else if (cbFilterData.SelectedIndex == 1)
            {
                int filterValue;
                if (int.TryParse(txtFilterData.Text, out filterValue))
                {
                    (DGListViewLDriver.DataSource as DataTable).DefaultView.RowFilter =
                        string.Format("Convert(DriverID, 'System.String') LIKE '{0}%'", filterValue);
                }
                else
                    (DGListViewLDriver.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
            else if (cbFilterData.SelectedIndex == 2)
            {
                int filterValue;
                if (int.TryParse(txtFilterData.Text, out filterValue))
                {
                    (DGListViewLDriver.DataSource as DataTable).DefaultView.RowFilter =
                        string.Format("Convert(PersonID, 'System.String') LIKE '{0}%'", filterValue);
                }
                else
                    (DGListViewLDriver.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
            else if (cbFilterData.SelectedIndex == 3)
            {
                (DGListViewLDriver.DataSource as DataTable).DefaultView.RowFilter =
                 string.Format("NationalNo LIKE '{0}%'", txtFilterData.Text);
            }
            else if (cbFilterData.SelectedIndex == 3)
            {
                (DGListViewLDriver.DataSource as DataTable).DefaultView.RowFilter =
                 string.Format("FullName LIKE '{0}%'", txtFilterData.Text);
            }
        }

        private void txtFilterData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((cbFilterData.SelectedIndex == 1 || cbFilterData.SelectedIndex == 2) && !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void cbFilterData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterData.SelectedIndex == 0)
            {
                txtFilterData.Enabled = false; 
            }
            else txtFilterData.Enabled = true;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
