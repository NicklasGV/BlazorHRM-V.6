using BlazorHRM.Models;
using BlazorSales;
using System.Data;
using System.Data.SqlClient;

namespace BlazorHRM.Repositories
{
    public class LoginRepository
    {
        SqlConnection Connection { get; set; } = new SqlConnection(Helper.ConnectionString);

        #region Addlogin
        public LoginModel AddLogin(LoginModel loginMl)
        {
            string command = "usp_INSERT_NEW_LOGIN";
            LoginModel addLogin = new LoginModel();

            Connection.Open();
            using (SqlCommand cmd = new SqlCommand(command, Connection))
            {
                cmd.CommandText = command;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", loginMl.Email);
                cmd.Parameters.AddWithValue("@Password", loginMl.Password);
                using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        addLogin.Email = Convert.ToString(reader["Email"]);
                        addLogin.Password = Convert.ToString(reader["Password"]);
                    }
                }
            }
            return addLogin;
        }
        #endregion

        #region Loginto
        public LoginModel Loginto(LoginModel loginMl)
        {
            string command = "usp_CHECK_LOGIN";
            LoginModel addLogin = new LoginModel();

            Connection.Open();
            using (SqlCommand cmd = new SqlCommand(command, Connection))
            {
                cmd.CommandText = command;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", loginMl.Email);
                cmd.Parameters.AddWithValue("@Password", loginMl.Password);
                using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        addLogin.Email = Convert.ToString(reader["Email"]);
                        addLogin.Password = Convert.ToString(reader["Password"]);
                    }
                }
            }
            return addLogin;
        }
        #endregion

        #region PWS
        public List<LoginModel> GetPWS()
        {
            string command = "usp_PWS";
            List<LoginModel> pws = new List<LoginModel>();

            Connection.Open();
            using (SqlCommand cmd = new SqlCommand(command, Connection))
            {
                cmd.CommandText = command;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        pws.Add(
                            new LoginModel
                            {
                                Password = reader["Password"].ToString(),
                            }
                        );
                    }
                }
            }
            return pws;
        }
        #endregion 

        #region IDS
        //public List<LoginModel> GetIDS()
        //{
        //    string command = "usp_IDS";
        //    List<LoginModel> ids = new List<LoginModel>();

        //    Connection.Open();
        //    using (SqlCommand cmd = new SqlCommand(command, Connection))
        //    {
        //        cmd.CommandText = command;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
        //        {
        //            while (reader.Read())
        //            {
        //                ids.Add(
        //                    new LoginModel
        //                    {
        //                        Id = Convert.ToInt32(reader["Id"]),
        //                    }
        //                );
        //            }
        //        }
        //    }
        //    return ids;
        //}
        #endregion 
    }
}
