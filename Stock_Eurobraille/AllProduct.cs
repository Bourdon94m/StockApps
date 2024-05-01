using MySql.Data.MySqlClient;
using Stock_Eurobraille.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Stock_Eurobraille
{
    public partial class AllProduct : Form
    {
        public AllProduct()
        {
            InitializeComponent();
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            Home homePage = new Home();
            homePage.Show();
            this.Visible = false;
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            NewCommand newCommandPage = new NewCommand();
            newCommandPage.Show();
            this.Visible = false;
        }

        private void siticoneDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }


        private void ButtonGetInfo_Click(object sender, EventArgs e)
        {
            if (Program.dbconnection2.isClosed() == true)
            {
                Program.dbconnection2.Connect(); // Connect to DB
            }

            if (Program.dbconnection2.isOpen() == true)
            {
                string query = "SELECT id, product_name, price, nom_gamme, nom_modele FROM eurobraille.products"; // Create the query
                MySqlCommand command = new MySqlCommand(query, Program.dbconnection2.GetMySqlConnection()); // Create command

                try
                {
                    MySqlDataReader reader = command.ExecuteReader(); // Execute reader

                    if (reader.HasRows) // check if it has rows 
                    {
                        while (reader.Read()) // Parcours all the table
                        {
                            DataGridViewShowAll.Rows.Add(reader["id"].ToString(), reader["product_name"].ToString(), reader["nom_gamme"].ToString(), reader["nom_modele"].ToString(), reader["price"].ToString() + " $");
                        }
                        reader.Close();
                        ButtonGetInfo.Enabled = false;
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }


        }

    }
}
