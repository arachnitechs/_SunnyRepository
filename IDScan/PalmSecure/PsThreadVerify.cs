
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
    class PsThreadVerify : PsThreadBase
    {
        /// <summary>
        /// Verification thread process.
        /// </summary>
        /// <param name="obj">Argument</param>
        public void PalmSecure_ThreadProc(Object obj)
        {
            THREAD_PARAM_TBL verifyParam = (THREAD_PARAM_TBL)obj;
            PS_THREAD_RESULT stResult = new PS_THREAD_RESULT();
            UInt32 waitTime = 0;
            
            try
            {
                int numOfRetry = int.Parse(PsFileAccessor.g_clSetting.NumberOfRetry);
                stResult.userId.Add(verifyParam.userId);

                string  filepath = String.Format(
                    @"{0}\Data\{1}{2}_{3}.dat",
                    verifyParam.dialog.m_ModulePath,
                    PsDataManager.m_sensorType,
                    PsDataManager.m_guideMode,
                    verifyParam.userId
                    );

                FileStream fs = null;
                Byte[] bufferBIR = null;


                //Get a instance of DNET_BioAPI_INPUT_BIR class
                ///////////////////////////////////////////////////////////////////////////
                DNET_BioAPI_INPUT_BIR StoredTemplate = new DNET_BioAPI_INPUT_BIR();
                StoredTemplate.Form = PalmSecureConstant.DNET_BioAPI_FULLBIR_INPUT;
                try
                {
                    fs = new FileStream(filepath, FileMode.Open);
                    bufferBIR = new Byte[fs.Length];
                    fs.Read(bufferBIR, 0, bufferBIR.Length);
//wd
                    StoredTemplate.BIR = PalmSecureHelper.convertByteToBIR(bufferBIR);

                }
                catch (PalmSecureException e)
                {
                    MessageBox.Show(
                        e.Message
                        + "Error No: " + e.ErrNumber
                        );
                }
                catch (Exception e)
                {
                    MessageBox.Show(
                        e.Message
                        );
                }
                finally
                {
                    if (fs != null)
                    {
                        fs.Dispose();
                    }
                }
                ///////////////////////////////////////////////////////////////////////////


                //Repeat numOfRetry times until verification succeed.
                int verifyCnt = 0;
                for (verifyCnt = 0; verifyCnt <= numOfRetry; verifyCnt++)
                {
                    verifyParam.dialog.PalmSecure_SetWorkMessage(
                        (int)PS_WRK_MESSAGE.PS_MESSAGE_VERIFY,
                        verifyCnt + 1
                        );

                    if (verifyCnt > 0)
                    {
                        verifyParam.dialog.PalmSecure_SetGuidance(
                            PsFileAccessor.g_clLang.Guidance.RetryTransaction,
                            false
                            );

                        waitTime = 0;
                        do
                        {
                            //End transaction in case of cancel.
                            if (verifyParam.dialog.m_CancelFlg == true)
                            {
                                break;
                            }

                            if (waitTime < verifyParam.dialog.m_PsFileAcsIni.PalmSecure_GetApiIfParamSleepTime())
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
                    if (verifyParam.dialog.m_CancelFlg == true)
                    {
                        break;
                    }

                    stResult.retryCnt = verifyCnt;


                    //Verification
                    ///////////////////////////////////////////////////////////////////////////
                    int MaxFARRequested = 0;
                    int MaxFRRRequested = PalmSecureConstant.DNET_PvAPI_MATCHING_LEVEL_NORMAL;
                    uint FARPrecedence = PalmSecureConstant.DNET_BioAPI_FALSE;
                    int AdaptedBIR = 0;
                    uint Result = 0;
                    int FARAchieved = 0;
                    int FRRAchieved = 0;
                    int AuditData = 0;
                    try
                    {
                        stResult.result = verifyParam.dialog.m_PalmSecureIf.DNET_BioAPI_Verify(
                            verifyParam.dialog.m_ModuleHandle,
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
                        break;
                    }
                    ///////////////////////////////////////////////////////////////////////////


                    //End transaction in case of cancel.
                    if( verifyParam.dialog.m_CancelFlg == true )
                    {
                        break;
                    }

                    //If PalmSecure method failed, get error info.
                    if ( stResult.result != PalmSecureConstant.DNET_BioAPI_OK )
                    {
                        verifyParam.dialog.m_PalmSecureIf.DNET_PvAPI_GetErrorInfo(stResult.errInfo);
                        verifyParam.dialog.PalmSecure_ErrorMessage(stResult.errInfo);
                        break;
                    }

                    //Log a shilouette image.
                    if (stResult.info.data != null)
                    {
                        stResult.info.data.Dispose();
                        stResult.info.data = null;
                    }
                    stResult.info.data = new MemoryStream(verifyParam.dialog.m_SilhouetteInfo.ToArray());

                    //If result of verification is false, retry verification.
                    if (Result != PalmSecureConstant.DNET_BioAPI_TRUE)
                    {
                        continue;
                    }
                    
                    stResult.authenticated = true;
                    break;
                }

                verifyParam.dialog.PalmSecure_EndVerify(stResult);
            }
            catch(Exception e)
            {
            }

            return;
        }
    }
}
