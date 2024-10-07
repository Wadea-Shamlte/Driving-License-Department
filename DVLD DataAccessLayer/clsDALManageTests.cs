using System;
using System.Configuration;
using System.Data.SqlClient;


namespace DVLD_DataAccessLayer
{
    public class clsDALManageTests
    {
        static string Path = ConfigurationManager.AppSettings["Path"];
        //static public string Path = "server=.;Database=DVLD;User Id=sa;Password=sa123456";

        static public int _GetTestIDIfExist(int TestAppointmentID)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"select * from Tests
                                              where TestAppointmentID = @TestAppointmentID", connection);

            cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                connection.Open();

                object Result = cmd.ExecuteScalar();

                if (Result != null)
                    return Convert.ToInt32(Result);
                else
                    return -1;

            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return -1; }
            finally { connection.Close(); }
        }

        static public bool _SaveResultTest(int TestAppointmentID , byte TestResult, string Notes , int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Tests]
                                              ([TestAppointmentID],[TestResult],[Notes],[CreatedByUserID])
                                              VALUES
                                              (@TestAppointmentID, @TestResult, @Notes, @CreatedByUserID);
                                              select SCOPE_IDENTITY();", connection);
            cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            cmd.Parameters.AddWithValue("@TestResult", TestResult);
            cmd.Parameters.AddWithValue("@Notes", Notes);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

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

        static public int _GetNumOfPassedTests(int LDLAppID)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"SELECT COUNT(TestAppointments.TestTypeID) AS PassedTestCount
                                              FROM Tests INNER JOIN dbo.TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                                              WHERE (TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID) AND (dbo.Tests.TestResult = 1 ) 
                                              and LocalDrivingLicenseApplicationID = @LDLAppID", connection);

            cmd.Parameters.AddWithValue("@LDLAppID", LDLAppID);

            try
            {
                connection.Open();

                object Result = cmd.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int passedTestCount))
                    return passedTestCount;
                else
                    return -1;

            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return -1; }
            finally { connection.Close(); }
        }

    }
}
