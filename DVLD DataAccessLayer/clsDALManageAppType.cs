using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DVLD_DataAccessLayer
{
    public class clsDALManageAppType
    {
        static string Path = ConfigurationManager.AppSettings["Path"];
        //static public string Path = "server=.;Database=DVLD;User Id=sa;Password=sa123456";

        static public void _GetDataAppInfo(int AppType, ref string ApplicationTypeTitle, ref decimal ApplicationFees)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"SELECT ApplicationTypeTitle, ApplicationFees  FROM ApplicationTypes WHERE ApplicationTypeID = @AppType", connection);
            cmd.Parameters.AddWithValue("@AppType", AppType);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    ApplicationTypeTitle = (string)reader["ApplicationTypeTitle"];
                    ApplicationFees = (decimal)reader["ApplicationFees"];

                    reader.Close();
                }
                else
                    reader.Close();

            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            finally { connection.Close(); }

        }

        static public DataTable _GetDataApplicationType()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"select * From ApplicationTypes", connection);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                    dt.Load(reader);

                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            finally { connection.Close(); }

            return dt;
        }

        static public bool _UpdateAppType(int AppType, string ApplicationTypeTitle, decimal ApplicationFees)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[ApplicationTypes]
                                              SET [ApplicationTypeTitle] = @ApplicationTypeTitle ,[ApplicationFees] = @ApplicationFees
                                              WHERE ApplicationTypeID = @AppType", connection);


            cmd.Parameters.AddWithValue("@AppType", AppType);
            cmd.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
            cmd.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);

            try
            {
                connection.Open();
                int RowAffected = cmd.ExecuteNonQuery();

                if (RowAffected < 1)
                    return false;
                else return true;

            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            finally { connection.Close(); }
        }

        static public decimal _GetFeesRetakeTestApp()
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"select ApplicationFees From ApplicationTypes
                                              where ApplicationTypeID = 7" , connection);

            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();

                if (result != null)
                    return Convert.ToDecimal(result) ;
                else return 0;

            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return 0; }
            finally { connection.Close(); }
        }

        static public decimal _GetAppTypeFees(int AppTypeID)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"select ApplicationFees From ApplicationTypes
                                              where ApplicationTypeID = @AppTypeID", connection);
            cmd.Parameters.AddWithValue("@AppTypeID", AppTypeID);
            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();

                if (result != null)
                    return Convert.ToDecimal(result);
                else return 0;

            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return 0; }
            finally { connection.Close(); }
        }

    }
}
