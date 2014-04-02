﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Net.Mime;
using SendGridMail;


namespace increment_the_app.Library
{
    public class Users
    {

        public static byte[] GetBlobFromDataBase(string userId)
        {
            int id = Convert.ToInt32(userId);
            string sqlQuery = @"SELECT [Image]  
                                      FROM [Users]
                                      WHERE UserId = '" + id + "'";
            byte[] Image = (byte[])Library.DataBase.ExecuteScalar(sqlQuery);
            return Image;

        }

        public static string ChangePicture(byte[] myimage, string id)
        {
            int userId = Convert.ToInt32(id);
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0]= Library.DataBase.SetImgParameter("@img", SqlDbType.Image, myimage.Length,myimage);
            string sqlQuery = @"UPDATE [Users] SET [Image] = @img WHERE UserId='"+id+"'";
            Library.DataBase.ExecuteSqlWithParameters(sqlQuery,parameters);    
            return "sucsess";
        }




        public static int ResetPassword(string email)
        {
            int returnedResult = 0;

            string mail = string.Empty;
            string quary = @"SELECT [Email]
                                  FROM [Users]
                                  WHERE Email ='" + email + "'";

            DataTable dt = Library.DataBase.GetDataTable(quary);
            mail = dt.Rows.Count.ToString();
            //mail = dt.Rows[0]["Email"].ToString();

            if (email.Length > 0)
            {
                Random rand = new Random();
                int password = rand.Next(1000, 1001);

                string sqlQuery = @"UPDATE [users]
   SET [Password] = '" + password + "'WHERE Email='" + email + "'";

                int result = Library.DataBase.ExecuteNonQuery(sqlQuery);

                //MailMessage mailMsg = new MailMessage();

                //// To
                //mailMsg.To.Add(new MailAddress("sungurtas.recep@gmail.com", "User"));

                //// From
                //mailMsg.From = new MailAddress("no-reply@increment.com", "increment team");

                //// Subject and multipart/alternative Body
                //mailMsg.Subject = "Şifre Sıfırlama";
                //string text = "Yeni şifreniz " + password + "  .Üçüncü kişiler ile paylaşmayınız";
                //string html = @"<p>html body</p>";
                //mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
                //mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

                //// Init SmtpClient and send
                //SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(25));
                //System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("azure_093dfa8238abf9d9703183d4a7c559f0@azure.com", "x4f0Zq9XO7Rj6JQ");
                //smtpClient.Credentials = credentials;

                //smtpClient.Send(mailMsg);

                SendGrid myMessage = SendGrid.GetInstance();
                myMessage.AddTo("sungurtas.recep@gmail.com");
                myMessage.From = new MailAddress("john@example.com", "John Smith");
                myMessage.Subject = "Testing the SendGrid Library";
                myMessage.Text = "Hello World!";

                // Create credentials, specifying your user name and password.
                var credentials = new NetworkCredential("azure_093dfa8238abf9d9703183d4a7c559f0@azure.com", "x4f0Zq9XO7Rj6JQ");

                // Create an Web transport for sending email.
                var transportWeb = Web.GetInstance(credentials);

                // Send the email.
                transportWeb.Deliver(myMessage);

                if (result > 0)
                {
                    

                    returnedResult = 1;
                }
                else
                {
                    //hata bölümü

                    returnedResult = -1;
                }

            }

            return returnedResult;
        }

        public static int LogIn(string email, string password)
        {
            int result = 0;

            string userId = string.Empty;
            string name = string.Empty;
            string surname = string.Empty;
            string uniqueId = string.Empty;

            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = DataBase.SetParameter("@email", SqlDbType.NVarChar, 80, "Input", email);
            parameters[1] = DataBase.SetParameter("@password", SqlDbType.NVarChar, 16, "Input", password);

            string queryUser = @" SELECT [UserId], [Name], [Surname],[UniqueId]
                                  FROM [Users]
                                  WHERE (Email = @email) AND ([Password] = @password)";

            try
            {
                DataTable dtUserInfo = DataBase.ExecuteSqlWithParameters(queryUser, parameters);
                if (dtUserInfo.Rows.Count > 0)
                {
                    DataRow drUserInfo = dtUserInfo.Rows[0];

                    //Get user specific info
                    userId = drUserInfo["UserId"].ToString();
                    name = drUserInfo["Name"].ToString();
                    surname = drUserInfo["Surname"].ToString();
                    uniqueId = drUserInfo["UniqueId"].ToString();

                    //Set session timeout to 3 hours
                    HttpContext.Current.Session.Timeout = 180;

                    //Set session vars
                    HttpContext.Current.Session["userId"] = userId;
                    HttpContext.Current.Session["name"] = name;
                    HttpContext.Current.Session["surname"] = surname;
                    HttpContext.Current.Session["LoginType"] = "1";
                    HttpContext.Current.Session["uniqueID"] = uniqueId;

                    //Logs.UpdateUserAccessLog(userId);
                    //Logs.CreateUserLoginLog(userId);

                    result = int.Parse(userId);

                }
            }
            catch (Exception ex)
            {
                //Exception trying to get user related info from "Users" Table
                result = -1;
                string ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
                Logs.InsertErrorLog(ex, System.Web.HttpContext.Current.Request.Url.AbsoluteUri, userId, ip, queryUser);
            }

            return result;

        }

        public static string LogOut(string userId)
        {
            string result = string.Empty;
            //the kill sesion

            try
            {
                HttpContext.Current.Session.Abandon();
                //Logs.UpdateUserLoginLog(userId);
                Logs.UpdateUserLoginLog(userId);

            }

            catch (Exception ex)
            {
                string ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
                Logs.InsertErrorLog(ex, System.Web.HttpContext.Current.Request.Url.AbsoluteUri, userId, ip, string.Empty);
                //ann erroroccured trying to abadon the session
                result = "ERROR_USER_SESSION_NOT_DESTROYED";
            }
            //check info from database
            return result;
        }

        public static string CheckIfIsFirstTime(string userId)
        {
            //check account if first time logged on
            string result = string.Empty;

            result = "ERROR_USER_WRONG_ID";
            string query = "SELECT IsFirstTime FROM [Users] WHERE (UserId = '" + userId + "'); UPDATE [Users] Set IsFirstTime = 0  WHERE (UserId = '" + userId + "')";

            try
            {
                DataTable dtUserInfo = DataBase.GetDataTable(query);

                if (dtUserInfo.Rows.Count > 0)
                {
                    DataRow dr = dtUserInfo.Rows[0];
                    result = dr["IsFirstTime"].ToString();
                }

            }
            catch (Exception exx)
            {
                result = "-1";
                string ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
                Logs.InsertErrorLog(exx, "Users.cs/CheckIfIsFirstTime", userId, ip, query);
            }


            return result;
        }

        public static string LoginWithFacebook(string facebookId, string email, string firstName, string lastName, string city, string sex, string pic, string bday)
        {
            //use facebook for connect
            return " ";
        }
        public static string UpdateUser(string userId, string name, string surname, string email, string address, string phone, string gender, string birthdate, string about)
        {
            //update user info
            SqlParameter[] parameters = new SqlParameter[9];

            parameters[0] = DataBase.SetParameter("@Name", SqlDbType.NVarChar, 80, "Input", name);
            parameters[1] = DataBase.SetParameter("@Surname", SqlDbType.NVarChar, 80, "Input", surname);
            parameters[2] = DataBase.SetParameter("@Email", SqlDbType.NVarChar, 80, "Input", email);
            parameters[3] = DataBase.SetParameter("@Address", SqlDbType.NVarChar, 250, "Input", address);
            parameters[4] = DataBase.SetParameter("@Phone", SqlDbType.NVarChar, 100, "Input", phone);
            parameters[5] = DataBase.SetParameter("@Gender", SqlDbType.NVarChar, 50, "Input", gender);
            parameters[6] = DataBase.SetParameter("@BirthDate", SqlDbType.NVarChar, 50, "Input", birthdate);
            parameters[7] = DataBase.SetParameter("@About", SqlDbType.NVarChar, 350, "Input", about);
            parameters[8] = DataBase.SetParameter("@UserId", SqlDbType.Int, 32, "Input", userId);

            string sqlUpdateUser = @"UPDATE [Users]
                                   SET [Name] = @Name
                                      ,[Surname] = @Surname                                     
                                      ,[Email] = @Email
                                      ,[Location] = @Address  
                                      ,[Gender] = @Gender
                                      ,[BirthDate] = @BirthDate                                  
                                      ,[Phone] = @Phone  
                                      ,[About] = @About                                   
                                 WHERE UserId= @UserId";

            DataBase.ExecuteSqlWithParameters(sqlUpdateUser, parameters);

            return "update sucsessfull";
        }

        public static int CreateNewUser(string userName, string userSurname, string email, string password)
        {
            int value = 0;

            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = DataBase.SetParameter("@userName", SqlDbType.NVarChar, 80, "Input", userName);
            parameters[1] = DataBase.SetParameter("@userSurname", SqlDbType.NVarChar, 80, "Input", userSurname);
            parameters[2] = DataBase.SetParameter("@email", SqlDbType.NVarChar, 80, "Input", email);
            parameters[3] = DataBase.SetParameter("@password", SqlDbType.NVarChar, 16, "Input", password);
            parameters[4] = DataBase.SetParameter("@value", SqlDbType.Int, 32, "Output", value);

            int result = DataBase.ExecuteStoredProcedure("spInsertUsers", parameters, "@value");
            return result;

            //            string returnValue = string.Empty;
            //            string hashGuid = string.Empty;
            //            string message = string.Empty;
            //            string query = string.Empty;

            //            string ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();

            //            Guid uniqueId;

            //            string errorState = "-1";

            //            if (CheckEmail(email) == "-1")
            //            {

            //                uniqueId = Guid.NewGuid();

            //                string sqlInsertUser = @"	DECLARE @UserId INT
            //        
            //        	                                        INSERT INTO [Users] (Name,Surname,[User].[Password],Email,IsFirstTime,IsActive,TotalAccessCount,UniqueId,CreatedAt)
            //                                                    VALUES ('" + userName + "','" + userSurname + "','" + password + "','" + email + @"',1,1,0,'" + uniqueId + @"',GETDATE())
            //                                                	
            //        	                                        SELECT @UserId = UserId 
            //        	                                        FROM [Users]
            //        	                                        WHERE UniqueId = '" + uniqueId + @"'
            //                                                	
            //        	                                        INSERT INTO UserLoginTypes (UserId,LoginType)
            //        	                                        VALUES
            //        	                                        (@UserId,'1') 
            //        
            //                                                    INSERT INTO [MailList]
            //                                                    ([Name],[Surname],[Email],[UniqueId],[UserId],[BirthDate],[Gender],[GSM],[Location],[Source],[MailSent],[Unsubscribe],[CreatedAt])
            //                                                    SELECT [Name],[Surname],[Email],[UniqueId],UserId,[BirthDate],[Gender],[GSM],[City],'increment',0,0,GETDATE()
            //                                                    FROM Users
            //                                                    WHERE UserId = @UserId AND [Email] NOT IN (SELECT [Email] FROM [MailList]) ";


            //                try
            //                {
            //                    DataBase.ExecuteNonQuery(sqlInsertUser);
            //                }
            //                catch (Exception exx)
            //                {

            //                    Logs.InsertErrorLog(exx, "wsUser.asmx.cs/CreateNewUser", uniqueId.ToString(), ip, sqlInsertUser);
            //                    errorState = "1";
            //                }

            //                if (errorState == "-1")
            //                {

            //                    hashGuid = Functions.MD5Encode(uniqueId.ToString());
            //                    try
            //                    {
            //                        Mail.SendTemplateMail(string.Empty, uniqueId.ToString(), string.Empty, string.Empty, Resources.Mail.MAIL_TEMPLATE_ACTIVATION.ToString(), email, Resources.GlobalVariables.PROJECT_CONTACT_MAIL_ADDRESS, string.Empty, string.Empty);
            //                    }
            //                    catch (Exception ex)
            //                    {

            //                        Logs.InsertErrorLog(ex, System.Web.HttpContext.Current.Request.Url.AbsoluteUri.ToString(), uniqueId.ToString(), ip, string.Empty);

            //                        query = "UPDATE [Users] WHERE UniqueId='" + uniqueId + "' Set IsValidated = -1";
            //                        DataBase.ExecuteNonQuery(query);

            //                    }

            //                    returnValue = LogIn(email, password);

            //                    if (returnValue == Resources.CustomCodes.ERROR_GENERIC.ToString())
            //                    {
            //                        return "-2";
            //                    }
            //                    else
            //                    {
            //                        return uniqueId.ToString();
            //                    }
            //                }
            //                else if (errorState == "1")
            //                {
            //                    return "-2";
            //                }

            //            }

            //            return "-1";
        }

        public static string CheckEmail(string email)
        {
            //check if email in use
            return "";
        }
        public static string CheckUserID(string guid)
        {
            return "";
        }
        public static string SendPassword(string email)
        {
            return "";
        }
        public static string GetUserInformation(string userId, string guid, string email)
        {
            return "";
        }
        public static string UpdateUserPassword(string userId, string password, string oldPassword)
        {
            return "";
        }
        public static string Unsubscribe(string userId, string email)
        {
            string sqlUnsubscribe = string.Empty;

            if (string.IsNullOrEmpty(userId) == false)
            {
                sqlUnsubscribe = @" UPDATE [MailList]
                                        SET [Unsubscribe] = 1
                                        WHERE [UserId] = " + userId;

            }
            else if (string.IsNullOrEmpty(email) == false)
            {
                sqlUnsubscribe = @" UPDATE [MailList]
                                        SET [Unsubscribe] = 1
                                        WHERE [Email] = '" + email + "' ";
            }

            object tmp = null;
            string retVal = string.Empty;

            try
            {
                tmp = DataBase.ExecuteNonQuery(sqlUnsubscribe);
            }
            catch (Exception exx)
            {
                string ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
                Logs.InsertErrorLog(exx, "Users.cs/Unsubscribe", string.Empty, ip, sqlUnsubscribe);
                retVal = "-1";
            }

            if (tmp != null)
            {
                retVal = tmp.ToString();
            }
            else
            {
                retVal = "-1";
            }
            return retVal;
        }
        public static string GetRole(int userId)
        {
            string sqlGetRole = @"SELECT [Name]
                                  FROM [Roles] R
                                  INNER JOIN Users U  ON U.RoleId = R.RoleId
                                   WHERE U.UserId = '" + userId + "' ";

            Object roleName = DataBase.ExecuteScalar(sqlGetRole);
            if (roleName != null)
            {
                return roleName.ToString();
            }
            else
            {
                return "customer";//fix
            }
        }

        public static string Subscribe(string userId, string email)
        {
            string sqlSubscribe = string.Empty;

            if (string.IsNullOrEmpty(userId) == false)
            {
                sqlSubscribe = @" INSERT INTO [MailList]([Name],[Surname],[Email],[UniqueId],[UserId],[BirthDate],[Gender],[GSM],[Location],[Source],[MailSent],[Unsubscribe],[CreatedAt])
                                      SELECT [Name],[Surname],[Email],[UniqueId],UserId,[BirthDate],[Gender],[GSM],[City],'facebook',0,0,GETDATE()
                                      FROM Users
                                      WHERE UserId = " + userId + " AND [Email] NOT IN (SELECT [Email] FROM [MailList]) ";

            }
            else if (string.IsNullOrEmpty(email) == false)
            {
                sqlSubscribe = @"   DECLARE @HasSubscribed INT
  
                                        SELECT @HasSubscribed=COUNT(*)
                                        FROM MailList
                                        WHERE Email = '" + email + @"'
                                          
                                        IF @HasSubscribed = 0
                                        BEGIN
	                                         INSERT INTO [MailList]([Email],[Source],[MailSent],[Unsubscribe],[CreatedAt])
										                                          VALUES( '" + email + @"','Increment',0,0,GETDATE() )
                                        END ";
            }

            object tmp = null;
            string retVal = string.Empty;

            try
            {
                tmp = DataBase.ExecuteNonQuery(sqlSubscribe);
            }
            catch (Exception exx)
            {
                string ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
                Logs.InsertErrorLog(exx, "Users.cs/Subscribe", string.Empty, ip, sqlSubscribe);
                retVal = "-1";
            }

            if (tmp != null)
            {
                retVal = tmp.ToString();
            }
            else
            {
                retVal = "-1";
            }
            return retVal;
        }

        public static int PostTask(string userId, string taskTitle, string taskDetail, string privateNotes, string date, string hour, string location, string money)
        {

            SqlParameter[] parameters = new SqlParameter[9];
            parameters[0] = DataBase.SetParameter("@userId", SqlDbType.Int, 32, "Input", userId);
            parameters[1] = DataBase.SetParameter("@taskTitle", SqlDbType.NVarChar, 50, "Input", taskTitle);
            parameters[2] = DataBase.SetParameter("@taskDetail", SqlDbType.NVarChar, 350, "Input", taskDetail);
            parameters[3] = DataBase.SetParameter("@privateNotes", SqlDbType.NVarChar, 350, "Input", privateNotes);
            parameters[4] = DataBase.SetParameter("@date", SqlDbType.Date, 0, "Input", date);
            parameters[5] = DataBase.SetParameter("@hour", SqlDbType.NVarChar, 10, "Input", hour);
            parameters[6] = DataBase.SetParameter("@location", SqlDbType.NVarChar, 50, "Input", location);
            parameters[7] = DataBase.SetParameter("@money", SqlDbType.Money, 0, "Input", money);
            parameters[8] = DataBase.SetParameter("@taskStatus", SqlDbType.Int, 32, "Input", "1");

            string taskQuery = @"INSERT INTO [Tasks]
                                       ([UserID]
                                       ,[TaskTitle]
                                       ,[TaskDetail]
                                       ,[PrivateNotes]
                                       ,[Date]
                                       ,[Hour] 
                                       ,[Location]
                                       ,[Money]
                                       ,[TaskStatus])
                                 VALUES
                                       (@userId
                                       ,@taskTitle
                                       ,@taskDetail
                                       ,@privateNotes
                                       ,@date
                                       ,@hour
                                       ,@location
                                       ,@money
                                       ,@taskStatus)";

            int result = DataBase.ExecuteNonQueryWithParameters(taskQuery, parameters);

            return result;
        }

        public static int ChangePassword(string password, string userId)
        {
            string sqlChangePassword = @" UPDATE [Users]
                                        SET [Password] = " + password + @"
                                        WHERE [UserId] = " + userId + "";

            DataBase.ExecuteNonQuery(sqlChangePassword);

            return 1;

        }

        public static int InsertTrafficSource(string via, string source)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = DataBase.SetParameter("@via", SqlDbType.NVarChar, 150, "Input", via);
            parameters[1] = DataBase.SetParameter("@source", SqlDbType.NVarChar, 150, "Input", source);
            string trafficQuery = @"INSERT INTO [TrafficSource]
                                       ([Via]
                                       ,[Source]
                                       )
                                 VALUES
                                       (@via
                                       ,@source)";
            int result = DataBase.ExecuteNonQueryWithParameters(trafficQuery, parameters);

            return result;

        }

    }
}