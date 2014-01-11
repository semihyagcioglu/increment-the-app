using increment_the_app.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace increment_the_app
{
    /// <summary>
    /// Summary description for WsUsers
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WsUsers : System.Web.Services.WebService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>0: login failed , -1 error, above 0 success</returns>
        [WebMethod(EnableSession = true)]
        public int LogIn(string email, string password)
        {
            return Users.LogIn(email, password);
        }

        [WebMethod]
        public static string LogOut(string userId)
        {
            return Users.LogOut(userId);
        }

        [WebMethod]
        public string UpdatePageIn(string userId, string page, string ip, Guid uniqueId)
        {
            return Logs.InsertActionLog(userId, page, ip, uniqueId);
        }

        [WebMethod]
        public string UpdatePageOut(string userId, Guid uniqueId)
        {
            return Logs.UpdateActionLog(userId, uniqueId);
        }

        [WebMethod]
        public static string CheckIfIsFirstTime(string userId)
        {
            return Users.CheckIfIsFirstTime(userId);
        }

        [WebMethod]
        public static string LoginWithFacebook(string facebookId, string email, string firstName, string lastName, string city, string sex, string pic, string bday)
        {
            return Users.LoginWithFacebook(facebookId, email, firstName, lastName, city, sex, pic, bday);
        }

        [WebMethod]
        public string UpdateUser(string userId, string name, string surname, string email, string gsm, string gender, string birthdate)
        {
            return Users.UpdateUser(userId, name, surname, email, gsm, gender,birthdate);
        }

        [WebMethod]
        public int CreateNewUser(string userName, string userSurname, string email, string password)
        {
            return Users.CreateNewUser(userName, userSurname, email, password);
        }

        [WebMethod]
        public static string CheckEmail(string email)
        {
            return Users.CheckEmail(email);
        }

        [WebMethod]
        public static string CheckUserID(string guid)
        {
            return Users.CheckUserID(guid);
        }

        [WebMethod]
        public static string SendPassword(string email)
        {
            return Users.SendPassword(email);
        }

        [WebMethod]
        public static string GetUserInformation(string userId, string guid, string email)
        {
            return Users.GetUserInformation(userId, guid, email);
        }

        [WebMethod]
        public static string UpdateUserPassword(string userId, string password, string oldPassword)
        {
            return Users.UpdateUserPassword(userId, password, oldPassword);
        }

        [WebMethod]
        public static string Subscribe(string userId, string email)
        {
            return Users.Subscribe(userId, email);
        }

        [WebMethod]
        public static string Unsubscribe(string userId, string email)
        {
            return Users.Unsubscribe(userId, email);
        }

        [WebMethod]
        public string PostTask(string taskTitle, string taskDetail, string date, string location, string money)
        {
            return Users.PostTask(taskTitle, taskDetail, date, location, money);
        }
    }
}
