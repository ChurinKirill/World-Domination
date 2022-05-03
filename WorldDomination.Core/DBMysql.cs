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

        public static List<Dictionary<string, string>> GetCitiesInfo(int countryId)
        {
            string query = $"select * from cities where country_id = '{countryId}'";
            MySqlDataReader result = ExecuteQuery(query);
            List<Dictionary<string, string>> response = new List<Dictionary<string, string>>();
            while (result.Read())
            {
                response.Add(new Dictionary<string, string>()
                {
                    { "city_id", result["city_id"].ToString() },
                    { "name_city", result["name_city"].ToString() },
                    { "growth", result["growth"].ToString() },
                    { "life_level", result["life_level"].ToString() },
                    { "income", result["income"].ToString() },
                    { "armament", result["armament"].ToString() }
                });
            }
            return response;
        }

        public static List<Dictionary<string, string>> GetOtherCountriesInfo(int countryId)
        {
            string query = $"select country_id, name_country from countries where country_id != '{countryId}'";
            MySqlDataReader result = ExecuteQuery(query);
            List<Dictionary<string, string>> response = new List<Dictionary<string, string>>();
            while (result.Read())
            {
                response.Add(new Dictionary<string, string>
                {
                    { "country_id", result["country_id"].ToString() },
                    { "name_country", result["name_country"].ToString() }
                });
            }
            return response;
        }

        public static Dictionary<string, string> GetCountryInfo(int countryId)
        {
            string query = $"select * from countries where country_id = '{countryId}'";
            MySqlDataReader result = ExecuteQuery(query);
            while (result.Read())
            {
                return new Dictionary<string, string>()
                {
                    { "country_id", result["country_id"].ToString() },
                    { "name_country", result["name_country"].ToString() },
                    { "budget", result["budget"].ToString() },
                    { "life_level", result["life_level"].ToString() },
                    { "nuclear", result["nuclear"].ToString() }
                };
            }
            return new Dictionary<string, string>() { { "0", "0" } };
        }
    }
}
