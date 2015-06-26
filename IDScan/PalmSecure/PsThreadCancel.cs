
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using PalmSecure;
using PalmSecure.util;

namespace PalmSecure
{
    class PsThreadCancel : PsThreadBase
    {
        /// <summary>
        /// Cancel thread process.
        /// </summary>
        /// <param name="obj">Argument</param>
        public void PalmSecure_ThreadProc(Object obj)
        {
            THREAD_PARAM_TBL cancelParam = (THREAD_PARAM_TBL)obj;
            PS_THREAD_RESULT stResult = new PS_THREAD_RESULT();


            //Cancel
            ///////////////////////////////////////////////////////////////////////////
            try
            {
                stResult.result = cancelParam.dialog.m_PalmSecureIf.DNET_PvAPI_Cancel(
                    cancelParam.dialog.m_ModuleHandle,
                    stResult.errInfo
                    );
                if (stResult.result != PalmSecureConstant.DNET_BioAPI_OK)
                {
                    return;
                }
            }
            catch(PalmSecureException e)
            {
                MessageBox.Show(
                    e.Message
                    + "Error No: "  + e.ErrNumber
                    );
            }
            ///////////////////////////////////////////////////////////////////////////


            return;
        }
    }
}
