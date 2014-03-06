using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


namespace increment_the_app
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSendPassword_Click(object sender, EventArgs e)
        {
//            string enteredEmail = Email.Value;
//            string email=string.Empty;
//            string quary=@"SELECT [Email]
//                                  FROM [Users]
//                                  WHERE Email ='"+enteredEmail+"'";
//            DataTable dt = Library.DataBase.GetDataTable(quary);
//            email = dt.Rows[0]["Email"].ToString();
//            if (email.Length > 0)
//            { 
//                Random rand=new Random();
//                int password=rand.Next(1000,1002);



//                string sqlQuery = @"UPDATE [dbo].[users]
//   SET [Password] = '"+password+"'WHERE Email='"+enteredEmail+"'";
//                int result=Library.DataBase.ExecuteNonQuery(sqlQuery);
//                if (result > 0)
//                {
//                    //mail gönderme bölümü

//                }
//                else
//                { 
//                //hata bölümü
//                }

//                Response.Redirect("Home.aspx");

            }



            }

        }
    
