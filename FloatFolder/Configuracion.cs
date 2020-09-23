using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.CodeDom.Compiler;

namespace FloatFolder
{
	public partial class Configuracion : Form
	{
		App generatedApp = new App();
		
		public Configuracion()
		{
			InitializeComponent();
			stripVersion.Text = "v" + Application.ProductVersion;
		}

		void button3_Click(object sender, EventArgs e)
		{
			if(dialogOpen.ShowDialog() == DialogResult.OK)
			{
				WinShortcut dialogShortcut = new WinShortcut(dialogOpen.SafeFileName.Replace(".exe", ""), dialogOpen.FileName);
				if (dialogShortcut.ShowDialog() == DialogResult.OK)
				{
					generatedApp.AddShortcut(dialogShortcut.GetShortcutName(), dialogOpen.FileName);
					listBox1.Items.Add(dialogShortcut.GetShortcutName());
					button4.Enabled = true;
					listBox1.SelectedIndex = listBox1.Items.Count - 1;
					listBox1.Focus();
				}
			}
		}

		void button1_Click(object sender, EventArgs e)
		{
			if (dialogIcon.ShowDialog() == DialogResult.OK)
				pictureBox1.Image = Image.FromFile(dialogIcon.FileName);
		}

		void button2_Click(object sender, EventArgs e)
		{	
			if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
			{
				//Generar Icono
				Bitmap pngIcon = new Bitmap(pictureBox1.Image);

				using (FileStream stream = File.OpenWrite("temp.ico"))
				{
					ImagingHelper.ConvertToIcon(pngIcon, stream);
				}

				Console.WriteLine("Generated icon");

				// Generar ejecutable
				CodeDomProvider codeProvider = CodeDomProvider.CreateProvider("CSharp");
				
				CompilerParameters parameters = new CompilerParameters();
				parameters.GenerateExecutable = true;
				parameters.OutputAssembly = folderBrowserDialog1.SelectedPath + "\\" + (txtName.Text.Length > 0 ? txtName.Text : "Untitled Folder") + ".exe";
				parameters.CompilerOptions = "/win32icon:temp.ico /target:winexe /optimize";
				parameters.ReferencedAssemblies.Add("System.dll");
				parameters.ReferencedAssemblies.Add("System.Drawing.dll");
				parameters.ReferencedAssemblies.Add("System.Collections.dll");
				parameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
				parameters.ReferencedAssemblies.Add("System.IO.dll");
				parameters.ReferencedAssemblies.Add("System.Reflection.dll");
				parameters.ReferencedAssemblies.Add("System.Runtime.InteropServices.dll");
				CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, generatedApp.GenerateApp());
				
				if (results.Errors.Count > 0)
				{
					string error = "";
					foreach (CompilerError CompErr in results.Errors)
					{
						error += "Line number " + CompErr.Line +
							", Error Number: " + CompErr.ErrorNumber +
							", '" + CompErr.ErrorText + ";" +
							Environment.NewLine;
					}
					MessageBox.Show(error);
				}
				else
				{
					pngIcon.Dispose();
					File.Delete("temp.ico"); //Elimina icono temporal.
					MessageBox.Show("Generated correctly");
					Application.Restart();
				}
			}
		}

		void button4_Click(object sender, EventArgs e)
		{
			if (listBox1.SelectedIndex != -1 && listBox1.Items.Count != 0)
			{
				generatedApp.RemoveShortcut(listBox1.SelectedIndex);
				listBox1.Items.RemoveAt(listBox1.SelectedIndex);
				
				button4.Enabled = listBox1.Items.Count != 0;
			}
		}
		void ListBox1KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete && button4.Enabled)
			{
				button4.PerformClick();
			}
		}
	}
}
