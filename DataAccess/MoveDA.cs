using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MoveDA
    {
        public static dynamic GetMoves<T>()
        {
            try
            {
                return Connector.ExecuteQuery<T>("GetMoves", null, true);
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public static bool NewMove(Dictionary<string, dynamic> parameters)
        {
            try
            {
                return Connector.ExecuteDUI("NewMove", parameters, true);
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
