using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
    static public class clsBLGlobalData
    {
        public static string SharedUserName {  get; set; }

        static public decimal GetFeesApplication(int IDApp)
        {
            return clsDALGlobalData._GetFeesApplication(IDApp);
        }

        
    }
}
