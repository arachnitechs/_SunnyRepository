//****************************************************************************

//****************************************************************************

using System;
using System.Windows.Forms;
using IDScan.AppForms;

namespace IDScan
{
    /// <summary>

    /// </summary>
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            //Application.Run(new MainForm());
            Application.Run(new MainIDScanWizForm());

        }
    }
}
