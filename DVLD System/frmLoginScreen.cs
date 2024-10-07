using DVLD_BusinessLayer;
using DVLDBusinessLayer;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD_System
{
    public partial class frmLoginScreen : Form
    {
        public frmLoginScreen()
        {
            InitializeComponent();
        }



        private bool _ValidateUser(string userName, string Password)
        {
            DataTable table = clsBLManageUsers.GetUserNamePass();

            bool userFound = false;
            bool isActive = false;

            foreach (DataRow row in table.Rows)
            {
                if (txtUserName.Text == row["UserName"].ToString() && txtPassword.Text == row["Password"].ToString())
                {
                    userFound = true;
                    isActive = clsBLManageUsers.isActive(txtUserName.Text.ToString());
                    break;
                }
            }

            if (userFound)
            {
                if (isActive)
                    return true;
                else
                {
                    MessageBox.Show("The User is not Active. Contact your admin!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else
                return false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (_ValidateUser(txtUserName.Text, txtPassword.Text))
            {
                clsBLGlobalData.SharedUserName = txtUserName.Text.ToString();
                frmMainScreen frm = new frmMainScreen(txtUserName.Text.ToString());

                frm.Show();
                this.Hide();

                frm.FormClosed += (s, args) => this.Close();
            }
            else
                MessageBox.Show("Invalid Username/Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPass.Checked)
                txtPassword.UseSystemPasswordChar = false;
            else
                txtPassword.UseSystemPasswordChar = true;

        }

        private void btnVisitor_Click(object sender, EventArgs e)
        {
            frmMainScreen frm = new frmMainScreen();

            frm.Show();
            this.Hide();

            frm.FormClosed += (s, args) => this.Close();
        }
    }
}
