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
using Stock_Eurobraille.Classes;

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

            Program.dbconnection2.executeQuery("SELECT password from eurobraille.users WHERE email = 'test@gmail.com' ");

            /*
            // check if any of textbox or empty or not
            if (string.IsNullOrEmpty(textBoxEmail.Text) || string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Warning : Required fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    MySqlCommand command = new MySqlCommand(Program.dbconnection2.executeQuery("SELECT password WHERE email = @email").ToString(), Program.dbconnection2.GetMySqlConnection());
                    command.Parameters.AddWithValue("@email", textBoxEmail.Text);
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        string passwordFromDB = reader.GetString("Password");

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

                    //Close the reader
                    reader.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la connexion à la base de données : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            */
        }


    }
}






       