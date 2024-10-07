using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DVLD_DataAccessLayer
{
    public class clsDALManagePeople
    {
        static string Path = ConfigurationManager.AppSettings["Path"];
        //static public string Path = "server=.;Database=DVLD;User Id=sa;Password=sa123456";

        static public void _GetDataByPersonalID(int personalID, ref string NationalNo, ref string FName, ref string SName, ref string ThName, ref string LName, ref DateTime DateOfBirth,
                                                ref int Gender, ref string Address, ref string Phone, ref string Email,
                                                ref string CountryName, ref string ImagePath)
        {

            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"SELECT People.*, Countries.CountryName 
                                              FROM People INNER JOIN Countries ON People.NationalityCountryID = Countries.CountryID
                                              where PersonID = @personalID", connection);
            cmd.Parameters.AddWithValue("@personalID", personalID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    NationalNo = (string)reader["NationalNo"];
                    FName = (string)reader["FirstName"];
                    SName = (string)reader["SecondName"];
                    ThName = (string)reader["ThirdName"];
                    LName = (string)reader["LastName"]; DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gender = (int)reader["Gender"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    Email = (string)reader["Email"];
                    CountryName = (string)reader["CountryName"];
                    if (reader["ImagePath"].ToString() == "")
                        ImagePath = "";
                    else
                        ImagePath = (string)reader["ImagePath"];

                    reader.Close();
                }
                else
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
        }
        static public void _GetDataByNationalNo(string NationalNo, ref int personalID, ref string FName, ref string SName, ref string ThName, ref string LName, ref DateTime DateOfBirth,
                                                ref int Gender, ref string Address, ref string Phone, ref string Email,
                                                ref string CountryName, ref string ImagePath)
        {

            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"SELECT People.*, Countries.CountryName
                                              FROM People INNER JOIN Countries ON People.NationalityCountryID = Countries.CountryID
                                              where NationalNo = @NO", connection);
            cmd.Parameters.AddWithValue("@NO", NationalNo);

            try
            {

                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    personalID = (int)reader["PersonID"];
                    FName = (string)reader["FirstName"];
                    SName = (string)reader["SecondName"];
                    ThName = (string)reader["ThirdName"];
                    LName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gender = (int)reader["Gender"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    Email = (string)reader["Email"];
                    CountryName = (string)reader["CountryName"];
                    if (reader["ImagePath"].ToString() == "")
                        ImagePath = "";
                    else
                        ImagePath = (string)reader["ImagePath"];

                    reader.Close();
                }
                else
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
        }
        static public bool _AddPerson(string NationalNo, string FName, string SName, string ThName, string LFName, DateTime DateOfBirth,
                                                 int Gender, string Address, string Phone, string Email,
                                                 int CountryID, string ImagePath)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[People] ([NationalNo],[FirstName],[SecondName],[ThirdName],[LastName],[DateOfBirth],
                                              [Gender],[Address],[Phone],[Email],[NationalityCountryID],[ImagePath])
                                              VALUES(@NationalNo, @FName, @SName, @ThName, @LFName, @DateOfBirth,
                                              @Gender, @Address, @Phone, @Email, @CountryID, @ImagePath);
                                              select SCOPE_IDENTITY();", connection);
            cmd.Parameters.AddWithValue("@NationalNo", NationalNo);
            cmd.Parameters.AddWithValue("@FName", FName);
            cmd.Parameters.AddWithValue("@SName", SName);
            cmd.Parameters.AddWithValue("@ThName", ThName);
            cmd.Parameters.AddWithValue("@LFName", LFName);
            cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Phone", Phone);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@CountryID", CountryID);
            cmd.Parameters.AddWithValue("@ImagePath", ImagePath);

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
        static public bool _UpdatePerson(int ID, string NationalNo, string FName, string SName, string ThName, string LFName, DateTime DateOfBirth,
                                                 int Gender, string Address, string Phone, string Email,
                                                 int CountryID, string ImagePath)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[People]
                                              SET [NationalNo] = @NationalNo,[FirstName] = @FName,[SecondName] = @SName,[ThirdName] = @ThName,[LastName] = @LFName,
                                              [DateOfBirth] = @DateOfBirth ,[Gender] = @Gender,[Address] = @Address,
                                              [Phone] = @Phone,[Email] = @Email,[NationalityCountryID] = @CountryID ,[ImagePath] = @ImagePath
                                              WHERE PersonID = @ID", connection);

            cmd.Parameters.AddWithValue("@ID", @ID);
            cmd.Parameters.AddWithValue("@NationalNo", NationalNo);
            cmd.Parameters.AddWithValue("@FName", FName);
            cmd.Parameters.AddWithValue("@SName", SName);
            cmd.Parameters.AddWithValue("@ThName", ThName);
            cmd.Parameters.AddWithValue("@LFName", LFName);
            cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Phone", Phone);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@CountryID", CountryID);
            cmd.Parameters.AddWithValue("@ImagePath", ImagePath);

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
        static public bool _DeletePerson(int ID)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[People] WHERE PersonID = @ID", connection);
            cmd.Parameters.AddWithValue("@ID", ID);

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


        static public DataTable _AllData()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"SELECT People.PersonID, People.NationalNo, People.FirstName, 
	                                          People.SecondName, People.ThirdName, People.LastName, People.DateOfBirth, 
	                                          case 
	                                          when People.Gender = 0 then 'Male'
	                                          else 'Female'
	                                          end as Gender,
	                                          People.Address, People.Phone, People.Email, 
                                              People.NationalityCountryID, People.ImagePath, Countries.CountryName
                                              FROM People INNER JOIN Countries ON People.NationalityCountryID = Countries.CountryID", connection);

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

        static public bool IsExist(int ID)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand("select NationalNo from People where PersonID = @ID", connection);
            cmd.Parameters.AddWithValue("@ID", ID);


            try
            {
                connection.Open();
                object Result = cmd.ExecuteScalar();

                if (Result != null)
                    return true;
                else return false;

            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            finally { connection.Close(); }
        }
        static public bool IsExist(string No)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand("select PersonID from People where NationalNo = @No", connection);
            cmd.Parameters.AddWithValue("@No", No);


            try
            {
                connection.Open();
                object Result = cmd.ExecuteScalar();

                if (Result != null)
                    return true;
                else return false;

            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            finally { connection.Close(); }
        }

        static public int _GetIDByNationalNo(string No)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand("select PersonID from People where NationalNo = @No", connection);
            cmd.Parameters.AddWithValue("@No", No);

            int personID = -1;

            try
            {
                connection.Open();
                object Result = cmd.ExecuteScalar();
                if (Result != null)
                {
                    personID = Convert.ToInt32(Result);
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

            return personID;
        }
        static public DataTable _GetAllNationalNo()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand("select NationalNo from People", connection);

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
        static public DataTable _GetAllPersonalID()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand("select PersonID from People", connection);

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
    }
}
