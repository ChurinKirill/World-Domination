using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace WorldDomination.Core
{
    public class DBMysql
    {
        public static MySqlConnection GetDBConnection(/*string host, int port, string database, string username, string password*/)
        {
            string connString = "Server=localhost;Database=countries;port=3306;uid=root;password=1";
            MySqlConnection connection = new MySqlConnection(connString);
            connection.Open();
            return connection;
        }

        public static MySqlDataReader ExecuteQuery(string query)
        {
            var connection = GetDBConnection();
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader result = command.ExecuteReader();
            //connection.Close();
            return result;
        }

        public static string GetAccountId(string login, string password)
        {
            string query = $"select account_id from countries_accounts where account_login = '{login}' and account_password = '{password}'";
            MySqlDataReader result = ExecuteQuery(query);
            while(result.Read())
            {
                return result["account_id"].ToString();
            }
            return "none";
            //return result.GetInt32("account_id");
        }

        public static List<Models.CityDataModel> GetCitiesInfo(int countryId)
        {
            string query = $"select * from cities where country_id = '{countryId}'";
            MySqlDataReader result = ExecuteQuery(query);
            List<Models.CityDataModel> response = new List<Models.CityDataModel>();
            while (result.Read())
            {
                response.Add(new Models.CityDataModel
                {
                    Id = int.Parse(result["city_id"].ToString()),
                    Name = result["name_city"].ToString(),
                    Progress = int.Parse(result["growth"].ToString()),
                    LifeLevel = int.Parse(result["life_level"].ToString()),
                    Income = int.Parse(result["income"].ToString())
                });
            }
            return response;
        }

        public static List<Models.OtherCountry> GetOtherCountriesInfo(int countryId)
        {
            string query = $"select country_id, name_country from countries where country_id != '{countryId}'";
            MySqlDataReader result = ExecuteQuery(query);
            List<Models.OtherCountry> response = new List<Models.OtherCountry>();
            while (result.Read())
            {
                response.Add(new Models.OtherCountry
                {
                    Id = int.Parse(result["country_id"].ToString()),
                    Name = result["name_country"].ToString(),
                    Cities = GetCitiesInfo(int.Parse(result["country_id"].ToString()))
                });
            }
            return response;
        }

        public static Models.CountryDataModel GetCountryInfo(int countryId)
        {
            string query = $"select * from countries where country_id = '{countryId}'";
            MySqlDataReader result = ExecuteQuery(query);
            while (result.Read())
            {
                return new Models.CountryDataModel
                {
                    Id = int.Parse(result["country_id"].ToString()),
                    Name = result["name_country"].ToString(),
                    Budget = int.Parse(result["budget"].ToString()),
                    LifeLevel = int.Parse(result["life_level"].ToString()),
                    Nuclear = true ? result["nuclear"].ToString() == "1" : false
                };
            }
            return new Models.CountryDataModel { };
        }
    }
}
