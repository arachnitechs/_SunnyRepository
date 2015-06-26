
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Windows.Forms;

using PalmSecure;
using PalmSecure.util;

namespace PalmSecure
{
    class PsThreadIdentify : PsThreadBase
    {
        /// <summary>
        /// Identification thread process.
        /// </summary>
        /// <param name="obj">Argument</param>
        public void PalmSecure_ThreadProc(Object obj)
        {
            THREAD_PARAM_TBL identifyParam = (THREAD_PARAM_TBL)obj;
            PS_THREAD_RESULT stResult = new PS_THREAD_RESULT();
            UInt32 waitTime = 0;

            try
            {
                List<string> idList = new List<string>();
                uint memberNum =
                    (uint)identifyParam.dialog.m_PsDataManager.PalmSecure_GetAllUserId(ref idList);


                //Create an array of DNET_BioAPI_BIR class
                ///////////////////////////////////////////////////////////////////////////
                DNET_BioAPI_BIR[] birAry = new DNET_BioAPI_BIR[memberNum];
                ///////////////////////////////////////////////////////////////////////////

                
                //Read vein data from a file
                for (int i = 0; i < memberNum; i++)
                {
                    string  filePath    = String.Format(
                        @"{0}\Data\{1}{2}_{3}.dat",
                        identifyParam.dialog.m_ModulePath,
                        PsDataManager.m_sensorType,
                        PsDataManager.m_guideMode,
                        idList[i]
                        );

                    FileStream fs = null;
                    Byte[] bufferBIR = null;


                    //Get a instance of DNET_BioAPI_BIR class
                    ///////////////////////////////////////////////////////////////////////////
                    try
                    {
                        fs = new FileStream(filePath, FileMode.Open);
                        bufferBIR = new Byte[fs.Length];
                        fs.Read(bufferBIR, 0, bufferBIR.Length);
                        birAry[i] = PalmSecureHelper.convertByteToBIR(bufferBIR);
                    }
                    catch (PalmSecureException e)
                    {
                        MessageBox.Show(
                            e.Message
                            + "Error No: " + e.ErrNumber
                            );
                        break;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(
                            e.Message
                            );
                        break;
                    }
                    finally
                    {
                        if (fs != null)
                        {
                            fs.Dispose();
                        }
                    }
                    ///////////////////////////////////////////////////////////////////////////


                }


                //Create a instance of DNET_BioAPI_IDENTIFY_POPULATION class
                ///////////////////////////////////////////////////////////////////////////
                DNET_BioAPI_BIR_ARRAY_POPULATION BIRAryPopu = new DNET_BioAPI_BIR_ARRAY_POPULATION();
                BIRAryPopu.NumberOfMembers = memberNum;
                BIRAryPopu.Members = birAry;
                DNET_BioAPI_IDENTIFY_POPULATION Population = new DNET_BioAPI_IDENTIFY_POPULATION();
                Population.Type = PalmSecureConstant.DNET_BioAPI_ARRAY_TYPE;
                Population.BIRArray = BIRAryPopu;
                ///////////////////////////////////////////////////////////////////////////


                //Repeat numOfRetry times until identification succeed.
                int numOfRetry = int.Parse(PsFileAccessor.g_clSetting.NumberOfRetry);
                for( int identifyCnt = 0; identifyCnt <= numOfRetry; identifyCnt++ )
                {
                    identifyParam.dialog.PalmSecure_SetWorkMessage(
                        (int)PS_WRK_MESSAGE.PS_MESSAGE_IDENTIFY,
                        identifyCnt + 1
                        );
                    if (identifyCnt > 0)
                    {
                        identifyParam.dialog.PalmSecure_SetGuidance(
                            PsFileAccessor.g_clLang.Guidance.RetryTransaction,
                            false
                            );

                        waitTime = 0;
                        do
                        {
                            //End transaction in case of cancel.
                            if (identifyParam.dialog.m_CancelFlg == true)
                            {
                                break;
                            }

                            if (waitTime < identifyParam.dialog.m_PsFileAcsIni.PalmSecure_GetApiIfParamSleepTime())
                            {
                                System.Threading.Thread.Sleep(100);
                                waitTime = waitTime + 100;
                            }
                            else
                            {
                                break;
                            }
                        }
                        while (true);
                    }

                    //End transaction in case of cancel.
                    if (identifyParam.dialog.m_CancelFlg == true)
                    {
                        break;
                    }

                    stResult = new PS_THREAD_RESULT();


                    //Set mode to get authentication score
                    ///////////////////////////////////////////////////////////////////////////
                    try
                    {
                        stResult.result = identifyParam.dialog.m_PalmSecureIf.DNET_PvAPI_SetProfile(
                            identifyParam.dialog.m_ModuleHandle,
                            PalmSecureConstant.DNET_PvAPI_PROFILE_SCORE_NOTIFICATIONS,
                            PalmSecureConstant.DNET_PvAPI_PROFILE_SCORE_NOTIFICATIONS_ON,
                            0,
                            0
                            );
                    }
                    catch (PalmSecureException e)
                    {
                        MessageBox.Show(
                            e.Message
                            + "Error No: " + e.ErrNumber
                            );
                        stResult.result = PalmSecureConstant.DNET_BioAPI_ERRCODE_FUNCTION_FAILED;
                        break;
                    }
                    ///////////////////////////////////////////////////////////////////////////


                    //If PalmSecure method failed, get error info.
                    if (stResult.result != PalmSecureConstant.DNET_BioAPI_OK)
                    {
                        identifyParam.dialog.m_PalmSecureIf.DNET_PvAPI_GetErrorInfo(stResult.errInfo);
                        identifyParam.dialog.PalmSecure_ErrorMessage(stResult.errInfo);
                        break;
                    }

                    stResult.retryCnt = identifyCnt;


                    //Identification
                    ///////////////////////////////////////////////////////////////////////////
                    int MaxFARRequested = 0;
                    int MaxFRRRequested = PalmSecureConstant.DNET_PvAPI_MATCHING_LEVEL_NORMAL;
                    uint FARPrecedence = PalmSecureConstant.DNET_BioAPI_FALSE;
                    uint Binning = PalmSecureConstant.DNET_BioAPI_FALSE;
                    uint NumberOfResults = 0;
                    DNET_BioAPI_CANDIDATE[] Candidates =
                        new DNET_BioAPI_CANDIDATE[UInt32.Parse(PsFileAccessor.g_clSetting.MaxResults)];
                    int AuditData = 0;
                    try
                    {
                        stResult.result = identifyParam.dialog.m_PalmSecureIf.DNET_BioAPI_Identify(
                            identifyParam.dialog.m_ModuleHandle,
                            ref MaxFARRequested,
                            ref MaxFRRRequested,
                            ref FARPrecedence,
                            Population,
                            ref Binning,
                            (uint)Candidates.Length,
                            ref NumberOfResults,
                            Candidates,
                            0,
                            ref AuditData
                            );
                    }
                    catch (PalmSecureException e)
                    {
                        MessageBox.Show(
                            e.Message
                            + "Error No: " + e.ErrNumber
                            );
                        break;
                    }
                    ///////////////////////////////////////////////////////////////////////////


                    //If PalmSecure method failed, get error info.
                    if ( (stResult.result != PalmSecureConstant.DNET_BioAPI_OK) &
                        (identifyParam.dialog.m_CancelFlg != true) )
                    {
                        identifyParam.dialog.m_PalmSecureIf.DNET_PvAPI_GetErrorInfo(stResult.errInfo);
                        identifyParam.dialog.PalmSecure_ErrorMessage(stResult.errInfo);
                        break;
                    }


                    //Set mode not to get authentication score
                    ///////////////////////////////////////////////////////////////////////////
                    try
                    {
                        stResult.result = identifyParam.dialog.m_PalmSecureIf.DNET_PvAPI_SetProfile(
                            identifyParam.dialog.m_ModuleHandle,
                            PalmSecureConstant.DNET_PvAPI_PROFILE_SCORE_NOTIFICATIONS,
                            PalmSecureConstant.DNET_PvAPI_PROFILE_SCORE_NOTIFICATIONS_OFF,
                            0,
                            0
                            );
                    }
                    catch (PalmSecureException e)
                    {
                        MessageBox.Show(
                            e.Message
                            + "Error No: " + e.ErrNumber
                            );
                        stResult.result = PalmSecureConstant.DNET_BioAPI_ERRCODE_FUNCTION_FAILED;
                        break;
                    }
                    ///////////////////////////////////////////////////////////////////////////


                    //End transaction in case of cancel.
                    if (identifyParam.dialog.m_CancelFlg == true)
                    {
                        break;
                    }

                    //If PalmSecure method failed, get error info.
                    if (stResult.result != PalmSecureConstant.DNET_BioAPI_OK)
                    {
                        identifyParam.dialog.m_PalmSecureIf.DNET_PvAPI_GetErrorInfo(stResult.errInfo);
                        identifyParam.dialog.PalmSecure_ErrorMessage(stResult.errInfo);
                        break;
                    }

                    //Log a shilouette image
                    if (stResult.info.data != null)
                    {
                        stResult.info.data.Dispose();
                        stResult.info.data = null;
                    }
                    stResult.info.data = new MemoryStream(identifyParam.dialog.m_SilhouetteInfo.ToArray());

                    //If result of identification is 0, retry identification.
                    if (NumberOfResults == 0)
                    {
                        continue;
                    }
                    
                    if (NumberOfResults >= 1)
                    {
                        for (int i = 0; i < NumberOfResults; i++)
                        {
                            stResult.farAchieved.Add((int)Candidates[i].FARAchieved);
                            stResult.userId.Add(idList[(int)Candidates[i].BIRInArray]);
                        }
                        if (NumberOfResults > 1 
                            && Math.Abs( Candidates[0].FARAchieved - Candidates[1].FARAchieved ) < 3000 )
                        {
                            continue;
                        }
                    }

                    stResult.authenticated = true;

                    break;
                }

                identifyParam.dialog.PalmSecure_EndIdentify(stResult);
            }
            catch(Exception e)
            {
            }

            return;
        }
    }
}
