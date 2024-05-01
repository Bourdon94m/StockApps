using Stock_Eurobraille.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock_Eurobraille
{
    internal static class Program
    {

        public static DbConnection dbconnection2;

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            dbconnection2 = new DbConnection("127.0.0.1", "eurobraille", "root", "root"); // Add ur info here, in my case its a localhost project
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
