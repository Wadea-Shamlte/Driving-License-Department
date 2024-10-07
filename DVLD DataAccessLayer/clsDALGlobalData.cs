using System;
using System.Configuration;
using System.Data.SqlClient;


namespace DVLD_DataAccessLayer
{
    public class clsDALGlobalData
    {
        static string Path = ConfigurationManager.AppSettings["Path"];
        //static public string Path = "server=.;Database=DVLD;User Id=sa;Password=sa123456";

        static public decimal _GetFeesApplication(int IDApp)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"select ApplicationFees from ApplicationTypes
                                              where ApplicationTypeID = @IDApp", connection);
            cmd.Parameters.AddWithValue("@IDApp", IDApp);

            try
            {
                connection.Open();

                object Result = cmd.ExecuteScalar();

                if (Result != null)
                    return Convert.ToDecimal(Result);
                else
                    return -1;
            }catch (Exception ex) { Console.WriteLine(ex.ToString()); return -1; }
            finally { connection.Close(); }
        }

    }
}
