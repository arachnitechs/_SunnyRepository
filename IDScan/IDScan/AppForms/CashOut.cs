using IDScan.WizardLib;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace IDScan.AppForms
{
	public class CashOut : ExteriorWizardPage
    {
		private System.ComponentModel.IContainer components = null;

		public CashOut()
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
            //((System.ComponentModel.ISupportInitialize)(this.m_watermarkPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // m_titleLabel
            // 
            //this.m_titleLabel.Text = "Cash Out";
            // 
            // CashOut
            // 
            this.Name = "CashOut";
            //((System.ComponentModel.ISupportInitialize)(this.m_watermarkPicture)).EndInit();
            this.ResumeLayout(false);

        }
		#endregion

        protected override bool OnSetActive()
        {
            if( !base.OnSetActive() )
                return false;
            
            // Enable both the Back and Finish (enabled/disabled) buttons on this page    
            //Wizard.SetWizardButtons( WizardButton.Back |
            //    (checkBox1.Checked ? WizardButton.Finish : WizardButton.DisabledFinish) );

            //Wizard.SetWizardButtons(WizardButton.Back |
            //    (checkBox1.Checked ? WizardButton.Finish : WizardButton.DisabledFinish));

            Wizard.SetWizardButtons(WizardButton.Finish | WizardButton.Cancel);

            return true;
        }

        //private void checkBox1_Click(object sender, System.EventArgs e)
        //{
        //    // Enable both the Back and Finish (enabled/disabled) buttons on this page    
        //    Wizard.SetWizardButtons( WizardButton.Back |
        //        (checkBox1.Checked ? WizardButton.Finish : WizardButton.DisabledFinish) );
        //}
    }
}

