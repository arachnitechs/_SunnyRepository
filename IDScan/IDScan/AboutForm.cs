
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AssureTec.AssureID.SDK;

namespace IDScan
{
    /// <summary>
    /// Implements the "About" dialog for the application. Displays version information
    /// for the application, the AssureID Engine and the AssureID Library.
    /// </summary>
    public partial class AboutForm : Form
    {
        /// <summary>
        ///  Constructor.
        /// </summary>
        public AboutForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The version information for the AssureID Engine.
        /// </summary>
        public Version EngineVersion
        {
            get { return m_EngineVersion; }
            set
            {
                m_EngineVersion = value;
                labelEngineVersion.Text = String.Format(Resources.EngineVersion, m_EngineVersion);
            }
        }
        private Version m_EngineVersion;

        /// <summary>
        /// The version information for the AssureID Library.
        /// </summary>
        public Version LibraryVersion
        {
            get { return m_LibraryVersion; }
            set
            {
                m_LibraryVersion = value;
                labelLibraryVersion.Text = String.Format(Resources.LibraryVersion, m_LibraryVersion);
            }
        }
        private Version m_LibraryVersion;

        public LicenseInfo LicenseInfo
        {
            get { return m_LicenseInfo; }
            set
            {
                m_LicenseInfo = value;
                labelLicense.Text = ((m_LicenseInfo != null) && (m_LicenseInfo.IsSubscription))
                    ? String.Format("Licensed to {0}", m_LicenseInfo.CustomerName)
                    : String.Empty;
                labelTransactions.Text = ((m_LicenseInfo != null) && (m_LicenseInfo.IsSubscription) && (m_LicenseInfo.TransactionLimit > 0))
                    ? String.Format("[{0} of {1} documents processed]", m_LicenseInfo.TransactionCount, m_LicenseInfo.TransactionLimit)
                    : String.Empty;
            }
        }
        private LicenseInfo m_LicenseInfo;

        /// <summary>
        /// Initializes the form's display using version information from the AssureID Session
        /// specified in the constructor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutForm_Load(object sender, EventArgs e)
        {
            labelVersion.Text = Resources.ApplicationVersion;
        }

        /// <summary>
        /// Closes the dialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
