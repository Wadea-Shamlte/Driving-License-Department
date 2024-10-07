using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLDBusinessLayer
{
    public class clsBLManageLicenses
    {
        public int LicenseID { set; get; }
        public int ApplicationID { set; get; }
        public int DriverID { set; get; }
        public int LicenseClass { set; get; }
        public DateTime IssueDate { set; get; }
        public DateTime ExpirationDate { set; get; }
        public string Notes { set; get; }
        public decimal PaidFees { set; get; }
        public bool IsActive { set; get; }
        public int IssueReason { set; get; }
        public int CreatedByUserID { set; get; }

        public clsBLManageLicenses()
        {
            LicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LicenseClass = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            Notes = " ";
            PaidFees = -1;
            IsActive = false;
            IssueReason = -1;
            CreatedByUserID = -1;
        }

        public clsBLManageLicenses(int licenseID, int applicationID, int driverID, int licenseClass, DateTime issueDate, DateTime expirationDate, string notes, decimal paidFees, bool isActive, int issueReason, int createdByUserID)
        {
            LicenseID = licenseID;
            ApplicationID = applicationID;
            DriverID = driverID;
            LicenseClass = licenseClass;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            Notes = notes;
            PaidFees = paidFees;
            IsActive = isActive;
            IssueReason = issueReason;
            CreatedByUserID = createdByUserID;
        }


        static public clsBLManageLicenses GetInfoLicenseID(int licenseID)
        {
            int applicationID = -1;   DateTime issueDate = DateTime.Now;
            int driverID = -1;        DateTime expirationDate = DateTime.Now;
            int licenseClass = -1;    string notes = " ";
            int issueReason = -1;     decimal paidFees = -1;
            int createdByUserID = -1; bool isActive = false;

            if (clsDALManageLicenses._IsExist(licenseID))
            {
                clsDALManageLicenses._GetInfoLicenseID(licenseID, ref applicationID, ref driverID, ref licenseClass, ref issueDate, ref expirationDate, ref notes, ref paidFees, ref isActive, ref issueReason, ref createdByUserID);

                return new clsBLManageLicenses(licenseID, applicationID, driverID, licenseClass, issueDate, expirationDate, notes, paidFees, isActive, issueReason, createdByUserID);
            }
            else
                return null;
        }

        static public clsBLManageLicenses GetInfoLicenseIfExist(int DriverID , int LicenseClass)
        {
            int licenseID = -1;       DateTime expirationDate = DateTime.Now;
            int appID = -1;           DateTime issueDate = DateTime.Now;
            string notes = " ";       decimal paidFees = -1;
            int issueReason = -1;     bool isActive = false;
            int createdByUserID = -1; 

            if(clsDALManageLicenses._GetInfoLicenseIfExist(DriverID , LicenseClass ,ref appID , ref licenseID , ref issueDate , ref expirationDate , ref notes , ref paidFees , ref isActive , ref issueReason , ref createdByUserID))
                return new clsBLManageLicenses(licenseID, appID, DriverID, LicenseClass, issueDate, expirationDate, notes, paidFees, isActive, issueReason, createdByUserID);
            else
                return null;
        }

        static public bool IsExist(int licenseID)
        {
            return clsDALManageLicenses._IsExist(licenseID);
        }

        static public bool DeactivateLicense(int LicenseID)
        {
            return clsDALManageLicenses._DeactivateLicense(LicenseID);
        }

        public bool AddLicense()
        {
            LicenseID = clsDALManageLicenses._AddLicense(ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
            return LicenseID != -1;
        }


    }
}
