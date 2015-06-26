using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace IDScan.WizardLib
{
    /// <summary>
    /// Used to identify the various buttons that may appear within a wizard
    /// dialog.  
    /// </summary>
    [Flags]		
    public enum WizardButton
    {

        Cancel = 0,
        /// <summary>
        /// Identifies the <b>Back</b> button.
        /// </summary>
        Back           = 0x00000001,
        
        /// <summary>
        /// Identifies the <b>Next</b> button.
        /// </summary>
        Next           = 0x00000002,
        
        /// <summary>
        /// Identifies the <b>Finish</b> button.
        /// </summary>
        Finish         = 0x00000004,
        
        /// <summary>
        /// Identifies the disabled <b>Finish</b> button.
        /// </summary>
        DisabledFinish = 0x00000008,



    }
    
    /// <summary>
    /// Represents a wizard dialog.
    /// </summary>
    public class WizardForm : Form
	{
        // ==================================================================
        // Public Constants
        // ==================================================================

        /// <summary>
        /// Used by a page to indicate to this wizard that the next page
        /// should be activated when either the Back or Next buttons are
        /// pressed.
        /// </summary>
        public const string NextPage = "";

        /// <summary>
        /// Used by a page to indicate to this wizard that the selected page
        /// should remain active when either the Back or Next buttons are
        /// pressed.
        /// </summary>
        public const string NoPageChange = null;
	
	
        // ==================================================================
        // Private Fields
        // ==================================================================
        
        /// <summary>
        /// Array of wizard pages.
        /// </summary>
        private ArrayList m_pages = new ArrayList();
        
        /// <summary>
        /// Index of the selected page; -1 if no page selected.
        /// </summary>
        private int m_selectedIndex = -1;


        // ==================================================================
        // Protected Fields
        // ==================================================================
        
        /// <summary>
        /// The Back button.
        /// </summary>
        protected Button m_backButton;

        /// <summary>
        /// The Next button.
        /// </summary>
        protected Button m_nextButton;

        /// <summary>
        /// The Cancel button.
        /// </summary>
        protected Button m_cancelButton;
        private RichTextBox txtMessageBar;

        /// <summary>
        /// The Finish button.
        /// </summary>
        protected Button m_finishButton;


        // ==================================================================
        // Public Constructors
        // ==================================================================
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SMS.Windows.Forms.WizardForm">WizardForm</see>
        /// class.
        /// </summary>
        public WizardForm()
		{
			// Required for Windows Form Designer support
			InitializeComponent();

            // Ensure Finish and Next buttons are positioned similarly
			m_finishButton.Location = m_nextButton.Location;
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
            this.m_backButton = new System.Windows.Forms.Button();
            this.m_nextButton = new System.Windows.Forms.Button();
            this.m_cancelButton = new System.Windows.Forms.Button();
            this.m_finishButton = new System.Windows.Forms.Button();
            this.txtMessageBar = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // m_backButton
            // 
            this.m_backButton.Location = new System.Drawing.Point(984, 609);
            this.m_backButton.Name = "m_backButton";
            this.m_backButton.Size = new System.Drawing.Size(125, 50);
            this.m_backButton.TabIndex = 8;
            this.m_backButton.Text = "< &Back";
            this.m_backButton.Click += new System.EventHandler(this.OnClickBack);
            // 
            // m_nextButton
            // 
            this.m_nextButton.Location = new System.Drawing.Point(1125, 610);
            this.m_nextButton.Name = "m_nextButton";
            this.m_nextButton.Size = new System.Drawing.Size(125, 50);
            this.m_nextButton.TabIndex = 9;
            this.m_nextButton.Text = "&Next >";
            this.m_nextButton.Click += new System.EventHandler(this.OnClickNext);
            // 
            // m_cancelButton
            // 
            this.m_cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cancelButton.Location = new System.Drawing.Point(1265, 610);
            this.m_cancelButton.Name = "m_cancelButton";
            this.m_cancelButton.Size = new System.Drawing.Size(125, 50);
            this.m_cancelButton.TabIndex = 11;
            this.m_cancelButton.Text = "Cancel";
            this.m_cancelButton.Click += new System.EventHandler(this.OnClickCancel);
            // 
            // m_finishButton
            // 
            this.m_finishButton.Location = new System.Drawing.Point(840, 610);
            this.m_finishButton.Name = "m_finishButton";
            this.m_finishButton.Size = new System.Drawing.Size(125, 50);
            this.m_finishButton.TabIndex = 10;
            this.m_finishButton.Text = "&Finish";
            this.m_finishButton.Visible = false;
            this.m_finishButton.Click += new System.EventHandler(this.OnClickFinish);
            // 
            // txtMessageBar
            // 
            this.txtMessageBar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMessageBar.DetectUrls = false;
            this.txtMessageBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtMessageBar.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessageBar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtMessageBar.Location = new System.Drawing.Point(10, 10);
            this.txtMessageBar.Margin = new System.Windows.Forms.Padding(10);
            this.txtMessageBar.Name = "txtMessageBar";
            this.txtMessageBar.ReadOnly = true;
            this.txtMessageBar.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtMessageBar.Size = new System.Drawing.Size(1399, 64);
            this.txtMessageBar.TabIndex = 0;
            this.txtMessageBar.TabStop = false;
            this.txtMessageBar.Text = "";
            // 
            // WizardForm
            // 
            this.AcceptButton = this.m_nextButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.m_cancelButton;
            this.ClientSize = new System.Drawing.Size(1419, 739);
            this.Controls.Add(this.txtMessageBar);
            this.Controls.Add(this.m_backButton);
            this.Controls.Add(this.m_nextButton);
            this.Controls.Add(this.m_cancelButton);
            this.Controls.Add(this.m_finishButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WizardForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.WizardForm_Load);
            this.ResumeLayout(false);

        }
		#endregion

        private void WizardForm_Load(object sender, EventArgs e)
        {

        }




        /// <summary>
        /// Activates the page at the specified index in the page array.
        /// </summary>
        /// <param name="newIndex">
        /// Index of new page to be selected.
        /// </param>
        private void ActivatePage( int newIndex )
        {
            // Ensure the index is valid
            if( newIndex < 0 || newIndex >= m_pages.Count )
                throw new ArgumentOutOfRangeException();

            // Deactivate the current page if applicable
            WizardPage currentPage = null;
            if( m_selectedIndex != -1 )
            {
                currentPage = (WizardPage)m_pages[ m_selectedIndex ];
                if( !currentPage.OnKillActive() )
                    return;
            }

            // Activate the new page
            WizardPage newPage = (WizardPage)m_pages[ newIndex ];
            if( !newPage.OnSetActive() )
                return;

            // Update state
            m_selectedIndex = newIndex;
            if( currentPage != null )
                currentPage.Visible = false;
            newPage.Visible = true;
            newPage.Focus();
        }

        /// <summary>
        /// Handles the Click event for the Back button.
        /// </summary>
        private void OnClickBack( object sender, EventArgs e )
        {
            // Ensure a page is currently selected
            if( m_selectedIndex != -1 )
            {
                // Inform selected page that the Back button was clicked
                string pageName = ((WizardPage)m_pages[
                    m_selectedIndex ]).OnWizardBack();
                switch( pageName )
                {
                    // Do nothing
                    case NoPageChange:
                        break;
                        
                    // Activate the next appropriate page
                    case NextPage:
                        if( m_selectedIndex - 1 >= 0 )
                            ActivatePage( m_selectedIndex - 1 );
                        break;

                    // Activate the specified page if it exists
                    default:
                        foreach( WizardPage page in m_pages )
                        {
                            if( page.Name == pageName )
                                ActivatePage( m_pages.IndexOf( page ) );
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Handles the Click event for the Cancel button.
        /// </summary>
        private void OnClickCancel( object sender, EventArgs e )
        {
            // Close wizard
            DialogResult = DialogResult.Cancel;
            Application.Restart();
        }

        /// <summary>
        /// Handles the Click event for the Finish button.
        /// </summary>
        private void OnClickFinish( object sender, EventArgs e )
        {
            // Ensure a page is currently selected
            if( m_selectedIndex != -1 )
            {
                // Inform selected page that the Finish button was clicked
                WizardPage page = (WizardPage)m_pages[ m_selectedIndex ];
                if( page.OnWizardFinish() )
                {
                    // Deactivate page and close wizard
                    if( page.OnKillActive() )
                        DialogResult = DialogResult.OK;

                    Application.Restart();
                }
            }
        }

        /// <summary>
        /// Handles the Click event for the Next button.
        /// </summary>
        private void OnClickNext( object sender, EventArgs e )
        {
            // Ensure a page is currently selected
            if( m_selectedIndex != -1 )
            {
                // Inform selected page that the Next button was clicked
                string pageName = ((WizardPage)m_pages[m_selectedIndex ]).OnWizardNext();
                switch( pageName )
                {
                    // Do nothing
                    case NoPageChange:
                        break;

                    // Activate the next appropriate page
                    case NextPage:
                        if( m_selectedIndex + 1 < m_pages.Count )
                            ActivatePage( m_selectedIndex + 1 );
                        break;

                    // Activate the specified page if it exists
                    default:
                        foreach( WizardPage page in m_pages )
                        {
                            if( page.Name == pageName )
                                ActivatePage( m_pages.IndexOf( page ) );
                        }
                        break;
                }
            }
        }


        // ==================================================================
        // Protected Methods
        // ==================================================================
        
        /// <seealso cref="System.Windows.Forms.Control.OnControlAdded">
        /// System.Windows.Forms.Control.OnControlAdded
        /// </seealso>
        protected override void OnControlAdded( ControlEventArgs e )
        {
            // Invoke base class implementation
            base.OnControlAdded( e );
            
            // Set default properties for all WizardPage instances added to
            // this form
            WizardPage page = e.Control as WizardPage;
            if( page != null )
            {
                page.Visible = false;
                page.Location = new Point( 0, 0 );
                //page.Size = new Size( Width, m_separator.Location.Y );
                m_pages.Add( page );
                if( m_selectedIndex == -1 )
                    m_selectedIndex = 0;
            }
        }

        /// <seealso cref="System.Windows.Forms.Form.OnLoad">
        /// System.Windows.Forms.Form.OnLoad
        /// </seealso>
        protected override void OnLoad( EventArgs e )
        {
            // Invoke base class implementation
            base.OnLoad( e );
            
            // Activate the first page in the wizard
            if( m_pages.Count > 0 )
                ActivatePage( 0 );
        }


        // ==================================================================
        // Public Methods
        // ==================================================================
        
        /// <summary>
        /// Sets the text in the Finish button.
        /// </summary>
        /// <param name="text">
        /// Text to be displayed on the Finish button.
        /// </param>
        public void SetFinishText( string text )
        {
            // Set the Finish button text
            m_finishButton.Text = text;
        }
        
        /// <summary>
        /// Enables or disables the Back, Next, or Finish buttons in the
        /// wizard.
        /// </summary>
        /// <param name="flags">
        /// A set of flags that customize the function and appearance of the
        /// wizard buttons.  This parameter can be a combination of any
        /// value in the <c>WizardButton</c> enumeration.
        /// </param>
        /// <remarks>
        /// Typically, you should call <c>SetWizardButtons</c> from
        /// <c>WizardPage.OnSetActive</c>.  You can display a Finish or a
        /// Next button at one time, but not both.
        /// </remarks>
        public void SetWizardButtons( WizardButton flags )
        {
            // always make the cancel button enabled
            m_cancelButton.Enabled = true;
            //m_cancelButton.Enabled = (flags == WizardButton.Cancel);

            // Enable/disable and show/hide buttons appropriately
            m_backButton.Enabled =
                (flags & WizardButton.Back) == WizardButton.Back;

            m_nextButton.Enabled =
                (flags & WizardButton.Next) == WizardButton.Next;

            m_nextButton.Visible =
                (flags & WizardButton.Finish) == 0 &&
                (flags & WizardButton.DisabledFinish) == 0;

            m_finishButton.Enabled =
                (flags & WizardButton.DisabledFinish) == 0;

            m_finishButton.Visible =
                (flags & WizardButton.Finish) == WizardButton.Finish ||
                (flags & WizardButton.DisabledFinish) == WizardButton.DisabledFinish;
                
            // Set the AcceptButton depending on whether or not the Finish
            // button is visible or not
            AcceptButton = m_finishButton.Visible ? m_finishButton :
                m_nextButton;
        }


        public void SetMessageBarText(string msg, bool withSpeach = false)
        {
            this.txtMessageBar.Text = msg;
            if (withSpeach)
            {
                SpeakMessageBarText(msg);
            }
        }

        public void SpeakMessageBarText(string msg)
        {
            //this.txtMessageBar.Text = msg;

            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.SetOutputToDefaultAudioDevice();
            synth.Speak(msg);


        }


    }
}
