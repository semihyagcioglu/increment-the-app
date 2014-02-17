using increment_the_app.Library;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace increment_the_app.Library
{
    class Logs
    {
        public static void InsertErrorLog(Exception ex, string uri, string userId, string ip, string additionalInfo)
        {
            // Get exception message
            string exceptionMessage = DataBase.CleanString(ex.Message);
            exceptionMessage += "\n" + DataBase.CleanString(ex.StackTrace);
            // Get the page that exception occured

            object objectUserIdDB = (object)userId;
            object objectAdditionalInfoDB = (object)additionalInfo;
            object objectUriDB = (object)uri;
            object objectIpDB = (object)ip;

            objectUserIdDB = string.IsNullOrEmpty(userId) == true ? DBNull.Value : objectUserIdDB;
            objectAdditionalInfoDB = string.IsNullOrEmpty(additionalInfo) == true ? DBNull.Value : objectAdditionalInfoDB;
            objectUriDB = string.IsNullOrEmpty(uri) == true ? DBNull.Value : objectUriDB;
            objectIpDB = string.IsNullOrEmpty(ip) == true ? DBNull.Value : objectIpDB;

            SqlParameter[] parameters = new SqlParameter[5];

            parameters[0] = DataBase.SetParameter("@page", SqlDbType.NVarChar, 4000, "Input", objectUriDB);
            parameters[1] = DataBase.SetParameter("@exception", SqlDbType.NVarChar, 4000, "Input", exceptionMessage);
            parameters[2] = DataBase.SetParameter("@userId", SqlDbType.Int, 32, "Input", objectUserIdDB);
            parameters[3] = DataBase.SetParameter("@ip", SqlDbType.NVarChar, 20, "Input", objectIpDB);
            parameters[4] = DataBase.SetParameter("@additionalInfo", SqlDbType.NVarChar, 4000, "Input", objectAdditionalInfoDB);

            string sqlInsertErrorLog = @" INSERT INTO ErrorLogs ([Page],[Exception],[Date],[UserId],[Ip],[AdditionalInfo],[IsClosed]) 
                                          VALUES (@page,@exception,GETDATE(),@userId,@ip,@additionalInfo,0) ";

            DataBase.ExecuteSqlWithParameters(sqlInsertErrorLog, parameters);

            //Mail.SendMail(GlobalVariables.SUPPORT_MAIL, GlobalVariables.PROJECT_CONTACT_MAIL_ADDRESS, string.Empty, string.Empty, GlobalVariables.PROJECT_NAME + " - ERRORLOG", uri + " <br><br> " + exceptionMessage);
        }


        public static string GetErrorMessage(Exception ex)
        {
            StringBuilder msg = new StringBuilder();
            BuildErrorMessage(ex, ref msg);

            msg.Append("\n");
            msg.Append(ex.StackTrace);

            return msg.ToString();
        }

        private static void BuildErrorMessage(Exception ex, ref StringBuilder msg)
        {
            if (ex != null)
            {
                msg.Append(ex.Message);
                msg.Append("\n");
                if (ex.InnerException != null)
                {
                    BuildErrorMessage(ex.InnerException, ref msg);
                }
            }
        }

        public static string InsertSupportLog(string userId, string supportMessage)
        {

            object objectUserIdDB = (object)userId;
            object objectSupportMessageDB = (object)supportMessage;

            objectUserIdDB = string.IsNullOrEmpty(userId) == true ? DBNull.Value : objectUserIdDB;
            objectSupportMessageDB = string.IsNullOrEmpty(supportMessage) == true ? DBNull.Value : objectSupportMessageDB;

            SqlParameter[] parameters = new SqlParameter[2];

            parameters[0] = DataBase.SetParameter("@userId", SqlDbType.Int, 32, "Input", objectUserIdDB);
            parameters[1] = DataBase.SetParameter("@supportMessage", SqlDbType.NVarChar, 4000, "Input", objectSupportMessageDB);

            string sqlInsertSupportLog = @" INSERT INTO [SupportLogs]([UserId],[SupportMessage],[Date],[IsClosed])
                                            VALUES
                                            (@userId,@supportMessage,GETDATE(),0) ";


            string retVal = string.Empty;

            try
            {
                DataBase.ExecuteSqlWithParameters(sqlInsertSupportLog, parameters);
                retVal = "1";
            }
            catch (Exception exx)
            {
                string ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
                InsertErrorLog(exx, "Logs.cs/InsertSupportLog", userId, ip, sqlInsertSupportLog);
                retVal = "-1";

            }
            return retVal;
        }

        public static string InsertActionLog(string userId, string page, string ip, Guid sessionId)
        {
            ArrayList arlActionVariables = GetActionVariablesFromUrl(page);

            // arlActionVariables[0] -> actionTable
            // arlActionVariables[1] -> actionField
            // arlActionVariables[2] -> actionValue
            // arlActionVariables[3] -> actionContentField

            object objectUserIdDB = (object)userId;

            objectUserIdDB = string.IsNullOrEmpty(userId) == true ? DBNull.Value : objectUserIdDB;
            arlActionVariables[0] = string.IsNullOrEmpty(arlActionVariables[0].ToString()) == true ? DBNull.Value : arlActionVariables[0];
            arlActionVariables[1] = string.IsNullOrEmpty(arlActionVariables[1].ToString()) == true ? DBNull.Value : arlActionVariables[1];
            arlActionVariables[2] = string.IsNullOrEmpty(arlActionVariables[2].ToString()) == true ? DBNull.Value : arlActionVariables[2];
            arlActionVariables[3] = string.IsNullOrEmpty(arlActionVariables[3].ToString()) == true ? DBNull.Value : arlActionVariables[3];

            SqlParameter[] parameters = new SqlParameter[8];

            parameters[0] = DataBase.SetParameter("@userId", SqlDbType.Int, 32, "Input", objectUserIdDB);
            parameters[1] = DataBase.SetParameter("@pageName", SqlDbType.VarChar, 150, "Input", page);
            parameters[2] = DataBase.SetParameter("@actionTable", SqlDbType.NVarChar, 50, "Input", arlActionVariables[0]);
            parameters[3] = DataBase.SetParameter("@actionField", SqlDbType.NVarChar, 50, "Input", arlActionVariables[1]);
            parameters[4] = DataBase.SetParameter("@actionValue", SqlDbType.NVarChar, 50, "Input", arlActionVariables[2]);
            parameters[5] = DataBase.SetParameter("@actionContentField", SqlDbType.NVarChar, 50, "Input", arlActionVariables[3]);
            parameters[6] = DataBase.SetParameter("@ip", SqlDbType.NVarChar, 15, "Input", ip);
            parameters[7] = DataBase.SetParameter("@sessionId", SqlDbType.UniqueIdentifier, 32, "Input", sessionId);

            UpdateActionLog(userId, sessionId);
            string sqlUpdatePageIn = @" INSERT INTO [ActionLogs]
                                        ([UserId],[PageName],[ActionTable],[ActionField],[ActionValue],[ActionContentField],[ActionTime],[Ip],[SessionId])
                                        VALUES                                        (@userId,@pageName,@actionTable,@actionField,@actionValue,@actionContentField,GETDATE(),@ip,@sessionId) ";

            string retVal;

            try
            {
                DataBase.ExecuteSqlWithParameters(sqlUpdatePageIn, parameters);
                retVal = "1";
            }
            catch (Exception exx)
            {
                Logs.InsertErrorLog(exx, "wsUser.asmx.cs/InsertActionLog", userId, ip, sqlUpdatePageIn);
                retVal = "-1";
            }

            return retVal;
        }

        public static string UpdateUserLoginLog(string userId)
        {
           // Will be updated
            return userId;
        }

        public static string UpdateActionLog(string userId, Guid sessionId)
        {

            object objectUserIdDB = (object)userId;

            objectUserIdDB = string.IsNullOrEmpty(userId) == true ? DBNull.Value : objectUserIdDB;

            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = DataBase.SetParameter("@userId", SqlDbType.Int, 32, "Input", objectUserIdDB);
            parameters[1] = DataBase.SetParameter("@sessionId", SqlDbType.UniqueIdentifier, 32, "Input", sessionId);

            string sqlUpdatePageOut = @"UPDATE [ActionLogs]
                                        SET [Milliseconds] = CONVERT(INT,DATEDIFF ( millisecond , ActionTime , GETDATE())) ,[OriginalMilliseconds] = CONVERT(INT,DATEDIFF ( millisecond , ActionTime , GETDATE())), [Minutes] =  CAST( CAST(DATEDIFF ( millisecond , ActionTime , GETDATE() ) AS FLOAT)/60000 AS DECIMAL(18,2))
                                        WHERE ObjectId IN (
                                                           SELECT ObjectId FROM ActionLogs 
							                               WHERE ( UserId = @userId OR [SessionId]= @sessionId ) AND Milliseconds IS NULL AND Minutes IS NULL 
                                                           ) 
                                        
                                        IF @userId IS NOT NULL 
                                        BEGIN

                                            UPDATE [ActionLogs]
                                            SET UserId = @userId 
                                            WHERE [SessionId]= @sessionId AND UserId IS NULL 

                                        END ";

            string retVal;

            try
            {
                DataBase.ExecuteSqlWithParameters(sqlUpdatePageOut, parameters);
                retVal = "1";
            }
            catch (Exception exx)
            {
                string ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
                Logs.InsertErrorLog(exx, "wsUser.asmx.cs/UpdateActionLog", userId, ip, sqlUpdatePageOut);
                retVal = "-1";
            }
            return retVal;

        }

        private static ArrayList GetActionVariablesFromUrl(string url)
        {
            ArrayList arlActionVariables = new ArrayList();

            string actionTable = string.Empty;//Table name
            string actionField = string.Empty;//Column name
            string actionValue = string.Empty;//Column value
            string actionContentField = string.Empty;//Display column name in reports

            string tmp;

            if (url.Contains("?") == true)
            {
                tmp = url.Substring(url.IndexOf("?"), url.Length - url.IndexOf("?"));

                NameValueCollection nvcActionParameters = HttpUtility.ParseQueryString(tmp);

                for (int i = 0; i < nvcActionParameters.Count; i++)
                {
                    if (nvcActionParameters.Keys[i].Equals("vId"))
                    {
                        actionField = "ContentId";
                        actionValue = Crypto.MD5Decode(nvcActionParameters[i]).Split('-')[0]; ;
                        actionTable = "Contents";
                        actionContentField = "Name";

                        break;
                    }

                    else if (nvcActionParameters.Keys[i].Equals("filter"))
                    {
                        actionField = "Filter";
                        actionValue = Crypto.MD5Decode(nvcActionParameters[i]);
                        actionTable = "Filters";
                        actionContentField = "Name";

                        break;
                    }
                }
            }

            arlActionVariables.Add(actionTable);
            arlActionVariables.Add(actionField);
            arlActionVariables.Add(actionValue);
            arlActionVariables.Add(actionContentField);

            return arlActionVariables;
        }

       
    }
}
