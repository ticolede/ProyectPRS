using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class NewPlayerModel : ResponseGeneric
    {
        public int IdPlayer { get; set; }
        public int IdGame { get; set; }
        public int IdRound { get; set; }
        public static List<NewPlayerModel> NewPlayer(string player, int idGame)
        {
            Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();
            parameters.Add(nameof(player), player);
            parameters.Add(nameof(idGame), idGame);
            return PlayerDA.NewPlayer<NewPlayerModel>(parameters);
        }
    }
}
