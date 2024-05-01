using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;



namespace Stock_Eurobraille.Classes
{
    internal class DbConnection
    {


        string server;
        string database;
        string user;
        string password;
        MySqlConnection conn;

        public DbConnection(string server, string database, string user, string password)
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
            string connectionString = "server=" + this.server + ";database=" + this.database + ";user=" + this.user + ";password=" + this.password + ";";
            Console.WriteLine(connectionString);
            try
            {
                Console.WriteLine(connectionString);
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                this.conn = conn;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

        }

        public void Close()
        { conn?.Close(); } // Utilisez ? pour éviter les erreurs si conn est null 



        // Execute une query que l'on passe en parametre
        public MySqlDataReader executeQuery(string query)
        {
            MySqlCommand command = new MySqlCommand(query, GetMySqlConnection());
            command.ExecuteScalar();
            MySqlDataReader r = command.ExecuteReader();
            return r;
        }

        // check si le compte correspond au mot de passe
        public void isValidAccount(string email, string password)
        {
            GetMySqlConnection();
            string query = "SELECT password FROM eurobraille.users WHERE email = @email";
            MySqlCommand command = new MySqlCommand(query, GetMySqlConnection());
            command.Parameters.AddWithValue("@email", email);

            MySqlDataReader reader = command.ExecuteReader();



            if (reader.Read())
            {
                string passwordFromDB = reader["password"].ToString();
            
                if (password.Equals(passwordFromDB))
                {
                    Console.WriteLine(password);

                    MessageBox.Show("Salut ! ", "Valid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Home stock = new Home();
                    Form login = new Form();

                    stock.Show();
                    login.Visible = false;
                    reader.Close();
                    
                }
                else
                {
                    MessageBox.Show("Wrong ID", "Wrong ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    reader.Close();

                }
            }
            else
            {
                MessageBox.Show("Not a valid account", "Wrong ID", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                reader.Close();
            }
             
        }

        public bool isOpen()
        {
            MySqlConnection connection = Program.dbconnection2.GetMySqlConnection();

            if (connection.State == System.Data.ConnectionState.Open) return true;
            else { return false; }
        }

        public bool isClosed()
        {
            MySqlConnection connection = Program.dbconnection2.GetMySqlConnection();

            if (connection.State == System.Data.ConnectionState.Closed) return true;
            else { return false; }
        }

    }
}
