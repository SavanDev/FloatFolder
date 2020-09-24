/*
 * Created by SharpDevelop.
 * Date: 22/09/2020
 * SavanDev - MIT License
 */
using System;
using System.Linq;
using System.Windows.Forms;

namespace FloatFolder
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
            
            Application.Run(new Configuracion());
        }
    }
}
