using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace increment_the_app.Library
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Reports //
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="interval"></param>
        public static string GetRegistrationCountByInterval(string interval)
        { //TODO: Son satırdaki loglama metodu log classı eklendikten sonra yeniden düzenlenebilir.
            string sqlGetRegistrationCountByInterval = @" SELECT COUNT(U.UserId) AS rCount
                                                          FROM [Users] U 
                                                          WHERE ";

            object tmp = null;
            string retVal = string.Empty;

            if (string.IsNullOrEmpty(interval) == false)
            {
                if (interval.Equals("d") == true)
                {
                    //daily
                    sqlGetRegistrationCountByInterval += @" DATEPART(YEAR, U.CreatedAt) = DATEPART(YEAR, GETDATE()) 
	                                                        AND DATEPART(MONTH, U.CreatedAt) = DATEPART(MONTH, GETDATE()) 
	                                                        AND DATEPART(WEEK, U.CreatedAt) = DATEPART(WEEK, GETDATE()) 
	                                                        AND DATEPART(DAY, U.CreatedAt) = DATEPART(DAY, GETDATE()) 
                                                            AND ";
                }
                else if (interval.Equals("w") == true)
                {
                    //weekly
                    sqlGetRegistrationCountByInterval += @" DATEPART(YEAR, U.CreatedAt) = DATEPART(YEAR, GETDATE()) 
                                                            AND DATEPART(MONTH, U.CreatedAt) = DATEPART(MONTH, GETDATE()) 
                                                            AND DATEPART(WEEK, U.CreatedAt) = DATEPART(WEEK, GETDATE()) 
                                                            AND ";
                }
                else if (interval.Equals("m") == true)
                {
                    //monthly
                    sqlGetRegistrationCountByInterval += @" DATEPART(YEAR, U.CreatedAt) = DATEPART(YEAR, GETDATE()) 
	                                                        AND DATEPART(MONTH, U.CreatedAt) = DATEPART(MONTH, GETDATE()) 
                                                            AND ";

                }
                else if (interval.Equals("y") == true)
                {
                    //yearly
                    sqlGetRegistrationCountByInterval += @" DATEPART(YEAR, U.CreatedAt) = DATEPART(YEAR, GETDATE()) 
                                                            AND ";
                }



            }
            sqlGetRegistrationCountByInterval += @" U.UserId NOT IN(SELECT UserId FROM UserLoginTypes WHERE LoginType = 4)
                                                    AND U.RoleId = 2 ";

            try
            {
                tmp = DataBase.ExecuteScalar(sqlGetRegistrationCountByInterval);

                if (tmp != null)
                {
                    retVal = tmp.ToString();
                }
            }
            catch (Exception exx)
            {
                string ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
                //Logs.InsertErrorLog(exx, "Reports.cs/GetRegistrationCountByInterval", string.Empty, ip, sqlGetRegistrationCountByInterval);
            }
            return retVal;
        }
    }
}