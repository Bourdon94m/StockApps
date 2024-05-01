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
    public partial class NewCommand : Form
    {
        public NewCommand()
        {
            InitializeComponent();
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            Home homePage = new Home();
            homePage.Show();
            this.Visible = false;

        }

        private void siticoneButton3_Click(object sender, EventArgs e)
        {
            AllProduct allProductPage = new AllProduct();
            allProductPage.Show();
            this.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            


        }

        private void ButtonAddToDB_Click(object sender, EventArgs e)
        {
            // Create our query 
            string query = "SET FOREIGN_KEY_CHECKS=0; INSERT INTO eurobraille.products (product_name, price, nom_gamme, nom_modele) VALUES (@name,@price,@gamme,@modele)";
            MySqlCommand command = new MySqlCommand(query,Program.dbconnection2.GetMySqlConnection());


            // Create parameters for eviter SQL injection
            command.Parameters.AddWithValue("@name", textBoxProductName.Text);
            command.Parameters.AddWithValue("@price", NumericUpDownPrice.Value.ToString());
            command.Parameters.AddWithValue("@gamme", listboxGamme.Text);
            command.Parameters.AddWithValue("@modele", listboxModele.Text);

            if (String.IsNullOrEmpty(textBoxProductName.Text) || String.IsNullOrEmpty(NumericUpDownPrice.Value.ToString()) || String.IsNullOrEmpty(listboxGamme.Text) || String.IsNullOrEmpty(listboxModele.Text)) { 
                MessageBox.Show("Missing somethings", "ERROR", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }
            else
            {
                command.ExecuteNonQuery(); // Execute Query 
                MessageBox.Show("Successfully added it into DB", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView.Rows.Add(textBoxProductName.Text, listboxModele.Text, listboxGamme.Text, NumericUpDownPrice.Value.ToString() + "$"); // Add it into a visual format
                clearData(); // Ckear Data from actual data entered
            }
            

            Program.dbconnection2.Close(); // Close the connexion

        }


        // Function for clear data where we add it to DB
        void clearData()
        {
            textBoxProductName.Clear();
            listboxGamme.ClearSelected();
            listboxModele.ClearSelected();
            NumericUpDownPrice.Value = 1;
        }

    }
}
