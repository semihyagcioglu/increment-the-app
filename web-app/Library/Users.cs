using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace increment_the_app.Library
{
    public class Users
    {
        public static string LogIn(string email, string password)
        {
             string result = string.Empty;

            string userId = string.Empty;
            string name = string.Empty;
            string surname = string.Empty;
            string uniqueId = string.Empty;

            string queryUser = @" SELECT [UserId], [Name], [Surname],[UniqueId]
                                  FROM [Users]
                                  WHERE (Email = '" + DataBase.CleanString(email) + "') AND ([Password] = '" + DataBase.CleanString(password) + "')";
            try
            {
                DataTable dtUserInfo = DataBase.GetDataTable(queryUser);
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

                    result = userId;

                }
                else
                {
                    //result = Resources.CustomCodes.ERROR_USER_NOT_FOUND;
                }

            }
            catch (Exception ex)
            {
                //Exception trying to get user related info from "Users" Table
                //result = Resources.CustomCodes.ERROR_GENERIC.ToString();
                //string ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
                //Logs.InsertErrorLog(ex, System.Web.HttpContext.Current.Request.Url.AbsoluteUri, userId, ip, queryUser);
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
        public static string UpdateUser(string userId, string name, string surname, string email, string gsm, string gender, string location, string birthdate)
        {
            //update user info
            return "update sucsessfull";
        }

        //public static string CreateNewUser(string userName, string userSurname, string email, string password)
        //{

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
        //	                                        INSERT INTO [Users] (Name,Surname,[User].[Password],Email,IsFirstTime,IsActive,TotalAccessCount,UniqueId,CreatedAt)
        //                                            VALUES ('" + userName + "','" + userSurname + "','" + password + "','" + email + @"',1,1,0,'" + uniqueId + @"',GETDATE())
        //                                        	
        //	                                        SELECT @UserId = UserId 
        //	                                        FROM [Users]
        //	                                        WHERE UniqueId = '" + uniqueId + @"'
        //                                        	
        //	                                        INSERT INTO UserLoginTypes (UserId,LoginType)
        //	                                        VALUES
        //	                                        (@UserId,'1') 
        //
        //                                            INSERT INTO [MailList]
        //                                            ([Name],[Surname],[Email],[UniqueId],[UserId],[BirthDate],[Gender],[GSM],[Location],[Source],[MailSent],[Unsubscribe],[CreatedAt])
        //                                            SELECT [Name],[Surname],[Email],[UniqueId],UserId,[BirthDate],[Gender],[GSM],[City],'increment',0,0,GETDATE()
        //                                            FROM Users
        //                                            WHERE UserId = @UserId AND [Email] NOT IN (SELECT [Email] FROM [MailList]) ";


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
        //}

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
        public static string UnsubscribeUser(string userId, string email)
        {
            return "";
        }
    }
}