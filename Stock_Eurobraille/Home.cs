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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void siticonePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Succesfully Logout", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            NewCommand commandPage = new NewCommand();
            commandPage.Show();
            this.Visible = false;
        }

        private void siticoneButton3_Click(object sender, EventArgs e)
        {
            AllProduct allProductPage = new AllProduct();
            allProductPage.Show();
            this.Visible = false;
        }
    }
    
}
