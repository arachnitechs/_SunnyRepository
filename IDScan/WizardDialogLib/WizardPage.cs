using System;
using System.Drawing;
using System.Windows.Forms;

namespace IDScan.WizardLib
{
	/// <summary>
	/// Represents a single page within a wizard dialog.
	/// </summary>
	public class WizardPage : UserControl
	{
        // ==================================================================
        // Public Constructors
        // ==================================================================

        /// <summary>
        /// Initializes a new instance of the <see cref="SMS.Windows.Forms.WizardPage">WizardPage</see>
        /// class.
        /// </summary>
        public WizardPage()
		{
            // Required for Windows Form Designer support
            InitializeComponent();

            this.Dock = DockStyle.Fill;

		}


        // ==================================================================
        // Protected Properties
        // ==================================================================
        
        /// <summary>
        /// Gets the <see cref="SMS.Windows.Forms.WizardForm">WizardForm</see>
        /// to which this <see cref="SMS.Windows.Forms.WizardPage">WizardPage</see>
        /// belongs.
        /// </summary>
        protected WizardForm Wizard
        {
            get
            {
                // Return the parent WizardForm
                return (WizardForm)Parent;
            }
        }
        
        
        // ==================================================================
        // Private Methods
        // ==================================================================
        
        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // WizardPage
            // 
            this.AutoSize = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "WizardPage";
            this.Size = new System.Drawing.Size(493, 309);
            this.Load += new System.EventHandler(this.WizardPage_Load);
            this.ResumeLayout(false);

        }
		#endregion


        // ==================================================================
        // Protected Internal Methods
        // ==================================================================
        
        /// <summary>
        /// Called when the page is no longer the active page.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the page was successfully deactivated; otherwise
        /// <c>false</c>.
        /// </returns>
        /// <remarks>
        /// Override this method to perform special data validation tasks.
        /// </remarks>
        protected internal virtual bool OnKillActive()
        {
            // Deactivate if validation successful
            return Validate();
        }

        /// <summary>
        /// Called when the page becomes the active page.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the page was successfully set active; otherwise
        /// <c>false</c>.
        /// </returns>
        /// <remarks>
        /// Override this method to performs tasks when a page is activated.
        /// Your override of this method should call the default version
        /// before any other processing is done.
        /// </remarks>
        protected internal virtual bool OnSetActive()
        {
            // Activate the page
            return true;
        }
        
        /// <summary>
        /// Called when the user clicks the Back button in a wizard.
        /// </summary>
        /// <returns>
        /// <c>WizardForm.DefaultPage</c> to automatically advance to the
        /// next page; <c>WizardForm.NoPageChange</c> to prevent the page
        /// changing.  To jump to a page other than the next one, return
        /// the <c>Name</c> of the page to be displayed.
        /// </returns>
        /// <remarks>
        /// Override this method to specify some action the user must take
        /// when the Back button is pressed.
        /// </remarks>
        protected internal virtual string OnWizardBack()
        {
            // Move to the default previous page in the wizard
            return WizardForm.NextPage;
        }
        
        /// <summary>
        /// Called when the user clicks the Finish button in a wizard.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the wizard finishes successfully; otherwise
        /// <c>false</c>.
        /// </returns>
        /// <remarks>
        /// Override this method to specify some action the user must take
        /// when the Finish button is pressed.  Return <c>false</c> to
        /// prevent the wizard from finishing.
        /// </remarks>
        protected internal virtual bool OnWizardFinish()
        {
            // Finish the wizard
            return true;
        }
        
        /// <summary>
        /// Called when the user clicks the Next button in a wizard.
        /// </summary>
        /// <returns>
        /// <c>WizardForm.DefaultPage</c> to automatically advance to the
        /// next page; <c>WizardForm.NoPageChange</c> to prevent the page
        /// changing.  To jump to a page other than the next one, return
        /// the <c>Name</c> of the page to be displayed.
        /// </returns>
        /// <remarks>
        /// Override this method to specify some action the user must take
        /// when the Next button is pressed.
        /// </remarks>
        protected internal virtual string OnWizardNext()
        {
            // Move to the default next page in the wizard
            return WizardForm.NextPage;
        }

        private void WizardPage_Load(object sender, EventArgs e)
        {

            this.Location = new Point(100, 100);

            //this.Dock = DockStyle.Fill;
            
        }
    }
}
