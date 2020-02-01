using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class GetPlayersModel :ResponseGeneric
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int WonGames { get; set; }
        public int LostGames { get; set; }

        public static List<GetPlayersModel> GetPlayersGame()
        {           
            return PlayerDA.GetPlayers<GetPlayersModel>();
        }
    }
}
