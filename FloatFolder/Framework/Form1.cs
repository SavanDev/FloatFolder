using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FloatFolder
{
    public partial class Form1 : Form
    {
        public List<string> Url = new List<string>();
        public List<string> Nombre = new List<string>();

        public Form1()
        {
            InitializeComponent();

            //Establecer posición del formulario
            if(Cursor.Position.X + Size.Width > Screen.PrimaryScreen.WorkingArea.Width || Cursor.Position.Y + Size.Height > Screen.PrimaryScreen.WorkingArea.Height)
                Location = Cursor.Position - Size;
            else
                Location = Cursor.Position;

            //FIX: Posición arriba
            if (Cursor.Position.Y - Size.Height < 0)
                Location = new Point(Location.X, Cursor.Position.Y);

            MaximumSize = MinimumSize = Size;
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {

        }

        public static Bitmap getApplicationIcon(string source)
        {
            return Icon.ExtractAssociatedIcon(source).ToBitmap();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] config = File.ReadAllLines(GlobalVariables.url + "\\" + GlobalVariables.nombre);
            for (int i = 0; i < config.Length; i++)
            {
                if (i % 2 == 0)
                    Nombre.Add(config[i]);
                else
                    Url.Add(config[i]);
            }

            foreach (var item in Url)
            {
                imageList1.Images.Add(getApplicationIcon(item));
            }

            for (int i = 0; i < Nombre.Count; i++)
            {
                listView1.Items.Add(Nombre[i]);
                listView1.Items[i].ImageIndex = i;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Url[listView1.SelectedIndices[0]]);
            Application.Exit();
        }
    }
}
