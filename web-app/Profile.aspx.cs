using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace increment_the_app
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProfileDetails();
            }
        }

        private void ProfileDetails()
        {
            int userID = int.Parse(Session["UserId"].ToString());
            string selectUser = @"Select [dbo].[Users]
                                   SET [Name] = @Name
                                      ,[Surname] = @Surname                                     
                                      ,[Email] = @Email
                                      ,[Gender] = @Gender
                                      ,[BirthDate] = @BirthDate                                  
                                      ,[GSM] = @Gsm                                     
                                 WHERE UserId= '"+userID+"'";

            DataTable userProfile = Library.DataBase.GetDataTable(selectUser);

            InputName.Value = userProfile.Rows[0]["Name"].ToString();
            InputSurname.Value = userProfile.Rows[0]["Surname"].ToString();
            InputEmail.Value = userProfile.Rows[0]["Email"].ToString();
            InputPhone.Value = userProfile.Rows[0]["Gsm"].ToString();
            //InputAdress.Value = userProfile.Rows[0]["Adress"].ToString();


        }
    }
}