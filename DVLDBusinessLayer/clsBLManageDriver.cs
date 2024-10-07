using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
    public class clsBLManageDriver
    {
        public int DriverID { set; get; }
        public int PersonID{ set; get; } 
        public int CreatedByUserID { set; get; }
        public DateTime CreatedDate { set; get; }

        public clsBLManageDriver()
        {
            DriverID = -1;
            PersonID = -1;
            CreatedByUserID = -1;
            CreatedDate = DateTime.Now;
        }

        public clsBLManageDriver(int driverID , int personID , int createdByUserID , DateTime createdDate)
        {
            DriverID = driverID;
            PersonID = personID;
            CreatedByUserID = createdByUserID;
            CreatedDate = createdDate;
        }


        static public clsBLManageDriver GetInfoByDriverID(int driverID)
        {
            int personID = -1;
            int createdByUserID = -1;
            DateTime createdDate = DateTime.Now;

            if (clsDALManageDriver._IsExistByDriverID(driverID))
            {
                clsDALManageDriver._GetInfoByDriverID(driverID, ref personID, ref createdByUserID, ref createdDate);

                return new clsBLManageDriver(driverID, personID, createdByUserID, createdDate);
            }
            else
                return null;
        }

        static public clsBLManageDriver GetInfoByPersonID(int personID)
        {
            int driverID = -1;
            int createdByUserID = -1;
            DateTime createdDate = DateTime.Now;

            if (clsDALManageDriver._IsExistByPersonID(personID))
            {
                clsDALManageDriver._GetInfoByPersonID(personID, ref driverID, ref createdByUserID, ref createdDate);

                return new clsBLManageDriver(driverID, personID, createdByUserID, createdDate);
            }
            else
                return null;
        }

        static public DataTable GetAllDrivers()
        {
            return clsDALManageDriver._GetAllDrivers();
        }


        static public bool IsExistByDriverID(int driverID)
        {
            return clsDALManageDriver._IsExistByDriverID(driverID);
        }

        static public bool IsExistByPersonID(int personID)
        {
            return clsDALManageDriver._IsExistByPersonID(personID);
        }


        public bool Add()
        {
            return clsDALManageDriver._AddDriver(PersonID , CreatedByUserID , CreatedDate);
        }


    }
}
