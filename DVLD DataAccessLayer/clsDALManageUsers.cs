using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DVLD_DataAccessLayer
{
    public class clsDALManageUsers
    {
        static string Path = ConfigurationManager.AppSettings["Path"];
        //static public string Path = "server=.;Database=DVLD;User Id=sa;Password=sa123456";

        static public void _GetUserInfoByPerID(int personalID, ref int UserID, ref string UserName, ref string Password, ref int IsActive)
        {

            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"SELECT UserID, Password , UserName, IsActive 
                                              FROM Users
                                              WHERE PersonID = @personalID", connection);
            cmd.Parameters.AddWithValue("@personalID", personalID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    UserID = (int)reader["UserID"];
                    Password = (string)reader["Password"];
                    UserName = (string)reader["UserName"];
                    IsActive = (int)reader["IsActive"];

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
        static public void _GetUserInfoByUID(int UserID, ref int personalID, ref string UserName, ref string Password, ref int IsActive)
        {

            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"SELECT *
                                              FROM Users
                                              WHERE UserID = @UserID", connection);
            cmd.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    personalID = (int)reader["PersonID"];
                    Password = (string)reader["Password"];
                    UserName = (string)reader["UserName"];
                    IsActive = (int)reader["IsActive"];

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
        static public void _GetUserInfoByUN(string userName, ref int personalID, ref int UserID, ref string Password, ref int IsActive)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"SELECT PersonID , UserID, Password , IsActive 
                                              FROM Users
                                              WHERE UserName = @userName", connection);
            cmd.Parameters.AddWithValue("@userName", userName);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    personalID = (int)reader["PersonID"];
                    UserID = (int)reader["UserID"];
                    Password = (string)reader["Password"];
                    IsActive = (int)reader["IsActive"];

                    reader.Close();
                }
                else
                    reader.Close();

            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            finally { connection.Close(); }

        }





        static public bool _AddNewUser(int PersonID, string UserName, string Password, int ISActive)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Users]([PersonID],[UserName],[Password],[IsActive])
                                              VALUES (@PersonID , @UserName , @Password , @IsActive )
                                              select SCOPE_IDENTITY();", connection);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@IsActive", ISActive);

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
        static public bool _UpdateUser(int PersonID, string UserName, string Password, int ISActive)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[Users]
                                              SET [UserName] = @UserName ,[Password] = @Password ,[IsActive] = @IsActive
                                              WHERE PersonID = @PersonID", connection);


            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@IsActive", ISActive);

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
        static public bool _DeleteUser(int ID)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[Users] WHERE UserID = @ID", connection);
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


        static public DataTable _GetAllUserName()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"SELECT UserName FROM Users", connection);

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
        static public DataTable _GetAllDataUsers()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"SELECT Users.UserID, Users.PersonID, FullName =( People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName), Users.UserName, Users.IsActive
                                              FROM Users INNER JOIN People ON Users.PersonID = People.PersonID", connection);

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
        static public DataTable _GetUserNamePass()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"SELECT UserName, Password FROM Users", connection);

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

        static public bool _IsExist(int ID)
        {
            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand("select UserID from Users where PersonID = @ID", connection);
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
        static public int _IsActive(string userName)
        {
            int isActive = -1;

            SqlConnection connection = new SqlConnection(Path);
            SqlCommand cmd = new SqlCommand(@"select * from Users where UserName = @userName", connection);
            cmd.Parameters.AddWithValue("@userName", userName);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isActive = (int)reader["IsActive"];

                    reader.Close();
                }
                else
                    reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            finally { connection.Close(); }

            return isActive;
        }
    }
}
