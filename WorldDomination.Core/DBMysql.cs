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
    }
}
