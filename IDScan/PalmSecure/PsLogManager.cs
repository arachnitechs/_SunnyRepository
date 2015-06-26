/*
 *  PsLogManager.cs
 *  Description:
 *      Management log information and silhouette data. 
 *
 *  History:
 *      NO  Date        Version     Updated by              Content of change
 *      1   2012/11     V02L02      FUJITSU FRONTECH        Newly created.
 *
 *      All Rights Reserved, Copyright(c) FUJITSU FRONTECH LIMITED 2012
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace PalmSecure
{
    public class PS_SILHOUETTE_TBL
    {
        public MemoryStream data;
        public int sensorType;
        public int guideMode;
        public string subdir;

        public PS_SILHOUETTE_TBL()
        {
            data       = null;
            sensorType = 0;
            guideMode  = 0;
            subdir     = "";
        }
    }

    public class PS_LOG_TBL
    {
        public string silhouette;
        public int sensorType;
        public int guideMode;
        public string authenticateMode;
        public bool result;
        public int retryNum;
        public List<string> idList;
        public List<int> farAchieved;

        public PS_LOG_TBL()
        {
            silhouette = "";
            sensorType = 0;
            guideMode = 0;
            authenticateMode = "";
            result = false;
            retryNum = 0;
            idList = new List<string>();
            farAchieved = new List<int>();
        }
    }

    class PsLogManager
    {
        PalmSecure.psWindowMain m_main;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="main">PsWindowMain handle</param>
        public PsLogManager(PalmSecure.psWindowMain main)
        {
            m_main = main;
        }

        /// <summary>
        /// Silhouette data output.
        /// </summary>
        /// <param name="stInfo">Silhouette table</param>
        /// <returns>File Name</returns>
        public string PalmSecure_OutputSilhouette(PS_SILHOUETTE_TBL stInfo)
        {
            DateTime now = DateTime.Now;

            PsFileAccessorIni ini = new PsFileAccessorIni();

            string logFolder = ini.PalmSecure_GetLogInfoSilhouetteFolder();

            string logPath = string.Format(@"{0}\{1}\{2}\", m_main.m_ModulePath, logFolder, stInfo.subdir);

            if (!Directory.Exists(logPath))
            {
                try
                {
                    Directory.CreateDirectory(logPath);
                }
                catch (Exception)
                {
                    m_main.PalmSecure_ErrorMessage(PS_APP_EXCEPTION.PS_APPEX_BMPDIR_OPEN);
                }
            }

            string fileName = string.Format(
                "{0}{1}_{2}.bmp", stInfo.sensorType, stInfo.guideMode, now.ToString("yyyyMMddHHmmss")
                );
            logPath += fileName;

            System.Drawing.Image imgData = System.Drawing.Image.FromStream(stInfo.data);
            imgData.RotateFlip(RotateFlipType.RotateNoneFlipX);
            try
            {
                imgData.Save(logPath);
            }
            catch (Exception)
            {
                m_main.PalmSecure_ErrorMessage(PS_APP_EXCEPTION.PS_APPEX_BMP_SAVE);
            }

            return fileName;

        }

        /// <summary>
        /// Write log in "Result.csv".
        /// </summary>
        /// <param name="LogTbl">Log Data</param>
        public void PalmSecure_WriteLog(PS_LOG_TBL logTbl)
        {
            string sResult;

            if (logTbl.result)
            {
                sResult = "OK";
            }
            else
            {
                sResult = "NG";
            }

            string log1, log2;

            DateTime now = DateTime.Now;

            log1 = string.Format("{0}", now.ToString("yyyy/MM/dd HH:mm:ss"));

            log2 = string.Format(",{0},{1},{2},{3},{4},{5}",
                logTbl.sensorType,
                logTbl.guideMode,
                logTbl.authenticateMode,
                sResult,
                logTbl.retryNum,
                logTbl.silhouette
                );

            string id="";
            for (int i=0 ; i < logTbl.idList.Count() ; i++)
            {
                id += ",";
                id += logTbl.idList[i];
                if (logTbl.farAchieved.Count > i)
                {
                    id += string.Format("({0})", logTbl.farAchieved[i]);
                }
            }

            PsFileAccessorIni ini = new PsFileAccessorIni();
            string logDir = ini.PalmSecure_GetLogInfoSilhouetteFolder();
            string logPath = string.Format(@"{0}\{1}\", m_main.m_ModulePath, logDir);

            if (!Directory.Exists(logPath))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(logPath);
                }
                catch (Exception)
                {
                    m_main.PalmSecure_ErrorMessage(PS_APP_EXCEPTION.PS_APPEX_LOGDIR_OPEN);
                }
            }

            logPath += "Result.csv";

            try
            {
                using (StreamWriter writer = new StreamWriter(logPath, true))
                {
                    string writestr = string.Format("{0}{1}{2}", log1, log2, id);

                    writer.WriteLine(writestr);
                }
            }
            catch (Exception)
            {
                m_main.PalmSecure_ErrorMessage(PS_APP_EXCEPTION.PS_APPEX_LOGFILE_WRITE);
            }

            return;
        }
    }
}
