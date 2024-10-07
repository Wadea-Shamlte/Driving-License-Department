using System;
using System.Configuration;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    public class clsDALManageLicenses
    {
        static string Path = ConfigurationManager.AppSettings["Path"];
        //static public string Path = "server=.;Database=DVLD;User Id=sa;Password=sa123456";

        static public void _GetInfoLicenseID(int LicenseID, ref int ApplicationID, ref int DriverID, ref int LicenseClass,ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes,ref decimal PaidFees, ref bool IsActive, ref int IssueReason, ref int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"select * from Licenses
                                              where LicenseID = @LicenseID", connection);
            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    LicenseClass = (int)reader["LicenseClass"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    Notes = (string)reader["Notes"];
                    PaidFees = (decimal)reader["PaidFees"];
                    IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));
                    IssueReason = (int)reader["IssueReason"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            finally { connection.Close(); }
            
        }

        static public bool _GetInfoLicenseIfExist(int DriverID , int LicenseClass ,ref int ApplicationID, ref int LicenseID, ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes, ref decimal PaidFees, ref bool IsActive, ref int IssueReason, ref int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(Path);
            string query1 = @"select count(*) from Licenses
                               where DriverID = @DriverID and LicenseClass = @LicenseClass and IsActive = 1";
            string query2 = @"select * from Licenses
                               where DriverID = @DriverID and LicenseClass = @LicenseClass and IsActive = 1";
            SqlCommand cmd1 = new SqlCommand(query1, connection);
            SqlCommand cmd2 = new SqlCommand(query2, connection);

            cmd1.Parameters.AddWithValue("@DriverID", DriverID);
            cmd1.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            cmd2.Parameters.AddWithValue("@DriverID", DriverID);
            cmd2.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            
            try
            {
                connection.Open();
                object result = cmd1.ExecuteScalar();
                bool IsExist = Convert.ToBoolean(result);
                if (IsExist)
                {
                    SqlDataReader reader = cmd2.ExecuteReader();

                    if (reader.Read())
                    {

                        LicenseID = (int)reader["LicenseID"];
                        ApplicationID = (int)reader["ApplicationID"];
                        IssueDate = (DateTime)reader["IssueDate"];
                        ExpirationDate = (DateTime)reader["ExpirationDate"];
                        Notes = (string)reader["Notes"];
                        PaidFees = (decimal)reader["PaidFees"];
                        IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));
                        IssueReason = (int)reader["IssueReason"];
                        CreatedByUserID = (int)reader["CreatedByUserID"];

                    }
                    return true;
                }
                else return false;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            finally { connection.Close(); }

        }

        static public int _AddLicense(int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees ,bool IsActive , int IssueReason ,int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Licenses]
                                             ([ApplicationID], [DriverID], [LicenseClass], [IssueDate], [ExpirationDate],
                                             [Notes], [PaidFees], [IsActive], [IssueReason], [CreatedByUserID])
                                             VALUES
                                             (@ApplicationID, @DriverID, @LicenseClass, @IssueDate, @ExpirationDate, 
                                             @Notes, @PaidFees, @IsActive, @IssueReason, @CreatedByUserID);
                                             SELECT SCOPE_IDENTITY();", connection);

            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            cmd.Parameters.AddWithValue("@DriverID", DriverID);
            cmd.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            cmd.Parameters.AddWithValue("@IssueDate", IssueDate);
            cmd.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            cmd.Parameters.AddWithValue("@Notes", Notes);
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            cmd.Parameters.AddWithValue("@IssueReason", IssueReason);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            { 
                connection.Open();

                object Result = cmd.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int testResult))
                    return testResult;
                else
                    return -1;

            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return -1; }
            finally { connection.Close(); }
        }

        static public bool _DeactivateLicense(int LicenseID)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[Licenses]
                                              SET [IsActive] = 0
                                              WHERE LicenseID = @LicenseID", connection);
            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            finally { connection.Close(); }
        }

        static public bool _IsExist(int LicenseID)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand("select count(*) from Licenses  where LicenseID = @LicenseID", connection);
            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);


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
