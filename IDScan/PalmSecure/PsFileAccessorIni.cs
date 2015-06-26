/*
 *  PsFileAccessorIni.cs
 *  Description:
 *      Module for "PalmSecureSample.ini" accessor of operational information.
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

namespace PalmSecure
{
    public class PsFileAccessorIni
    {
        public const int PS_DEF_MAIN_SLEEPTIME = 2000;

        public const string PS_FILENAME = "PalmSecure.ini";
        public const string PS_DEF_MAIN_SILHOUETTEFOLDER = "Log";

        /// <summary>
        /// Read "PsSampleApl.ini" file.
        /// </summary>
        public void PalmSecure_Read(string rootPath)
        {
            PsFileAccessor psFacs = new PsFileAccessor();
            psFacs.PalmSecure_ReadIni(rootPath+PS_FILENAME);
            return;
        }

        /// <summary>
        /// Get the folder to strage silhouette data.
        /// </summary>
        /// <returns>Folder name</returns>
        public string PalmSecure_GetLogInfoSilhouetteFolder()
        {
            string result = PS_DEF_MAIN_SILHOUETTEFOLDER;

            if (PsFileAccessor.g_clSetting.LogFolderPath != string.Empty)
            {
                result = PsFileAccessor.g_clSetting.LogFolderPath;
            }

            return result;
        }

        /// <summary>
        /// Get sleep time
        /// </summary>
        /// <returns>Millisecond</returns>
        public int PalmSecure_GetApiIfParamSleepTime()
        {
            int result = 0;

            if (! int.TryParse(PsFileAccessor.g_clSetting.SleepTime.ToString(), out result))
            {
                result = PS_DEF_MAIN_SLEEPTIME;
            }

            return result;
        }
    }
}
