using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoDL
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string value = "0";
            foreach (string arg in args)
            {
                string[] parts = arg.Split(':');
                if (parts.Length >= 2)
                {
                    string key = parts[0];
                    value = parts[1];

                    switch (key)
                    {
                        case "-T":
                            int.TryParse(value, out int time);
                            break;
                
                    }
                }
            }
            Application.Run(new Form1(int.Parse(value)));
        }
    }
}
