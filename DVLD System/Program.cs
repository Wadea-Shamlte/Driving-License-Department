using DVLD_System.ApplicationType_Form;
using DVLD_System.ApplicationType_Form.FirstApp_NowLocalDL;
using DVLD_System.ApplicationType_Form.FirstApp_NowLocalDL.Test_Fomes;
using DVLD_System.ApplicationType_Form.fourth_fifthِApp_Damage_lostLicense;
using DVLD_System.ApplicationType_Form.SecondApp_NewInternatioalDL;
using DVLD_System.ApplicationType_Form.SixthApp_Release_DetentionLicense;
using DVLD_System.ApplicationType_Form.ThirdApp_RenewLicense;
using DVLD_System.Driver_Form;
using DVLD_System.My_Controls;
using DVLD_System.People_Forms;
using DVLD_System.TestType_Form;
using DVLD_System.User_Forms;
using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_System
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLoginScreen());
            
        }
    }
}
