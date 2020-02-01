using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class GameDA
    {
        public static dynamic CheckGameRoundMoves<T>(Dictionary<string, dynamic> parameters)
        {
            try
            {
                return Connector.ExecuteQuery<T>("CheckRoundMoves", parameters, true);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static dynamic GetGameMoves<T>(Dictionary<string, dynamic> parameters)
        {
            try
            {
                return Connector.ExecuteQuery<T>("GetGameMoves", parameters, true);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static bool NewGame()
        {
            try
            {
                return Connector.ExecuteDUI("NewGame", null, true);
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
