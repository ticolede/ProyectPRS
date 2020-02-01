using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class CheckRoundMovesModel : ResponseGeneric
    {
        public int Winner { get; set; }
        public int Loser { get; set; }
        public int NextRound { get; set; }
        public int NextRoundNumber { get; set; }
        public int GameOver { get; set; }

        public static List<CheckRoundMovesModel> CheckGameRoundMoves(int IdGame, int IdRound)
        {            
            Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();
            parameters.Add(nameof(IdGame), IdGame);
            parameters.Add(nameof(IdRound), IdRound);
            return GameDA.CheckGameRoundMoves<CheckRoundMovesModel>(parameters);
        }
    }
}
