
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
    public class PS_THREAD_RESULT 
    {
        public uint result;
        public int retryCnt;
        public bool authenticated;
        public List<string> userId;
        public List<int> farAchieved;
        public PS_SILHOUETTE_TBL info;
        public DNET_PvAPI_ErrorInfo errInfo;

        public PS_THREAD_RESULT()
        {
            result        = 0;
            retryCnt      = 0;
            authenticated = false;
            userId        = new List<string>();
            farAchieved   = new List<int>();
            info          = new PS_SILHOUETTE_TBL();
            errInfo       = new DNET_PvAPI_ErrorInfo();
        }
    }

    public class THREAD_PARAM_TBL
    {
        public PalmSecure.psWindowMain dialog;
        public string userId;

        public THREAD_PARAM_TBL()
        {
            dialog = null;
            userId = "";
        }
    }

    /// <summary>
    /// Thread Base
    /// </summary>
    class PsThreadBase
    {
        private Thread trd = null;

        public void PalmSecure_StartThread(ParameterizedThreadStart threadDelegate, THREAD_PARAM_TBL Param = null)
        {
            trd = new Thread(threadDelegate);
            trd.IsBackground = true;
            trd.Start(Param);
        }
    }
}
