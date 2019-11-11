using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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

            //Obtener nombre del archivo.
            string filename = Application.ExecutablePath;
            filename = filename.Remove(0, filename.LastIndexOf("\\") + 1);
            filename = filename.Replace(".exe", "");

            //Variables globales
            GlobalVariables.nombre = filename;
            GlobalVariables.url = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\FloatFolder\\";

            //Verificar carpeta de configuración
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\FloatFolder"))
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\FloatFolder");

            //Verificar configuración
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\FloatFolder\\" + filename))
            {
                Application.Run(new Form1());
            }
            else
                Application.Run(new Configuracion());
        }
    }
}
