namespace FloatFolder
{
    partial class Configuracion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        	this.label1 = new System.Windows.Forms.Label();
        	this.txtName = new System.Windows.Forms.TextBox();
        	this.label2 = new System.Windows.Forms.Label();
        	this.button1 = new System.Windows.Forms.Button();
        	this.button2 = new System.Windows.Forms.Button();
        	this.listBox1 = new System.Windows.Forms.ListBox();
        	this.button3 = new System.Windows.Forms.Button();
        	this.button4 = new System.Windows.Forms.Button();
        	this.dialogOpen = new System.Windows.Forms.OpenFileDialog();
        	this.pictureBox1 = new System.Windows.Forms.PictureBox();
        	this.dialogIcon = new System.Windows.Forms.OpenFileDialog();
        	this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
        	this.groupBox1 = new System.Windows.Forms.GroupBox();
        	this.statusStrip1 = new System.Windows.Forms.StatusStrip();
        	this.lblCredit = new System.Windows.Forms.ToolStripStatusLabel();
        	this.stripVersion = new System.Windows.Forms.ToolStripStatusLabel();
        	this.button5 = new System.Windows.Forms.Button();
        	((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
        	this.groupBox1.SuspendLayout();
        	this.statusStrip1.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(12, 9);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(68, 13);
        	this.label1.TabIndex = 0;
        	this.label1.Text = "Folder name:";
        	// 
        	// txtName
        	// 
        	this.txtName.Location = new System.Drawing.Point(12, 25);
        	this.txtName.Name = "txtName";
        	this.txtName.Size = new System.Drawing.Size(295, 20);
        	this.txtName.TabIndex = 1;
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Location = new System.Drawing.Point(12, 51);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(31, 13);
        	this.label2.TabIndex = 2;
        	this.label2.Text = "Icon:";
        	// 
        	// button1
        	// 
        	this.button1.Location = new System.Drawing.Point(15, 173);
        	this.button1.Name = "button1";
        	this.button1.Size = new System.Drawing.Size(100, 23);
        	this.button1.TabIndex = 4;
        	this.button1.Text = "Change icon...";
        	this.button1.UseVisualStyleBackColor = true;
        	this.button1.Click += new System.EventHandler(this.button1_Click);
        	// 
        	// button2
        	// 
        	this.button2.Location = new System.Drawing.Point(313, 23);
        	this.button2.Name = "button2";
        	this.button2.Size = new System.Drawing.Size(72, 23);
        	this.button2.TabIndex = 6;
        	this.button2.Text = "Generate";
        	this.button2.UseVisualStyleBackColor = true;
        	this.button2.Click += new System.EventHandler(this.button2_Click);
        	// 
        	// listBox1
        	// 
        	this.listBox1.FormattingEnabled = true;
        	this.listBox1.Location = new System.Drawing.Point(6, 22);
        	this.listBox1.Name = "listBox1";
        	this.listBox1.Size = new System.Drawing.Size(249, 95);
        	this.listBox1.TabIndex = 7;
        	this.listBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListBox1KeyDown);
        	// 
        	// button3
        	// 
        	this.button3.Location = new System.Drawing.Point(6, 122);
        	this.button3.Name = "button3";
        	this.button3.Size = new System.Drawing.Size(87, 23);
        	this.button3.TabIndex = 9;
        	this.button3.Text = "Add";
        	this.button3.UseVisualStyleBackColor = true;
        	this.button3.Click += new System.EventHandler(this.button3_Click);
        	// 
        	// button4
        	// 
        	this.button4.Enabled = false;
        	this.button4.Location = new System.Drawing.Point(99, 122);
        	this.button4.Name = "button4";
        	this.button4.Size = new System.Drawing.Size(75, 23);
        	this.button4.TabIndex = 10;
        	this.button4.Text = "Delete";
        	this.button4.UseVisualStyleBackColor = true;
        	this.button4.Click += new System.EventHandler(this.button4_Click);
        	// 
        	// dialogOpen
        	// 
        	this.dialogOpen.AddExtension = false;
        	this.dialogOpen.Filter = "Executables|*.exe";
        	// 
        	// pictureBox1
        	// 
        	this.pictureBox1.Image = global::FloatFolder.Properties.Resource.Folder;
        	this.pictureBox1.Location = new System.Drawing.Point(15, 67);
        	this.pictureBox1.Name = "pictureBox1";
        	this.pictureBox1.Size = new System.Drawing.Size(100, 100);
        	this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        	this.pictureBox1.TabIndex = 3;
        	this.pictureBox1.TabStop = false;
        	// 
        	// dialogIcon
        	// 
        	this.dialogIcon.Filter = "Images (PNG, JPG, JPEG)|*.png;*.jpg;*.jpeg";
        	// 
        	// folderBrowserDialog1
        	// 
        	this.folderBrowserDialog1.Description = "Select the save path";
        	// 
        	// groupBox1
        	// 
        	this.groupBox1.Controls.Add(this.button5);
        	this.groupBox1.Controls.Add(this.listBox1);
        	this.groupBox1.Controls.Add(this.button3);
        	this.groupBox1.Controls.Add(this.button4);
        	this.groupBox1.Location = new System.Drawing.Point(121, 51);
        	this.groupBox1.Name = "groupBox1";
        	this.groupBox1.Size = new System.Drawing.Size(264, 151);
        	this.groupBox1.TabIndex = 12;
        	this.groupBox1.TabStop = false;
        	this.groupBox1.Text = "Shortcuts";
        	// 
        	// statusStrip1
        	// 
        	this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.lblCredit,
			this.stripVersion});
        	this.statusStrip1.Location = new System.Drawing.Point(0, 215);
        	this.statusStrip1.Name = "statusStrip1";
        	this.statusStrip1.Size = new System.Drawing.Size(397, 22);
        	this.statusStrip1.SizingGrip = false;
        	this.statusStrip1.TabIndex = 13;
        	this.statusStrip1.Text = "statusStrip1";
        	// 
        	// lblCredit
        	// 
        	this.lblCredit.Name = "lblCredit";
        	this.lblCredit.Size = new System.Drawing.Size(159, 17);
        	this.lblCredit.Text = "SavanDev 2020 - MIT License";
        	// 
        	// stripVersion
        	// 
        	this.stripVersion.Name = "stripVersion";
        	this.stripVersion.RightToLeft = System.Windows.Forms.RightToLeft.No;
        	this.stripVersion.Size = new System.Drawing.Size(223, 17);
        	this.stripVersion.Spring = true;
        	this.stripVersion.Text = "toolStripStatusLabel1";
        	this.stripVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// button5
        	// 
        	this.button5.Location = new System.Drawing.Point(180, 122);
        	this.button5.Name = "button5";
        	this.button5.Size = new System.Drawing.Size(75, 23);
        	this.button5.TabIndex = 11;
        	this.button5.Text = "Clear";
        	this.button5.UseVisualStyleBackColor = true;
        	this.button5.Click += new System.EventHandler(this.Button5Click);
        	// 
        	// Configuracion
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(397, 237);
        	this.Controls.Add(this.statusStrip1);
        	this.Controls.Add(this.groupBox1);
        	this.Controls.Add(this.button2);
        	this.Controls.Add(this.button1);
        	this.Controls.Add(this.pictureBox1);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.txtName);
        	this.Controls.Add(this.label1);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        	this.Icon = global::FloatFolder.Properties.Resource.FloatFolder_1;
        	this.MaximizeBox = false;
        	this.Name = "Configuracion";
        	this.Text = "FloatFolder - Settings";
        	((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
        	this.groupBox1.ResumeLayout(false);
        	this.statusStrip1.ResumeLayout(false);
        	this.statusStrip1.PerformLayout();
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.OpenFileDialog dialogOpen;
        private System.Windows.Forms.OpenFileDialog dialogIcon;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblCredit;
        private System.Windows.Forms.ToolStripStatusLabel stripVersion;
        private System.Windows.Forms.Button button5;
    }
}