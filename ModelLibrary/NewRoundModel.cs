using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class NewRoundModel : ResponseGeneric
    {
        public int IdRound { get; set; }

        public static NewRoundModel NewRound(int idGame)
        {            
            Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();
            parameters.Add(nameof(idGame), idGame);
            return RoundDA.NewRound<NewRoundModel>(parameters);
        }
    }
}
