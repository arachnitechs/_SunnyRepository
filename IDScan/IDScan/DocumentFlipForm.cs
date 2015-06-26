//****************************************************************************

//****************************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IDScan
{
    /// <summary>
    /// Dialog box used to ask the user to flip the current document in the reader.
    /// </summary>
    public partial class DocumentFlipForm : Form
    {
        /// <summary>
        /// Event for continue from document flip request.
        /// </summary>
        public event EventHandler ContinueDocumentFlip;

        /// <summary>
        /// Event for cancel of document flip request.
        /// </summary>
        public event EventHandler CancelDocumentFlip;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="bundle">The resource bundle from which UI elements are taken.</param>
        public DocumentFlipForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles continue button click. Notifies any listeners that user has completed document flip request
        /// and that processing may continue.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonContinue_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (ContinueDocumentFlip != null)
            {
                ContinueDocumentFlip(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Handles cancel button click. Notifies any listeners that user cancelled document flip request.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (CancelDocumentFlip != null)
            {
                CancelDocumentFlip(this, EventArgs.Empty);
            }
        }
    }
}
