using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
    public class clsBLManageTests
    {
        public int TestAppointmentID { set; get; } 
        public byte TestResult { set; get; }
        public string Notes { set; get; }
        public int CreatedByUserID { set; get; }

        public clsBLManageTests()
        {
            TestAppointmentID = -1;
            TestResult = 0;
            Notes = " ";
            CreatedByUserID = 0;
        }

        public clsBLManageTests(int testAppointmentID, byte testResult, string notes, int createdByUserID)
        {
            TestAppointmentID = testAppointmentID;
            TestResult = testResult;
            Notes = notes;
            CreatedByUserID = createdByUserID;
        }

        static public int GetTestIDIfExist(int TestAppointmentID)
        {
            return clsDALManageTests._GetTestIDIfExist(TestAppointmentID);
        }

        static public int GetNumOfPassedTests(int LDLAppID)
        {
            return clsDALManageTests._GetNumOfPassedTests(LDLAppID);
        }

        public bool SaveResultTest()
        {
            return clsDALManageTests._SaveResultTest(TestAppointmentID , TestResult , Notes , CreatedByUserID);
        }

        
    }
}
