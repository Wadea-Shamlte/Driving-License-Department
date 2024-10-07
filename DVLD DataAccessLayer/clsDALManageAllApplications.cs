using System;
using System.Configuration;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    public class clsDALManageAllApplications
    {
        static string Path = ConfigurationManager.AppSettings["Path"];
        //static public string Path = "server=.;Database=DVLD;User Id=sa;Password=sa123456";

        static public void _GetInfo(int ApplicationID, ref int AppTypeID ,  ref int ApplicantPersonID, ref DateTime ApplicationDate, ref byte ApplicationStatus, ref DateTime LastStatusDate, ref decimal PaidFees, ref int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"select * from Applications
                                              where ApplicationID = @ApplicationID", connection);
            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    ApplicantPersonID = (int)reader["ApplicantPersonID"];
                    ApplicationDate = (DateTime)reader["ApplicationDate"];
                    AppTypeID = (int)reader["ApplicationTypeID"];
                    ApplicationStatus = (byte)reader["ApplicationStatus"];
                    LastStatusDate = (DateTime)reader["LastStatusDate"];
                    PaidFees = (decimal)reader["PaidFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
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
        }

        public static int _GetID()
        {
            using (SqlConnection connection = new SqlConnection(Path))
            {
                string query = $"SELECT TOP 1 ApplicationID FROM Applications ORDER BY [ApplicationID] DESC ";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                            return Convert.ToInt32(result);
                        else return -1;

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        return -1;
                    }
                    finally {  connection.Close(); }
                }
            }
        }

        static public int _AppApplication(int ApplicantPersonID , DateTime ApplicationDate, int ApplicationTypeID , int ApplicationStatus , DateTime LastStatusDate , decimal PaidFees , int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Applications]([ApplicantPersonID],[ApplicationDate],[ApplicationTypeID],
			                                  [ApplicationStatus],[LastStatusDate],[PaidFees],[CreatedByUserID])
                                              VALUES (@ApplicantPersonID , @ApplicationDate , @ApplicationTypeID, @ApplicationStatus, @LastStatusDate, @PaidFees, @CreatedByUserID);
                                              select SCOPE_IDENTITY();", connection);

            cmd.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            cmd.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            cmd.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            cmd.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            

            try
            {
                connection.Open();

                object Result = cmd.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int testResult))
                    return testResult;
                return -1;

            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return -1; }
            finally { connection.Close(); }
        }

        static public bool _UpdateApplication(int AppID, int ApplicationTypeID, int ApplicantPersonID, DateTime ApplicationDate, int ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[Applications]
                                              SET [ApplicantPersonID] = @ApplicantPersonID, [ApplicationDate] = @ApplicationDate ,
                                              [ApplicationStatus] = @ApplicationStatus ,[LastStatusDate] = @LastStatusDate,
                                              [PaidFees] = @PaidFees ,[CreatedByUserID] = @CreatedByUserID
                                              WHERE ApplicationID = @AppID ", connection);

            cmd.Parameters.AddWithValue("@AppID", AppID);
            cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            cmd.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            cmd.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            cmd.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            cmd.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

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

        static public bool _DeleteApplication(int ApplicationID)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[Applications] WHERE ApplicationID = @ApplicationID", connection);
            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);

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

        static public bool _CancelledApplication(int AppID)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[Applications]
                                              SET [ApplicationStatus] = 2 
                                              WHERE ApplicationID = @AppID ", connection);
            cmd.Parameters.AddWithValue("@AppID", AppID);

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

        static public bool _ISExist(int PersonID , int LicenseClassID , int Status)
        {
            SqlConnection connection = new SqlConnection(Path); 
            SqlCommand cmd = new SqlCommand(@"SELECT COUNT(*)
                                              FROM Applications
                                              JOIN LocalDrivingLicenseApplications
                                              ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                                              WHERE LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID
                                              AND Applications.ApplicantPersonID = @PersonID and ApplicationStatus = @Status", connection);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            cmd.Parameters.AddWithValue("@Status", Status);

            try
            {
                connection.Open();
                object Result = cmd.ExecuteScalar();

                return Convert.ToInt32( Result ) >= 1;

            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            finally { connection.Close(); }
        }

        static public bool _CompleteProgramAndHasLicense(int AppID)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[Applications]
                                              SET [ApplicationStatus] = 3 
                                              WHERE ApplicationID = @AppID ", connection);
            cmd.Parameters.AddWithValue("@AppID", AppID);

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
