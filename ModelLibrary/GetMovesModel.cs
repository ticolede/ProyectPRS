using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class GetMovesModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int LosedAgainst { get; set; }
        public int WinsAgainst { get; set; }

        public static List<GetMovesModel> GetMoves()
        {
            List<GetMovesModel> list = MoveDA.GetMoves<GetMovesModel>();
            return list;
        }
    }
}
