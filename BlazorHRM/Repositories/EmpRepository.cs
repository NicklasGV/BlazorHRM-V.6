using BlazorHRM.Models;
using BlazorSales;
using System.Data.SqlClient;
using System.Data;

namespace BlazorHRM.Repositories
{
    public class EmpRepository
    {
        SqlConnection Connection { get; set; } = new SqlConnection(Helper.ConnectionString);
        public List<EmpModel> GetAllEmps()
        {
            string command = "usp_GET_ALL_EMPLOYEES_ID_NAME_ISADMIN_LOGINID";
            List<EmpModel> employees = new List<EmpModel>();

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
                            new EmpModel
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                IsAdmin = reader["IsAdmin"].ToString() == "True",
                                LoginId = Convert.ToInt32(reader["LoginId"])
                            }
                        );
                    }
                }
            }

            return employees;
        }

        public EmpModel AddEmp(EmpModel empMl)
        {
            string command = "usp_INSERT_EMPLOYEE";
            EmpModel addEmp = new EmpModel();

            Connection.Open();
            using (SqlCommand cmd = new SqlCommand(command, Connection))
            {
                cmd.CommandText = command;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", empMl.FirstName);
                cmd.Parameters.AddWithValue("@LastName", empMl.LastName);
                cmd.Parameters.AddWithValue("@LoginId", empMl.LoginId);
                cmd.Parameters.AddWithValue("@CityId", empMl.CityId);
                cmd.Parameters.AddWithValue("@DepartmentId", empMl.DepartmentId);
                using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        addEmp.FirstName = Convert.ToString(reader["Email"]);
                        addEmp.LastName = Convert.ToString(reader["Password"]);
                        addEmp.LoginId = Convert.ToInt32(reader["LoginId"]);
                        addEmp.DepartmentId = Convert.ToInt32(reader["DepartmentId"]);
                        addEmp.CityId = Convert.ToInt32(reader["CityId"]);
                    }
                }
            }
            return addEmp;
        }

        public EmpModel GetEmpById(int id)
        {
            EmpModel theEmp = new EmpModel();

            string command = "usp_GET_EMP_BY_ID";

            Connection.Open();
            using (SqlCommand cmd = new SqlCommand(command, Connection))
            {
                cmd.CommandText = command;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SalesId", id);
                using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        theEmp.Id = Convert.ToInt32(reader["Id"]);
                        theEmp.FirstName = reader["FirstName"].ToString();

                    }
                }
            }
            return theEmp;
        }

        public EmpModel IsAdmin(EmpModel lm)
        {
            EmpModel theEmp = new EmpModel();

            string command = "usp_MAKE_ISADMIN";

            Connection.Open();
            using (SqlCommand cmd = new SqlCommand(command, Connection))
            {
                cmd.CommandText = command;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", lm.Id);
                cmd.Parameters.AddWithValue("@IsAdmin", lm.IsAdmin);
                using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        theEmp.Id = Convert.ToInt32(reader["Id"]);
                        theEmp.IsAdmin = Convert.ToBoolean(reader["IsAdmin"]);
                    }
                }
            }
            return theEmp;
        }

            public List<EmpModel> GetAdmins()
        {
            string command = "usp_CHECK_ADMIN";
            List<EmpModel> employees = new List<EmpModel>();

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
                            new EmpModel
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                IsAdmin = reader["IsAdmin"].ToString() == "True",
                            }
                        );
                    }
                }
            }

            return employees;
        }

        public EmpModel DelEmp(EmpModel lm)
        {
            EmpModel theEmp = new EmpModel();

            string command = "usp_UPDATE_DELETE_LOGIN_BY_ID";

            Connection.Open();
            using (SqlCommand cmd = new SqlCommand(command, Connection))
            {
                cmd.CommandText = command;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", lm.Id);
                using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        theEmp.Id = Convert.ToInt32(reader["Id"]);
                    }
                }
            }
            return theEmp;
        }
    }
}
