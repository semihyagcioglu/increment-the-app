using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace increment_the_app.Library
{
    public class Users
    {
        DataBase db = new DataBase("");
        public static string LogIn(string email, string password)
        {
            //check info from database
            return "sucsess";
        }

        public static string LogOut(string userId)
        {
            //close account connection to site
            return "session closed";
        }

        public static string CheckIfIsFirstTime(string userId)
        {
            //check account if first time logged on
            return "-1";
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