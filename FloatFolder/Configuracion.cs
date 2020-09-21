using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using System.CodeDom.Compiler;
using System.Diagnostics;

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

            // Generar ejecutable
            CodeDomProvider codeProvider = CodeDomProvider.CreateProvider("CSharp");
		
		    CompilerParameters parameters = new CompilerParameters();
		    parameters.GenerateExecutable = true;
		    parameters.OutputAssembly = "Out.exe";
		    parameters.CompilerOptions = "/win32icon:temp.ico /target:winexe";
		    parameters.ReferencedAssemblies.Add("System.dll");
		    parameters.ReferencedAssemblies.Add("System.Drawing.dll");
		    parameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
		    parameters.ReferencedAssemblies.Add("System.IO.dll");
		    CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, System.Text.Encoding.UTF8.GetString(FloatFolder.Properties.Resources.appTemplate));
		    
		    if (results.Errors.Count > 0)
		    {
		    	/*string error = "";
		        foreach (CompilerError CompErr in results.Errors)
		        {
		            error += "Line number " + CompErr.Line +
		                     ", Error Number: " + CompErr.ErrorNumber +
		                     ", '" + CompErr.ErrorText + ";" +
		                     Environment.NewLine + Environment.NewLine;
		        }
		        MessageBox.Show(error);*/
		    	MessageBox.Show("Se ha producido un error");
		    }
		    else
		    {
		    	//Mover el ejecutable
	            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
	            {
	                File.Move("Out.exe", folderBrowserDialog1.SelectedPath + "\\" + txtName.Text + ".exe");
	            }
	            
		    	pictureBox1.Image.Dispose();
	            input.Dispose();
	            File.Delete("temp.png"); //Elimina imagen temporal.
	            File.Delete("temp.ico"); //Elimina icono temporal.
	            MessageBox.Show("Generated correctly");
	            Application.Restart();
		    }
        }

        void button4_Click(object sender, EventArgs e)
        {
            Name.Remove(listBox1.SelectedIndex);
            Url.RemoveAt(listBox1.SelectedIndex);
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }
    }
}
