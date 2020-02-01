using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Connector
    {
        static string ConnectionString = @"Data Source = DESKTOP-46VV2T7\SQLEXPRESS;" +
                                                        "Initial Catalog=ProyectPRS;" +
                                                        "User id=prs;" +
                                                        "Password=jenova17;";
        /*AZURE: Server=tcp:jenovadb.database.windows.net,1433;Initial Catalog=ProyectPRS;Persist Security Info=False;User ID=admindb;Password=Jenova17;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;*/


        public static dynamic ExecuteQuery<T>(string sql, Dictionary<string, dynamic> parameters, bool isStoreProc)
        {
            try
            {
                List<T> dynamicReturn = new List<T>();
                DynamicParameters parameter = GetParameters(parameters);
                using (IDbConnection db = new SqlConnection(ConnectionString))
                {
                    dynamicReturn = db.Query<T>(sql, parameters, null, true, null, isStoreProc ? CommandType.StoredProcedure : CommandType.Text).ToList();
                }
                return dynamicReturn;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// Execute delete , update or insert statements
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static bool ExecuteDUI(string sql, Dictionary<string, dynamic> parameters, bool isStoreProc)
        {
            try
            {
                int affectedRows = 0;

                DynamicParameters parameter = GetParameters(parameters);
                using (var connection = new SqlConnection(ConnectionString))
                {
                    affectedRows = connection.Execute(sql, parameter, null, null, isStoreProc ? CommandType.StoredProcedure : CommandType.Text);
                }
                return affectedRows > 0;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private static DynamicParameters GetParameters(Dictionary<string, dynamic> parameters)
        {
            try
            {
                DynamicParameters parameter = null;
                if (parameters != null && parameters.Count > 0)
                {
                    parameter = new DynamicParameters();
                    foreach (KeyValuePair<string, dynamic> d in parameters)
                        parameter.Add(string.Concat("@", d.Key), d.Value.ToString());
                }
                return parameter;
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
