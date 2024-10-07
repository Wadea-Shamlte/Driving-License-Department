using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
    public class clsBLManagePeople
    {
        public int ID { set; get; }
        public string NationalNo { set; get; }
        public string FName { set; get; }
        public string SName { set; get; }
        public string ThName { set; get; }
        public string LName { set; get; }
        public string FullName()
        {
            return FName + " " + SName + " " + ThName + " " + LName;
        }
        public int Gender { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public string Address { set; get; }
        public DateTime DateOfBirth { set; get; }
        public string CountryName { set; get; }
        public int CountryID { set; get; }
        public string ImagePath { set; get; }

        public clsBLManagePeople()
        {
            this.ID = -1;
            this.NationalNo = "";
            this.FName = "";
            this.SName = "";
            this.ThName = "";
            this.LName = "";
            this.Email = "";
            this.Phone = "";
            this.Address = "";
            this.DateOfBirth = DateTime.Now;
            this.Gender = -1;
            this.CountryName = "";
            this.ImagePath = "";
        }
        public clsBLManagePeople(int ID, string NationalNo, string FName, string SName, string ThName, string LName, DateTime DateOfBirth, int Gender, string Address, string Phone, string Email, string CountryName, string ImagePath)
        {
            this.ID = ID;
            this.NationalNo = NationalNo;
            this.FName = FName;
            this.SName = SName;
            this.ThName = ThName;
            this.LName = LName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.CountryName = CountryName;
            this.ImagePath = ImagePath;
        }

        public static bool IsExist(int ID)
        {
            return clsDALManagePeople.IsExist(ID);
        }
        public static bool IsExist(string No)
        {
            return clsDALManagePeople.IsExist(No);
        }

        static clsBLManagePeople Find(int ID)
        {
            string FName = " "; string NationalNo = " ";
            string SName = " "; string Phone = " ";
            string ThName = " "; DateTime DateOfBirth = DateTime.Now.Date;
            string LName = " "; string CountryName = "";
            string Email = " "; string ImagePath = " ";
            string Address = " "; int Gender = -1;


            if (IsExist(ID))
            {
                clsDALManagePeople._GetDataByPersonalID(ID, ref NationalNo, ref FName, ref SName, ref ThName, ref LName, ref DateOfBirth, ref Gender, ref Address, ref Phone, ref Email, ref CountryName, ref ImagePath);

                return new clsBLManagePeople(ID, NationalNo, FName, SName, ThName, LName, DateOfBirth.Date, Gender, Address, Phone, Email, CountryName, ImagePath);
            }
            else
                return new clsBLManagePeople();


        }
        static clsBLManagePeople Find(string No)
        {
            string FName = " "; int ID = -1;
            string SName = " "; string Phone = " ";
            string ThName = " "; DateTime DateOfBirth = DateTime.Now;
            string LName = " "; string CountryName = "";
            string Email = " "; string ImagePath = " ";
            string Address = " "; int Gender = -1;

            if (IsExist(No))
            {
                clsDALManagePeople._GetDataByNationalNo(No, ref ID, ref FName, ref SName, ref ThName, ref LName, ref DateOfBirth, ref Gender, ref Address, ref Phone, ref Email, ref CountryName, ref ImagePath);

                return new clsBLManagePeople(ID, No, FName, SName, ThName, LName, DateOfBirth.Date, Gender, Address, Phone, Email, CountryName, ImagePath);
            }
            else
                return new clsBLManagePeople();
        }

        static public clsBLManagePeople GetPersonalInfo(int ID)
        {
            clsBLManagePeople clsBusiness = clsBLManagePeople.Find(ID);

            return clsBusiness;
        }
        static public clsBLManagePeople GetPersonalInfo(string No)
        {
            clsBLManagePeople clsBusiness = clsBLManagePeople.Find(No);

            return clsBusiness;
        }



        public bool _Add()
        {
            return clsDALManagePeople._AddPerson(NationalNo, FName, SName, ThName, LName, DateOfBirth, Gender, Address, Phone, Email, CountryID, ImagePath);
        }
        public bool _Update()
        {
            return clsDALManagePeople._UpdatePerson(ID, NationalNo, FName, SName, ThName, LName, DateOfBirth, Gender, Address, Phone, Email, CountryID, ImagePath);
        }
        public bool _Save()
        {
            if (this.ID == -1)
                return _Add();
            else
                return _Update();
        }
        static public bool _Delete(int ID)
        {
            return clsDALManagePeople._DeletePerson(ID);
        }
        static public int GetIDByNationalNo(string No)
        {
            return clsDALManagePeople._GetIDByNationalNo(No);
        }
        static public DataTable GetAllData()
        {
            return clsDALManagePeople._AllData();
        }
        static public DataTable GetAllNationalNo()
        {
            DataTable dt = clsDALManagePeople._GetAllNationalNo();
            return dt;

        }
        static public DataTable GetAllPersonalID()
        {
            DataTable dt = clsDALManagePeople._GetAllPersonalID();
            return dt;
        }
    }
}
