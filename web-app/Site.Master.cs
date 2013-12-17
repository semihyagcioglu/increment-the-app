using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace increment_the_app
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnUserIpAdress.Value = Request.ServerVariables["REMOTE_ADDR"];

            string roleId = string.Empty;
            string page = string.Empty;
            string userId = string.Empty;
            string userName = string.Empty;
            string userSurname = string.Empty;

            Guid sessionId;

            if (HttpContext.Current.Session["sessionId"] == null)
            {
                sessionId = Guid.NewGuid();
                HttpContext.Current.Session["sessionId"] = sessionId;
            }
            else
            {
                sessionId = (Guid)HttpContext.Current.Session["sessionId"];
            }
            hdnSessionId.Value = sessionId.ToString();
        }
    }
}