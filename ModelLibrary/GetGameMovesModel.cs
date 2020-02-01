using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class GetGameMovesModel : ResponseGeneric
    {
        public int IdGame { get; set; }
        public int IdGameMove { get; set; }
        public int IdMove { get; set; }
        public string Move { get; set; }
        public int IdPlayer { get; set; }
        public string Player { get; set; }
        public int TurnOrder { get; set; }
        public int RoundNumber { get; set; }
        public int RoundWinner { get; set; }
        public int IdWinner { get; set; }
        public string NameWinner { get; set; }

        public static GetGameMovesModel GetGamePlayersMove(int IdGame)
        {            
            Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();
            parameters.Add(nameof(IdGame), IdGame);
            return GameDA.GetGameMoves<GetGameMovesModel>(parameters);
        }
    }
}
