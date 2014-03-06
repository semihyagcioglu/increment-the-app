using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace increment_the_app
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString != null)
            {
                string id = Request.QueryString["id"].ToString();
                TaskDetails(id);
            }

            else
            {
                Response.Redirect("home.aspx");
            }
            
        }

        private void TaskDetails(string TaskId)
        {
            string taskDetails = @"SELECT [ID]
      ,[UserID]
      ,[TaskTopic]
      ,[TaskContent]
      ,[Date]
      ,[Money]
      ,[TaskStatus]
  FROM [Tasks]
  WHERE [ID] = '" + TaskId + "'";

            DataTable dtSearch = Library.DataBase.GetDataTable(taskDetails);
            lblTaskTitle.Text = dtSearch.Rows[0]["TaskTitle"].ToString();
            lblTaskDetails.Text = dtSearch.Rows[0]["TaskDetails"].ToString();

        }

      
    }
}