using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class NewGameModel
    {
        public int IdGame { get; set; }
        public int IdRound { get; set; }

        public static bool NewGame()
        {
            return GameDA.NewGame();
        }
    }
}
