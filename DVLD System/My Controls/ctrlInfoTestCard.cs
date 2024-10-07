using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_System.My_Controls
{
    public partial class ctrlInfoTestCard : UserControl
    {
        public ctrlInfoTestCard()
        {
            InitializeComponent();
        }

        public string LbAppTypeID
        {
            set { lbAppTypeID.Text = value; }
            get { return lbAppTypeID.Text.ToString(); }
        }

        public string LbClassName
        {
            set { lbClassName.Text = value; }
            get { return lbClassName.Text.ToString(); }
        }

        public string LbPassedTest
        {
            set { lbPassedTest.Text = value; }
            get { return lbPassedTest.Text.ToString(); }
        }

        public string LbAppID
        {
            set { lbAppID.Text = value; }
            get { return lbAppID.Text.ToString(); }
        }

        public string LbStatus
        {
            set { lbStatus.Text = value; }
            get { return lbStatus.Text.ToString(); }
        }

        public string LbFees
        {
            set { lbFees.Text = value; }
            get { return lbFees.Text.ToString(); }
        }

        public string LbType
        {
            set { lbType.Text = value; }
            get { return lbType.Text.ToString(); }
        }

        public string LbApplicantName
        {
            set { lbApplicantName.Text = value; }
            get { return lbApplicantName.Text.ToString(); }
        }

        public string LbDate
        {
            set { lbDate.Text = value; }
            get { return lbDate.Text.ToString(); }
        }

        public string LbStatusDate
        {
            set { lbStatusDate.Text = value; }
            get { return lbStatusDate.Text.ToString(); }
        }

        public string LbCreatedByName
        {
            set { lbCreatedByName.Text = value; }
            get { return lbCreatedByName.Text.ToString(); }
        }

        public LinkLabel LlViewInfo
        {
            get
            {
                return llViewInfo;
            }
        }


    }
}
