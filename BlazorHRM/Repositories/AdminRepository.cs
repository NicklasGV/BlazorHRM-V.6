using BlazorHRM.Models;
using BlazorSales;
using System.Data.SqlClient;
using System.Data;

namespace BlazorHRM.Repositories
{
    public class AdminRepository
    {
        SqlConnection Connection { get; set; } = new SqlConnection(Helper.ConnectionString);
        public List<TaskModel> GetAllTasks()
        {
            string command = "usp_GET_ADMINTASKS";
            List<TaskModel> tasks = new List<TaskModel>();

            Connection.Open();
            using (SqlCommand cmd = new SqlCommand(command, Connection))
            {
                cmd.CommandText = command;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        tasks.Add(
                            new TaskModel
                            {
                                EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                                FirstName = reader["FirstName"].ToString(),
                                Task = reader["Desc"].ToString()
                            }
                        );
                    }
                }
            }

            return tasks;
        }
    }
}
