using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    public class clsDALManageTestAppointments
    {
        static string Path = ConfigurationManager.AppSettings["Path"];
        //static public string Path = "server=.;Database=DVLD;User Id=sa;Password=sa123456";

        static public void _GetInfo(int TestAppointmentID, ref int TestTypeID, ref int LDLAppID , ref DateTime AppointmentDate, ref decimal PaidFees, ref int CreatedByUserID, ref bool IsLocked)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"select * from TestAppointments
                                              where TestAppointmentID = @TestAppointmentID", connection);

            cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    TestTypeID = (int)reader["TestTypeID"];
                    LDLAppID = (int)reader["LocalDrivingLicenseApplicationID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = (decimal)reader["PaidFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsLocked = reader.GetInt32(reader.GetOrdinal("IsLocked")) == 1;
                }
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            finally { connection.Close(); }
        }
        
        static public DataTable _GetTestAppointmentsInfoByAppTypeID(int LDLAppID , int TestID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"SELECT TestAppointmentID, AppointmentDate, PaidFees, IsLocked
                                              FROM TestAppointments 
                                              WHERE LocalDrivingLicenseApplicationID = @LDLAppID and TestTypeID = @TestID;", connection);
            cmd.Parameters.AddWithValue("@LDLAppID", LDLAppID);
            cmd.Parameters.AddWithValue("@TestID", TestID);

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

        static public bool _IsAppointmentExist(int LDLAppID , int TestTypeID)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"select count(*) from TestAppointments
                                              where LocalDrivingLicenseApplicationID = @LDLAppID and TestTypeID = @TestTypeID and IsLocked = 0;", connection);
            cmd.Parameters.AddWithValue("@LDLAppID" , LDLAppID );
            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object Result = cmd.ExecuteScalar();
                if (Convert.ToInt32(Result) >= 1)
                    return true;
                else
                    return false;

            }catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            finally { connection.Close(); }
        }

        static public bool _IsPassed(int LDLAppID, int TestTypeID)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"SELECT  top(1) Tests.TestResult
                                              FROM Tests INNER JOIN TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                                              where TestAppointments.LocalDrivingLicenseApplicationID = @LDLAppID and TestAppointments.TestTypeID = @TestTypeID
                                              order by TestAppointments.TestAppointmentID desc ", connection);
            cmd.Parameters.AddWithValue("@LDLAppID", LDLAppID);
            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object Result = cmd.ExecuteScalar();

                return Convert.ToBoolean(Result) ? true : false;    

            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            finally { connection.Close(); }
        }

        static public bool _IsFailed(int LDLAppID, int TestTypeID)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"SELECT  top(1) Tests.TestResult
                                              FROM Tests INNER JOIN TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                                              where TestAppointments.LocalDrivingLicenseApplicationID = @LDLAppID and TestAppointments.TestTypeID = @TestTypeID
                                              order by TestAppointments.TestAppointmentID desc ", connection);
            cmd.Parameters.AddWithValue("@LDLAppID", LDLAppID);
            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object Result = cmd.ExecuteScalar();

                if (Result != null && bool.TryParse(Result.ToString(), out bool testResult))
                    return !testResult; 
                else
                    return false;

            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            finally { connection.Close(); }
        }

        static public bool _AddAppointment(int TestTypeID, int LDLAppID, DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID, bool IsLocked)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[TestAppointments]
                                              ([TestTypeID],[LocalDrivingLicenseApplicationID],[AppointmentDate]
                                              ,[PaidFees],[CreatedByUserID],[IsLocked])
                                              VALUES
                                              (@TestTypeID , @LocalDrivingLicenseApplicationID , @AppointmentDate ,
                                              @PaidFees , @CreatedByUserID , @IsLocked );
                                              select SCOPE_IDENTITY();", connection);
            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLAppID);
            cmd.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            cmd.Parameters.AddWithValue("@IsLocked", IsLocked);

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
        
        static public bool _UpdateAppointment(int TestAppointmentID, int TestTypeID, int LDLAppID, DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[TestAppointments]
                                              SET [TestTypeID] = @TestTypeID, [LocalDrivingLicenseApplicationID] = @LocalDrivingLicenseApplicationID ,
                                              [AppointmentDate] = @AppointmentDate ,[PaidFees] = @PaidFees , [CreatedByUserID] = @CreatedByUserID 
                                              WHERE TestAppointmentID = @TestAppointmentID", connection);


            cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLAppID);
            cmd.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
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

        static public bool _UpdateStatusLooked(int TestAppointmentID , byte IsLocked)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[TestAppointments]
                                              SET [IsLocked] = @IsLocked 
                                              WHERE TestAppointmentID = @TestAppointmentID", connection);


            cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            cmd.Parameters.AddWithValue("@IsLocked", IsLocked);

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
