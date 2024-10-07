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
    public partial class frmEditAppType : Form
    {
        int _ID;
        clsBLManageAppType clsBLApp;

        public frmEditAppType(int ID)
        {
            InitializeComponent();
            _ID = ID;
        }

        private void _LeadData()
        {
            clsBLApp = clsBLManageAppType.GetInfoByID(_ID);

            lbID.Text = _ID.ToString();
            txtTitle.Text = clsBLApp.ApplicationTypeTitle.ToString();
            txtFees.Text = clsBLApp.ApplicationFees.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsBLApp = new clsBLManageAppType();

            clsBLApp.ApplicationTypeTitle = txtTitle.Text.ToString();
            clsBLApp.ApplicationFees = decimal.Parse(txtFees.Text);

            if (clsBLApp.Update(_ID))
            {
                if (MessageBox.Show("The Update Process is Successfully . ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    this.Close();
            }
            else
                MessageBox.Show("The Process is not Succeed . ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEditAppType_Load(object sender, EventArgs e)
        {
            _LeadData();
        }
    }
}
