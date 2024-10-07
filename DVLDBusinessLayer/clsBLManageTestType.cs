using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
    public class clsBLManageTestType
    {
        public int TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public decimal TestTypeFees { get; set; }

        public clsBLManageTestType()
        {
            TestTypeID = -1;
            TestTypeTitle = " ";
            TestTypeDescription = " ";
            TestTypeFees = 0;
        }
        public clsBLManageTestType(int testTypeID, string testTypeTitle, string testTypeDescription, decimal testTypeFees)
        {
            TestTypeID = testTypeID;
            TestTypeTitle = testTypeTitle;
            TestTypeDescription = testTypeDescription;
            TestTypeFees = testTypeFees;
        }

        static public clsBLManageTestType GetTestTypeInfo(int ID)
        {
            string testTypeTitle = " ";
            string testTypeDescription = " ";
            decimal testTypeFees = 0;

            clsDALManageTestType._GetTestTypeInfo(ID, ref testTypeTitle, ref testTypeDescription , ref testTypeFees);

            return new clsBLManageTestType(ID, testTypeTitle, testTypeDescription, testTypeFees);
        }

        static public DataTable GetAllTestTypeInfo()
        {
            DataTable dataTable = clsDALManageTestType._GetAllDataTestType();
            return dataTable;
        }

        public bool Update(int ID)
        {
            return clsDALManageTestType._UpdateDataTestType(ID, TestTypeTitle, TestTypeDescription , TestTypeFees);
        }
    }
}
