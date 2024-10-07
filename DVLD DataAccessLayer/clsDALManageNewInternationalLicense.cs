using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    public class clsDALManageNewInternationalLicense
    {
        //static public string Path = "server=.;Database=DVLD;User Id=sa;Password=sa123456";
        static string Path = ConfigurationManager.AppSettings["Path"];

        //static public void _GetInfoLicenseID(int LicenseID, ref int ApplicationID, ref int DriverID, ref int LicenseClass, ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes, ref decimal PaidFees, ref bool IsActive, ref int IssueReason, ref int CreatedByUserID)
        //{
        //    SqlConnection connection = new SqlConnection(Path);
        //    SqlCommand cmd = new SqlCommand(@"select * from Licenses
        //                                      where LicenseID = @LicenseID", connection);
        //    cmd.Parameters.AddWithValue("@LicenseID", LicenseID);

        //    try
        //    {
        //        connection.Open();
        //        SqlDataReader reader = cmd.ExecuteReader();

        //        if (reader.Read())
        //        {

        //            ApplicationID = (int)reader["ApplicationID"];
        //            DriverID = (int)reader["DriverID"];
        //            LicenseClass = (int)reader["LicenseClass"];
        //            IssueDate = (DateTime)reader["IssueDate"];
        //            ExpirationDate = (DateTime)reader["ExpirationDate"];
        //            Notes = (string)reader["Notes"];
        //            PaidFees = (decimal)reader["PaidFees"];
        //            IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));
        //            IssueReason = (int)reader["IssueReason"];
        //            CreatedByUserID = (int)reader["CreatedByUserID"];
        //        }
        //    }
        //    catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        //    finally { connection.Close(); }

        //}

        static public DataTable _GetAllInternationalLicenseInfo()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"select * From InternationalLicenses", connection);

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

        static public bool _AddLicense(int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate, bool IsActive,int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[InternationalLicenses]
                                             ([ApplicationID],[DriverID],[IssuedUsingLocalLicenseID],
                                             [IssueDate],[ExpirationDate],[IsActive],[CreatedByUserID])
                                             VALUES
                                             (@ApplicationID, @DriverID, @IssuedUsingLocalLicenseID, 
                                             @IssueDate, @ExpirationDate, @IsActive, @CreatedByUserID);
                                             SELECT SCOPE_IDENTITY();", connection);

            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            cmd.Parameters.AddWithValue("@DriverID", DriverID);
            cmd.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            cmd.Parameters.AddWithValue("@IssueDate", IssueDate);
            cmd.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();

                object Result = cmd.ExecuteScalar();

                return Result != null;

            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            finally { connection.Close(); }
        }

        static public bool _IsExist(int DriverID)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand("select count(*) from InternationalLicenses  where DriverID = @DriverID and IsActive = 1;", connection);
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


    }
}
