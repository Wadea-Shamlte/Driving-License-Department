using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsBLManageUsers
    {
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public int IsActive { get; set; }
        public string _UserName { get; set; }
        public string _Password { get; set; }

        public clsBLManageUsers()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.IsActive = -1;
            this._UserName = "";
            this._Password = "";
        }
        public clsBLManageUsers(int UserId, int PersonId, int IsActive, string UserName, string Password)
        {
            this.UserID = UserId;
            this.PersonID = PersonId;
            this.IsActive = IsActive;
            this._UserName = UserName;
            this._Password = Password;
        }

        static public bool IsExist(int ID)
        {
            return clsDALManageUsers._IsExist(ID);
        }



        static public clsBLManageUsers GetUserInfoByUserID(int userID)
        {
            int PersonID = -1;
            string UserName = " ";
            string Password = " ";
            int IsActive = 0;


            clsDALManageUsers._GetUserInfoByUID(userID, ref PersonID, ref UserName, ref Password, ref IsActive);

            return new clsBLManageUsers(userID, PersonID, IsActive, UserName, Password);
        }

        static public clsBLManageUsers GetUserInfoByPersonID(int PersonID)
        {
            int UserID = -1;
            string UserName = " ";
            string Password = " ";
            int IsActive = 0;


            if (IsExist(PersonID))
            {
                clsDALManageUsers._GetUserInfoByPerID(PersonID, ref UserID, ref UserName, ref Password, ref IsActive);

                return new clsBLManageUsers(UserID, PersonID, IsActive, UserName, Password);
            }
            else
                return new clsBLManageUsers();
        }

        static public clsBLManageUsers GetUserInfoByUserName(string userName)
        {
            int UserID = -1;
            int PersonID = -1;
            string Password = " ";
            int IsActive = 0;

            clsDALManageUsers._GetUserInfoByUN(userName, ref PersonID, ref UserID, ref Password, ref IsActive);

            return new clsBLManageUsers(UserID, PersonID, IsActive, userName, Password);
        }



        public bool _Add()
        {
            return clsDALManageUsers._AddNewUser(PersonID, _UserName, _Password, IsActive);
        }
        public bool _Update()
        {
            return clsDALManageUsers._UpdateUser(PersonID, _UserName, _Password, IsActive);
        }
        static public bool _Delete(int ID)
        {
            return clsDALManageUsers._DeleteUser(ID);
        }

        static public DataTable GetAllUserName()
        {
            DataTable dt = clsDALManageUsers._GetAllUserName();
            return dt;
        }
        static public DataTable GetAllDataUsers()
        {
            DataTable dt = clsDALManageUsers._GetAllDataUsers();
            return dt;
        }
        static public DataTable GetUserNamePass()
        {
            DataTable dt = clsDALManageUsers._GetUserNamePass();
            return dt;
        }


        public static bool isActive(string UserName)
        {
            if (clsDALManageUsers._IsActive(UserName) == 1)
                return true;
            else
                return false;
        }
    }
}
