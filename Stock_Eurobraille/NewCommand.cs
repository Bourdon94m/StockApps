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
    }
}
