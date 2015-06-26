//****************************************************************************
//																			 *
//							AssureTec Technologies, Inc.					 *
//							  200 Perimeter Road							 *
//					 Manchester, New Hampshire, 03103 USA					 *
//								(603) 641-8443								 *
//																			 *
//			Copyright (c) 2002-2014, AssureTec Technologies, Inc.,			 *
//			All Rights Reserved.  Unpublished rights reserved				 *
//			under the copyright laws of the United States.					 *
//																			 *
//			The software contained on this media is proprietary				 *
//			to and embodies the confidential technology of					 *
//			AssureTec Technologies, Inc.  Possession, use, duplication		 *
//			or dissemination of the software and media is					 *
//			authorized only pursuant to a valid written license				 *
//			from AssureTec Technologies, Inc.								 *
//																			 *
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
    /// Implements dialog from which the user can correct an MRZ code. Displays an original
    /// MRZ, and has a control for the user to update the code.
    /// </summary>
    public partial class MrzCorrectionForm : Form
    {
        public MrzCorrectionForm()
        {
            InitializeComponent();
        }

        public String CorrectedMRZ
        {
            get { return m_CorrectedMRZ; }
        }
        private String m_CorrectedMRZ;

        public String OriginalMRZ
        {
            get { return m_OriginalMRZ; }
            set
            {
                m_OriginalMRZ = value;
                textBoxOriginalMRZ.Text = m_OriginalMRZ;
                textBoxCorrectedMRZ.Text = m_OriginalMRZ;
            }
        }
        private String m_OriginalMRZ;

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            // Reset corrected MRZ
            m_CorrectedMRZ = m_OriginalMRZ;
            this.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            // Set corrected MRZ
            m_CorrectedMRZ = textBoxCorrectedMRZ.Text;
            this.Close();
        }
    }
}
