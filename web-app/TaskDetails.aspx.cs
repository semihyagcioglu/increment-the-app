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
            if (Request.QueryString["id"] != null)
            {
                string TaskId = Request.QueryString["id"].ToString();
                TaskDetails(TaskId);
            }

            else
            {
                Response.Redirect("home.aspx");
            }
            
        }

        private void TaskDetails(string TaskId)
        {
            string taskDetails = @"SELECT [ID]
      ,U.[Name]
      ,T.[UserID]
      ,[TaskTitle]
      ,[TaskDetail]
      ,[Date]
      ,[Money]
      ,[TaskStatus]
  FROM [Tasks] AS T INNER JOIN [Users] AS U ON T.[UserId] = U.[UserId]
  WHERE [ID] = '" + TaskId + "'";

            DataTable dtSearch = Library.DataBase.GetDataTable(taskDetails);
            taskTitle.Text = dtSearch.Rows[0]["TaskTitle"].ToString();
            lblTaskDetails.Text = dtSearch.Rows[0]["TaskDetail"].ToString();
            lblPrice.Text = dtSearch.Rows[0]["Money"].ToString();
            lblUser.Text = dtSearch.Rows[0]["Name"].ToString();

        }

      
    }
}