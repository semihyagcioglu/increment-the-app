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
            if (Session["userId"] != null)
            {
                ProfileDetails();
            }
            
        }

        private void ProfileDetails()
        {
            int userID = int.Parse(Session["UserId"].ToString());
            string selectUser = @"Select [Name],[Surname],[Email],[Phone],[Location]                                      
                                     From [Users]                                 
                                     WHERE UserId= '" + userID + "'";

            DataTable userProfile = Library.DataBase.GetDataTable(selectUser);

            InputName.Value = userProfile.Rows[0]["Name"].ToString();
            InputSurname.Value = userProfile.Rows[0]["Surname"].ToString();
            InputEmail.Value = userProfile.Rows[0]["Email"].ToString();
            InputPhone.Value = userProfile.Rows[0]["Phone"].ToString();
            InputAdress.Value = userProfile.Rows[0]["Location"].ToString();


        }
    }
}