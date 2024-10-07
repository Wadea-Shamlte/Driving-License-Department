using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
    public class clsBLManageFirstApp_NLDL
    {
        public int LocalDrivingLicenseApplicationID {  get; set; }
        public int AppID {  get; set; }
        public int ClassID { get; set; }


        public clsBLManageFirstApp_NLDL()
        {
            LocalDrivingLicenseApplicationID = -1;
            AppID = -1;
            ClassID = -1;
        }

        public clsBLManageFirstApp_NLDL(int localDrivingLicenseApplicationID, int appID, int classID)
        {
            LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            AppID = appID;
            ClassID = classID;
        }

        static public DataTable LocalDrivingLicenseApplications_View()
        {
            DataTable dt = clsDALManageFirstApp_NLDL._LocalDrivingLicenseApplications_View();
            return dt;
        }

        static public clsBLManageFirstApp_NLDL GetInfo(int ID)
        {
            int appID = -1;
            int classID = -1;

            clsDALManageFirstApp_NLDL._GetInfo(ID ,ref appID ,ref classID );

            return new clsBLManageFirstApp_NLDL(ID , appID ,classID );
        }


        static public string GetClassName(int LicenseClassID)
        {
            return clsDALManageFirstApp_NLDL._GetClassName(LicenseClassID);
        }

        static public byte GetValidityLength(int LicenseClassID)
        {
            return clsDALManageFirstApp_NLDL._GetValidityLength(LicenseClassID);
        }

        static public decimal GetClassFees(int LicenseClassID)
        {
            return clsDALManageFirstApp_NLDL._GetClassFees(LicenseClassID);
        }


        static public decimal GetTestFees(int ID)
        {
            return clsDALManageFirstApp_NLDL._GetTestFees(ID);
        }

        public bool AddLocalDrivingLicenseApplications()
        {
            return clsDALManageFirstApp_NLDL._AddLocalDrivingLicenseApplication(AppID, ClassID);
        }

        public bool UpdateLocalDrivingLicenseApplications()
        {
            return clsDALManageFirstApp_NLDL._UpdateLocalDrivingLicenseApplication(AppID, ClassID);
        }

        static public bool Delete(int LDLApp)
        {
            return clsDALManageFirstApp_NLDL._DeleteLocalDrivingLicenseApplication(LDLApp);
        }
    }
}
