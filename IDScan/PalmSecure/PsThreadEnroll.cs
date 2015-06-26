
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

using PalmSecure;
using PalmSecure.util;

namespace PalmSecure
{
    /// <summary>
    /// Enroll Class
    /// </summary>
    class PsThreadEnroll : PsThreadBase
    {
        delegate void SetGuidanceDelegate(string msg, bool bErr);

        /// <summary>
        /// Enrollment thread process.
        /// </summary>
        /// <param name="obj">Object</param>
        public void PalmSecure_ThreadProc(Object obj)
        {
            THREAD_PARAM_TBL enrollParam = (THREAD_PARAM_TBL)obj;
            PS_THREAD_RESULT stResult = new PS_THREAD_RESULT();

            try
            {
                int enrollScore = 0;
                List<int> scoreList = new List<int>();
                int numOfRetry = int.Parse(PsFileAccessor.g_clSetting.NumberOfRetry);
                UInt32 waitTime = 0;

                //Repeat numOfRetry times until enrollment succeed.
                for (int enrollCnt = 0; enrollCnt <= numOfRetry; enrollCnt++)
                {
                    if (enrollCnt > 0)
                    {
                        enrollParam.dialog.PalmSecure_SetGuidance(
                            PsFileAccessor.g_clLang.Guidance.RetryTransaction,
                            false
                            );

                        waitTime = 0;
                        do
                        {
                            //End transaction in case of cancel.
                            if (enrollParam.dialog.m_CancelFlg == true)
                            {
                                break;
                            }

                            if (waitTime < enrollParam.dialog.m_PsFileAcsIni.PalmSecure_GetApiIfParamSleepTime())
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
                    if (enrollParam.dialog.m_CancelFlg == true)
                    {
                        break;
                    }

                    enrollParam.dialog.m_EnrollFlg = true;
                    stResult.retryCnt = enrollCnt;


                    //Enrollment
                    ///////////////////////////////////////////////////////////////////////////
                    int BIRHandle = 0;
                    int AuditData = 0;
                    try
                    {
                        stResult.result = enrollParam.dialog.m_PalmSecureIf.DNET_BioAPI_Enroll(
                            enrollParam.dialog.m_ModuleHandle,
                            PalmSecureConstant.DNET_BioAPI_PURPOSE_VERIFY,
                            null,
                            ref BIRHandle,
                            null,
                            0,
                            ref AuditData
                            );
                    }
                    catch(PalmSecureException e)
                    {
                        MessageBox.Show(
                            e.Message
                            + "Error No: "  + e.ErrNumber
                            );
                        stResult.result = PalmSecureConstant.DNET_BioAPI_ERRCODE_FUNCTION_FAILED;
                        enrollParam.dialog.m_EnrollFlg = false;
                        break;
                    }
                    ///////////////////////////////////////////////////////////////////////////


                    enrollParam.dialog.m_EnrollFlg = false;

                    //End transaction in case of cancel.
                    if (enrollParam.dialog.m_CancelFlg == true)
                    {
                        break;
                    }

                    //If PalmSecure method failed, get error info.
                    if (stResult.result != PalmSecureConstant.DNET_BioAPI_OK )
                    {
                        enrollParam.dialog.m_PalmSecureIf.DNET_PvAPI_GetErrorInfo(stResult.errInfo);
                        enrollParam.dialog.PalmSecure_ErrorMessage(stResult.errInfo);
                        break;
                    }

                    enrollScore = (int)enrollParam.dialog.m_NotifiedScore;

                    //Log a shilouette image.
                    if (stResult.info.data != null)
                    {
                        stResult.info.data.Dispose();
                        stResult.info.data = null;
                    }
                    stResult.info.data = new MemoryStream(enrollParam.dialog.m_SilhouetteInfo.ToArray());


                    //Get BIR data ( vein data )
                    ///////////////////////////////////////////////////////////////////////////
                    DNET_BioAPI_BIR BIR = new DNET_BioAPI_BIR();
                    try
                    {
                        stResult.result = enrollParam.dialog.m_PalmSecureIf.DNET_BioAPI_GetBIRFromHandle(
                            enrollParam.dialog.m_ModuleHandle,
                            BIRHandle,
                            BIR
                            );
                    }
                    catch(PalmSecureException e)
                    {
                        MessageBox.Show(
                            e.Message
                            + "Error No: "  + e.ErrNumber
                            );
                        stResult.result = PalmSecureConstant.DNET_BioAPI_ERRCODE_FUNCTION_FAILED;
                        break;
                    }
                    ///////////////////////////////////////////////////////////////////////////


                    //If PalmSecure method failed, get error info.
                    if (stResult.result != PalmSecureConstant.DNET_BioAPI_OK )
                    {
                        enrollParam.dialog.m_PalmSecureIf.DNET_PvAPI_GetErrorInfo(stResult.errInfo);
                        enrollParam.dialog.PalmSecure_ErrorMessage(stResult.errInfo);
                        break;
                    }


                    //Free BIR handle
                    ///////////////////////////////////////////////////////////////////////////
                    try
                    {
                        stResult.result = enrollParam.dialog.m_PalmSecureIf.DNET_BioAPI_FreeBIRHandle(
                            enrollParam.dialog.m_ModuleHandle,
                            BIRHandle
                            );
                    }
                    catch(PalmSecureException e)
                    {
                        MessageBox.Show(
                            e.Message
                            + "Error No: "  + e.ErrNumber
                            );
                        stResult.result = PalmSecureConstant.DNET_BioAPI_ERRCODE_FUNCTION_FAILED;
                        break;
                    }
                    ///////////////////////////////////////////////////////////////////////////


                    //End transaction in case of cancel.
                    if (enrollParam.dialog.m_CancelFlg == true)
                    {
                        break;
                    }
                    
                    //If PalmSecure method failed, get error info.
                    if (stResult.result != PalmSecureConstant.DNET_BioAPI_OK)
                    {
                        enrollParam.dialog.m_PalmSecureIf.DNET_PvAPI_GetErrorInfo(stResult.errInfo);
                        enrollParam.dialog.PalmSecure_ErrorMessage(stResult.errInfo);
                        break;
                    }

                    //Repeat 2 times until enrollment test failed.
                    bool retryFlg  = false;
                    scoreList.Clear();
                    for( int cnt = 0; cnt < 2; cnt++ )
                    {
                        if (cnt == 0)
                        {
                            enrollParam.dialog.PalmSecure_SetGuidance(
                                PsFileAccessor.g_clLang.Guidance.EnrollmentTest,
                                false
                                );
                        }
                        else
                        {
                            enrollParam.dialog.PalmSecure_SetGuidance(
                                PsFileAccessor.g_clLang.Guidance.RetryTransaction,
                                false
                                );
                        }

                        enrollParam.dialog.PalmSecure_SetWorkMessage(
                            (int)PS_WRK_MESSAGE.PS_MESSAGE_ENROLL_TEST,
                            cnt+1
                            );

                        waitTime = 0;
                        do
                        {
                            //End transaction in case of cancel.
                            if (enrollParam.dialog.m_CancelFlg == true)
                            {
                                break;
                            }

                            if (waitTime < enrollParam.dialog.m_PsFileAcsIni.PalmSecure_GetApiIfParamSleepTime())
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

                        //End transaction in case of cancel.
                        if (enrollParam.dialog.m_CancelFlg == true)
                        {
                            break;
                        }


                        //Set mode to get authentication score
                        ///////////////////////////////////////////////////////////////////////////
                        try
                        {
                            stResult.result = enrollParam.dialog.m_PalmSecureIf.DNET_PvAPI_SetProfile(
                                enrollParam.dialog.m_ModuleHandle,
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
                            enrollParam.dialog.m_PalmSecureIf.DNET_PvAPI_GetErrorInfo(stResult.errInfo);
                            enrollParam.dialog.PalmSecure_ErrorMessage(stResult.errInfo);
                            break;
                        }


                        //Verification to check template quality
                        ///////////////////////////////////////////////////////////////////////////
                        int MaxFARRequested = 0;
                        int MaxFRRRequested = PalmSecureConstant.DNET_PvAPI_MATCHING_LEVEL_NORMAL;
                        uint FARPrecedence = PalmSecureConstant.DNET_BioAPI_FALSE;
                        DNET_BioAPI_INPUT_BIR StoredTemplate = new DNET_BioAPI_INPUT_BIR();
                        StoredTemplate.Form = PalmSecureConstant.DNET_BioAPI_FULLBIR_INPUT;
                        StoredTemplate.BIR = BIR;
                        int AdaptedBIR = 0;
                        uint Result = 0;
                        int FARAchieved = 0;
                        int FRRAchieved = 0;
                        try
                        {
                            stResult.result = enrollParam.dialog.m_PalmSecureIf.DNET_BioAPI_Verify(
                                enrollParam.dialog.m_ModuleHandle,
                                ref MaxFARRequested,
                                ref MaxFRRRequested,
                                ref FARPrecedence,
                                StoredTemplate,
                                ref AdaptedBIR,
                                ref Result,
                                ref FARAchieved,
                                ref FRRAchieved,
                                null,
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
                            stResult.result = PalmSecureConstant.DNET_BioAPI_ERRCODE_FUNCTION_FAILED;
                            break;
                        }
                        ///////////////////////////////////////////////////////////////////////////


                        //If PalmSecure method failed, get error info.
                        if ( (stResult.result != PalmSecureConstant.DNET_BioAPI_OK) &&
                            (enrollParam.dialog.m_CancelFlg != true) )
                        {
                            enrollParam.dialog.m_PalmSecureIf.DNET_PvAPI_GetErrorInfo(stResult.errInfo);
                            enrollParam.dialog.PalmSecure_ErrorMessage(stResult.errInfo);
                            break;
                        }


                        //Set mode not to get authentication score
                        ///////////////////////////////////////////////////////////////////////////
                        try
                        {
                            stResult.result = enrollParam.dialog.m_PalmSecureIf.DNET_PvAPI_SetProfile(
                                enrollParam.dialog.m_ModuleHandle,
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
                        if (enrollParam.dialog.m_CancelFlg == true)
                        {
                            break;
                        }

                        //If PalmSecure method failed, get error info.
                        if (stResult.result != PalmSecureConstant.DNET_BioAPI_OK)
                        {
                            enrollParam.dialog.m_PalmSecureIf.DNET_PvAPI_GetErrorInfo(stResult.errInfo);
                            enrollParam.dialog.PalmSecure_ErrorMessage(stResult.errInfo);
                            break;
                        }

                        //If result of verification is false, retry enrollment test.
                        if (Result != PalmSecureConstant.DNET_BioAPI_TRUE)
                        {
                            stResult.authenticated = false;
                            retryFlg = true;
                            break;
                        }

                        stResult.authenticated = true;
                        scoreList.Add(FARAchieved);
                    }
                    if (enrollParam.dialog.m_CancelFlg == true)
                    {
                        break;
                    }
                    if (stResult.result != PalmSecureConstant.DNET_BioAPI_OK)
                    {
                        break;
                    }
                    if (retryFlg == true)
                    {
                        continue;
                    }

                    //Get an average score
                    int veriScore  = 0;
                    for (int i=0; i<scoreList.Count(); i++)
                    {
                        veriScore += scoreList[i];
                    }
                    if (scoreList.Count() > 0)
                    {
                        veriScore /= scoreList.Count();
                    }
                    stResult.farAchieved.Add(veriScore);

                    string filePath = string.Format(
                        @"{0}\Data\{1}{2}_{3}.dat",
                        enrollParam.dialog.m_ModulePath,
                        PsDataManager.m_sensorType,
                        PsDataManager.m_guideMode,
                        enrollParam.userId
                        );

                    MemoryStream ms = null;
                    BinaryWriter bw = null;
                    byte[] bufferBIR = null;


                    //Create a byte array of vein data and output vein data to file 
                    ///////////////////////////////////////////////////////////////////////////
                    try
                    {
//wd
                        bufferBIR = PalmSecureHelper.convertBIRToByte(BIR);

                        ms = new MemoryStream();
                        ms.Write(bufferBIR, 0, bufferBIR.Length);
                        bw = new BinaryWriter(File.OpenWrite(filePath));
                        bw.Write(ms.ToArray());

                        //wd
                        SessionData.bio_palm_id = ms.ToArray();
                        

                    }
                    catch (PalmSecureException e)
                    {
                        MessageBox.Show(e.Message+" Error #: " + e.ErrNumber
                            );
                        stResult.result = PalmSecureConstant.DNET_BioAPI_ERRCODE_FUNCTION_FAILED;
                        break;
                    }
                    finally
                    {
                        if (bw != null)
                        {
                            bw.Dispose();
                        }
                        if (ms != null)
                        {
                            ms.Dispose();
                        }
                    }
                    ///////////////////////////////////////////////////////////////////////////


                    enrollParam.dialog.m_PsDataManager.PalmSecure_Insert(enrollParam.userId, filePath);
                    break;
                }

                enrollParam.dialog.PalmSecure_EndEnroll(stResult, enrollScore);
            }
            catch(Exception e)
            {
                throw;
            }

            return;
        }
    }
}
