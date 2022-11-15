using BlazorHRM.Models;
using System.Data.SqlClient;
using System.Data;
using BlazorSales;

namespace BlazorHRM.Repositories
{
    public class EmpLoginRepository
    {
        SqlConnection Connection { get; set; } = new SqlConnection(Helper.ConnectionString);
        public List<EmpLoginModel> GetEmpLogs()
        {
            string command = "usp_EMPLOGIN";
            List<EmpLoginModel> employees = new List<EmpLoginModel>();

            Connection.Open();
            using (SqlCommand cmd = new SqlCommand(command, Connection))
            {
                cmd.CommandText = command;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        employees.Add(
                            new EmpLoginModel
                            {
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Email = reader["Email"].ToString(),
                                LoginId = Convert.ToInt32(reader["LoginId"])
                            }
                        );
                    }
                }
            }

            return employees;
        }
    }
}
