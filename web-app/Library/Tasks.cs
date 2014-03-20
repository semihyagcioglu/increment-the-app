using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace increment_the_app.Library
{
    public class Tasks
    {
        public static DataTable GetLastTask(int count)
        {
            string sql = @"SELECT TOP (" + count + @")[ID]
                                  ,[UserID] AS [Kullanıcı No]
                                  ,[TaskTitle] AS [İş]
                                  ,[TaskDetail] AS [İşin Detayı]
                                  ,[Date] AS [Tarih]
                                  ,[Location] AS [Yapılacak Yer]
                                  ,[Money] AS [İşin Ücreti]
                                  ,[TaskStatus] AS [İşin Durum]
                              FROM [Tasks]
                                   WHERE [TaskStatus] = '1' ORDER BY DESC";

            DataTable dtTasks = Library.DataBase.GetDataTable(sql);

            return dtTasks;            
        }

        public static string SearchTask(string searchTask)
        {
            string jsonData = "-1";

            string searchQuery = @"SELECT [ID]     
                                          ,[UserID]                                      
                                          ,[TaskTitle]
                                          ,[TaskDetail]                                         
                                      FROM [Tasks] WHERE [TaskTitle] like '%" + searchTask + "%'";

            DataTable dtSearch = Library.DataBase.GetDataTable(searchQuery);

            if (dtSearch.Rows.Count > 0)
            {
                jsonData = Library.Data.DataTableToJSON(dtSearch);
            }
          
            return jsonData;

        }       
        public static string GetMyTask(string userId)
        {
            string sql = @"SELECT [ID]                                  
                                  ,[TaskTitle]
                                  ,[TaskDetail]                                
                              FROM [Tasks]
                                   WHERE [TaskStatus] = '1' AND [UserID]='"+ userId +"' ORDER BY [ID] DESC";

            DataTable dtTasks = Library.DataBase.GetDataTable(sql);
            string jsonData = Library.Data.DataTableToJSON(dtTasks);

            return jsonData;
            
        }

        public static int Offer(string userId, string taskId)
        {
            int result;

            string selectOffer = @"SELECT COUNT(*) AS [Total]
                                      FROM [Offer] WHERE [UserId] = '"+userId+"' AND [TaskId] = '"+taskId+"' ";

            DataTable dt = Library.DataBase.GetDataTable(selectOffer);

            int total = int.Parse(dt.Rows[0]["Total"].ToString());

            if(total>0)
            {
                result = -1;
            }
            else
            {
                string offerInsert = @"INSERT INTO [Offer]
                                               ([UserId]
                                               ,[TaskId])
                                         VALUES
                                               ('" + userId + "','" + taskId + "')";

                result = Library.DataBase.ExecuteNonQuery(offerInsert);

            }

            return result;
        }

        public static string GetMyOffer(string userId)
        {
            string sql = @"SELECT  O.[ID]                                  
                                  ,O.[UserId]
                                  ,O.[TaskId]
                                  ,T.[ID]
                                  ,T.[UserID]                                  
                                  ,T.[TaskTitle]
                                  ,T.[TaskDetail]                             
                              FROM [Offer] AS O 
                              INNER JOIN [Tasks] AS T ON T.[Id] = O.[TaskId]
                                   WHERE O.[UserID]='" + userId + "' ORDER BY T.[ID] DESC";

            DataTable dtTasks = Library.DataBase.GetDataTable(sql);
            string jsonData = Library.Data.DataTableToJSON(dtTasks);

            return jsonData;

        }

    }
}
