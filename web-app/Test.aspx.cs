using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using increment_the_app.Library;
using System.Data;

namespace increment_the_app
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dtUsers = DataBase.GetDataTable("SELECT COUNT(UserId) AS Count, GETDATE() AS Time FROM Users");

            gvUsers.DataSource = dtUsers;
            gvUsers.DataBind();
        }
    }
}