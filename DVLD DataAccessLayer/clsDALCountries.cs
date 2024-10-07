using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DVLD_DataAccessLayer
{
    public class clsDALCountries
    {
        static string Path = ConfigurationManager.AppSettings["Path"];
        //static public string Path = "server=.;Database=DVLD;User Id=sa;Password=sa123456";

        static public DataTable _GetAllCountries()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand("select CountryName from Countries", connection);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                    dt.Load(reader);

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }
        static public int _GetCountryID(string CountryName)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand("select CountryID from Countries where CountryName = @CountryName", connection);
            cmd.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                connection.Open();

                object Result = cmd.ExecuteScalar();
                if (Result != null)
                {
                    ID = Convert.ToInt32(Result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                connection.Close();
            }

            return ID;
        }

    }
}
