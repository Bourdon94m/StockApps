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
    }
}
