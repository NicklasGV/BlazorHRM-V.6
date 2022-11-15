using BlazorHRM.Models;
using BlazorSales;
using System.Data.SqlClient;
using System.Data;

namespace BlazorHRM.Repositories
{
    public class CityRepository
    {
        SqlConnection Connection { get; set; } = new SqlConnection(Helper.ConnectionString);
        public List<CityModel> GetAll()
        {
            string command = "usp_GET_ALL_CITIES";
            List<CityModel> cities = new List<CityModel>();

            Connection.Open();
            using (SqlCommand cmd = new SqlCommand(command, Connection))
            {
                cmd.CommandText = command;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        cities.Add(
                            new CityModel
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                CityName = reader["CityName"].ToString(),
                            }
                        );
                    }
                }
            }

            return cities;
        }

        public CityModel GetCitiesById(int id)
        {
            CityModel theCity = new CityModel();

            string command = "usp_GET_CITY_BY_ID";

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
                        theCity.Id = Convert.ToInt32(reader["Id"]);
                        theCity.CityName = reader["CityName"].ToString();
                        
                    }
                }
            }
            return theCity;
        }

        public string DeleteCityById(int id)
        {
            CityModel theCity = new CityModel();

            theCity = GetCitiesById(id);
            if (theCity.Id == 0)
            {
                return ($"Record with id {id} was not deleted!"); ;
            }
            else
            {
                string command = "usp_DELETE_CITY_BY_ID";
                using (SqlCommand cmd = new SqlCommand(command, Connection))
                {
                    Connection.Open();
                    cmd.CommandText = command;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SalesId", id);
                    cmd.ExecuteNonQuery();
                    Connection.Close();
                }
                return $"Record {theCity.Id} {theCity.CityName} is now deleted!";
            }
        }

        public string UpdateSalesByRecord(CityModel cityModel)
        {
            string returnMessage = "";
            CityModel theCity = new CityModel();

            theCity  = GetCitiesById(cityModel.Id);
            if (theCity.Id == 0)
            {
                returnMessage = $"Record with id {cityModel.Id} was not found! Update action CANCELLED!";
                return returnMessage;
            }
            else
            {
                string command = "[usp_UPDATE_CITY_BY_ID]";

                using (SqlCommand cmd = new SqlCommand(command, Connection))
                {
                    cmd.CommandText = command;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", cityModel.Id);
                    cmd.Parameters.AddWithValue("@CityName", cityModel.CityName);

                    Connection.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        returnMessage = $"Record with #{cityModel.Id} was successfully updated!";
                    }
                    else
                    {
                        returnMessage = $"Updating Record with #{cityModel.Id} FAILED! ";
                    }
                    Connection.Close();
                }
                return returnMessage;
            }
        }

        public string InsertSalesRecord(CityModel cityModel)
        {
            string returnMessage = "";
            string command = "[usp_INSERT_CITY]";
            using (SqlCommand cmd = new SqlCommand(command, Connection))
            {
                cmd.CommandText = command;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", cityModel.Id);
                cmd.Parameters.AddWithValue("@ProductName", cityModel.CityName);
                

                Connection.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    returnMessage = $"Record with city: {cityModel.CityName}  was successfully inserted!";

                }
                else
                {
                    returnMessage = $"Inserting Record with city {cityModel.CityName} FAILED! ";
                }
                Connection.Close();
            }

            return returnMessage;

        }
    }
}
