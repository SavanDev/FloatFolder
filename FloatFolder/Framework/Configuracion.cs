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
using Vestris.ResourceLib;

namespace FloatFolder
{
    public partial class Configuracion : Form
    {
        public List<string> Url = new List<string>();
        public List<string> Nombre = new List<string>();

        public Configuracion()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0: pictureBox1.Image = Properties.Resources.my_files;
                    break;
                case 1: pictureBox1.Image = Properties.Resources.files;
                    break;
                case 2: pictureBox1.Image = Properties.Resources.Folder_icon;
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(dialogOpen.ShowDialog() == DialogResult.OK)
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Enter a name for the shortcut", "Shortcut", dialogOpen.SafeFileName.Replace(".exe", ""));
                Url.Add(dialogOpen.FileName);

                Nombre.Add(input);
                listBox1.Items.Add(input);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dialogIcon.ShowDialog() == DialogResult.OK)
                pictureBox1.Image = Image.FromFile(dialogIcon.FileName);
        }

        private void Configuracion_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int LenghtTotal = Nombre.Count + Url.Count;
            string[] guardado = new string[LenghtTotal];
            GlobalVariables.nombre = txtName.Text;

            int nIndex = 0;
            int uIndex = 0;

            for (int i = 0; i < guardado.Length; i++)
            {
                if (i % 2 == 0)
                {
                    guardado[i] = Nombre[nIndex];
                    nIndex++;
                }
                else
                {
                    guardado[i] = Url[uIndex];
                    uIndex++;
                }
            }

            File.WriteAllLines(GlobalVariables.url + "\\" + GlobalVariables.nombre, guardado);

            //Generar Icono
            pictureBox1.Image.Save("temp.png", System.Drawing.Imaging.ImageFormat.Png);
            FileStream input = File.OpenRead("temp.png");

            using (FileStream stream = File.OpenWrite("temp.ico"))
            {
                PngToIcon.Convert(input, stream);
            }

            Console.WriteLine("Generated icon");

            //Generar ejecutable
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                File.Copy(Application.ExecutablePath, folderBrowserDialog1.SelectedPath + "\\" + txtName.Text + ".exe");
            }

            //Cambiar icono de ejecutable
            var iconPath = "temp.ico";
            var executablePath = folderBrowserDialog1.SelectedPath + "\\" + txtName.Text + ".exe";
            var iconFile = new IconFile(iconPath);

            if (iconFile.Type != IconFile.GroupType.Icon || iconFile.Icons.Count == 0)
            {
                Console.Error.WriteLine("The file {0} does not contain any icons", iconPath);
            }
            else
            {
                var resourcesToDelete = new List<Resource>();

                using (var vi = new ResourceInfo())
                {
                    vi.Load(executablePath);

                    foreach (var type in vi.ResourceTypes.Where(r => r.ResourceType == Kernel32.ResourceTypes.RT_GROUP_ICON || r.ResourceType == Kernel32.ResourceTypes.RT_ICON))
                    {
                        resourcesToDelete.AddRange(vi.Resources[type]);
                    }
                }

                foreach (var resource in resourcesToDelete)
                {
                    resource.DeleteFrom(executablePath);
                }

                //
                // Set the icon.
                //
                // Windows NT+ chooses the first RT_GROUP_ICON, which is normally the one with the lowest id as the Application icon.
                // See the "DLL and EXE Files" and "Choosing an Icon" sections at http://msdn.microsoft.com/en-us/library/ms997538.aspx

                var iconDirectory = new IconDirectoryResource();
                iconDirectory.Name = new ResourceId(1);
                iconDirectory.Language = 1033; // US-English

                foreach (var p in iconFile.Icons.Select((icon, i) => new { icon, i }))
                {
                    iconDirectory.Icons.Add(
                        new IconResource(
                            p.icon,
                            new ResourceId((uint)p.i + 1),
                            iconDirectory.Language
                        )
                    );
                }

                iconDirectory.SaveTo(executablePath);
            }

            pictureBox1.Image.Dispose();
            input.Dispose();
            File.Delete("temp.png"); //Elimina imagen temporal.
            File.Delete("temp.ico"); //Elimina icono temporal.
            MessageBox.Show("Generated correctly");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Name.Remove(listBox1.SelectedIndex);
            Url.RemoveAt(listBox1.SelectedIndex);
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }
    }
}
