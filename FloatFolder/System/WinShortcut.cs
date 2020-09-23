/*
 * Created by SharpDevelop.
 * Date: 23/09/2020
 * SavanDev - MIT License
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FloatFolder
{
	/// <summary>
	/// Description of WinShortcut.
	/// </summary>
	public partial class WinShortcut : Form
	{
		public WinShortcut(string fileName, string url)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			txtFileName.Text = fileName;
			pictureBox1.Image = Icon.ExtractAssociatedIcon(url).ToBitmap();
			
			btnOK.Click += CloseEvent;
			btnCancel.Click += CloseEvent;
		}
		
		public string GetShortcutName()
		{
			return txtFileName.Text;
		}
		
		void CloseEvent(object sender, EventArgs e)
		{
			Close();
		}
	}
}
