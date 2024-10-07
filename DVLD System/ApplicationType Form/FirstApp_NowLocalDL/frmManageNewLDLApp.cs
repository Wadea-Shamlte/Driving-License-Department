using DVLD_BusinessLayer;
using DVLD_System.ApplicationType_Form.FirstApp_NowLocalDL.Test_Fomes;
using DVLD_System.ApplicationType_Form.FirstApp_NowLocalDL.Test_Forms;
using DVLD_System.Drriver_Form;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD_System.ApplicationType_Form.FirstApp_NowLocalDL
{
    public partial class frmManageNewLDLApp : Form
    {
        clsBLManageFirstApp_NLDL _clsBLManageFirstApp;


        public frmManageNewLDLApp()
        {
            InitializeComponent();
        }

        private void _RefreshData()
        {
            DGListViewLDLApp.DataSource = clsBLManageFirstApp_NLDL.LocalDrivingLicenseApplications_View();
            lbRecordCount.Text = Convert.ToString(DGListViewLDLApp.RowCount);
            DGListViewLDLApp.Columns[0].HeaderText = "L.D.L App";
            DGListViewLDLApp.Columns[0].Width = 80;
            DGListViewLDLApp.Columns[1].Width = 250;
            DGListViewLDLApp.Columns[3].Width = 250;
            DGListViewLDLApp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }



        private void frmManageNewLDLApp_Load(object sender, EventArgs e)
        {
            _RefreshData();
        }

        private void btnAddNewLDLApp_Click(object sender, EventArgs e)
        {
            frmAddEditNewLDLApp frm = new frmAddEditNewLDLApp(-1);

            frm.ShowDialog();

            _RefreshData();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditNewLDLApp frm = new frmAddEditNewLDLApp((int)DGListViewLDLApp.CurrentRow.Cells[0].Value);

            frm.ShowDialog();

            _RefreshData();
        }


        private void txtFilterData_TextChanged(object sender, EventArgs e)
        {
            
            if (cbFilterData.SelectedIndex == 1)
            {
                int filterValue;
                if (int.TryParse(txtFilterData.Text, out filterValue))
                {
                    (DGListViewLDLApp.DataSource as DataTable).DefaultView.RowFilter =
                        string.Format("Convert(LocalDrivingLicenseApplicationID, 'System.String') LIKE '{0}%'", filterValue);
                }else
                    (DGListViewLDLApp.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
            else if (cbFilterData.SelectedIndex == 2)
            {
                (DGListViewLDLApp.DataSource as DataTable).DefaultView.RowFilter =
                 string.Format("NationalNo LIKE '{0}%'", txtFilterData.Text);
            }
            else if (cbFilterData.SelectedIndex == 3)
            {
                (DGListViewLDLApp.DataSource as DataTable).DefaultView.RowFilter =
                 string.Format("FullName LIKE '{0}%'", txtFilterData.Text);
            }
        }

        private void txtFilterData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterData.SelectedIndex == 1 && !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void cbStatusSelect_TextChanged(object sender, EventArgs e)
        {
            (DGListViewLDLApp.DataSource as DataTable).DefaultView.RowFilter =
                 string.Format("Status LIKE '%{0}%'", cbStatusSelect.Text);
        }

        private void cbFilterData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterData.SelectedIndex == 1)
            {
                txtFilterData.Visible = true; cbStatusSelect.Visible = false;
            }
            else if (cbFilterData.SelectedIndex == 2)
            {
                txtFilterData.Visible = true; cbStatusSelect.Visible = false;
            }
            else if (cbFilterData.SelectedIndex == 3)
            {
                txtFilterData.Visible = true; cbStatusSelect.Visible = false;
            }
            else if(cbFilterData.SelectedIndex == 4)
            {
                txtFilterData.Visible = false; cbStatusSelect.Visible = true;
            }
            else
            {
                cbStatusSelect.Visible = false; txtFilterData.Visible = false;
            }
        }


        private void showApplicationDetalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowApplicationDetails frm = new frmShowApplicationDetails((int)DGListViewLDLApp.CurrentRow.Cells[0].Value);

            frm.ShowDialog();

            _RefreshData();

        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditNewLDLApp frm = new frmAddEditNewLDLApp((int)DGListViewLDLApp.CurrentRow.Cells[0].Value);

            frm.ShowDialog();

            _RefreshData();
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _clsBLManageFirstApp = clsBLManageFirstApp_NLDL.GetInfo((int)DGListViewLDLApp.CurrentRow.Cells[0].Value);

            if (MessageBox.Show("Are You Sure You Want to cancelled This Application ", "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (clsBLManageAllApplications.Cancelled(_clsBLManageFirstApp.AppID))
                {
                    MessageBox.Show("Cancelled Application Process is Done Successfully .", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshData();
                }

                else
                    MessageBox.Show("Error : The Cancelled process did not take place .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _clsBLManageFirstApp = clsBLManageFirstApp_NLDL.GetInfo((int)DGListViewLDLApp.CurrentRow.Cells[0].Value);

            if (MessageBox.Show("Are You Sure You Want to Delete this application ? ", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                if (clsBLManageFirstApp_NLDL.Delete((int)DGListViewLDLApp.CurrentRow.Cells[0].Value) && clsBLManageAllApplications.Delete(_clsBLManageFirstApp.AppID))
                {
                    MessageBox.Show("Deleted Process is done Successfully ." , "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshData();
                }
                else
                    MessageBox.Show("Error : The Deletion process did not take place .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void visionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageVisionTest frm = new frmManageVisionTest((int)DGListViewLDLApp.CurrentRow.Cells[0].Value);

            frm.ShowDialog();

            _RefreshData();
        }

        private void writtenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageWrittenTest frm = new frmManageWrittenTest((int)DGListViewLDLApp.CurrentRow.Cells[0].Value);

            frm.ShowDialog();

            _RefreshData();
        }

        private void streetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageStreetTest frm = new frmManageStreetTest((int)DGListViewLDLApp.CurrentRow.Cells[0].Value);

            frm.ShowDialog();

            _RefreshData();
        }


        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueDrivingLicenseFirstTime frm = new frmIssueDrivingLicenseFirstTime((int)DGListViewLDLApp.CurrentRow.Cells[0].Value);

            frm.ShowDialog();

            _RefreshData();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDriverLicenseInfo frm = new frmDriverLicenseInfo((int)DGListViewLDLApp.CurrentRow.Cells[0].Value);

            frm.ShowDialog();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            
            if (DGListViewLDLApp.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = DGListViewLDLApp.SelectedRows[0];
                int CurrentAppID = (int)DGListViewLDLApp.CurrentRow.Cells[0].Value;
                bool IsVisionTestPassed = clsBLManageTestAppointments.IsPassed(CurrentAppID, 1);
                bool IsWrittenTestPassed = clsBLManageTestAppointments.IsPassed(CurrentAppID, 2);
                bool IsStreetTestPassed = clsBLManageTestAppointments.IsPassed(CurrentAppID, 3);

                schedulingTestToolStripMenuItem.Enabled = true;
                editApplicationToolStripMenuItem.Enabled = true;
                deleteApplicationToolStripMenuItem.Enabled = true;
                cancelApplicationToolStripMenuItem.Enabled = true;
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = true;
                showLicenseToolStripMenuItem.Enabled = true;

                visionTestToolStripMenuItem.Enabled = !IsVisionTestPassed;
                writtenTestToolStripMenuItem.Enabled = IsVisionTestPassed && !IsWrittenTestPassed;
                streetTestToolStripMenuItem.Enabled = IsVisionTestPassed && IsWrittenTestPassed && !IsStreetTestPassed;

                if (IsStreetTestPassed)
                {
                    schedulingTestToolStripMenuItem.Enabled = false;
                }

                if (selectedRow.Cells["Status"] != null && selectedRow.Cells["Status"].Value != DBNull.Value)
                {
                    string status = selectedRow.Cells["Status"].Value.ToString();
                    int passedTest = int.Parse(selectedRow.Cells["PassedTestCount"].Value.ToString());

                    if (status == "New" && passedTest > 0)
                    {
                        if(passedTest == 3)
                        {
                            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = true;
                        }
                        else
                            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                        editApplicationToolStripMenuItem.Enabled = false;
                        deleteApplicationToolStripMenuItem.Enabled = false;
                        cancelApplicationToolStripMenuItem.Enabled = false;
                        showLicenseToolStripMenuItem.Enabled = false;
                    }
                    else if(status == "New" && passedTest == 0)
                    {
                        editApplicationToolStripMenuItem.Enabled = true;
                        deleteApplicationToolStripMenuItem.Enabled = true;
                        cancelApplicationToolStripMenuItem.Enabled = true;
                        issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                        showLicenseToolStripMenuItem.Enabled = false;
                    }
                    else if(status == "Cancelled")
                    {
                        editApplicationToolStripMenuItem.Enabled = false;
                        deleteApplicationToolStripMenuItem.Enabled = false;
                        cancelApplicationToolStripMenuItem.Enabled = false;
                        schedulingTestToolStripMenuItem.Enabled = false;
                        issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                        showLicenseToolStripMenuItem.Enabled = false;
                    }
                    else if(status == "Completed")
                    {
                        editApplicationToolStripMenuItem.Enabled = false;
                        deleteApplicationToolStripMenuItem.Enabled = false;
                        cancelApplicationToolStripMenuItem.Enabled = false;
                        schedulingTestToolStripMenuItem.Enabled = false;
                        issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                        showLicenseToolStripMenuItem.Enabled = true;
                    }

                }
            }
        }
        
    }
}
