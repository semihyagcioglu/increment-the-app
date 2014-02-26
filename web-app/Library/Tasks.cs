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

        public static List<DataRow> SearchTask(string searchTask)
        {
            string searchQuery = @"SELECT [ID]
                                          ,[UserID]
                                          ,[TaskTitle]
                                          ,[TaskDetail]
                                          ,[Date]
                                          ,[Money]
                                          ,[Location]
                                          ,[TaskStatus]
                                      FROM [Tasks] WHERE [TaskTitle] like '%" + searchTask + "%'";

            List<DataRow> dtSearch = Library.DataBase.GetList(searchQuery);

            return dtSearch;

        }
    }
}
