using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

using SendGridMail;


namespace increment_the_app
{
    public partial class sendmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.sendgrid.net");

            mail.From = new MailAddress("increment@increment.com");
            mail.To.Add("sungurtas.recep@gmail.com");
            mail.Subject = "deneme";
            mail.Body = "Report";
       
            SmtpServer.Port = 25;
            SmtpServer.Credentials = new System.Net.NetworkCredential("azure_093dfa8238abf9d9703183d4a7c559f0@azure.com", "x4f0Zq9XO7Rj6JQ");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

        }
    }
}