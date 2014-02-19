using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace increment_the_app
{
    public partial class PostTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SelectCity();
            }
        }

        private void SelectCity()
        {
            try
            {
                string city = @"SELECT [Id]
                                  ,[Name]
                              FROM [City]";

                DataTable dtCity = Library.DataBase.GetDataTable(city);
                Library.UI.Bind2Ddl(ddlLocation, dtCity, "Name", "Id");
            }
            catch
            {

            }
        }
    }
}