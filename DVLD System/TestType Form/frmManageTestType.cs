using DVLD_System.ApplicationType_Form;
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

namespace DVLD_System.TestType_Form
{
    public partial class frmManageTestType : Form
    {
        public frmManageTestType()
        {
            InitializeComponent();
        }

        void _RefreshData()
        {
            DGListItem.DataSource = clsBLManageTestType.GetAllTestTypeInfo();
            lbRecordCount.Text = Convert.ToString(DGListItem.RowCount);
            DGListItem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void frmManageTestType_Load(object sender, EventArgs e)
        {
            _RefreshData();
        }
        
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditTestType frm = new frmEditTestType((int)DGListItem.CurrentRow.Cells[0].Value);

            frm.ShowDialog();
            _RefreshData();
        }

    }
}
