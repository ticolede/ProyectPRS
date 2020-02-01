using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class NewMoveModel : ResponseGeneric
    {
        public int IdGameRound { get; set; }
        public int IdGameMove { get; set; }

        public static bool NewMove(int IdGame, int IdMove, int IdPlayer, int IdRound)
        {            
            Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();
            parameters.Add(nameof(IdGame), IdGame);
            parameters.Add(nameof(IdMove), IdMove);
            parameters.Add(nameof(IdPlayer), IdPlayer);
            parameters.Add(nameof(IdRound), IdRound);
            return MoveDA.NewMove(parameters);
        }

    }
}
