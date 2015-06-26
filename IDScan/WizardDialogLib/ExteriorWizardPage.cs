
using System;
using System.Windows.Forms;

namespace IDScan.WizardLib
{
    /// <summary>
    /// Base class that is used to represent an exterior page (welcome or
    /// completion page) within a wizard dialog.
    /// </summary>
    public class ExteriorWizardPage : WizardPage
    {
        // ==================================================================
        // Protected Fields
        // ==================================================================

        /// <summary>
        /// The title label.
        /// </summary>
        //protected Label m_titleLabel;


        // ==================================================================
        // Public Constructors
        // ==================================================================
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SMS.Windows.Forms.ExteriorWizardPage">ExteriorWizardPage</see>
        /// class.
        /// </summary>
        public ExteriorWizardPage()
		{
			// This call is required by the Windows Form Designer
			InitializeComponent();
		}


        // ==================================================================
        // Private Methods
        // ==================================================================

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.SuspendLayout();
            // 
            // ExteriorWizardPage
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Location = new System.Drawing.Point(600, 500);
            this.Margin = new System.Windows.Forms.Padding(15);
            this.Name = "ExteriorWizardPage";
            this.Size = new System.Drawing.Size(1280, 704);
            this.ResumeLayout(false);

        }
		#endregion

    }
}
