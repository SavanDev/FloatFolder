/*
 * Created by SharpDevelop.
 * Date: 22/09/2020
 * SavanDev - MIT License
 */
namespace FloatFolder
{
	static class Template
	{
		public static readonly string AppNamespace = @"using System;
			using System.Collections.Generic;
			using System.Drawing;
			using System.IO;
			using System.Windows.Forms;
			using System.Reflection;
			using System.Runtime.InteropServices;";
		
		public static readonly string AppProgram = @"static class Program
			{
				static void Main()
				{
					Application.EnableVisualStyles();
					Application.SetCompatibleTextRenderingDefault(false);
					Application.Run(new App());
				}
			}";
		
		public static string AppMain(string shortcuts, string size)
		{
			return @"public class App : Form
				{
			        System.ComponentModel.IContainer components;
			        ListView listView1;
			        ImageList imageList1;
			
			        protected override void Dispose(bool disposing)
			        {
			            if (disposing && (components != null))
			            {
			                components.Dispose();
			            }
			            base.Dispose(disposing);
			        }
			
			        void InitializeComponent()
			        {
			            this.components = new System.ComponentModel.Container();
			            this.listView1 = new ListView();
			            this.imageList1 = new ImageList(this.components);
			            this.SuspendLayout();
			            // 
			            // listView1
			            // 
			            this.listView1.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
			            this.listView1.BackColor = SystemColors.Control;
			            this.listView1.BorderStyle = BorderStyle.None;
			            this.listView1.LargeImageList = this.imageList1;
			            this.listView1.Location = new Point(12, 12);
			            this.listView1.Size = new Size(" + size + @");
			            this.listView1.TileSize = new Size(143, 32);
						this.listView1.SelectedIndexChanged += this.listView1_SelectedIndexChanged;
			            // 
			            // imageList1
			            // 
			            this.imageList1.ColorDepth = ColorDepth.Depth32Bit;
			            this.imageList1.ImageSize = new Size(32, 32);
			            this.imageList1.TransparentColor = Color.Transparent;
			            // 
			            // Form1
			            // 
			            this.AutoScaleDimensions = new SizeF(6F, 13F);
			            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			            this.ClientSize = new Size(this.listView1.Width + 12, this.listView1.Height + 12);
			            this.ControlBox = false;
			            this.Controls.Add(this.listView1);
			            this.ShowIcon = false;
			            this.ShowInTaskbar = false;
			            this.StartPosition = FormStartPosition.Manual;
						this.Deactivate += this.Form1_Deactivate;
						this.Load += this.Form1_Load;
			            this.ResumeLayout(false);
			
			        }
			        
			        // Normal code
			        List<string> Url = new List<string>();
			        List<string> Nombre = new List<string>();
			
			        public App()
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
			            " + shortcuts + 
				  @"}
			
			        void Form1_Deactivate(object sender, EventArgs e)
			        {
			            Application.Exit();
			        }
			
			        public static Bitmap getApplicationIcon(string source)
			        {
			            return Icon.ExtractAssociatedIcon(source).ToBitmap();
			        }
			
			        void Form1_Load(object sender, EventArgs e)
			        {	
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
			
			        void listView1_SelectedIndexChanged(object sender, EventArgs e)
			        {
			            System.Diagnostics.Process.Start(Url[listView1.SelectedIndices[0]]);
			            Application.Exit();
			        }
			}";
		}
	}
}