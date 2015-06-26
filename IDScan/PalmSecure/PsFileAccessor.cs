

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Specialized;
using System.Runtime.InteropServices;

namespace PalmSecure
{
    public class LangData
    {
        public MainDialogData      MainDialog      = new MainDialogData();
        public GuidanceData        Guidance        = new GuidanceData();
        public CompleteMessageData CompleteMessage = new CompleteMessageData();
        public ConfirmMessageData  ConfirmMessage  = new ConfirmMessageData();
        public ErrorMessageData    ErrorMessage    = new ErrorMessageData();
    }

    public class MainDialogData
    {
        public string Title       = "";
        public string EnrollBtn   = "";
        public string VerifyBtn   = "";
        public string IdentifyBtn = "";
        public string CancelBtn   = "";
        public string DeleteBtn   = "";
        public string ExitBtn     = "";
        public string IdLbl       = "";
        public string IdListLbl   = "";
        public string IdNumLbl    = "";
        public string SensorName0 = "";
        public string SensorName1 = "";
        public string SensorName2 = "";
        public string SensorName3 = "";
        public string SensorName4 = "";
        public string SensorName5 = "";
        public string SensorName1_Compati = "";
        public string SensorName1_Extend = "";
        public string GuideMode0 = "";
        public string GuideMode1  = "";
    }

    public class GuidanceData
    {
        public string NOTIFY_CAP_GUID_BADIMAGE     = "";
        public string NOTIFY_CAP_GUID_MOVING       = "";
        public string NOTIFY_CAP_GUID_LESSINFO     = "";
        public string NOTIFY_CAP_GUID_RIGHT        = "";
        public string NOTIFY_CAP_GUID_LEFT         = "";
        public string NOTIFY_CAP_GUID_DOWN         = "";
        public string NOTIFY_CAP_GUID_UP           = "";
        public string NOTIFY_CAP_GUID_FAR          = "";
        public string NOTIFY_CAP_GUID_NEAR         = "";
        public string NOTIFY_CAP_GUID_CAPTURING    = "";
        public string NOTIFY_CAP_GUID_PITCH_DOWN   = "";
        public string NOTIFY_CAP_GUID_PITCH_UP     = "";
        public string NOTIFY_CAP_GUID_ROLL_RIGHT   = "";
        public string NOTIFY_CAP_GUID_ROLL_LEFT    = "";
        public string NOTIFY_CAP_GUID_YAW_RIGHT    = "";
        public string NOTIFY_CAP_GUID_YAW_LEFT     = "";
        public string NOTIFY_CAP_GUID_ADJUST_LIGHT = "";
        public string NOTIFY_CAP_GUID_ADJUST_NG    = "";
        public string NOTIFY_CAP_GUID_PHASE_END    = "";
        public string NOTIFY_CAP_GUID_NO_HANDS     = "";
        public string NOTIFY_CAP_GUID_ROUND        = "";
        public string NOTIFY_CAP_GUID_START        = "";

        public string IllegalId           = "";
        public string RegistId            = "";
        public string MaxOver             = "";
        public string AdminMaxOver        = "";
        public string SelectId            = "";
        public string Unregist            = "";
        public string UnregistId          = "";
        public string RetryTransaction    = "";
        public string EnrollmentTest = "";

        public string WorkEnrollStart   = "";
        public string WorkEnroll        = "";
        public string WorkEnrollSL      = "";
        public string WorkEnrollTest    = "";
        public string WorkIdentifyStart = "";
        public string WorkIdentify      = "";
        public string WorkVerify        = "";
        public string WorkVerifyStart   = "";
        public string WorkDelete        = "";
    }

    public class CompleteMessageData
    {
        public string EnrollOk       = "";
        public string EnrollNg       = "";
        public string EnrollRetry    = "";
        public string Delete         = "";
        public string VerifyOk       = "";
        public string VerifyNg       = "";
        public string IdentifyOk     = "";
        public string IdentifyNg     = "";
        public string EnrollCancel   = "";
        public string VerifyCancel   = "";
        public string IdentifyCancel = "";
    }

    public class ConfirmMessageData
    {
        public string Delete = "";
    }

    public class ErrorMessageData
    {
        public string LibErrorTitle            = "";
        public string LibErrorLevel            = "";
        public string LibErrorCode             = "";
        public string LibErrorDetail           = "";
        public string AplErrorTitle            = "";
        public string AplErrorBmpSave          = "";
        public string AplErrorBmpDirOpen       = "";
        public string AplErrorLogDirOpen       = "";
        public string AplErrorLogFileOpen      = "";
        public string AplErrorLogFileWrite     = "";
        public string AplErrorFileDirOpen      = "";
        public string AplErrorFileOpen         = "";
        public string AplErrorFileWrite        = "";
        public string AplErrorFileDelete       = "";
        public string AplErrorDataFileNotFound = "";
        public string AplErrorNoData           = "";
        public string AplErrorGuideBmpLoad     = "";
        public string AplErrorsilhouetteLoad   = "";
        public string AplErrorSystemError      = "";
    }

    public class SettingData
    {
        public string GuideMode      = "0";
        public string MaxResults     = "2";
        public string NumberOfRetry  = "2";
        public string LogMode        = "1";
        public string LogFolderPath  = "Log";
        public string SilhouetteMode = "1";
        public string SleepTime      = "2000";
    }

    class PsFileAccessor
    {
        public static LangData g_clLang;
        public static SettingData g_clSetting;

        /// <summary>
        /// Read "PalmSecureSample.lang" file
        /// </summary>
        /// <param name="strFileName">FileName</param>
        public void PalmSecure_ReadLang(string strFileName)
        {

            //Create XmlSerializer Object
            System.Xml.Serialization.XmlSerializer serializer =
                new System.Xml.Serialization.XmlSerializer(typeof(LangData));

            System.IO.FileStream fs = null;

            try
            {
                //File Open
                fs = new System.IO.FileStream(
                    strFileName, System.IO.FileMode.Open
                    );

                //Deserialize
                g_clLang = (LangData)serializer.Deserialize(fs);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Dispose();
                }
            }

            return;
        }

        /// <summary>
        /// Read "PalmSecureSample.ini" file.
        /// </summary>
        /// <param name="strFileName">FileName</param>
        public void PalmSecure_ReadIni(string strFileName)
        {
            g_clSetting = new SettingData();

            //Create XmlSerializer Object
            System.Xml.Serialization.XmlSerializer serializer =
                new System.Xml.Serialization.XmlSerializer(typeof(SettingData));

            System.IO.FileStream fs = null;
            SettingData w = null;

            try
            {
                //File Open
                fs = new System.IO.FileStream(strFileName, System.IO.FileMode.Open);

                //Deserialize
                w = (SettingData)serializer.Deserialize(fs);

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Dispose();
                }
            }
    
            if (w.GuideMode != null && w.GuideMode != ""
                && 0 <= int.Parse(w.GuideMode)
                && int.Parse(w.GuideMode) <= 1)
            {
                g_clSetting.GuideMode = w.GuideMode;
            }
            if (w.MaxResults != null && w.MaxResults != ""
                && 0 < int.Parse(w.MaxResults)
                && int.Parse(w.MaxResults) < 31)
            {
                g_clSetting.MaxResults = w.MaxResults;
            }
            if (w.NumberOfRetry != null && w.NumberOfRetry != ""
                && 0 <= int.Parse(w.NumberOfRetry))
            {
                g_clSetting.NumberOfRetry = w.NumberOfRetry;
            }
            if (w.LogMode != null && w.LogMode != ""
                && 0 <= int.Parse(w.LogMode)
                && int.Parse(w.LogMode) <= 1)
            {
                g_clSetting.LogMode = w.LogMode;
            }
            if (w.LogFolderPath != null && w.LogFolderPath != "" )
            {
                g_clSetting.LogFolderPath = w.LogFolderPath;
            }
            if (w.SilhouetteMode != null && w.SilhouetteMode != ""
                && 0 <= int.Parse(w.SilhouetteMode)
                && int.Parse(w.SilhouetteMode) <= 1)
            {
                g_clSetting.SilhouetteMode = w.SilhouetteMode;
            }
            if (w.SleepTime != null && w.SleepTime != ""
                && 0 <= int.Parse(w.SleepTime))
            {
                g_clSetting.SleepTime = w.SleepTime;
            }

            return;
        }
    }
}
