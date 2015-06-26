
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections;

using PalmSecure;
using PalmSecure.util;

namespace PalmSecure
{
    public class PsDataManager
    {
        public Hashtable UserList = new Hashtable();
        public static int m_sensorType;
        public static int m_guideMode;
        PalmSecure.psWindowMain m_main;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mainWindow">PvsWindowMain handle</param>
        public PsDataManager(PalmSecure.psWindowMain mainWindow)
        {
            m_main = mainWindow;
        }

        /// <summary>
        /// Call initialization of Data management control.
        /// After initialization succeeds, get all data and maintain the
        /// individual attribute.
        /// </summary>
        /// <param name="sensorType">Sensor Type</param>
        /// <param name="guideMode">Guide Mode</param>
        public void PalmSecure_Init(int sensorType, int guideMode)
        {
            string sUserID;

            m_sensorType = sensorType;
            m_guideMode = guideMode;

            string strDatPath = m_main.m_ModulePath + @"\Data";
            string strfilefmt = string.Format("{0}{1}_*.dat", sensorType, guideMode);

            if (!Directory.Exists(strDatPath))
            {
                Directory.CreateDirectory(strDatPath);
            }
            else
            {
                foreach (string strFilePath in System.IO.Directory.GetFiles(strDatPath, strfilefmt))
                {
                    string sFileName = Path.GetFileNameWithoutExtension(strFilePath);

                    sUserID = sFileName.Substring(3);
                    UserList.Add(sUserID, strFilePath);
                }
            }

            return;

        }

        /// <summary>
        /// Get the registration status of specified user ID.
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <returns>
        /// true    : Registered<para/>
        /// flase   : Not registered<para/>
        /// </returns>
        public bool PalmSecure_IsRegist(string userId)
        {
            if (!UserList.ContainsKey(userId))
            {
                return false;
            }
            return true;
        }
        
        /// <summary>
        /// Get the number of registration.
        /// </summary>
        /// <returns>Number of registration</returns>
        public int PalmSecure_GetRegistNum()
        {
            return UserList.Count;
        }

        /// <summary>
        /// Add the data to internal maintenance.
        /// </summary>
        /// <param name="strUserId">User ID</param>
        /// <param name="filePath">File Path</param>
        public void PalmSecure_Insert(string strUserId, string filePath)
        {
            UserList.Add(strUserId, filePath);
            return;
        }

        /// <summary>
        /// Call Data management control function for deletion.
        /// </summary>
        /// <param name="userId">User ID</param>
        public bool PalmSecure_Delete(string userId)
        {
            if (UserList.ContainsKey(userId))
            {
                string filePath = (string)UserList[userId];
                try
                {
                    System.IO.File.Delete(filePath);
                }
                catch (Exception)
                {
                    return false;
                }
                UserList.Remove(userId);
            }

            return true;

        }

        /// <summary>
        /// Get registered all ID information.
        /// </summary>
        /// <param name="idList">user ID list</param>
        /// <returns>Number of registration data.</returns>
        public int PalmSecure_GetAllUserId(ref List<string> idList)
        {
            foreach (string sUserid in UserList.Keys)
            {
                idList.Add(sUserid);
            }

            return idList.Count();

        }
    }
}
