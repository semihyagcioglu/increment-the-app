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
            string searchQuery = @"SELECT [ID]                                         
                                          ,[TaskTitle]
                                          ,[TaskDetail]                                         
                                      FROM [Tasks] WHERE [TaskTitle] like '%" + searchTask + "%'";

            DataTable dtSearch = Library.DataBase.GetDataTable(searchQuery);
            string jsonData = Library.Data.DataTableToJSON(dtSearch);

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
            string offerInsert = @"INSERT INTO [Offer]
                                               ([UserId]
                                               ,[TaskId])
                                         VALUES
                                               ('"+userId+"','"+taskId+"')";

            int result = Library.DataBase.ExecuteNonQuery(offerInsert);

            return result;
        }

    }
}
