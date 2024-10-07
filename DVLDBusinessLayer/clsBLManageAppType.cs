using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
    public class clsBLManageAppType
    {
        public int AppTypeID { get; set; }
        public string ApplicationTypeTitle { get; set; }
        public decimal ApplicationFees { get; set; }

        public clsBLManageAppType()
        {
            AppTypeID = -1;
            ApplicationTypeTitle = " ";
            ApplicationFees = 0;
        }
        public clsBLManageAppType(int appTypeID, string applicationTypeTitle, decimal applicationFees)
        {
            AppTypeID = appTypeID;
            ApplicationTypeTitle = applicationTypeTitle;
            ApplicationFees = applicationFees;
        }

        static public clsBLManageAppType GetInfoByID(int ID)
        {
            string applicationTypeTitle = " ";
            decimal applicationFees = 0;

            clsDALManageAppType._GetDataAppInfo(ID, ref applicationTypeTitle, ref applicationFees);

            return new clsBLManageAppType(ID, applicationTypeTitle, applicationFees);
        }

        static public DataTable GetAllDataAppType()
        {
            DataTable dataTable = clsDALManageAppType._GetDataApplicationType();
            return dataTable;
        }

        static public decimal GetFeesRetakeTestApp()
        {
            return clsDALManageAppType._GetFeesRetakeTestApp();
        }

        static public decimal GetAppTypeFees(int AppTypeID)
        {
            return clsDALManageAppType._GetAppTypeFees(AppTypeID);
        }

        public bool Update(int ID)
        {
            return clsDALManageAppType._UpdateAppType(ID, ApplicationTypeTitle, ApplicationFees);
        }
    }
}
