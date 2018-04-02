using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Z.Mobset;
using System.Collections;

namespace Z.SMS
{
    /// <summary>
    /// 首易短信发送辅助类
    /// </summary>
    public class SmsHelper
    {
        private static int CorpID = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["SmsCorpID"]);
        private static string UserName = System.Configuration.ConfigurationSettings.AppSettings["SmsUserName"];
        private static string UserPassword = System.Configuration.ConfigurationSettings.AppSettings["SmsUserPassword"];

        /// <summary>
        /// 短信发送
        /// </summary>
        /// <param name="TelList"></param>
        /// <param name="strMsg"></param>
        /// <param name="errMsg"></param>
        /// <param name="smsIDGroup"></param>
        /// <returns></returns>
        public static long SendSms(ArrayList TelList, string strMsg, out string errMsg, out SmsIDGroup[] smsIDGroup)
        {
            MobsetApi mobsetMms = new MobsetApi();
            long lCorpID = CorpID;
            string strLoginName = UserName;
            string strPasswd = UserPassword;
            string strTimeStamp = DateTime.Now.ToString("MMddHHmmss");
            string strInput = lCorpID + strPasswd + strTimeStamp;
            string strMd5 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(strInput, "MD5");

            String strAddNum = "001";  //扩展码
            String tTimer = "";// = "2005-05-05 12:00:00"; //定时时间，yyyy-MM-dd HH:mm:ss
            long lLongSms = 1;  //使用长短信方式发送
                                //SmsIDGroup[] smsIDGroup = new SmsIDGroup[2];
            long ret = 0;
            errMsg = "";
            List<SmsIDGroup> lsig = new List<SmsIDGroup>();
            ArrayList tltemp = new ArrayList();
            for (int i = 0; i < TelList.Count; i++)
            {
                tltemp.Add(TelList[i]);
                if (((i + 1) >= 40 && (i + 1) % 40 == 0) || (i == TelList.Count - 1))
                {
                    //发送
                    MobileListGroup[] strMobiles2 = new MobileListGroup[tltemp.Count];  //目标号码
                    for (int j = 0; j < tltemp.Count; j++)
                    {
                        strMobiles2[j] = new MobileListGroup();
                        strMobiles2[j].Mobile = tltemp[j].ToString();
                    }
                    try
                    {
                        SmsIDGroup[] smsidgroup2;
                        ret = mobsetMms.Sms_Send(lCorpID, strLoginName, strMd5, strTimeStamp, strAddNum, tTimer, lLongSms, strMobiles2, strMsg, out errMsg, out smsidgroup2);
                        if (ret < 0) break;
                        foreach (SmsIDGroup sig in smsidgroup2)
                        {
                            lsig.Add(sig);
                        }

                    }
                    catch (Exception ex) { throw ex; }
                    tltemp = new ArrayList();
                }
            }
            smsIDGroup = new SmsIDGroup[lsig.Count];
            for (int i = 0; i < lsig.Count; i++)
            {
                smsIDGroup[i] = lsig[i];
            }
            return ret;
        }

        /// <summary>
        /// 获取状态报告
        /// </summary>
        /// <param name="ErrMsg"></param>
        /// <param name="SmsReportList"></param>
        /// <returns></returns>
        public static long GetSmsReport(out string ErrMsg, out SmsReportGroup[] SmsReportList)
        {
            MobsetApi mobsetMms = new MobsetApi();
            long lCorpID = CorpID;
            string strLoginName = UserName;
            string strPasswd = UserPassword;
            string strTimeStamp = DateTime.Now.ToString("MMddHHmmss");
            string strInput = lCorpID + strPasswd + strTimeStamp;
            string strMd5 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(strInput, "MD5");

            long ret = mobsetMms.Sms_GetReport(lCorpID, strLoginName, strMd5, strTimeStamp, out ErrMsg, out SmsReportList);
            return ret;
        }
    }
}
