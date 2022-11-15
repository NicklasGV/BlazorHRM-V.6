using BlazorHRM.Models;
using BlazorSales;
using System.Data.SqlClient;
using System.Data;

namespace BlazorHRM.Repositories
{
    public class DepRepository
    {
        SqlConnection Connection { get; set; } = new SqlConnection(Helper.ConnectionString);
        public List<DepartmentModel> GetAll()
        {
            string command = "usp_GET_ALL_DEPARTMENTS";
            List<DepartmentModel> deps = new List<DepartmentModel>();

            Connection.Open();
            using (SqlCommand cmd = new SqlCommand(command, Connection))
            {
                cmd.CommandText = command;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        deps.Add(
                            new DepartmentModel
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                            }
                        );
                    }
                }
            }

            return deps;
        }
    }
}
