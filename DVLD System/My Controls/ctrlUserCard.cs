using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DVLD_System.My_Controls
{
    public partial class ctrlUserCard : UserControl
    {
        public ctrlUserCard()
        {
            InitializeComponent();
        }

        public string LbPersonalId
        {
            set { lbPresonalID.Text = value; }
            get { return lbPresonalID.Text.ToString(); }
        }
        public string LbName
        {
            set { lbName.Text = value; }
            get { return lbName.Text.ToString(); }
        }
        public string LbNationalNo
        {
            set { lbNationalNo.Text = value; }
            get { return lbNationalNo.Text.ToString(); }
        }
        public string LbEmail
        {
            set { lbEmail.Text = value; }
            get { return lbEmail.Text.ToString(); }
        }
        public string LbBirth
        {
            set { lbBirth.Text = value; }
            get { return lbBirth.Text.ToString(); }
        }
        public string LbGender
        {
            set { lbGender.Text = value; }
            get { return lbGender.Text.ToString(); }
        }
        public string LbAddress
        {
            set { lbAddress.Text = value; }
            get { return lbAddress.Text.ToString(); }
        }
        public string LbPhone
        {
            set { lbPhone.Text = value; }
            get { return lbPhone.Text.ToString(); }
        }
        public string LbCountryName
        {
            set { lbCountryName.Text = value; }
            get { return lbCountryName.Text.ToString(); }
        }
        public PictureBox PbPersonalPicture
        {
            get { return pbPersonalPicture; }
        }
        public LinkLabel LlEditPersonInfo
        {
            get
            {
                return llEditPersonInfo;
            }
        }
        public string LbID
        {
            set { lbID.Text = value; }
            get { return lbID.Text.ToString(); }
        }
        public string LbUserName
        {
            set { lbUserName.Text = value; }
            get { return lbUserName.Text.ToString(); }
        }
        public string LbIsActive
        {
            set { lbIsActive.Text = value; }
            get { return lbIsActive.Text.ToString(); }
        }

        
    }
}
