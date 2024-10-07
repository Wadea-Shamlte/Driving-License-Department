using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace DVLD_DataAccessLayer
{
    public class clsDALManageDriver
    {
        static string Path = ConfigurationManager.AppSettings["Path"];
        //static public string Path = "server=.;Database=DVLD;User Id=sa;Password=sa123456";

        static public void _GetInfoByDriverID(int DriverID, ref int PersonID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"select * from Drivers
                                              where DriverID = @DriverID", connection);
            cmd.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    PersonID = (int)reader["PersonID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            finally { connection.Close(); }
            
        }

        static public void _GetInfoByPersonID(int PersonID, ref int DriverID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"select * from Drivers
                                              where PersonID = @PersonID", connection);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    DriverID = (int)reader["DriverID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            finally { connection.Close(); }

        }

        static public DataTable _GetAllDrivers()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"select * from Drivers_View", connection);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                    dt.Load(reader);

                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            finally { connection.Close();  }

            return dt;

        }

        static public bool _AddDriver(int PersonID ,int CreatedByUserID ,DateTime CreatedDate)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Drivers]
                                              ([PersonID],[CreatedByUserID],[CreatedDate])
                                              VALUES
                                              (@PersonID, @CreatedByUserID, @CreatedDate)
                                              Select SCOPE_IDENTITY();", connection);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            cmd.Parameters.AddWithValue("@CreatedDate", CreatedDate);

            try
            {
                connection.Open();

                object Result = cmd.ExecuteScalar();

                if (Result == null)
                    return false;
                else return true;


            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            finally { connection.Close(); }
        }

        static public bool _IsExistByDriverID(int DriverID)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand("select count(*) from Drivers  where DriverID = @DriverID", connection);
            cmd.Parameters.AddWithValue("@DriverID", DriverID);


            try
            {
                connection.Open();

                object Result = cmd.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int count))
                    return count > 0;
                else
                    return false;

            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            finally { connection.Close(); }
        }

        static public bool _IsExistByPersonID(int PersonID)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand("select count(*) from Drivers  where PersonID = @PersonID", connection);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);


            try
            {
                connection.Open();

                object Result = cmd.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int count))
                    return count > 0;
                else
                    return false;

            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            finally { connection.Close(); }
        }

        
    }
}
