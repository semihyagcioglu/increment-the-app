using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace increment_the_app
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Library.DataBase.GetConnectionString());
            conn.Open();

            string sql = @"SELECT [ID]
                                  ,[UserID] AS [Kullanıcı No]
                                  ,[TaskTitle] AS [İş]
                                  ,[TaskDetail] AS [İşin Detayı]
                                  ,[Date] AS [Tarih]
                                  ,[Location] AS [Yapılacak Yer]
                                  ,[Money] AS [İşin Ücreti]
                                  ,[TaskStatus] AS [İşin Durum]
                              FROM [Tasks]
                                   WHERE [TaskStatus] = 'Aktif' ORDER BY ID";                                   

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();

            adp.Fill(dt);
            gvOnlineTask.DataSource = dt;
            gvOnlineTask.DataBind();    
    
      }

        protected void lvTask_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}