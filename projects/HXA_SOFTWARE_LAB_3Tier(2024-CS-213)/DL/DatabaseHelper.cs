using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXA_SOFTWARE_LAB.DL
{
    public class DatabaseHelper
    {
        private string serverName = "127.0.0.1";
        private string port = "3306";
        private string databaseName = "HXA";
        private string databaseUser = "root";
        private string databasePassword = "1234567890-=1234567890-=";

        private DatabaseHelper() { }

        private static DatabaseHelper _instance;
        public static DatabaseHelper Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DatabaseHelper();
                return _instance;
            }
        }
        public MySqlConnection getConnection()
        {
            string connectionString = $"server={serverName};port={port};user={databaseUser};database ={databaseName}; password ={databasePassword}; SslMode = Required; ";
            var connection = new MySqlConnection(connectionString);
            connection.Open();



            return connection;
        }

        public MySqlDataReader getData(string query)
        {
            using (var connection = getConnection())
            {
                using (var command = new MySqlCommand(query, getConnection()))
                {
                    return command.ExecuteReader();
                }
            }

        }

        public int Update(string query)
        {
            using (var connection = getConnection())
            {
                using (var command = new MySqlCommand(query, getConnection()))
                {
                    return command.ExecuteNonQuery();
                }
            }

        }
    }
}
