using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Increment
{
    class Mail
    {
        public static string SendMail(string to, string from, string cc, string bcc, string subject, string body)
        {
            string result = string.Empty;
            string userId = string.Empty;
            string smtpServer = GlobalVariables.SMTP_SERVER;

            int smtpPort = 0;
            int isSent = 0;
            try
            {
                smtpPort = int.Parse(GlobalVariables.SMTP_PORT);

                NetworkCredential nc = new NetworkCredential(GlobalVariables.SMTP_USER, GlobalVariables.SMTP_PASSWORD);
                SmtpClient mySmtpClient = new SmtpClient(GlobalVariables.SMTP_SERVER.ToString(), int.Parse(GlobalVariables.SMTP_PORT));
                //mySmtpClient.UseDefaultCredentials = true;
                mySmtpClient.Credentials = nc;

                MailMessage message = new MailMessage();
                message.IsBodyHtml = true;

                // Add TO recipient.
                message.To.Add(new MailAddress(to, to)); //address

                message.From = new MailAddress(from, from);
                message.Sender = new MailAddress(from, from);

                // Add CC recipient.
                if (!string.IsNullOrEmpty(cc))
                {
                    message.CC.Add(new MailAddress(cc, cc));
                }

                // Add BCC recipient.
                if (!string.IsNullOrEmpty(bcc))
                {
                    message.Bcc.Add(new MailAddress(bcc, bcc));
                }

                message.Subject = subject;
                message.Body = body;
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = true;

                mySmtpClient.Send(message);

                isSent = 1;

                result = "SUCCESS";

                if (String.IsNullOrEmpty(userId))
                {
                    userId = "NULL";
                }
                // Insert into database for every mails sent with also the result

            }
            catch (Exception exx)
            {
                isSent = 0;
                result = "ERROR_MAIL_SEND";

            }

            string sql = @" INSERT INTO [MailLogs]
                                   ([Date]
                                   ,[Subject]
                                   ,[Body]
                                   ,[From]
                                   ,[To]
                                   ,[Cc]
                                   ,[Bcc]
                                   ,[IsSent])
                             VALUES
                                   (GETDATE()
                                   ,'" + subject + @"'
                                   ,'" + DataBase.CleanString(body) + @"'
                                   ,'" + from + @"'
                                   ,'" + to + @"'
                                   ,'" + cc + @"'
                                   ,'" + bcc + @"'
                                   ," + isSent + @") ";

            try
            {
                DataBase.ExecuteNonQuery(sql);
            }
            catch (Exception exc)
            {
                string ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
                Logs.InsertErrorLog(exc, System.Web.HttpContext.Current.Request.Url.AbsoluteUri, userId, ip, sql);
            }

            return result;
        }
    }
}
