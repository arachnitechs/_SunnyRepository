
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;

namespace PalmSecure
{
    public class PsFileAccessorLang
    {
        public const string PS_FILENAME = "PalmSecure.lang";

        /// <summary>
        /// Read the language information definition file
        /// </summary>
        public void PalmSecure_Read(string rootPath)
        {
            PsFileAccessor psFacs = new PsFileAccessor();
            psFacs.PalmSecure_ReadLang(rootPath+"PalmSecure.lang");
            return;
        }

        /// <summary>
        /// Get a displayed string.
        /// </summary>
        /// <param name="iGuid">Message ID</param>
        /// <returns>message</returns>
        public string PalmSecure_GetWorkMessage(PS_WRK_MESSAGE iGuid)
        {
            string data;

            switch(iGuid)
            {
                case PS_WRK_MESSAGE.PS_MESSAGE_ENROLL_START:
                    data = PsFileAccessor.g_clLang.Guidance.WorkEnrollStart;
                    break;
                case PS_WRK_MESSAGE.PS_MESSAGE_ENROLL:
                    data = PsFileAccessor.g_clLang.Guidance.WorkEnroll;
                    break;
                case PS_WRK_MESSAGE.PS_MESSAGE_ENROLL_TEST:
                    data = PsFileAccessor.g_clLang.Guidance.WorkEnrollTest;
                    break;
                case PS_WRK_MESSAGE.PS_MESSAGE_IDENTIFY_START:
                    data = PsFileAccessor.g_clLang.Guidance.WorkIdentifyStart;
                    break;
                case PS_WRK_MESSAGE.PS_MESSAGE_IDENTIFY:
                    data = PsFileAccessor.g_clLang.Guidance.WorkIdentify;
                    break;
                case PS_WRK_MESSAGE.PS_MESSAGE_VERIFY_START:
                    data = PsFileAccessor.g_clLang.Guidance.WorkVerifyStart;
                    break;
                case PS_WRK_MESSAGE.PS_MESSAGE_VERIFY:
                    data = PsFileAccessor.g_clLang.Guidance.WorkVerify;
                    break;
                case PS_WRK_MESSAGE.PS_MESSAGE_DELETE:
                    data = PsFileAccessor.g_clLang.Guidance.WorkDelete;
                    break;
                default:
                    return "";
            }
            data = data.Replace("\\r\\n", "\r\n");

            return data;
        }

        /// <summary>
        /// Obtain the name of the sensor.
        /// </summary>
        /// <param name="sensorType">Sensor Type</param>
        /// <returns>Sensor name</returns>
        public string PalmSecure_GetSensorName(int sensorType)
        {
            string data;

            switch (sensorType)
            {
                case 0:
                    data = PsFileAccessor.g_clLang.MainDialog.SensorName0;
                    break;
                case 1:
                    data = PsFileAccessor.g_clLang.MainDialog.SensorName1;
                    break;
                case 2:
                    data = PsFileAccessor.g_clLang.MainDialog.SensorName2;
                    break;
                case 3:
                    data = PsFileAccessor.g_clLang.MainDialog.SensorName3;
                    break;
                case 4:
                    data = PsFileAccessor.g_clLang.MainDialog.SensorName4;
                    break;
                case 5:
                    data = PsFileAccessor.g_clLang.MainDialog.SensorName5;
                    break;
                default:
                    data = "";
                    break;
            }

            return data;
        }

        /// <summary>
        /// Obtain the name of guide mode.
        /// </summary>
        /// <param name="guideMode">guide mode</param>
        /// <returns>guide mode name</returns>
        public string PalmSecure_GetGuideModeName(int guideMode)
        {
            string data;

            switch (guideMode)
            {
                case 0:
                    data = PsFileAccessor.g_clLang.MainDialog.GuideMode0;
                    break;
                case 1:
                    data = PsFileAccessor.g_clLang.MainDialog.GuideMode1;
                    break;
                default:
                    data = "";
                    break;
            }

            return data;
        }

        /// <summary>
        /// Gets the title of the sample error
        /// </summary>
        /// <returns>title</returns>
        public string PalmSecure_GetSampleErrorTitle()
        {
            return PsFileAccessor.g_clLang.ErrorMessage.AplErrorTitle;
        }

        /// <summary>
        /// Getting the error message
        /// </summary>
        /// <param name="ex">Message ID</param>
        /// <returns>Error Message</returns>
        public string PalmSecure_GetSampleErrorMsg(PS_APP_EXCEPTION ex)
        {
            string data;

            switch(ex)
            {
                case PS_APP_EXCEPTION.PS_APPEX_BMP_SAVE:
                    data = PsFileAccessor.g_clLang.ErrorMessage.AplErrorBmpSave;
                    break;
                case PS_APP_EXCEPTION.PS_APPEX_BMPDIR_OPEN:
                    data = PsFileAccessor.g_clLang.ErrorMessage.AplErrorBmpDirOpen;
                    break;
                case PS_APP_EXCEPTION.PS_APPEX_LOGDIR_OPEN:
                    data = PsFileAccessor.g_clLang.ErrorMessage.AplErrorLogDirOpen;
                    break;
                case PS_APP_EXCEPTION.PS_APPEX_LOGFILE_OPEN:
                    data = PsFileAccessor.g_clLang.ErrorMessage.AplErrorLogFileOpen;
                    break;
                case PS_APP_EXCEPTION.PS_APPEX_LOGFILE_WRITE:
                    data = PsFileAccessor.g_clLang.ErrorMessage.AplErrorLogFileWrite;
                    break;
                case PS_APP_EXCEPTION.PS_APPEX_FILEDIR_OPEN:
                    data = PsFileAccessor.g_clLang.ErrorMessage.AplErrorFileDirOpen;
                    break;
                case PS_APP_EXCEPTION.PS_APPEX_FILE_OPEN:
                    data = PsFileAccessor.g_clLang.ErrorMessage.AplErrorFileOpen;
                    break;
                case PS_APP_EXCEPTION.PS_APPEX_FILE_WRITE:
                    data = PsFileAccessor.g_clLang.ErrorMessage.AplErrorFileWrite;
                    break;
                case PS_APP_EXCEPTION.PS_APPEX_FILE_DELETE:
                    data = PsFileAccessor.g_clLang.ErrorMessage.AplErrorFileDelete;
                    break;
                case PS_APP_EXCEPTION.PS_APPEX_FILE_NOTFOUND:
                    data = PsFileAccessor.g_clLang.ErrorMessage.AplErrorDataFileNotFound;
                    break;
                case PS_APP_EXCEPTION.PS_APPEX_NODATA_FOUND:
                    data = PsFileAccessor.g_clLang.ErrorMessage.AplErrorNoData;
                    break;
                case PS_APP_EXCEPTION.PS_APPEX_GUIDEBMP_LOAD:
                    data = PsFileAccessor.g_clLang.ErrorMessage.AplErrorGuideBmpLoad;
                    break;
                case PS_APP_EXCEPTION.PS_APPEX_SILHOUETTE_LOAD:
                    data = PsFileAccessor.g_clLang.ErrorMessage.AplErrorsilhouetteLoad;
                    break;
                case PS_APP_EXCEPTION.PS_APPEX_SYSTEM_ERROR:
                    data = PsFileAccessor.g_clLang.ErrorMessage.AplErrorSystemError;
                    break;
                default:
                    data = "";
                    break;
            }
            data = data.Replace("\\r\\n", "\r\n");

            return data;
        }

        /// <summary>
        /// Gets the title of the API error
        /// </summary>
        /// <returns>title</returns>
        public string PalmSecure_GetApiErrorTitle()
        {
            return PsFileAccessor.g_clLang.ErrorMessage.LibErrorTitle;
        }

        /// <summary>
        /// Gets the level of the API error
        /// </summary>
        /// <returns>Item Name</returns>
        public string PalmSecure_GetApiErrorLevel()
        {
            return PsFileAccessor.g_clLang.ErrorMessage.LibErrorLevel;
        }

        /// <summary>
        /// Gets the ErrorCode of the API error
        /// </summary>
        /// <returns>Item Name</returns>
        public string PalmSecure_GetApiErrorCode()
        {
            return PsFileAccessor.g_clLang.ErrorMessage.LibErrorCode;
        }

        /// <summary>
        /// Gets the Detail of the API error
        /// </summary>
        /// <returns>Item Name</returns>
        public string PalmSecure_GetApiErrorDetail()
        {
            return PsFileAccessor.g_clLang.ErrorMessage.LibErrorDetail;
        }
    }
}
