using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
    public class clsBLManageTestAppointments
    {
        public int TestAppointmentID{ set; get; } 
        public int TestTypeID { set; get; }
        public int LDLAppID { set; get; }
        public DateTime AppointmentDate { set; get; }
        public decimal PaidFees { set; get; }
        public int CreatedByUserID { set; get; }
        public bool IsLocked { set; get; }

        public clsBLManageTestAppointments()
        {
            TestAppointmentID = -1;
            TestTypeID = -1;
            LDLAppID = -1;
            AppointmentDate = DateTime.Now;
            PaidFees = -1;
            CreatedByUserID = -1;
            IsLocked = false;
        }

        public clsBLManageTestAppointments(int testAppointmentID, int testTypeID, int lDLAppID, DateTime appointmentDate, decimal paidFees, int createdByUserID, bool isLocked)
        {
            TestAppointmentID = testAppointmentID;
            TestTypeID = testTypeID;
            LDLAppID = lDLAppID;
            AppointmentDate = appointmentDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
            IsLocked = isLocked;
        }

        static public clsBLManageTestAppointments GetInfo(int testAppointmentID)
        {
            int testTypeID =  -1;
            int lDLAppID = -1;
            DateTime appointmentDate = DateTime.Now;
            decimal paidFees = -1;
            int createdByUserID = -1;
            bool isLocked = false;

            clsDALManageTestAppointments._GetInfo(testAppointmentID, ref testTypeID, ref lDLAppID, ref appointmentDate, ref paidFees, ref createdByUserID, ref isLocked);

            return new clsBLManageTestAppointments(testAppointmentID, testTypeID, lDLAppID, appointmentDate, paidFees, createdByUserID, isLocked);
        }

        static public DataTable GetTestAppointmentsInfoByAppTypeID(int LDLAppID, int TestID)
        {
            DataTable dt = clsDALManageTestAppointments._GetTestAppointmentsInfoByAppTypeID(LDLAppID , TestID);
            return dt;
        }

        static public bool IsAppointmentExist(int LDLAppID , int TestTypeID)
        {
            return clsDALManageTestAppointments._IsAppointmentExist(LDLAppID , TestTypeID);
        }

        static public bool IsPassed(int LDLAppID , int TestTypeID)
        {
            return clsDALManageTestAppointments._IsPassed(LDLAppID , TestTypeID);
        }

        static public bool IsFailed(int LDLAppID, int TestTypeID)
        {
            return clsDALManageTestAppointments._IsFailed(LDLAppID, TestTypeID);
        }

        static public bool UpdateStatusLooked(int testAppointmentID , byte isLocked)
        {
            return clsDALManageTestAppointments._UpdateStatusLooked(testAppointmentID, isLocked);
        }

        public bool _Add()
        {
            return clsDALManageTestAppointments._AddAppointment(TestTypeID, LDLAppID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked);
        }

        public bool _Update()
        {
            return clsDALManageTestAppointments._UpdateAppointment(TestAppointmentID, TestTypeID, LDLAppID, AppointmentDate, PaidFees, CreatedByUserID);
        }

    }
}
