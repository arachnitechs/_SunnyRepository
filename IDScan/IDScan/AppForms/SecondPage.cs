
using IDScan.WizardLib;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using IDScan.Model;

using PalmSecure;
using PalmSecure.util;


namespace IDScan.AppForms
{
    /// <summary>
    /// MainForm class
    /// </summary>
    /// 
    //public partial class PsWindowMain : Form
    public partial class SeconPage : Form
    {
        public const int PS_REGISTER_MAX = 1000;

        delegate void SetGuidanceDelegate(string msg, bool bErr, string userId);
        delegate void SetWorkMsgDelegateId(int workid, int count);
        delegate void SetWorkMsgDelegateMsg(string msg);
        delegate void InitListDelegate();
        delegate void InitControlsDelegate();

        private PsFileAccessorLang clPsFileAccessorLang;
        public PsFileAccessorLang m_PsFileAcsLang
        {
            get { return clPsFileAccessorLang; }
            set { clPsFileAccessorLang = value; }
        }

        private PsFileAccessorIni clPsFileAccessorIni;
        public PsFileAccessorIni m_PsFileAcsIni
        {
            get { return clPsFileAccessorIni; }
            set { clPsFileAccessorIni = value; }
        }

        private PsDataManager clPsDataManager;
        public PsDataManager m_PsDataManager
        {
            get { return clPsDataManager; }
            set { clPsDataManager = value; }
        }
 
        private PalmSecureIf clsPalmSecureIf;
        public PalmSecureIf m_PalmSecureIf
        {
            get { return clsPalmSecureIf; }
            set { clsPalmSecureIf = value; }
        }

        private MemoryStream msSilhouetteInfo;
        public MemoryStream m_SilhouetteInfo
        {
            get { return msSilhouetteInfo; }
            set { msSilhouetteInfo = value; }
        }

        private bool bCancelFlg;
        public bool m_CancelFlg
        {
            get { return bCancelFlg; }
            set { bCancelFlg = value; }
        }

        public string m_ModulePath = "";
        public uint m_ModuleHandle = 0;
        public uint m_NotifiedScore = 0;
        public bool m_EnrollFlg = false;

        /// <summary>
        /// Read main form.
        /// </summary>
        public SecondPage()
        {
            uint uiSensor = 0;
            uint sensorExtKind = 0;
            int guideMode = 0;

            InitializeComponent();

            m_PsFileAcsLang  = new PsFileAccessorLang();
            m_PsFileAcsIni   = new PsFileAccessorIni();
            m_PsDataManager  = new PsDataManager(this);
            m_PalmSecureIf = new PalmSecureIf();

            //Set Module Path.
            PalmSecure_SetModulePath();

            //Load configuration file.
            System.Diagnostics.Process pr = System.Diagnostics.Process.GetCurrentProcess();
            if (! System.IO.File.Exists(PsFileAccessorLang.PS_FILENAME))
            {
                System.Windows.Forms.MessageBox.Show("Read Error " + PsFileAccessorLang.PS_FILENAME);
                pr.Kill();
            }
            if (! System.IO.File.Exists(PsFileAccessorIni.PS_FILENAME))
            {
                System.Windows.Forms.MessageBox.Show("Read Error " + PsFileAccessorIni.PS_FILENAME);
                pr.Kill();
            }
            if (!System.IO.File.Exists("PalmSecure_GUIDELESS.BMP"))
            {
                System.Windows.Forms.MessageBox.Show("Read Error " + "PalmSecure_GUIDELESS.bmp");
                pr.Kill();
            }
            if (!System.IO.File.Exists("PalmSecure_HANDGUIDE.BMP"))
            {
                System.Windows.Forms.MessageBox.Show("Read Error " + "PalmSecure_HANDGUIDE.bmp");
                pr.Kill();
            }
            if (!System.IO.File.Exists("PalmSecure_OK.wav"))
            {
                System.Windows.Forms.MessageBox.Show("Read Error " + "PalmSecure_OK.wav");
                pr.Kill();
            }
            if (!System.IO.File.Exists("PalmSecure_NG.wav"))
            {
                System.Windows.Forms.MessageBox.Show("Read Error " + "PalmSecure_NG.wav");
                pr.Kill();
            }

            try
            {
                m_PsFileAcsLang.PalmSecure_Read();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Read Error " + PsFileAccessorLang.PS_FILENAME);
                pr.Kill();
            }

            try
            {
                m_PsFileAcsIni.PalmSecure_Read();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Read Error " + PsFileAccessorIni.PS_FILENAME);
                pr.Kill();
            }

            //Initialize authentication library.
            if (!PalmSecure_InitLibrary(ref uiSensor, ref sensorExtKind, ref guideMode))
            {
                pr.Kill();
            }

            m_PsDataManager.PalmSecure_Init(
                (int)uiSensor,
                guideMode
                );

            if (uiSensor == PalmSecureConstant.DNET_PvAPI_INFO_SENSOR_TYPE_4)
            {
                PsFileAccessor.g_clLang.Guidance.WorkEnroll =
                    PsFileAccessor.g_clLang.Guidance.WorkEnrollSL;
            }
            else if (uiSensor == PalmSecureConstant.DNET_PvAPI_INFO_SENSOR_TYPE_2)
            {
                if (sensorExtKind == PalmSecureConstant.DNET_PvAPI_INFO_SENSOR_MODE_COMPATIBLE)
                {
                    PsFileAccessor.g_clLang.MainDialog.SensorName1 =
                        PsFileAccessor.g_clLang.MainDialog.SensorName1_Compati;
                }
                else if (sensorExtKind == PalmSecureConstant.DNET_PvAPI_INFO_SENSOR_MODE_EXTEND)
                {
                    PsFileAccessor.g_clLang.MainDialog.SensorName1 =
                        PsFileAccessor.g_clLang.MainDialog.SensorName1_Extend;
                }
            }

            PalmSecure_ReadGuideBmp();
            PalmSecure_InitControls();
            PalmSecure_InitIdList();
        }

        /// <summary>
        /// Set module path.
        /// </summary>
        void PalmSecure_SetModulePath()
        {
            string strFullPath = Application.ExecutablePath;
            m_ModulePath = Path.GetDirectoryName(strFullPath);
        }

        /// <summary>
        /// Initialize interface library.
        /// </summary>
        /// <param name="uiSensor">Sensor kind</param>
        /// <param name="guideMode">Guide mode</param>
        /// <returns>
        /// true  : Normal end<para/>
        /// false : Error occur<para/>
        /// </returns>
        bool PalmSecure_InitLibrary(ref uint uiSensor, ref uint sensorExtKind, ref int guideMode)
        {
            string Key = "4CJCccBuk2FSRsC0";

            byte[] ModuleGuid = new byte[]{
                (byte)0xe1, (byte)0x9a, (byte)0x69, (byte)0x01,
                (byte)0xb8, (byte)0xc2, (byte)0x49, (byte)0x80,
                (byte)0x87, (byte)0x7e, (byte)0x11, (byte)0xd4,
                (byte)0xd8, (byte)0xf1, (byte)0xbe, (byte)0x79
                };
            uint lpuiSensorNum = 0;
            DNET_PvAPI_SensorInfoEx[] lptSensorInfo =
                new DNET_PvAPI_SensorInfoEx[PalmSecureConstant.DNET_PvAPI_GET_SENSOR_INFO_MAX];
            DNET_PvAPI_LBINFO lbInfo = new DNET_PvAPI_LBINFO(); 

            PS_THREAD_RESULT stResult = new PS_THREAD_RESULT();


            //Authenticate application by key
            ///////////////////////////////////////////////////////////////////////////
            try
            {
                stResult.result = m_PalmSecureIf.DNET_PvAPI_ApAuthenticate(Key);
                if (stResult.result != PalmSecureConstant.DNET_BioAPI_OK)
                {
                    m_PalmSecureIf.DNET_PvAPI_GetErrorInfo(stResult.errInfo);
                    PalmSecure_ErrorMessage(stResult.errInfo);
                    return false;
                }
            }
            catch(PalmSecureException e)
            {
                MessageBox.Show(
                    e.Message
                    + "Error No: "  + e.ErrNumber
                    );
                return  false;
            }
            ///////////////////////////////////////////////////////////////////////////


            //Load module
            ///////////////////////////////////////////////////////////////////////////
            try
            {
                stResult.result = m_PalmSecureIf.DNET_BioAPI_ModuleLoad(ModuleGuid, 0, null, null);
                if (stResult.result != PalmSecureConstant.DNET_BioAPI_OK)
                {
                    m_PalmSecureIf.DNET_PvAPI_GetErrorInfo(stResult.errInfo);
                    PalmSecure_ErrorMessage(stResult.errInfo);
                    return false;
                }
            }
            catch(PalmSecureException e)
            {
                MessageBox.Show(
                    e.Message
                    + "Error No: "  + e.ErrNumber
                    );
                return  false;
            }
            ///////////////////////////////////////////////////////////////////////////


            //Get connected sensor information
            ///////////////////////////////////////////////////////////////////////////
            try
            {
                stResult.result = m_PalmSecureIf.DNET_PvAPI_GetConnectSensorInfoEx(
                    ref lpuiSensorNum,
                    lptSensorInfo
                    );
                if (stResult.result != PalmSecureConstant.DNET_BioAPI_OK)
                {
                    m_PalmSecureIf.DNET_PvAPI_GetErrorInfo(stResult.errInfo);
                    PalmSecure_ErrorMessage(stResult.errInfo);
                    return false;
                }
            }
            catch(PalmSecureException e)
            {
                MessageBox.Show(
                    e.Message
                    + "Error No: "  + e.ErrNumber
                    );
                return  false;
            }
            ///////////////////////////////////////////////////////////////////////////


            //Attatch to module
            ///////////////////////////////////////////////////////////////////////////
            try
            {
                stResult.result = m_PalmSecureIf.DNET_BioAPI_ModuleAttach(
                    ModuleGuid,
                    null,
                    null,
                    0,
                    0,
                    0,
                    0,
                    null,
                    0,
                    null,
                    ref m_ModuleHandle
                    );
                if (stResult.result != PalmSecureConstant.DNET_BioAPI_OK)
                {
                    m_PalmSecureIf.DNET_PvAPI_GetErrorInfo(stResult.errInfo);
                    PalmSecure_ErrorMessage(stResult.errInfo);
                    return false;
                }
            }
            catch(PalmSecureException e)
            {
                MessageBox.Show(
                    e.Message
                    + "Error No: "  + e.ErrNumber
                    );
                return  false;
            }
            ///////////////////////////////////////////////////////////////////////////


            //Set delegate methods
            ///////////////////////////////////////////////////////////////////////////
            try
            {
                stResult.result = m_PalmSecureIf.DNET_BioAPI_SetGUICallbacks(
                    m_ModuleHandle,
                    StreamingCallback,
                    this,
                    StateCallback,
                    this
                    );
                if (stResult.result != PalmSecureConstant.DNET_BioAPI_OK)
                {
                    m_PalmSecureIf.DNET_PvAPI_GetErrorInfo(stResult.errInfo);
                    PalmSecure_ErrorMessage(stResult.errInfo);
                    return false;
                }
            }
            catch (PalmSecureException e)
            {
                MessageBox.Show(
                    e.Message
                    + "Error No: " + e.ErrNumber
                    );
                return false;
            }
            ///////////////////////////////////////////////////////////////////////////


            //Get library information
            ///////////////////////////////////////////////////////////////////////////
            try
            {
                stResult.result = m_PalmSecureIf.DNET_PvAPI_GetLibraryInfo(lbInfo);
                if (stResult.result != PalmSecureConstant.DNET_BioAPI_OK)
                {
                    m_PalmSecureIf.DNET_PvAPI_GetErrorInfo(stResult.errInfo);
                    PalmSecure_ErrorMessage(stResult.errInfo);
                    return false;
                }
            }
            catch (PalmSecureException e)
            {
                MessageBox.Show(
                    e.Message
                    + "Error No: " + e.ErrNumber
                    );
                return false;
            }
            ///////////////////////////////////////////////////////////////////////////


            uiSensor = lptSensorInfo[0].uiSensor;
            sensorExtKind = lbInfo.uiSensorExtKind;
            guideMode = int.Parse(PsFileAccessor.g_clSetting.GuideMode);

            ulong dwParam1 = 0;
            if (guideMode == 1)
            {
                dwParam1 = PalmSecureConstant.DNET_PvAPI_PROFILE_GUIDE_MODE_GUIDE;
            }
            else
            {
                dwParam1 = PalmSecureConstant.DNET_PvAPI_PROFILE_GUIDE_MODE_NO_GUIDE;
            }


            //Set guide mode
            ///////////////////////////////////////////////////////////////////////////
            try
            {
                stResult.result = m_PalmSecureIf.DNET_PvAPI_SetProfile(
                    m_ModuleHandle,
                    PalmSecureConstant.DNET_PvAPI_PROFILE_GUIDE_MODE,
                    dwParam1,
                    0,
                    0
                    );

                if (stResult.result != PalmSecureConstant.DNET_BioAPI_OK)
                {
                    m_PalmSecureIf.DNET_PvAPI_GetErrorInfo(stResult.errInfo);
                    PalmSecure_ErrorMessage(stResult.errInfo);
                    return false;
                }
            }
            catch (PalmSecureException e)
            {
                MessageBox.Show(
                    e.Message
                    + "Error No: " + e.ErrNumber
                    );
                return false;
            }
            ///////////////////////////////////////////////////////////////////////////


            return true;
        }

        /// <summary>
        /// For finishing to use PalmSecure library,
        /// Detach and Unload PalmSecure library.
        /// </summary>
        void PalmSecure_FinishLibrary()
        {
            uint ret = PalmSecureConstant.DNET_BioAPI_ERRCODE_FUNCTION_FAILED;
            byte[] ModuleGuid = new byte[]{
                (byte)0xe1, (byte)0x9a, (byte)0x69, (byte)0x01,
                (byte)0xb8, (byte)0xc2, (byte)0x49, (byte)0x80,
                (byte)0x87, (byte)0x7e, (byte)0x11, (byte)0xd4,
                (byte)0xd8, (byte)0xf1, (byte)0xbe, (byte)0x79
                };


            //Detach module
            ///////////////////////////////////////////////////////////////////////////
            try
            {
                ret = m_PalmSecureIf.DNET_BioAPI_ModuleDetach(m_ModuleHandle);
            }
            catch(PalmSecureException e)
            {
            }
            ///////////////////////////////////////////////////////////////////////////


            //Unload module
            ///////////////////////////////////////////////////////////////////////////
            try
            {
                ret = m_PalmSecureIf.DNET_BioAPI_ModuleUnload(
                    ModuleGuid,
                    null,
                    null
                    );
            }
            catch(PalmSecureException e)
            {
            }
            ///////////////////////////////////////////////////////////////////////////

            return;
        }

        /// <summary>
        /// Reading the Guide file.
        /// </summary>
        void PalmSecure_ReadGuideBmp()
        {
            try
            {
                if (int.Parse(PsFileAccessor.g_clSetting.GuideMode) == 0)
                {
                    ImagePic.Image = new Bitmap("PalmSecure_GUIDELESS.BMP");
                }
                else
                {
                    ImagePic.Image = new Bitmap("PalmSecure_HANDGUIDE.BMP");
                }
            }
            catch
            {
                PalmSecure_ErrorMessage(PS_APP_EXCEPTION.PS_APPEX_GUIDEBMP_LOAD);
            }

            return;
        }

        /// <summary>
        /// Control initialization.
        /// </summary>
        void PalmSecure_InitControls()
        {
            if (InvokeRequired)
            {
                Invoke(new InitControlsDelegate(PalmSecure_InitControlsMain));
            }
            else
            {
                PalmSecure_InitControlsMain();
            }
            return;
        }

        /// <summary>
        /// Control initialization Main.
        /// </summary>
        void PalmSecure_InitControlsMain()
        {
            this.Text = PsFileAccessor.g_clLang.MainDialog.Title;

            ModeLabel.Text = m_PsFileAcsLang.PalmSecure_GetSensorName(PsDataManager.m_sensorType) + "  " + 
                m_PsFileAcsLang.Ps_Sample_Apl_CS_GetGuideModeName(int.Parse(PsFileAccessor.g_clSetting.GuideMode));
            ModeLabel.BackColor = Color.LightCyan;

            EnrollBtn.Text   = PsFileAccessor.g_clLang.MainDialog.EnrollBtn;
            DeleteBtn.Text   = PsFileAccessor.g_clLang.MainDialog.DeleteBtn;
            VerifyBtn.Text   = PsFileAccessor.g_clLang.MainDialog.VerifyBtn;
            IdentifyBtn.Text = PsFileAccessor.g_clLang.MainDialog.IdentifyBtn;
            CancelBtn.Text   = PsFileAccessor.g_clLang.MainDialog.CancelBtn;
            EndBtn.Text      = PsFileAccessor.g_clLang.MainDialog.ExitBtn;

            IDLabel.Text     = PsFileAccessor.g_clLang.MainDialog.IdLbl;
            ListLabel.Text   = PsFileAccessor.g_clLang.MainDialog.IdListLbl;
            IDNumLabel.Text  = PsFileAccessor.g_clLang.MainDialog.IdNumLbl;

            EnrollBtn.Enabled    = true;
            DeleteBtn.Enabled    = true;
            VerifyBtn.Enabled    = true;
            IdentifyBtn.Enabled  = true;
            CancelBtn.Enabled    = false;
            EndBtn.Enabled       = true;
            IDTextBox.Enabled    = true;
            IDNumTextBox.Enabled = true;
            
            return;
        }

        /// <summary>
        /// ID List initialization.
        /// </summary>
        void PalmSecure_InitIdList()
        {
            if (InvokeRequired)
            {
                Invoke(new InitListDelegate(PalmSecure_InitIdListMain));
            }else{
                PalmSecure_InitIdListMain();
            }
            
            return;
        }

        /// <summary>
        /// ID List initialization Main.
        /// </summary>
        void PalmSecure_InitIdListMain()
        {
            PalmSecure_ClearIdList();

            foreach (string sUserid in m_PsDataManager.UserList.Keys)
            {
                PalmSecure_SetIdList(sUserid);
            }
            IDNumTextBox.Text = m_PsDataManager.UserList.Count.ToString();

            return;
        }

        /// <summary>
        /// ID List Clear.
        /// </summary>
        void PalmSecure_ClearIdList()
        {
            IDListBox.Items.Clear();
            
            return;
        }

        /// <summary>
        /// Set the user ID to the list.
        /// </summary>
        /// <param name="sUserid">User ID</param>
        void PalmSecure_SetIdList(string sUserid)
        {
            IDListBox.Items.Add(sUserid);
            
            return;
        }
            

        /// <summary>
        ///  Process when streaming callback function is called.
        ///  This callback only show bitmap image.
        /// </summary>
        /// <param name="GuiStreamingCallbackCtx">Context set by BioAPI_SetGUICallback()</param>
        /// <param name="SampleBuffer">Silhouette image</param>
        /// <returns></returns>
        uint StreamingCallback(
            object GuiStreamingCallbackCtx,
            DNET_BioAPI_GUI_BITMAP Bitmap
        )
        {
            //Handle a guidance image
            ///////////////////////////////////////////////////////////////////////////
            MemoryStream silhouetteInfo = null;

            silhouetteInfo = new MemoryStream();
            silhouetteInfo.Write(
                Bitmap.Bitmap.Data,
                0,
                (int)Bitmap.Bitmap.Length
                );

            PalmSecure_ShowSilhouette(silhouetteInfo);

            silhouetteInfo.Dispose();
            ///////////////////////////////////////////////////////////////////////////

            return PalmSecureConstant.DNET_BioAPI_OK;
        }
        
        /// <summary>
        ///  Process when state callback function is called.
        /// </summary>
        /// <param name="GuiStateCallbackCtx">Context set by BioAPI_SetGUICallback()</param>
        /// <param name="GuiState">Notice kind</param>
        /// <param name="Response">Unused</param>
        /// <param name="Message">Message id when notice kind is guidance</param>
        /// <param name="Progress">Unused</param>
        /// <param name="SampleBuffer">Silhouette image, setted when notice kind is silhouette</param>
        /// <returns></returns>
        uint StateCallback(
            object GuiStateCallbackCtx,
            uint GuiState,
            ref byte Response,
            uint Message,
            byte Progress,
            DNET_BioAPI_GUI_BITMAP SampleBuffer
            )
        {

            //Handle a silhouette image
            ///////////////////////////////////////////////////////////////////////////
            if( (GuiState & PalmSecureConstant.DNET_BioAPI_SAMPLE_AVAILABLE) != 0)
            {
                if (m_SilhouetteInfo != null)
                {
                    m_SilhouetteInfo.Dispose();
                    m_SilhouetteInfo = null;
                }

                m_SilhouetteInfo = new MemoryStream();
                m_SilhouetteInfo.Write(
                    SampleBuffer.Bitmap.Data,
                    0,
                    (int)SampleBuffer.Bitmap.Length
                    );
                PalmSecure_ShowSilhouette(m_SilhouetteInfo);
                return PalmSecureConstant.DNET_BioAPI_OK;
            }
            ///////////////////////////////////////////////////////////////////////////


            //Handle a guidance message
            ///////////////////////////////////////////////////////////////////////////
            if ((GuiState & PalmSecureConstant.DNET_BioAPI_MESSAGE_PROVIDED) != 0)
            {
                //Get template quality.
                if ((Message & 0xff000000) == PalmSecureConstant.DNET_PvAPI_NOTIFY_REGIST_SCORE)
                {
                    m_NotifiedScore = Message & 0x0000000f;
                    return PalmSecureConstant.DNET_BioAPI_OK;
                }

                //Get number of capture.
                if ((Message & 0xffffff00) == PalmSecureConstant.DNET_PvAPI_NOTIFY_CAP_GUID_START)
                {
                    PsWindowMain localPvsWinMain = (PsWindowMain)GuiStateCallbackCtx;
                    if (localPvsWinMain.m_EnrollFlg == true)
                    {
                        PalmSecure_SetWorkMessage(
                            (int)PS_WRK_MESSAGE.PS_MESSAGE_ENROLL,
                            (int)(Message & 0x0000000f)
                            );
                    }
                    return PalmSecureConstant.DNET_BioAPI_OK;
                }

                //Get a guidance message
                string langKey = "";
                if (Message == PalmSecureConstant.DNET_PvAPI_NOTIFY_CAP_GUID_MOVING)
                {
                    langKey = PsFileAccessor.g_clLang.Guidance.NOTIFY_CAP_GUID_MOVING;
                }
                else if (Message == PalmSecureConstant.DNET_PvAPI_NOTIFY_CAP_GUID_NO_HANDS)
                {
                    langKey = PsFileAccessor.g_clLang.Guidance.NOTIFY_CAP_GUID_NO_HANDS;
                }
                else if (Message == PalmSecureConstant.DNET_PvAPI_NOTIFY_CAP_GUID_LESSINFO)
                {
                    langKey = PsFileAccessor.g_clLang.Guidance.NOTIFY_CAP_GUID_LESSINFO;
                }
                else if (Message == PalmSecureConstant.DNET_PvAPI_NOTIFY_CAP_GUID_FAR)
                {
                    langKey = PsFileAccessor.g_clLang.Guidance.NOTIFY_CAP_GUID_FAR;
                }
                else if (Message == PalmSecureConstant.DNET_PvAPI_NOTIFY_CAP_GUID_NEAR)
                {
                    langKey = PsFileAccessor.g_clLang.Guidance.NOTIFY_CAP_GUID_NEAR;
                }
                else if (Message == PalmSecureConstant.DNET_PvAPI_NOTIFY_CAP_GUID_CAPTURING)
                {
                    langKey = PsFileAccessor.g_clLang.Guidance.NOTIFY_CAP_GUID_CAPTURING;
                }
                else if (Message == PalmSecureConstant.DNET_PvAPI_NOTIFY_CAP_GUID_PHASE_END)
                {
                    langKey = PsFileAccessor.g_clLang.Guidance.NOTIFY_CAP_GUID_PHASE_END;
                }
                else if (Message == PalmSecureConstant.DNET_PvAPI_NOTIFY_CAP_GUID_RIGHT)
                {
                    langKey = PsFileAccessor.g_clLang.Guidance.NOTIFY_CAP_GUID_RIGHT;
                }
                else if (Message == PalmSecureConstant.DNET_PvAPI_NOTIFY_CAP_GUID_LEFT)
                {
                    langKey = PsFileAccessor.g_clLang.Guidance.NOTIFY_CAP_GUID_LEFT;
                }
                else if (Message == PalmSecureConstant.DNET_PvAPI_NOTIFY_CAP_GUID_DOWN)
                {
                    langKey = PsFileAccessor.g_clLang.Guidance.NOTIFY_CAP_GUID_DOWN;
                }
                else if (Message == PalmSecureConstant.DNET_PvAPI_NOTIFY_CAP_GUID_UP)
                {
                    langKey = PsFileAccessor.g_clLang.Guidance.NOTIFY_CAP_GUID_UP;
                }
                else if (Message == PalmSecureConstant.DNET_PvAPI_NOTIFY_CAP_GUID_PITCH_DOWN)
                {
                    langKey = PsFileAccessor.g_clLang.Guidance.NOTIFY_CAP_GUID_PITCH_DOWN;
                }
                else if (Message == PalmSecureConstant.DNET_PvAPI_NOTIFY_CAP_GUID_PITCH_UP)
                {
                    langKey = PsFileAccessor.g_clLang.Guidance.NOTIFY_CAP_GUID_PITCH_UP;
                }
                else if (Message == PalmSecureConstant.DNET_PvAPI_NOTIFY_CAP_GUID_ROLL_RIGHT)
                {
                    langKey = PsFileAccessor.g_clLang.Guidance.NOTIFY_CAP_GUID_ROLL_RIGHT;
                }
                else if (Message == PalmSecureConstant.DNET_PvAPI_NOTIFY_CAP_GUID_ROLL_LEFT)
                {
                    langKey = PsFileAccessor.g_clLang.Guidance.NOTIFY_CAP_GUID_ROLL_LEFT;
                }
                else if (Message == PalmSecureConstant.DNET_PvAPI_NOTIFY_CAP_GUID_YAW_RIGHT)
                {
                    langKey = PsFileAccessor.g_clLang.Guidance.NOTIFY_CAP_GUID_YAW_RIGHT;
                }
                else if (Message == PalmSecureConstant.DNET_PvAPI_NOTIFY_CAP_GUID_YAW_LEFT)
                {
                    langKey = PsFileAccessor.g_clLang.Guidance.NOTIFY_CAP_GUID_YAW_LEFT;
                }
                else if (Message == PalmSecureConstant.DNET_PvAPI_NOTIFY_CAP_GUID_ROUND)
                {
                    langKey = PsFileAccessor.g_clLang.Guidance.NOTIFY_CAP_GUID_ROUND;
                }
                else if (Message == PalmSecureConstant.DNET_PvAPI_NOTIFY_CAP_GUID_ADJUST_LIGHT)
                {
                    langKey = PsFileAccessor.g_clLang.Guidance.NOTIFY_CAP_GUID_ADJUST_LIGHT;
                }
                else if (Message == PalmSecureConstant.DNET_PvAPI_NOTIFY_CAP_GUID_ADJUST_NG)
                {
                    langKey = PsFileAccessor.g_clLang.Guidance.NOTIFY_CAP_GUID_ADJUST_NG;
                }
                else if (Message == PalmSecureConstant.DNET_PvAPI_NOTIFY_CAP_GUID_BADIMAGE)
                {
                    langKey = PsFileAccessor.g_clLang.Guidance.NOTIFY_CAP_GUID_BADIMAGE;
                }
                else
                {
                    return PalmSecureConstant.DNET_BioAPI_OK;
                }

                PalmSecure_SetGuidance(langKey, false);

            }
            ///////////////////////////////////////////////////////////////////////////


            return PalmSecureConstant.DNET_BioAPI_OK;
        }

        /// <summary>
        /// Display a silhouette image.
        /// </summary>
        /// <param name="buff">Silhouette image Data.</param>
        void PalmSecure_ShowSilhouette(MemoryStream buff)
        {
            System.Drawing.Image img = System.Drawing.Image.FromStream(buff);
            img.RotateFlip(RotateFlipType.RotateNoneFlipX);
            ImagePic.Image = img;
            return;
        }

        /// <summary>
        /// Press the Enroll button.
        /// </summary>
        /// <param name="sender">Event sender object</param>
        /// <param name="e">Event</param>
        private void EnrollBtn_Click(object sender, EventArgs e)
        {
            PalmSecure_SetWorkMessage((int)PS_WRK_MESSAGE.PS_MESSAGE_ENROLL_START);
            PalmSecure_SetGuidance("", false);
            PalmSecure_ReadGuideBmp();
            
            string userId = IDTextBox.Text.ToString();
            if (String.IsNullOrEmpty(userId) != false)
            {
                PalmSecure_SetGuidance(PsFileAccessor.g_clLang.Guidance.IllegalId, true);
                PalmSecure_SetWorkMessage("");
                return;
            }

            if (m_PsDataManager.PalmSecure_IsRegist(userId))
            {
                PalmSecure_SetGuidance(PsFileAccessor.g_clLang.Guidance.RegistId, true);
                PalmSecure_SetWorkMessage("");
                return;
            }

            if (m_PsDataManager.PalmSecure_GetRegistNum() >= PS_REGISTER_MAX)
            {
                PalmSecure_SetGuidance(PsFileAccessor.g_clLang.Guidance.MaxOver, true);
                PalmSecure_SetWorkMessage("");
                return;
            }

            m_CancelFlg = false;

            EnrollBtn.Enabled    = false;
            DeleteBtn.Enabled    = false;
            VerifyBtn.Enabled    = false;
            IdentifyBtn.Enabled  = false;
            CancelBtn.Enabled    = true;
            EndBtn.Enabled       = false;
            IDTextBox.Enabled    = false;
            IDNumTextBox.Enabled = false;

            THREAD_PARAM_TBL enrollParam = new THREAD_PARAM_TBL();
            enrollParam.userId = userId;
            enrollParam.dialog = this;
            
            PsThreadEnroll enrollthread = new PsThreadEnroll();
            enrollthread.PalmSecure_StartThread(
                new ParameterizedThreadStart(enrollthread.PalmSecure_ThreadProc),
                enrollParam
                );

            return;
        }

        /// <summary>
        /// Press the Delete button.
        /// </summary>
        /// <param name="sender">Event sender object</param>
        /// <param name="e">Event</param>
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            PalmSecure_SetWorkMessage((int)PS_WRK_MESSAGE.PS_MESSAGE_DELETE);
            PalmSecure_SetGuidance("", false);
            string userId = IDTextBox.Text;

            if (String.IsNullOrEmpty(userId))
            {
                PalmSecure_SetGuidance(PsFileAccessor.g_clLang.Guidance.IllegalId, true);
                PalmSecure_SetWorkMessage("");
                return;
            }

            if (!m_PsDataManager.PalmSecure_IsRegist(userId))
            {
                PalmSecure_SetGuidance(PsFileAccessor.g_clLang.Guidance.UnregistId, true);
                PalmSecure_SetWorkMessage("");
                return;
            }

            EnrollBtn.Enabled    = false;
            DeleteBtn.Enabled    = false;
            VerifyBtn.Enabled    = false;
            IdentifyBtn.Enabled  = false;
            CancelBtn.Enabled    = false;
            EndBtn.Enabled       = false;
            IDTextBox.Enabled    = false;
            IDNumTextBox.Enabled = false;

            DialogResult result = MessageBox.Show(PsFileAccessor.g_clLang.ConfirmMessage.Delete,
                "",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2
                );

            if (result != DialogResult.Yes)
            {
                PalmSecure_InitControls();
                PalmSecure_InitIdList();
                PalmSecure_SetWorkMessage("");
                return;
            }

            bool bRet = m_PsDataManager.PalmSecure_Delete(userId);
            if (bRet)
            {
                PalmSecure_SetGuidance(PsFileAccessor.g_clLang.CompleteMessage.Delete, false);
            }
            else
            {
                PalmSecure_ErrorMessage(PS_APP_EXCEPTION.PS_APPEX_FILE_DELETE);
            }

            PalmSecure_InitControls();
            PalmSecure_InitIdList();
            PalmSecure_SetWorkMessage("");

            return;
        }

        /// <summary>
        /// Press the Cancell button.
        /// </summary>
        /// <param name="sender">Event sender object</param>
        /// <param name="e">Event</param>
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            m_CancelFlg = true;

            THREAD_PARAM_TBL cancelParam = new THREAD_PARAM_TBL();
            cancelParam.userId = "";
            cancelParam.dialog = this;

            PsThreadCancel cancelthread = new PsThreadCancel();
            cancelthread.PalmSecure_StartThread(
                new ParameterizedThreadStart(cancelthread.PalmSecure_ThreadProc),
                cancelParam
                );

            return;
        }
        
        /// <summary>
        /// Press the Verify button.
        /// </summary>
        /// <param name="sender">Event sender object</param>
        /// <param name="e">Event</param>
        private void VerifyBtn_Click(object sender, EventArgs e)
        {
            PalmSecure_SetWorkMessage((int)PS_WRK_MESSAGE.PS_MESSAGE_VERIFY_START);
            PalmSecure_SetGuidance("", false);
            PalmSecure_ReadGuideBmp();

            string userId = IDTextBox.Text;

            if (String.IsNullOrEmpty(userId))
            {
                PalmSecure_SetGuidance(PsFileAccessor.g_clLang.Guidance.IllegalId, true);
                PalmSecure_SetWorkMessage("");
                return;
            }

            if (!m_PsDataManager.PalmSecure_IsRegist(userId))
            {
                PalmSecure_SetGuidance(PsFileAccessor.g_clLang.Guidance.UnregistId, true);
                PalmSecure_SetWorkMessage("");
                return;
            }

            m_CancelFlg = false;

            EnrollBtn.Enabled    = false;
            DeleteBtn.Enabled    = false;
            VerifyBtn.Enabled    = false;
            IdentifyBtn.Enabled  = false;
            CancelBtn.Enabled    = true;
            EndBtn.Enabled       = false;
            IDTextBox.Enabled    = false;
            IDNumTextBox.Enabled = false;

            THREAD_PARAM_TBL verifyParam = new THREAD_PARAM_TBL();

            verifyParam.userId = userId;
            verifyParam.dialog = this;

            PsThreadVerify verifythread = new PsThreadVerify();
            verifythread.PalmSecure_StartThread(
                new ParameterizedThreadStart(verifythread.PalmSecure_ThreadProc),
                verifyParam
                );

            return;
        }

        /// <summary>
        /// Press the Identify button.
        /// </summary>
        /// <param name="sender">Event sender object</param>
        /// <param name="e">Event</param>
        private void IdentifyBtn_Click(object sender, EventArgs e)
        {
            PalmSecure_SetWorkMessage((int)PS_WRK_MESSAGE.PS_MESSAGE_IDENTIFY_START);
            PalmSecure_SetGuidance("", false);

            if (m_PsDataManager.PalmSecure_GetRegistNum() <= 0)
            {
                PalmSecure_SetGuidance(PsFileAccessor.g_clLang.Guidance.Unregist, true);
                PalmSecure_SetWorkMessage("");
                return;
            }

            m_CancelFlg = false;

            EnrollBtn.Enabled    = false;
            DeleteBtn.Enabled    = false;
            VerifyBtn.Enabled    = false;
            IdentifyBtn.Enabled  = false;
            CancelBtn.Enabled    = true;
            EndBtn.Enabled       = false;
            IDTextBox.Enabled    = false;
            IDNumTextBox.Enabled = false;

            PalmSecure_ReadGuideBmp();

            THREAD_PARAM_TBL identifyParam = new THREAD_PARAM_TBL();
            identifyParam.userId = "";
            identifyParam.dialog = this;

            PsThreadIdentify Identifythread = new PsThreadIdentify();
            Identifythread.PalmSecure_StartThread(
                new ParameterizedThreadStart(Identifythread.PalmSecure_ThreadProc),
                identifyParam
                );

            return;
        }

        /// <summary>
        /// Press the End button.
        /// </summary>
        /// <param name="sender">Event sender object</param>
        /// <param name="e">Event</param>
        private void EndBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Result of enrollment process.
        /// </summary>
        /// <param name="stResult">Result information.</param>
        public void PalmSecure_EndEnroll(PS_THREAD_RESULT stResult, int enrollScore)
        {
            PsLogManager lm = new PsLogManager(this);
            PS_LOG_TBL tbl = new PS_LOG_TBL();
            tbl.result = false;

            //Show a guidance message.
            if (stResult.result != PalmSecureConstant.DNET_BioAPI_OK
                || stResult.authenticated == false
                || m_CancelFlg == true)
            {
                if (m_CancelFlg == true)
                {
                    PalmSecure_SetGuidance(PsFileAccessor.g_clLang.CompleteMessage.EnrollCancel, false);
                }
                else
                {
                    PalmSecure_SetGuidance(PsFileAccessor.g_clLang.CompleteMessage.EnrollNg, true);
                }
            }
            else
            {
                tbl.result = true;
                if (enrollScore > PalmSecureConstant.DNET_PvAPI_REGIST_SCORE_QUALITY_2
                    || stResult.farAchieved[0]  < 3000)
                {
                    PalmSecure_SetGuidance(PsFileAccessor.g_clLang.CompleteMessage.EnrollRetry, false);
                }
                else
                {
                    PalmSecure_SetGuidance(PsFileAccessor.g_clLang.CompleteMessage.EnrollOk, false);
                }
            }

            //Output a silhouette image
            if (int.Parse(PsFileAccessor.g_clSetting.SilhouetteMode) == 1
                && stResult.result == PalmSecureConstant.DNET_BioAPI_OK
                && stResult.info.data != null
                && m_CancelFlg != true)
            {
                stResult.info.subdir     = "Enroll";
                stResult.info.guideMode  = int.Parse(PsFileAccessor.g_clSetting.GuideMode);
                stResult.info.sensorType = PsDataManager.m_sensorType;
                tbl.silhouette = lm.PalmSecure_OutputSilhouette(stResult.info);
            }

            //Output log messages.
            if (int.Parse(PsFileAccessor.g_clSetting.LogMode) == 1
                && stResult.result == PalmSecureConstant.DNET_BioAPI_OK
                && m_CancelFlg != true)
            {
                tbl.authenticateMode = "E";
                tbl.retryNum         = stResult.retryCnt;
                tbl.guideMode        = int.Parse(PsFileAccessor.g_clSetting.GuideMode);
                tbl.sensorType       = PsDataManager.m_sensorType;

                if (stResult.userId.Count() >= 1)
                {
                    tbl.idList.Add(stResult.userId[0]);
                }

                if (stResult.farAchieved.Count() >= 1)
                {
                    tbl.farAchieved.Add(stResult.farAchieved[0]);
                }

                lm.Ps_Sample_Apl_CS_WriteLog(tbl);
            }
            
            //Reinitialize
            PalmSecure_InitControls();
            PalmSecure_InitIdList();
            PalmSecure_SetWorkMessage("");

            if (m_SilhouetteInfo != null)
            {
                m_SilhouetteInfo.Dispose();
                m_SilhouetteInfo = null;
            }

            if (stResult.info.data != null)
            {
                stResult.info.data.Dispose();
                stResult.info.data = null;
            }
            
            return;
        }

        /// <summary>
        /// Result of verification process.
        /// </summary>
        /// <param name="stResult">Result information.</param>
        public void PalmSecure_EndVerify(PS_THREAD_RESULT stResult)
        {
            PsLogManager lm = new PsLogManager(this);
            PS_LOG_TBL tbl = new PS_LOG_TBL();
            tbl.result = false;

            //Show a guidance message.
            try
            {
                System.Media.SoundPlayer player;

                if (stResult.result == PalmSecureConstant.DNET_BioAPI_OK
                    && stResult.authenticated == true
                    && m_CancelFlg != true)
                {
                    tbl.result = true;
                    player = new System.Media.SoundPlayer("PalmSecure_OK.wav");
                    player.Play();
                    PalmSecure_SetGuidance(PsFileAccessor.g_clLang.CompleteMessage.VerifyOk, false, stResult.userId[0]);
                }
                else
                {
                    if (m_CancelFlg == true)
                    {
                        PalmSecure_SetGuidance(PsFileAccessor.g_clLang.CompleteMessage.VerifyCancel, false, stResult.userId[0]);
                    }
                    else
                    {
                        player = new System.Media.SoundPlayer("PalmSecure_NG.wav");
                        player.Play();
                        PalmSecure_SetGuidance(PsFileAccessor.g_clLang.CompleteMessage.VerifyNg, true, stResult.userId[0]);
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Error SoundPlayer");
            }

            //Output a silhouette image
            if (int.Parse(PsFileAccessor.g_clSetting.SilhouetteMode) == 1
                && stResult.result == PalmSecureConstant.DNET_BioAPI_OK
                && stResult.info.data != null
                && m_CancelFlg != true)
            {
                stResult.info.subdir     = "Match";
                stResult.info.guideMode  = int.Parse(PsFileAccessor.g_clSetting.GuideMode);
                stResult.info.sensorType = PsDataManager.m_sensorType;
                tbl.silhouette = lm.PalmSecure_OutputSilhouette(stResult.info);
            }

            //Output log messages.
            if (int.Parse(PsFileAccessor.g_clSetting.LogMode) == 1
                && stResult.result == PalmSecureConstant.DNET_BioAPI_OK
                && m_CancelFlg != true)
            {
                tbl.authenticateMode = "V";
                tbl.retryNum         = stResult.retryCnt;
                tbl.guideMode        = int.Parse(PsFileAccessor.g_clSetting.GuideMode);
                tbl.sensorType       = PsDataManager.m_sensorType;

                if (stResult.userId.Count() >= 1)
                {
                    tbl.idList.Add(stResult.userId[0]);
                }

                if (stResult.farAchieved.Count() >= 1)
                {
                    tbl.farAchieved.Add(stResult.farAchieved[0]);
                }

                lm.Ps_Sample_Apl_CS_WriteLog(tbl);
            }

            //Reinitialize
            PalmSecure_InitControls();
            PalmSecure_InitIdList();
            PalmSecure_SetWorkMessage("");

            if (m_SilhouetteInfo != null)
            {
                m_SilhouetteInfo.Dispose();
                m_SilhouetteInfo = null;
            }

            if (stResult.info.data != null)
            {
                stResult.info.data.Dispose();
                stResult.info.data = null;
            }

            return;
        }

        /// <summary>
        /// Result of identification process.
        /// </summary>
        /// <param name="stResult">Result information</param>
        public void PalmSecure_EndIdentify(PS_THREAD_RESULT stResult)
        {
            PsLogManager lm = new PsLogManager(this);
            PS_LOG_TBL tbl = new PS_LOG_TBL();
            tbl.result = false;

            //Show a guidance message.
            try 
            {
                System.Media.SoundPlayer player;

                if (stResult.result == PalmSecureConstant.DNET_BioAPI_OK
                    && stResult.farAchieved.Count() > 0
                    && stResult.authenticated == true
                    && m_CancelFlg != true)
                {
                    tbl.result = true;
                    player = new System.Media.SoundPlayer("PalmSecure_OK.wav");
                    player.Play();
                    PalmSecure_SetGuidance(PsFileAccessor.g_clLang.CompleteMessage.IdentifyOk, false, stResult.userId[0]);
                }
                else
                {
                    if (m_CancelFlg == true)
                    {
                        PalmSecure_SetGuidance(PsFileAccessor.g_clLang.CompleteMessage.IdentifyCancel, false, "");
                    }
                    else
                    {
                        player = new System.Media.SoundPlayer("PalmSecure_NG.wav");
                        player.Play();
                        PalmSecure_SetGuidance(PsFileAccessor.g_clLang.CompleteMessage.IdentifyNg, true, "");
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Error SoundPlayer");
            }

            //Output a silhouette image
            if (int.Parse(PsFileAccessor.g_clSetting.SilhouetteMode) == 1
                && stResult.result == PalmSecureConstant.DNET_BioAPI_OK
                && stResult.info.data != null
                && m_CancelFlg != true)
            {
                stResult.info.subdir     = "Match";
                stResult.info.guideMode  = int.Parse(PsFileAccessor.g_clSetting.GuideMode);
                stResult.info.sensorType = PsDataManager.m_sensorType;
                tbl.silhouette = lm.PalmSecure_OutputSilhouette(stResult.info);
            }

            //Output log messages.
            if (int.Parse(PsFileAccessor.g_clSetting.LogMode) == 1
                && stResult.result == PalmSecureConstant.DNET_BioAPI_OK
                && m_CancelFlg != true)
            {
                tbl.authenticateMode = "I";
                tbl.retryNum         = stResult.retryCnt;
                tbl.guideMode        = int.Parse(PsFileAccessor.g_clSetting.GuideMode);
                tbl.sensorType       = PsDataManager.m_sensorType;

                for (int i = 0; i < stResult.userId.Count(); i++)
                {
                    tbl.idList.Add(stResult.userId[i]);
                }

                for (int i = 0; i < stResult.farAchieved.Count(); i++)
                {
                    tbl.farAchieved.Add(stResult.farAchieved[i]);
                }

                lm.Ps_Sample_Apl_CS_WriteLog(tbl);
            }

            //Reinitialize
            PalmSecure_InitControls();
            PalmSecure_InitIdList();
            PalmSecure_SetWorkMessage("");

            if (m_SilhouetteInfo != null)
            {
                m_SilhouetteInfo.Dispose();
                m_SilhouetteInfo = null;
            }

            if (stResult.info.data != null)
            {
                stResult.info.data.Dispose();
                stResult.info.data = null;
            }

            return;
        }

        /// <summary>
        /// Guidance display process.
        /// </summary>
        /// <param name="msg">Message</param>
        /// <param name="bErr">Error Flag</param>
        /// <param name="userId">User ID</param>
        public void PalmSecure_SetGuidance(string msg, bool bErr = false, string userId = null)
        {
            if (InvokeRequired)
            {
                Invoke(new SetGuidanceDelegate(PalmSecure_SetGuidanceMain), msg, bErr, userId);
            }
            else
            {
                PalmSecure_SetGuidanceMain(msg, bErr, userId);
            }
            
            return;
        }

        /// <summary>
        /// Guidance display process.(Main)
        /// </summary>
        /// <param name="msg">Message</param>
        /// <param name="bErr">Error Flag</param>
        /// <param name="userId">User ID</param>
        void PalmSecure_SetGuidanceMain(string msg, bool bErr, string userId)
        {
            if (bErr)
            {
                GuidanceLabel.ForeColor = Color.Red;
            }
            else
            {
                GuidanceLabel.ForeColor = Color.Blue;
            }
            if (msg.IndexOf("{0}") != -1)
            {
                msg = String.Format(msg, userId);
            }
            GuidanceLabel.Text = msg.Replace("\\r\\n","\r\n");
            
            return;
        }

        /// <summary>
        /// WorkMessage display process.
        /// </summary>
        /// <param name="workid">Message id</param>
        /// <param name="count">Parameter</param>
        public void PalmSecure_SetWorkMessage(int workid, int count = 0)
        {
            if (InvokeRequired)
            {
                Invoke(new SetWorkMsgDelegateId(PalmSecure_WorkMessage), workid, count);
            }
            else
            {
                PalmSecure_WorkMessage(workid, count);
            }
            
            return;
        }

        /// <summary>
        /// WorkMessage display process.
        /// </summary>
        /// <param name="msg">Message</param>
        public void PalmSecure_SetWorkMessage(string msg)
        {
            if (InvokeRequired)
            {
                Invoke(new SetWorkMsgDelegateMsg(PalmSecure_WorkMessage), msg);
            }
            else
            {
                PalmSecure_WorkMessage(msg);
            }
            
            return;
        }

        /// <summary>
        /// WorkMessage display process.
        /// </summary>
        /// <param name="workid">Message id</param>
        /// <param name="count">Parameter</param>
        void PalmSecure_WorkMessage(int workid, int count)
        {
            string msg;
            msg = m_PsFileAcsLang.PalmSecure_GetWorkMessage((PS_WRK_MESSAGE)workid);
            if (!String.IsNullOrEmpty(msg))
            {
                switch ((PS_WRK_MESSAGE)workid)
                {
                    case PS_WRK_MESSAGE.PS_MESSAGE_ENROLL:
                    case PS_WRK_MESSAGE.PS_MESSAGE_IDENTIFY:
                    case PS_WRK_MESSAGE.PS_MESSAGE_VERIFY:
                    case PS_WRK_MESSAGE.PS_MESSAGE_ENROLL_TEST:
                        if (msg.IndexOf("{0}") != -1)
                        {
                            msg = String.Format(msg, count);
                        }
                        break;
                }
                PalmSecure_WorkMessage(msg);
            }
            
            return;
        }

        /// <summary>
        /// WorkMessage display process.
        /// </summary>
        /// <param name="msg">Message</param>
        void PalmSecure_WorkMessage(string msg)
        {
            if (String.IsNullOrEmpty(msg))
            {
                WorkMsgLabel.BackColor = Color.White;
            }
            else
            {
                WorkMsgLabel.BackColor = Color.Green;
            }
            WorkMsgLabel.Text = msg;
            
            return;
        }

        /// <summary>
        /// ErrorMessage display process.
        /// </summary>
        /// <param name="ex">Error Info</param>
        public void PalmSecure_ErrorMessage(PS_APP_EXCEPTION ex)
        {

            string msg = String.Format(
                    "{0}\n　{1} ",
                    m_PsFileAcsLang.PalmSecure_GetSampleErrorTitle(),
                    m_PsFileAcsLang.PalmSecure_GetSampleErrorMsg(ex)
                    );
            MessageBox.Show(msg);
            
            return;
        }

        /// <summary>
        /// ErrorMessage display process.
        /// </summary>
        /// <param name="errcode">Error Code</param>
        public void PalmSecure_ErrorMessage(int errcode)
        {

            string msg = String.Format("{0}\n　{1}({2}) ",
                    m_PsFileAcsLang.PalmSecure_GetSampleErrorTitle(),
                    m_PsFileAcsLang.PalmSecure_GetSampleErrorMsg(PS_APP_EXCEPTION.PS_APPEX_SYSTEM_ERROR),
                    errcode
                    );
            msg = msg.Replace("\\r\\n", "\r\n");
            MessageBox.Show(msg);
            Application.Exit();
        }
        
        /// <summary>
        /// ErrorMessage display process.
        /// </summary>
        /// <param name="inf">Error Info</param>
        public void PalmSecure_ErrorMessage(DNET_PvAPI_ErrorInfo inf)
        {
            string msg = String.Format(
                "{0}\n{1}:0x{2:X8}\n{3}:0x{4:X8}\n{5}:0x{6:X8}\n",
                m_PsFileAcsLang.PalmSecure_GetApiErrorTitle(),
                m_PsFileAcsLang.PalmSecure_GetApiErrorLevel(),
                inf.ErrorLevel,
                m_PsFileAcsLang.PalmSecure_GetApiErrorCode(),
                inf.ErrorCode,
                m_PsFileAcsLang.PalmSecure_GetApiErrorDetail(),
                inf.ErrorDetail
                );
            string msg2 = String.Format(
                "ErrorInfo1   :0x{0:X8}\nErrorInfo2   :0x{1:X8}\n",
                inf.ErrorInfo1,
                inf.ErrorInfo2
                );
            if (inf.ErrorInfo3 != null)
            {
                string buf = String.Format(
                    "ErrorInfo3[0]:0x{0:X8}\nErrorInfo3[1]:0x{1:X8}\nErrorInfo3[2]:0x{2:X8}\nErrorInfo3[3]:0x{3:X8}",
                    inf.ErrorInfo3[0],
                    inf.ErrorInfo3[1],
                    inf.ErrorInfo3[2],
                    inf.ErrorInfo3[3]
                    );
                msg2 += buf;
            }
            MessageBox.Show(msg+msg2);

            return;
        }

        /// <summary>
        /// Processing when the text has been changed.
        /// </summary>
        /// <param name="sender">Event sender object</param>
        /// <param name="e">Event</param>
        private void IDTextBox_TextChanged(object sender, EventArgs e)
        {
            System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex("[^A-Za-z0-9_\\-]");
            IDTextBox.Text = r.Replace(IDTextBox.Text,"");
            IDTextBox.SelectionStart = IDTextBox.Text.Length;
            return;
        }

        /// <summary>
        /// Called by changing selected item in id list, and set selected item
        /// to id text box.
        /// </summary>
        /// <param name="sender">Event sender object</param>
        /// <param name="e">Event</param>
        private void IDListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IDListBox.SelectedIndex < 0)
            {
                IDTextBox.Text = "";
                return;
            }
            IDTextBox.Text = IDListBox.SelectedItem.ToString();
            return;
        }
    }
}
