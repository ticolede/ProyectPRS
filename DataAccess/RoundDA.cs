using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RoundDA
    {
        public static dynamic NewRound<T>(Dictionary<string, dynamic> parameters)
        {
            try
            {
                return Connector.ExecuteQuery<T>("NewRound", parameters, true);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
