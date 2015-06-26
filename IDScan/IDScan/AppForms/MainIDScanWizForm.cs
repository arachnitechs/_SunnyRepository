using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace IDScan.AppForms
{
	/// <summary>
	/// Summary description for MainForm.
	/// </summary>
    public class MainIDScanWizForm : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Button button1;
        private TextBox textBox1;
        private Label lblIstructions;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MainIDScanWizForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainIDScanWizForm));
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblIstructions = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.Location = new System.Drawing.Point(291, 512);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(347, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Click to Start the Membership Process";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(32, 32);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(886, 450);
            this.textBox1.TabIndex = 1;
            // 
            // lblIstructions
            // 
            this.lblIstructions.AutoSize = true;
            this.lblIstructions.Location = new System.Drawing.Point(32, 13);
            this.lblIstructions.Name = "lblIstructions";
            this.lblIstructions.Size = new System.Drawing.Size(61, 13);
            this.lblIstructions.TabIndex = 2;
            this.lblIstructions.Text = "Instructions";
            // 
            // MainIDScanWizForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(954, 565);
            this.Controls.Add(this.lblIstructions);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainIDScanWizForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tilden Club Membership";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
		#endregion


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[STAThread]
        //static void Main() 
        //{
        //    Application.Run( new MainForm() );
        //}

        private void button1_Click(object sender, System.EventArgs e)
        {
            IDScanWizardForm form = new IDScanWizardForm();
            form.ShowDialog();
        }


    }
}
