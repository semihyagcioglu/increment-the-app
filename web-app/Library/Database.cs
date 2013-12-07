using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace increment_the_app.Library
{
    public class DataBase
    {
        private static string cnnStr = null;

        /// <summary>
        /// Default constructor to connect Azure database.
        /// </summary>
        public DataBase()
        {
            cnnStr = ConfigurationManager.ConnectionStrings["IncrementDBConnection"].ConnectionString;
        }

        /// <summary>
        /// This constructors set connection string
        /// </summary>
        /// <param name="cnnStrName">is a connection strings name in the application config file (app.config)</param>
        public DataBase(string cnnStrsName)
        {
            cnnStr = ConfigurationManager.ConnectionStrings[cnnStrsName].ConnectionString;
        }

        /// <summary>
        /// This method return a DataSet
        /// </summary>
        /// <param name="sqlCommand">is a query string</param>
        /// <returns><b>DataSet</b> included your query result</returns>
        public static DataSet GetDataSet(string sqlCommand)
        {
            using (SqlConnection connection = new SqlConnection(cnnStr))
            {
               // SqlTransaction transaction = connection.BeginTransaction();
                //SqlCommand cmd = new SqlCommand(sqlCommand, connection, transaction);
                SqlCommand cmd = new SqlCommand(sqlCommand, connection);
                
                var ds = new DataSet();

                try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    var da = new SqlDataAdapter(cmd);
                    da.SelectCommand.CommandTimeout = 30000;

                    
                    da.Fill(ds);
                    //cmd.Transaction.Commit();


                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                    
                }
                catch (SqlException eX)
                {
                    //try
                    //{
                    //   // cmd.Transaction.Rollback();
                    //}
                    //catch (SqlException eXR)
                    //{
                    //    throw eXR;
                    //}
                    //throw eX;
                }

                return ds;
            }
        }

        /// <summary>
        /// Return a datatable in created dataset
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <returns>First DataTable in DataSet</returns>
        public static DataTable GetDataTable(string sqlCommand)
        {
            return GetDataSet(sqlCommand).Tables[0];
        }

        // GetList : Gets the SQL command and retrieves a list as type of string with comma delimiter
        public static List<string> GetList(string sqlCommand)
        {
            DataTable dt = GetDataTable(sqlCommand);
            //List<DataRow> list = dt.AsEnumerable().toList(); // FIX : This should be working for .NET 3.5 Framework!
            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                string item = string.Empty; // FIX : convert it to stringbuilder!

                foreach (DataColumn column in dt.Columns)
                {
                    item += row[column].ToString() + ",";
                }

                item = item.Remove(item.Length - 1, 1);

                list.Add(item);
            }

            return list;
        }

        //// GetList : Gets the SQL command and retrieves a list as type of DataRow
        //public static  List<DataRow> GetList(string sqlCommand)
        //{
        //    DataTable dt = GetDataTable(sqlCommand);
        //    //List<DataRow> list = dt.AsEnumerable().toList(); // FIX : This should be working for .NET 3.5 Framework!
        //    List<DataRow> list = new List<DataRow>();


        //    foreach (DataRow row in dt.Rows)
        //    {
        //        list.Add(row);
        //    }

        //    return list;
        //}

        //SetParameter: Stored procedure için parametre hazırlar. Yönü string bir değerle
        //verilir. Daha sonra, alınan bu değer Direction değerlerinden birine çevrilir.
        //Geriye bir SqlParameter çevrilir.
        // "parameterName": Parametre adı.
        // "dbType": Parametre tipi.
        // "iSize": Parametre boyu.
        // "direction": Parametrenin yönü.
        // "oParamValue": Parametrenin değeri.

        public static SqlParameter SetParameter(string parameterName, SqlDbType dbType, Int32 iSize, string direction, object oParamValue)
        {
            var parameter = new SqlParameter(parameterName, dbType, iSize);

            switch (direction)
            {
                case "Input":
                    parameter.Direction = ParameterDirection.Input;
                    break;
                case "Output":
                    parameter.Direction = ParameterDirection.Output;
                    break;
                case "ReturnValue":
                    parameter.Direction = ParameterDirection.ReturnValue;
                    break;
                case "InputOutput":
                    parameter.Direction = ParameterDirection.InputOutput;
                    break;
                default:
                    break;
            }

            parameter.Value = oParamValue;
            return parameter;
        }

        // This function requires SqlParameters and and Sql command and returns a datatable.
        // Usage is :
        //
        //    int userId = 21;
        //    string sql = "SELECT * FROM Users WHERE UserID = @id";
        //    SqlParameter[] parameters = new SqlParameter[1];
        //    parameters[0] = DataBase.SetParameter("@id", System.Data.SqlDbType.Int, 4, "Input", userId);
        //    DataTable dt = DataBase.ExecuteSqlWithParameters(sql, parameters);
        //
        /// <summary>
        /// This method execute query string with parameters
        /// </summary>
        /// <param name="sql">Your query</param>
        /// <param name="sqlParameters">parameters of query</param>
        /// <returns></returns>
        public static DataTable ExecuteSqlWithParameters(string sql, SqlParameter[] sqlParameters)
        {

            using (SqlConnection connection = new SqlConnection(cnnStr))
            {
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand(sql, connection, transaction);
                try
                {
                    if (sqlParameters != null)
                    {
                        foreach (var parameter in sqlParameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }
                    }

                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }


                    var da = new SqlDataAdapter(cmd);

                    da.SelectCommand.CommandTimeout = 300;

                    var ds = new DataSet();
                    da.Fill(ds);
                    cmd.Transaction.Commit();


                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                        connection.Dispose();
                    }

                    return ds.Tables.Count != 0 ? ds.Tables[0] : new DataTable();
                }
                catch (SqlException ex)
                {
                    try
                    {
                        cmd.Transaction.Rollback();
                    }
                    catch (SqlException eXR)
                    {
                        throw eXR;
                    }
                    throw ex;
                }
            }
        }


        //ExecuteStoredProcedure: Stored Procedure çağrılır.
        //procedureName: Çağrılacak prosedürün adı
        //sqlParameters: Stored Procedure gönderilecek parametre arrayi
        //returnValueParameter: Stored Procedure içinde tanımlamış olduğumuz geri dönüş parametresinin ismi.
        /// <summary>
        /// This method execute only stored procedure with parameters of sp
        /// </summary>
        /// <param name="procedureName">StoredProcedure name</param>
        /// <param name="sqlParameters">Parameters of StoredProcedure</param>
        /// <param name="returnValueParameter">Stored Procedure that we have defined in the name of the return parameter.</param>
        /// <returns></returns>
        public static int ExecuteStoredProcedure(string procedureName, SqlParameter[] sqlParameters, string returnValueParameter)
        {
            //var connection = new SqlConnection(GetConnectionString());
            using (SqlConnection connection = new SqlConnection(cnnStr))
            {
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand cmd = new SqlCommand(procedureName, connection, transaction);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    if (sqlParameters != null)
                    {
                        foreach (var parameter in sqlParameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }
                    }

                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    cmd.CommandTimeout = 300;

                    cmd.ExecuteNonQuery();
                    cmd.Transaction.Commit();

                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                        connection.Dispose();
                    }

                    return Convert.ToInt32(cmd.Parameters[returnValueParameter].Value);
                }
                catch (SqlException ex)
                {
                    try
                    {
                        cmd.Transaction.Rollback();
                    }
                    catch (SqlException eXR)
                    {
                        throw eXR;
                    }
                    throw ex;
                }
            }
        }

        //ExecuteStoredProcedure: Stored Procedure çağrılır.
        //procedureName: Çağrılacak prosedürün adı
        //sqlParameters: Stored Procedure gönderilecek parametre arrayi
        //Sonuc olarak DataTable döndürür.
        // Örnek kullanım -->

        /* var sqlParameters = new SqlParameter[6];
        sqlParameters[0] = DataBase.SetParameter("@parametreAdi", SqlDbType.VarChar, 32, "Input", Session["parametre"]);
        var dt = DataBase.ExecuteStoredProcedure2DataTable("ListeGetir", sqlParameters);
         */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="procedureName"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        public static DataTable ExecuteStoredProcedure2DataTable(string procedureName, SqlParameter[] sqlParameters)
        {
            //var connection = new SqlConnection(GetConnectionString());
            using (SqlConnection connection = new SqlConnection(cnnStr))
            {
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = new SqlCommand(procedureName, connection, transaction);
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    if (sqlParameters != null)
                    {
                        foreach (var parameter in sqlParameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }

                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    var da = new SqlDataAdapter(command);

                    da.SelectCommand.CommandTimeout = 300;

                    var ds = new DataSet();
                    da.Fill(ds);
                    command.Transaction.Commit();

                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                        connection.Dispose();
                    }

                    return ds.Tables.Count != 0 ? ds.Tables[0] : new DataTable();
                }
                catch (SqlException eX)
                {
                    try
                    {
                        command.Transaction.Rollback();
                    }
                    catch (SqlException eXR)
                    {
                        throw eXR;
                    }
                    throw eX;
                }
            }
        }

        //ExecuteNonQuery: SQL cümlesi alır. Sadece o SQL cümlesini çalıştırır.,
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sqlCommand)
        {
            //var connection = new SqlConnection(GetConnectionString());
            using (SqlConnection connection = new SqlConnection(cnnStr))
            {
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = new SqlCommand(sqlCommand, connection, transaction);
                try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    command.CommandTimeout = 300;

                    var result = command.ExecuteNonQuery();
                    command.Transaction.Commit();

                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                        connection.Dispose();
                    }

                    return result;
                }
                catch (SqlException eX)
                {
                    try
                    {
                        command.Transaction.Rollback();
                    }
                    catch (SqlException eXR)
                    {
                        throw eXR;
                    }
                    throw eX;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlCommand">Query</param>
        /// <returns>First cell[0,0]</returns>
        public static object ExecuteScalar(string sqlCommand)
        {
            using (SqlConnection connection = new SqlConnection(cnnStr))
            {
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = new SqlCommand(sqlCommand, connection, transaction);
                try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    command.CommandTimeout = 300;

                    var result = command.ExecuteScalar();
                    command.Transaction.Commit();

                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                        connection.Dispose();
                    }

                    return result;
                }
                catch (SqlException eX)
                {
                    try
                    {
                        command.Transaction.Rollback();
                    }
                    catch (SqlException eXR)
                    {
                        throw eXR;
                    }
                    throw eX;
                }
            }
        }

        //CleanString: SQL cümlesini alır. İçerisindeki tırnak işaretlerini SQL'i çaktırmayacak hale getirip geri döndürür.
        public static string CleanString(string sqlCommand)
        {
            return sqlCommand.Replace("'", "''");
        }

        public static string SqlFilter(string text)
        {
            try
            {
                text = text.Replace("'", "’").Replace("^", " ").Replace("<", " ").Replace(">", " ").Replace("%", " ");
            }
            catch
            {
            }
            return text;
        }

    }
}
