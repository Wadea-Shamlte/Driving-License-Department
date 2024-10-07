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

namespace DVLD_System.ApplicationType_Form
{
    public partial class frmManageApplicationType : Form
    {
        public frmManageApplicationType()
        {
            InitializeComponent();
        }

        void _RefreshData()
        {
            DGListItem.DataSource = clsBLManageAppType.GetAllDataAppType();
            lbRecordCount.Text = Convert.ToString(DGListItem.RowCount);
            DGListItem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void frmManageApplicationType_Load(object sender, EventArgs e)
        {
            _RefreshData();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditAppType frm = new frmEditAppType((int)DGListItem.CurrentRow.Cells[0].Value);

            frm.ShowDialog();
            _RefreshData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
