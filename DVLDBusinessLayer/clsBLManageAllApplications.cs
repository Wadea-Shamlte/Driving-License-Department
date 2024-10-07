using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLDBusinessLayer
{
    public class clsBLManageAllApplications
    {
        public int      ApplicationID     { get; set; }
        public int      ApplicantPersonID { get; set; }
        public DateTime ApplicationDate   { get; set; }
        public int      ApplicationTypeID { get; set; }
        public byte     ApplicationStatus { get; set; }
        public DateTime LastStatusDate    { get; set; }
        public decimal  PaidFees          { get; set; }
        public int      CreatedByUserID   { get; set; }

        public clsBLManageAllApplications()
        {
            ApplicationID = -1;
            ApplicantPersonID = -1;
            ApplicationDate = DateTime.Now;
            ApplicationTypeID = -1;
            ApplicationStatus = 0;
            LastStatusDate = DateTime.Now;
            PaidFees = -1;
            CreatedByUserID = -1;
        }

        public clsBLManageAllApplications(int applicationID, int applicantPersonID, DateTime applicationDate, int applicationTypeID, byte applicationStatus, DateTime lastStatusDate, decimal paidFees, int createdByUserID)
        {
            ApplicationID = applicationID;
            ApplicantPersonID = applicantPersonID;
            ApplicationDate = applicationDate;
            ApplicationTypeID = applicationTypeID;
            ApplicationStatus = applicationStatus;
            LastStatusDate = lastStatusDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
        }

        static public clsBLManageAllApplications GetInfo(int AppID )
        {
            int applicantPersonID = -1;
            DateTime applicationDate = DateTime.Now;
            int applicationTypeID = -1;
            byte applicationStatus = 0;
            DateTime lastStatusDate = DateTime.Now;
            decimal paidFees = -1;
            int createdByUserID = -1;

            clsDALManageAllApplications._GetInfo(AppID, ref applicationTypeID, ref applicantPersonID, ref applicationDate, ref applicationStatus, ref lastStatusDate, ref paidFees, ref createdByUserID);

            return new clsBLManageAllApplications(AppID, applicantPersonID, applicationDate, applicationTypeID, applicationStatus, lastStatusDate, paidFees, createdByUserID);
                                   
        }

        static public int GetLastID()
        {
            return clsDALManageAllApplications._GetID();
        }

        public bool Add()
        {
            ApplicationID = clsDALManageAllApplications._AppApplication(ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus , LastStatusDate, PaidFees, CreatedByUserID);

            return ApplicationID != -1;
        }

        public bool Update()
        {
            return clsDALManageAllApplications._UpdateApplication(ApplicationID , ApplicationTypeID, ApplicantPersonID, ApplicationDate,  ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);

        }

        static public bool Delete(int AppTypeID)
        {
            return clsDALManageAllApplications._DeleteApplication(AppTypeID);
        }

        static public bool Cancelled(int AppID)
        {
            return clsDALManageAllApplications._CancelledApplication(AppID);
        }

        static public bool IsExist(int PersonID , int LicenseClassID , int Status)
        {
            return clsDALManageAllApplications._ISExist(PersonID , LicenseClassID , Status);
        }

        static public bool CompleteProgramAndHasLicense(int AppID)
        {
            return clsDALManageAllApplications._CompleteProgramAndHasLicense(AppID);    
        }
    }
}
