using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PlayerDA
    {
        public static dynamic GetDetailScore<T>(Dictionary<string, dynamic> parameters)
        {
            try
            {
                return Connector.ExecuteQuery<T>("GetDetailScore", parameters, true);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static dynamic GetPlayers<T>()
        {
            try
            {
                return Connector.ExecuteQuery<T>("GetPlayers", null, true);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static dynamic NewPlayer<T>(Dictionary<string, dynamic> parameters)
        {
            try
            {
                return Connector.ExecuteQuery<T>("NewPlayer", parameters, true);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
