using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace increment_the_app
{
    public partial class ProfileEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] != null)
            {
                ProfileView(Session["UserId"].ToString());
            }
        }

        private void ProfileView(string userId)
        {
            string selectUser = @"Select [Name] + ' ' +[Surname] AS [UserName]
                                        ,[Email]
                                        ,[Phone]
                                        ,[Location]
                                        ,[BirthDate]
                                        ,[About]                                      
                                     From [Users]                                 
                                     WHERE UserId= '" + userId + "'";

            DataTable userProfile = Library.DataBase.GetDataTable(selectUser);

            hdName.InnerText = userProfile.Rows[0]["UserName"].ToString();
            lblName.InnerText = userProfile.Rows[0]["UserName"].ToString();
            lblEmail.InnerText = userProfile.Rows[0]["Email"].ToString();
            lblBirthDate.InnerText = userProfile.Rows[0]["BirthDate"].ToString();
            lblAddress.InnerText = userProfile.Rows[0]["Location"].ToString();
            lblPhone.InnerText = userProfile.Rows[0]["Phone"].ToString();
            lblAbout.InnerText = userProfile.Rows[0]["About"].ToString();

        }
    }
}