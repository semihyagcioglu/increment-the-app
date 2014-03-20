﻿using System;
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
            btnLogIn.Visible = false;
            btnSignUp.Visible = false;
           
            btnProfile.Visible = false;
            string url = Request.Url.ToString();

            if (HttpContext.Current.Session["userId"] != null)
            {
                hdnUserId.Value = HttpContext.Current.Session["userId"].ToString();
              
                btnProfile.Visible = true;
                btnMain.Visible = false;
                hdnUsername.Value = HttpContext.Current.Session["name"].ToString() + " " + HttpContext.Current.Session["surname"].ToString();
                //btnProfile.InnerText = hdnUsername.Value;
                btnProfile.InnerHtml = hdnUsername.Value;
                //imgProfile.Src = "Image.ashx?id=" + hdnUserId.Value;
            }
            else
            {
                btnSignUp.Visible = true;
                btnLogIn.Visible = true;
                Response.Redirect("Default.aspx");
            }

            //if (Session["userId"] == null)
            //{
            //    btnSignUp.Visible = true;
            //    btnLogIn.Visible = true;
            //}
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