using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Services;
using System.Web.UI.WebControls;

namespace increment_the_app
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        //[WebMethod]
        //private void SearchTask2Json(string task)
        //{
        //   DataTable dtSearchTask = Library.Data.JSONToDataTable(task);
        //   int searchTotal = dtSearchTask.Rows.Count;
                      
        //    for (int i = 0; i < searchTotal; i++)
        //   {
        //       ImageButton imgBtn = new ImageButton();
        //       imgBtn.ID = i.ToString();
        //       imgBtn.ImageUrl = "/img/poster.png";
        //       imgBtn.Width = 50;
        //       imgBtn.Height = 50;

              

        //       HyperLink hl = new HyperLink();
        //       hl.ID = i.ToString();
        //       hl.Text = dtSearchTask.Rows[i]["TaskTitle"].ToString();

        //       Label lbl = new Label();
        //       lbl.ID = i.ToString();
        //       lbl.Text = dtSearchTask.Rows[i]["TaskDetail"].ToString()+"<br /> <hr />";



        //       pnlSearchTask.Controls.Add(imgBtn);
        //       pnlSearchTask.Controls.Add(hl);
        //       pnlSearchTask.Controls.Add(lbl);

        //   }
        
        //}
    }
}