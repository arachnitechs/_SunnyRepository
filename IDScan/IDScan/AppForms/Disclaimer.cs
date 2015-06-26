using IDScan.WizardLib;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using IDScan.Classes;


namespace IDScan.AppForms
{
	public class Disclaimer : WizardPage
    {
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private Button btnTest;
		private System.ComponentModel.IContainer components = null;

		public Disclaimer()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(76, 86);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(737, 280);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "Terms and Conditions Agreement: blah blah blah";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(10, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "&Disclaimer:";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(369, 410);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(119, 23);
            this.btnTest.TabIndex = 4;
            this.btnTest.Text = "Write Data Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // Disclaimer
            // 
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Name = "Disclaimer";
            this.Size = new System.Drawing.Size(929, 491);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
		#endregion

        protected override bool OnSetActive()
        {
            if( !base.OnSetActive() )
                return false;

            Wizard.SetWizardButtons(WizardButton.Next | WizardButton.Cancel);
            return true;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {

            DataAccess db = new DataAccess();
            //try
            //{
                db.insertMembership();
            //}
            //catch( Exception err)
            //{

            //    throw err;

            //}


      }


        //private void textBox1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        //{
        //    try
        //    {
        //        if( textBox1.Text.Length == 0 )
        //            throw new Exception( "Please enter some text." );
        //    }
        //    catch( Exception ex )
        //    {
        //        e.Cancel = true;
        //        errorProvider1.SetError( textBox1, ex.Message );
        //    }
        //}

        //private void textBox1_Validated(object sender, System.EventArgs e)
        //{
        //    errorProvider1.SetError( textBox1, "" );
        //}
    }
}

