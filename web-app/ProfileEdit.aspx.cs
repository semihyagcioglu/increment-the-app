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
                ProfileDetails(int.Parse(Session["UserId"].ToString()));
            }
            
        }

        private void ProfileDetails(int userID)
        {

            string selectUser = @"Select [Name],[Surname],[Email],[Phone],[Location],[BirthDate],[About],[Gender]                                      
                                     From [Users]                                 
                                     WHERE UserId= '" + userID + "'";

            DataTable userProfile = Library.DataBase.GetDataTable(selectUser);

            InputName.Value = userProfile.Rows[0]["Name"].ToString();
            InputSurname.Value = userProfile.Rows[0]["Surname"].ToString();
            InputEmail.Value = userProfile.Rows[0]["Email"].ToString();
            InputPhone.Value = userProfile.Rows[0]["Phone"].ToString();
            InputAdress.Value = userProfile.Rows[0]["Location"].ToString();
            InputBirtDay.Value = userProfile.Rows[0]["BirthDate"].ToString();
            InputAbout.Value = userProfile.Rows[0]["About"].ToString();

            string gender = userProfile.Rows[0]["Gender"].ToString();
            if (gender == "1")
            {
                Male.Checked = true;
            }
            else
            {
                Female.Checked = true;
            }

        }
    }
}