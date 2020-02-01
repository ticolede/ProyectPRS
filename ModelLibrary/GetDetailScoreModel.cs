using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class GetDetailScoreModel : ResponseGeneric
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Rounds { get; set; }
        public string Winner { get; set; }
        public string PlayerOne { get; set; }
        public string PlayerTwo { get; set; }

        public static GetDetailScoreModel GetGameDetailScore(int IdPlayer)
        {            
            Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();
            parameters.Add(nameof(IdPlayer), IdPlayer);
            return PlayerDA.GetDetailScore<GetDetailScoreModel>(parameters)[0];
        }
    }
}
