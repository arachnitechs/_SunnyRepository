
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PalmSecure
{
    static class Program
    {
        /// <summary>
        /// Main entry point.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // shut off
            //Application.Run(new PalmSecure.psWindowMain());
        }
    }
}
