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
            MailMessage mailMsg = new MailMessage();

            // To
            mailMsg.To.Add(new MailAddress("info@increment.com", "increment site"));

            // From
            mailMsg.From = new MailAddress("sungurtas.recep@gmail.com", "recep sungurtas");

            // Subject and multipart/alternative Body
            mailMsg.Subject = "subject";
            string text = "text body";
            string html = @"<p>html body</p>";


            // Init SmtpClient and send
            SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("azure_093dfa8238abf9d9703183d4a7c559f0@azure.com", "x4f0Zq9XO7Rj6JQ");
            smtpClient.Credentials = credentials;

            smtpClient.Send(mailMsg);

        }
    }
}