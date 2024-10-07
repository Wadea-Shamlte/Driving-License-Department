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
    public partial class frmManagePeople : Form
    {
        public frmManagePeople()
        {
            InitializeComponent();
        }

        void _RefreshData()
        {
            DGListItem.DataSource = clsBLManagePeople.GetAllData();
            lbRecordCount.Text = Convert.ToString(DGListItem.RowCount);
            DGListItem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _RefreshData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmAddEditPersonInfo frm = new frmAddEditPersonInfo(-1);
            frm.ShowDialog();
            _RefreshData();

        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditPersonInfo frm = new frmAddEditPersonInfo(-1);
            frm.ShowDialog();
            _RefreshData();
        }

        private void updatePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditPersonInfo frm = new frmAddEditPersonInfo((int)DGListItem.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshData();
        }

        private void deletePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want to Delete This Person That have ID [" + DGListItem.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                if (clsBLManagePeople._Delete((int)DGListItem.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Record Deleted Successfully.");
                    _RefreshData();
                }

                else
                    MessageBox.Show("Person Record is not Deleted.");
            }

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonDetails frm = new frmShowPersonDetails((int)DGListItem.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshData();
        }
    }
}
