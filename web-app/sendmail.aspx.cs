using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Net.Mime;


using SendGridMail;


namespace increment_the_app
{
    public partial class sendmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }


        protected void btnSend_Click(object sender, EventArgs e)
        {
            MailMessage mailMsg = new MailMessage();

            // To
            mailMsg.To.Add(new MailAddress(txtToMail.Text, txtToName.Text));

            // From
            mailMsg.From = new MailAddress(txtFromMail.Text, txtFromName.Text);

            // Subject and multipart/alternative Body
            mailMsg.Subject = txtSubject.Text;
            string text = txtText.Text;
            //string html = @"<p>html body</p>";
            mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
            //mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

            // Init SmtpClient and send
            SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(25));
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("azure_093dfa8238abf9d9703183d4a7c559f0@azure.com", "x4f0Zq9XO7Rj6JQ");
            smtpClient.Credentials = credentials;

            smtpClient.Send(mailMsg);
        }
    }
}