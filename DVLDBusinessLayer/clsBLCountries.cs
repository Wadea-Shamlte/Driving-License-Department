using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
    public class clsBLCountries
    {
        static public DataTable GetAllCountries()
        {
            DataTable table = clsDALCountries._GetAllCountries();
            return table;

        }
        static public int GetCountryID(string CountryName)
        {
            return clsDALCountries._GetCountryID(CountryName);
        }
    }
}
