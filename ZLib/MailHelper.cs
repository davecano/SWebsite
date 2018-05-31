using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using System.Web;
using System.Net.Mail;
using System.Collections;

namespace Z
{
    /// <summary>
    /// 邮件发送
    /// </summary>
    public class MailHelper
    {
        #region 发送电子邮件
        /// <summary>
        /// 发送电子邮件
        /// </summary>
        /// <param name="smtpserver">SMTP服务器</param>
        /// <param name="userName">登录帐号</param>
        /// <param name="pwd">登录密码</param>
        /// <param name="nickName">发件人昵称</param>
        /// <param name="strfrom">发件人</param>
        /// <param name="strto">收件人</param>
        /// <param name="subj">主题</param>
        /// <param name="bodys">内容</param>
        public static void sendMail(string smtpserver, string userName, string pwd, string nickName, string strfrom, ArrayList strto, string subj, string bodys)
        {
            MailMessage _mailMessage = new MailMessage();
            //_mailMessage.ReplyTo = new MailAddress(strfrom, nickName, Encoding.GetEncoding(936));
            _mailMessage.From = new MailAddress(strfrom, nickName, Encoding.GetEncoding(936));
            //_mailMessage.To.Add(strto);
            _mailMessage.Subject = subj;//主题
            _mailMessage.SubjectEncoding = Encoding.GetEncoding(936);

            _mailMessage.Body = bodys;//内容
            _mailMessage.BodyEncoding = System.Text.Encoding.Default;//正文编码
            _mailMessage.IsBodyHtml = true;//设置为HTML格式
            _mailMessage.Priority = MailPriority.Normal;//优先级
            ////附件
            //long FileSize = 0;
            //if (AttachFilePaths != null)
            //{
            //    foreach (string afp in AttachFilePaths)
            //    {
            //        if (File.Exists(afp))
            //        {
            //            Attachment a = new Attachment(afp);
            //            a.NameEncoding = System.Text.Encoding.UTF8;
            //            _mailMessage.Attachments.Add(a);
            //            FileInfo f = new FileInfo(afp);
            //            FileSize += f.Length;
            //        }
            //    }
            //}
            ////************如果附件过大，不发送附件***********
            //if (FileSize >= 1024*1024*4)
            //{
            //    _mailMessage.Attachments.Clear();
            //    _mailMessage.Body += "<p style='font-weight:bold;color:red;font-size:14px'>由于附件过大，请登录<a href='http://www.zcqxxx.com' >智采官方网站</a>进行下载</p>";
            //}
            ////********************
            for (int i = 0; i < strto.Count; i++)
            {
                if (ValidateHelper.IsEmail(strto[i].ToString()))
                {
                    _mailMessage.Bcc.Add(strto[i].ToString());//直接发送
                    if ((i > 90 && i % 90 == 0) || i == strto.Count - 1)
                    {
                    try
                    {
                        SmtpClient _smtpClient = new SmtpClient();
                        _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式
                        _smtpClient.Host = smtpserver;//指定SMTP服务器
                        _smtpClient.Credentials = new System.Net.NetworkCredential(userName, pwd);//用户名和密码
                        _smtpClient.Send(_mailMessage);
                    }
                    catch (Exception ex)
                    {
                          throw  new Exception(ex.Message);
                        
                    }
                    _mailMessage.Bcc.Clear();
                    }
                }
            }

        }
        /// <summary>
        /// 发送电子邮件
        /// </summary>
        /// <param name="smtpserver">SMTP服务器</param>
        /// <param name="enablessl">是否启用SSL加密</param>
        /// <param name="userName">登录帐号</param>
        /// <param name="pwd">登录密码</param>
        /// <param name="nickName">发件人昵称</param>
        /// <param name="strfrom">发件人</param>
        /// <param name="strto">收件人</param>
        /// <param name="subj">主题</param>
        /// <param name="bodys">内容</param>
        public static void sendMail(string smtpserver, int enablessl, string userName, string pwd, string nickName, string strfrom, string strto, string subj, string bodys)
        {
            SmtpClient _smtpClient = new SmtpClient();
            _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式
            _smtpClient.Host = smtpserver;//指定SMTP服务器
            _smtpClient.Credentials = new System.Net.NetworkCredential(userName, pwd);//用户名和密码
            if (enablessl == 1)
            {
                _smtpClient.EnableSsl = true;
            }

            MailAddress _from = new MailAddress(strfrom, nickName);
            MailAddress _to = new MailAddress(strto);
            MailMessage _mailMessage = new MailMessage(_from, _to);
            _mailMessage.Subject = subj;//主题
            _mailMessage.Body = bodys;//内容
            _mailMessage.BodyEncoding = System.Text.Encoding.Default;//正文编码
            _mailMessage.IsBodyHtml = true;//设置为HTML格式
            _mailMessage.Priority = MailPriority.Normal;//优先级
            _smtpClient.Send(_mailMessage);
        }
        #endregion
    }
}
