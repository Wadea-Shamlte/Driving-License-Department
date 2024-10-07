using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
    public class clsBLManageDetainLicense
    {
        public int DetainID { set; get; }
        public int LicenseID{ set; get; } 
        public decimal FineFees { set; get; }
        public DateTime DetainDate { set; get; }
        public int CreatedByUserID { set; get; }
        public bool IsReleased { set; get; }
        public DateTime? ReleaseDate { get; set; }
        public int? ReleasedByUserID { get; set; }
        public int? ReleaseApplicationID { get; set; }

        public clsBLManageDetainLicense()
        {

            DetainID = -1;            
            LicenseID = -1;
            FineFees = 0;
            DetainDate = DateTime.Now;
            CreatedByUserID = -1;
            IsReleased = false;
            ReleaseDate = DateTime.Now;
            ReleasedByUserID = -1;   
            ReleaseApplicationID = -1;
        }

        public clsBLManageDetainLicense(int detainID, int licenseID, decimal fineFees, DateTime detainDate, int createdByUserID, bool isReleased, DateTime? releaseDate, int? releasedByUserID, int? releaseApplicationID)
        {
            DetainID = detainID;
            LicenseID = licenseID;
            FineFees = fineFees;
            DetainDate = detainDate;
            CreatedByUserID = createdByUserID;
            IsReleased = isReleased;
            ReleaseDate = releaseDate;
            ReleasedByUserID = releasedByUserID;
            ReleaseApplicationID = releaseApplicationID;
        }


        static public clsBLManageDetainLicense GetInfoByDetainID(int detainID)
        {
            int licenseID = -1;
            decimal fineFees = 0;
            DateTime detainDate = DateTime.Now;
            int createdByUserID = -1;
            bool isReleased = false;
            DateTime? releaseDate = null;
            int? releasedByUserID = null;
            int? releaseApplicationID = null;

            clsDALManageDetainLicense._GetInfoByDetainID(detainID,ref licenseID, ref fineFees, ref detainDate, ref createdByUserID, ref isReleased, ref releaseDate, ref releasedByUserID, ref releaseApplicationID);

            return new clsBLManageDetainLicense(detainID, licenseID, fineFees, detainDate, createdByUserID, isReleased, releaseDate, releasedByUserID, releaseApplicationID);

        }

        static public clsBLManageDetainLicense GetInfoByLicenseID(int licenseID)
        {
            int detainID = -1;
            decimal fineFees = 0;
            DateTime detainDate = DateTime.Now;
            int createdByUserID = -1;
            bool isReleased = false;
            DateTime? releaseDate = null;
            int? releasedByUserID = null;
            int? releaseApplicationID = null;

            if(clsDALManageDetainLicense._IsDetained(licenseID))
            {
                clsDALManageDetainLicense._GetInfoByLicenseID(licenseID, ref detainID, ref fineFees, ref detainDate, ref createdByUserID, ref isReleased, ref releaseDate, ref releasedByUserID, ref releaseApplicationID);

                return new clsBLManageDetainLicense(detainID, licenseID, fineFees, detainDate, createdByUserID, isReleased, releaseDate, releasedByUserID, releaseApplicationID);
            }
            else
                return null;
        }


        static public DataTable GetAllDetainedLicenses()
        {
            return clsDALManageDetainLicense._GetAllDetainedLicenses();
        }


        public bool DetainedLicense()
        {
            DetainID = clsDALManageDetainLicense._DetainedLicense(LicenseID, FineFees, DetainDate, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);

            return DetainID != -1;

        }

        public bool ReleaseLicense()
        {
            return clsDALManageDetainLicense._ReleaseLicense(DetainID ,LicenseID, FineFees, DetainDate, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
        }


        static public bool IsDetained(int licenseID)
        {
            return clsDALManageDetainLicense._IsDetained(licenseID);
        }

    }
}
