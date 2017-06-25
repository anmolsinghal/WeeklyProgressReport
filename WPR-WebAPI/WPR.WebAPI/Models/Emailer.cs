using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.IO;
using System.Configuration;
using System.Data;

namespace PartnerView.WebAPI.Models
{
    public class Emailer
    {
        #region "Public Methods"

        public static void SendMailMessage(string to, string from, string cc, string bcc, string subject,
                                           string text, string priority, bool isBodyHtml)
        {
            try
            {
                var mailMsg = new MailMessage();
                string[] toEmailId = to.Split(',');
                string[] ccEmailId = cc.Split(',');
                string[] bccEmailId = bcc.Split(',');
                var mailFrom = new MailAddress(from);
                mailMsg.From = mailFrom;
                foreach (string detail in toEmailId)
                {
                    if (!String.IsNullOrEmpty(detail.Trim()))
                    {
                        var toEmailAddress = new MailAddress(detail.Trim());
                        mailMsg.To.Add(toEmailAddress);
                    }
                }
                foreach (string detail in ccEmailId)
                {
                    if (!String.IsNullOrEmpty(detail.Trim()))
                    {
                        var ccEmailAddress = new MailAddress(detail.Trim());
                        mailMsg.CC.Add(ccEmailAddress);
                    }
                }
                foreach (string detail in bccEmailId)
                {
                    if (!String.IsNullOrEmpty(detail.Trim()))
                    {
                        var bccEmailAddress = new MailAddress(detail.Trim());
                        mailMsg.Bcc.Add(bccEmailAddress);
                    }
                }
                if (!string.IsNullOrEmpty(priority))
                {
                    if (priority.ToLower() == "high")
                        mailMsg.Priority = MailPriority.High;
                    else if (priority.ToLower() == "low")
                        mailMsg.Priority = MailPriority.Low;
                    else
                        mailMsg.Priority = MailPriority.Normal;
                }
                mailMsg.Subject = subject;
                mailMsg.IsBodyHtml = isBodyHtml;
                mailMsg.Body = text;

                var MailServer = ConfigurationManager.AppSettings["SmtpIP"];
                SmtpClient smtp = new SmtpClient(MailServer);
                smtp.Send(mailMsg);
                // client.Send(mailMsg);

                //  SendEmail(mailMsg);
                mailMsg.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SendMailMessage(string to, string from, string cc, string bcc, string subject,
                                           string strText, string strPriority, bool isBodyHtml, string[] lstFileName)
        {
            try
            {
                var mailMsg = new MailMessage();
                string[] toEmailId = to.Split(',');
                string[] ccEmailId = cc.Split(',');
                string[] bccEmailId = bcc.Split(',');
                var mailFrom = new MailAddress(from);
                mailMsg.From = mailFrom;
                foreach (string detail in toEmailId)
                {
                    if (!string.IsNullOrEmpty(detail.Trim()))
                    {
                        var toEmailAddress = new MailAddress(detail.Trim());
                        mailMsg.To.Add(toEmailAddress);
                    }
                }
                foreach (string detail in ccEmailId)
                {
                    if (!string.IsNullOrEmpty(detail.Trim()))
                    {
                        var ccEmailAddress = new MailAddress(detail.Trim());
                        mailMsg.CC.Add(ccEmailAddress);
                    }
                }
                foreach (string detail in bccEmailId)
                {
                    if (!string.IsNullOrEmpty(detail.Trim()))
                    {
                        var bccEmailAddress = new MailAddress(detail.Trim());
                        mailMsg.Bcc.Add(bccEmailAddress);
                    }
                }
                if (!string.IsNullOrEmpty(strPriority))
                {
                    if (strPriority.ToLower() == "high")
                        mailMsg.Priority = MailPriority.High;
                    else if (strPriority.ToLower() == "low")
                        mailMsg.Priority = MailPriority.Low;
                    else
                        mailMsg.Priority = MailPriority.Normal;
                }
                Int64 totalAttachmentSize = 0;
                foreach (string detail in lstFileName)
                {
                    var fileInfo = new FileInfo(detail);
                    if (fileInfo.Exists)
                    {
                        totalAttachmentSize = fileInfo.Length;
                    }
                }
                totalAttachmentSize = (totalAttachmentSize / (1024 * 1024));
                if (totalAttachmentSize < 10)
                {
                    foreach (string detail in lstFileName)
                    {
                        var attachment = new Attachment(detail);
                        mailMsg.Attachments.Add(attachment);
                    }
                }
                mailMsg.Subject = subject;
                mailMsg.IsBodyHtml = isBodyHtml;
                mailMsg.Body = strText;
                SendEmail(mailMsg);
                mailMsg.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// method to create unique token
        /// </summary>
        public static string GenerateToken(int length)
        {
            Random random = new Random();
            string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(characters[random.Next(characters.Length)]);
            }
            return result.ToString();
        }
        #endregion

        #region "Private Methods"

        private static void SendEmail(MailMessage mailMessage)
        {
            var client = new SmtpClient();
            client.Send(mailMessage);
        }

        #endregion



    }
}
