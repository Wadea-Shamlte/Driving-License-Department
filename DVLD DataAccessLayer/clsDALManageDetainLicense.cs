using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    public class clsDALManageDetainLicense
    {
        static string Path = ConfigurationManager.AppSettings["Path"];
        //static public string Path = "server=.;Database=DVLD;User Id=sa;Password=sa123456";

        static public void _GetInfoByDetainID(int DetainID, ref int LicenseID,ref decimal FineFees , ref DateTime DetainDate ,ref int CreatedByUserID , ref bool IsReleased , ref DateTime? ReleaseDate , ref int? ReleasedByUserID , ref int? ReleaseApplicationID)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"select * from DetainedLicenses
                                              where DetainID = @DetainID and IsReleased = 0", connection);
            cmd.Parameters.AddWithValue("@DetainID", DetainID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    LicenseID = (int)reader["LicenseID"];
                    FineFees = (decimal)reader["FineFees"];
                    DetainDate = (DateTime)reader["DetainDate"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsReleased = (bool)reader["IsReleased"];
                    ReleaseDate = reader.IsDBNull(reader.GetOrdinal("ReleaseDate")) ? (DateTime?)null : (DateTime)reader["ReleaseDate"];
                    ReleasedByUserID = reader.IsDBNull(reader.GetOrdinal("ReleasedByUserID")) ? (int?)null : (int)reader["ReleasedByUserID"];
                    ReleaseApplicationID = reader.IsDBNull(reader.GetOrdinal("ReleaseApplicationID")) ? (int?)null : (int)reader["ReleaseApplicationID"];

                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            finally { connection.Close(); }

        }

        static public void _GetInfoByLicenseID(int LicenseID , ref int DetainID, ref decimal FineFees, ref DateTime DetainDate, ref int CreatedByUserID, ref bool IsReleased, ref DateTime? ReleaseDate, ref int? ReleasedByUserID, ref int? ReleaseApplicationID)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"select * from DetainedLicenses
                                              where LicenseID = @LicenseID and IsReleased = 0", connection);
            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    DetainID = (int)reader["DetainID"];
                    FineFees = (decimal)reader["FineFees"];
                    DetainDate = (DateTime)reader["DetainDate"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsReleased = (bool)reader["IsReleased"];
                    ReleaseDate = reader.IsDBNull(reader.GetOrdinal("ReleaseDate")) ? (DateTime?)null : (DateTime)reader["ReleaseDate"];
                    ReleasedByUserID = reader.IsDBNull(reader.GetOrdinal("ReleasedByUserID")) ? (int?)null : (int)reader["ReleasedByUserID"];
                    ReleaseApplicationID = reader.IsDBNull(reader.GetOrdinal("ReleaseApplicationID")) ? (int?)null : (int)reader["ReleaseApplicationID"];

                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            finally { connection.Close(); }

        }


        static public DataTable _GetAllDetainedLicenses()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"select * from DetainedLicenses", connection);

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


        static public int _DetainedLicense(int LicenseID, decimal FineFees, DateTime DetainDate, int CreatedByUserID, bool IsReleased, DateTime? ReleaseDate, int? ReleasedByUserID, int? ReleaseApplicationID)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[DetainedLicenses]
                                      ([LicenseID],[DetainDate],[FineFees],[CreatedByUserID],
                                      [IsReleased],[ReleaseDate],[ReleasedByUserID],[ReleaseApplicationID])
                                      VALUES
                                      (@LicenseID, @DetainDate, @FineFees, @CreatedByUserID,
                                      @IsReleased, @ReleaseDate, @ReleasedByUserID, @ReleaseApplicationID);
                                      SELECT SCOPE_IDENTITY();", connection);

            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
            cmd.Parameters.AddWithValue("@DetainDate", DetainDate);
            cmd.Parameters.AddWithValue("@FineFees", FineFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            cmd.Parameters.AddWithValue("@IsReleased", IsReleased);

            if (ReleaseDate.HasValue)
                cmd.Parameters.AddWithValue("@ReleaseDate", ReleaseDate.Value);
            else
                cmd.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);

            if (ReleasedByUserID.HasValue)
                cmd.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID.Value);
            else
                cmd.Parameters.AddWithValue("@ReleasedByUserID", DBNull.Value);

            if (ReleaseApplicationID.HasValue)
                cmd.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID.Value);
            else
                cmd.Parameters.AddWithValue("@ReleaseApplicationID", DBNull.Value);

            try
            {
                connection.Open();
                object Result = cmd.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int testResult))
                    return testResult;
                else
                    return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString()); return -1;
            }
            finally
            {
                connection.Close();
            }
        }

        static public bool _ReleaseLicense(int DetainID, int LicenseID, decimal FineFees, DateTime DetainDate, int CreatedByUserID, bool IsReleased, DateTime? ReleaseDate, int? ReleasedByUserID, int? ReleaseApplicationID)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[DetainedLicenses]
                                              SET [LicenseID] = @LicenseID , [DetainDate] = @DetainDate ,
                                                  [FineFees] = @FineFees , [CreatedByUserID] = @CreatedByUserID , 
                                              	  [IsReleased] = @IsReleased , [ReleaseDate] = @ReleaseDate ,
                                              	  [ReleasedByUserID] = @ReleasedByUserID , [ReleaseApplicationID] = @ReleaseApplicationID
                                              WHERE DetainID = @DetainID", connection);

            cmd.Parameters.AddWithValue("@DetainID", DetainID);
            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
            cmd.Parameters.AddWithValue("@DetainDate", DetainDate);
            cmd.Parameters.AddWithValue("@FineFees", FineFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            cmd.Parameters.AddWithValue("@IsReleased", IsReleased);
            cmd.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            cmd.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            cmd.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);

            try
            {
                connection.Open();

                int affectedRows = cmd.ExecuteNonQuery();

                return affectedRows > 0;


            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            finally { connection.Close(); }
        }


        static public bool _IsDetained(int LicenseID)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand("select count(*) from DetainedLicenses  where LicenseID = @LicenseID and IsReleased = 0", connection);
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
