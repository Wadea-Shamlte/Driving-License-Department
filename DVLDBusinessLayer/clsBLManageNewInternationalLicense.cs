using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
    public class clsBLManageNewInternationalLicense
    {
        public int InternationalLicenseID { set; get; }
        public int ApplicationID{ set; get; } 
        public int DriverID { set; get; }
        public int IssuedUsingLocalLicenseID { set; get; }
        public DateTime IssueDate { set; get; }
        public DateTime ExpirationDate { set; get; }
        public bool IsActive { set; get; }
        public int CreatedByUserID { set; get; }

        public clsBLManageNewInternationalLicense()
        {
            InternationalLicenseID = -1;
            ApplicationID = -1;
            IssuedUsingLocalLicenseID = -1;
            DriverID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            IsActive = false;
            CreatedByUserID = -1;
        }

        public clsBLManageNewInternationalLicense(int internationalLicenseID, int applicationID, int driverID, int issuedUsingLocalLicenseID, DateTime issueDate, DateTime expirationDate, bool isActive, int createdByUserID)
        {
            InternationalLicenseID = internationalLicenseID;
            ApplicationID = applicationID;
            IssuedUsingLocalLicenseID = issuedUsingLocalLicenseID;
            DriverID = driverID;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            IsActive = isActive;
            CreatedByUserID = createdByUserID;
        }

        //int internationalLicenseID = -1;
        //int applicationID = -1;
        //int driverID = -1;
        //int issuedUsingLocalLicenseID = -1;
        //DateTime issueDate = DateTime.Now;
        //DateTime expirationDate = DateTime.Now;
        //bool isActive = false;
        //int createdByUserID = -1;

        static public DataTable GetAllInternationalLicenseInfo()
        {
            return clsDALManageNewInternationalLicense._GetAllInternationalLicenseInfo();
        }

        public bool AddInternationalLicense()
        {
            return clsDALManageNewInternationalLicense._AddLicense(ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID);
        }

        static public bool IsExist(int DriverID)
        {
            return clsDALManageNewInternationalLicense._IsExist(DriverID);
        }

    }
}
