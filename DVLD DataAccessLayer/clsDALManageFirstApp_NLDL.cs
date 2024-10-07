using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    public class clsDALManageFirstApp_NLDL
    {
        static string Path = ConfigurationManager.AppSettings["Path"];
        //static public string Path = "server=.;Database=DVLD;User Id=sa;Password=sa123456";

        static public DataTable _LocalDrivingLicenseApplications_View()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"SELECT * from LocalDrivingLicenseApplications_View", connection);

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

        static public void _GetInfo(int ID , ref int AppId, ref int ClassID)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"select * from LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID = @ID ", connection);

            cmd.Parameters.AddWithValue("@ID", ID);  

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AppId = (int)reader["ApplicationID"];
                    ClassID = (int)reader["LicenseClassID"];
                }
                reader.Close();
            }
            catch(Exception ex) { Console.WriteLine(ex.ToString()); }
            finally { connection.Close(); }
        }


        static public string _GetClassName(int LicenseClassID)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"select ClassName from LicenseClasses
                                              where LicenseClassID = @LicenseClassID ", connection);

            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            string className = " ";
            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.Read()) 
                    className = (string)reader["ClassName"];

                reader.Close();
                return className;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return className; }
            finally { connection.Close(); }
        }

        static public byte _GetValidityLength(int LicenseClassID)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"select DefaultValidityLength from LicenseClasses
                                              where LicenseClassID = @LicenseClassID ", connection);

            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                    return (byte)result;
                else
                    return 0;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return 0; }
            finally { connection.Close(); }
        }

        static public decimal _GetClassFees(int LicenseClassID)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"select ClassFees from LicenseClasses
                                              where LicenseClassID = @LicenseClassID ", connection);

            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                    return (decimal)result;
                else
                    return -1;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return -1; }
            finally { connection.Close(); }
        }


        static public decimal _GetTestFees(int ID)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"select TestTypeFees from TestTypes
                                              where TestTypeID = @ID ", connection);

            cmd.Parameters.AddWithValue("@ID", ID);
            decimal className = -1;
            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                    className = (decimal)reader["TestTypeFees"];

                reader.Close();
                return className;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return className; }
            finally { connection.Close(); }
        }

        static public bool _AddLocalDrivingLicenseApplication(int AppID , int ClassID)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[LocalDrivingLicenseApplications] ([ApplicationID], [LicenseClassID])
                                              VALUES (@AppID, @ClassID);
                                              SELECT SCOPE_IDENTITY();", connection);
            cmd.Parameters.AddWithValue("@AppID", AppID);
            cmd.Parameters.AddWithValue("@ClassID", ClassID);

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

        static public bool _UpdateLocalDrivingLicenseApplication(int AppID, int ClassID)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[LocalDrivingLicenseApplications]
                                            SET [LicenseClassID] = @ClassID
                                            WHERE ApplicationID = @AppID", connection);
            cmd.Parameters.AddWithValue("@AppID", AppID);
            cmd.Parameters.AddWithValue("@ClassID", ClassID);

            try
            {
                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            finally { connection.Close(); }
        }

        static public bool _DeleteLocalDrivingLicenseApplication(int LDLApp)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[LocalDrivingLicenseApplications] WHERE LocalDrivingLicenseApplicationID = @LDLApp", connection);
            cmd.Parameters.AddWithValue("@LDLApp", LDLApp);

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











    }
}
