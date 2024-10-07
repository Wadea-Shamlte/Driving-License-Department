using DVLD_BusinessLayer;
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
    public partial class frmManageUser : Form
    {
        clsBLManageUsers clsBLUser;

        public frmManageUser()
        {
            InitializeComponent();
        }


        private void _RefreshData()
        {
            DGListIUser.DataSource = clsBLManageUsers.GetAllDataUsers();
            lbRecordCount.Text = Convert.ToString(DGListIUser.RowCount);
            DGListIUser.Columns[2].Width = 250;
            DGListIUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "IsActive",
                HeaderText = "Is Active",
                Name = "IsActive",
                TrueValue = 1,
                FalseValue = 0
            };

            int columnIndex = DGListIUser.Columns["IsActive"].Index;
            DGListIUser.Columns.RemoveAt(columnIndex);
            DGListIUser.Columns.Insert(columnIndex, checkBoxColumn);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManageUser_Load(object sender, EventArgs e)
        {
            _RefreshData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser(-1);

            frm.ShowDialog();
            _RefreshData();
        }



        private void showDetialsTSM_Click(object sender, EventArgs e)
        {
            frmShowDetails frm = new frmShowDetails((int)DGListIUser.CurrentRow.Cells[1].Value);

            frm.ShowDialog();
            _RefreshData();
        }
        private void addTSM_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser(-1);

            frm.ShowDialog();
            _RefreshData();
        }
        private void editTSM_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser((int)DGListIUser.CurrentRow.Cells[1].Value);

            frm.ShowDialog();
            _RefreshData();
        }
        private void deleteTSM_Click(object sender, EventArgs e)
        {
            if (DGListIUser.CurrentRow.Cells[3].Value.ToString() == clsBLGlobalData.SharedUserName)
            {
                MessageBox.Show("The User cannot be deleted because data is based on it .", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Are You Sure You Want to Delete This User That have ID [" + DGListIUser.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (clsBLManageUsers._Delete((int)DGListIUser.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("User Record Deleted Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshData();
                }

                else
                    MessageBox.Show("User Record is not Deleted.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void changePasswordTSM_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword((int)DGListIUser.CurrentRow.Cells[1].Value);

            frm.ShowDialog();
            _RefreshData();
        }








        private void DGListIUser_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DGListIUser.IsCurrentCellDirty)
                DGListIUser.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private void DGListIUser_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == DGListIUser.Columns["IsActive"].Index && e.RowIndex >= 0)
            {
                clsBLUser = clsBLManageUsers.GetUserInfoByPersonID((int)DGListIUser.Rows[e.RowIndex].Cells["PersonID"].Value);
                clsBLUser.IsActive = (int)DGListIUser.Rows[e.RowIndex].Cells["IsActive"].Value;



                clsBLUser._Update();
            }
        }
    }
}
