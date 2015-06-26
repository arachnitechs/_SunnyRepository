using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using AssureTec.AssureID.SDK;
using AssureTec.AssureID.SDK.Events;
using AssureTec.AssureID.SDK.TransactionDocument;
using System.Collections.Generic;
using System.Text;
using IDScan.Data;
//using IDScan.Model;
using IDScan.WizardLib;

namespace IDScan.AppForms
{

	public class IDScanWizardForm : WizardForm
	{

        public IDScanWizardForm()
		{
		    InitializeComponent();


            Controls.AddRange(new Control[] 
            {
                new PalmSecure.psWindowMain(),
                new AssureTech(),
                new Disclaimer(),
                new CashOut()
            });


            //Controls.AddRange( new Control[] {
            //    new FirstPage(),
            //    new SecondPage(),
            //    new ThirdPage(),
            //    new FourthPage()
            //    } );
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // m_backButton
            // 
            this.m_backButton.Location = new System.Drawing.Point(988, 773);
            // 
            // m_nextButton
            // 
            this.m_nextButton.Location = new System.Drawing.Point(1129, 773);
            // 
            // m_cancelButton
            // 
            this.m_cancelButton.Location = new System.Drawing.Point(1266, 773);
            // 
            // m_finishButton
            // 
            this.m_finishButton.Location = new System.Drawing.Point(846, 773);
            // 
            // IDScanWizardForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1419, 858);
            this.Name = "IDScanWizardForm";
            this.Text = "   Membership Kiosk";
            this.ResumeLayout(false);

        }
		#endregion


 

 



    }
}

