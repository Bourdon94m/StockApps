using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Stock_Eurobraille
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // check if any of textbox or empty or not
            if (string.IsNullOrEmpty(textBoxEmail.Text) || string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Warning : Required fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Connect to DB
                string connectionString = "Server=localhost;Database=EuroBraille;User=root;Password=root;";
                MySqlConnection connection = new MySqlConnection(connectionString);
                try
                {
                    connection.Open();

                    // Execute a query with parameterized query
                    string query = "SELECT password FROM eurobraille.users WHERE email = @email";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@email", textBoxEmail.Text);
                    MySqlDataReader reader = command.ExecuteReader();

                    // Check if there are rows returned
                    if (reader.HasRows)
                    {
                        reader.Read(); // Read the first row
                        string passwordFromDB = reader.GetString("password");
                        // Check if password matches
                        if (passwordFromDB.Equals(textBoxPassword.Text))
                        {
                            MessageBox.Show("Connexion Approved", "Connected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Form2 form2 = new Form2();
                            form2.Show();
                            Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("Connexion rejetée", "Échec", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Aucun compte ne correspond !", "Échec", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    // Close the reader
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la connexion à la base de données : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Close the connection
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }




        }
        }
    }



       