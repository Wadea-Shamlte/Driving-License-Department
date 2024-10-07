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
    public partial class frmEditTestType : Form
    {
        int _ID;
        clsBLManageTestType clsBlTest;

        public frmEditTestType(int ID)
        {
            InitializeComponent();

            _ID = ID;
        }


        private void _LeadData()
        {
            clsBlTest = clsBLManageTestType.GetTestTypeInfo(_ID);

            lbID.Text = _ID.ToString();
            txtTitle.Text = clsBlTest.TestTypeTitle.ToString();
            txtDescription.Text = clsBlTest.TestTypeDescription.ToString();
            txtFees.Text = clsBlTest.TestTypeFees.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsBlTest = new clsBLManageTestType();

            clsBlTest.TestTypeTitle = txtTitle.Text.ToString();
            clsBlTest.TestTypeDescription = txtDescription.Text.ToString();
            clsBlTest.TestTypeFees = decimal.Parse(txtFees.Text);

            if (clsBlTest.Update(_ID))
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
