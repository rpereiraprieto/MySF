using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Datos.Control;

namespace MySoftPhone
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Globals.Cnf = new Config();
            Application.Run(new  FrmMain());
        }
    }
}
