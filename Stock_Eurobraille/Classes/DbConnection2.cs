using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Stock_Eurobraille.Classes
{
    internal class DbConnection2
    {


        string server;
        string database;
        string user;
        string password;
        MySqlConnection conn;

        public DbConnection2(string server, string database, string user, string password)
        {
            this.server = server;
            this.database = database;
            this.user = user;
            this.password = password;
            Connect();
        }

        public string Database { get => database; set => database = value; }
        public string User { get => user; set => user = value; }
        public string Password { get => password; set => password = value; }

        public MySqlConnection GetMySqlConnection() { return this.conn;}

        public void Connect()
        {
            string connectionString = "server="+this.server+";database=" + this.database + ";user=" + this.user + ";password=" + this.password+";";
            Console.WriteLine(connectionString);
            try
            {
                Console.WriteLine(connectionString);
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                this.conn = conn;
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Close()
        { this.conn.Close(); }

        public MySqlDataReader executeQuery(string query)
        {
            MySqlCommand command = new MySqlCommand(query, GetMySqlConnection());
            command.ExecuteScalar();
            MySqlDataReader r = command.ExecuteReader();
            return r;
        }
    }
}
