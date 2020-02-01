using ModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class GameMove : IService
    {       
        public int IdGame { get; set; }
        public Player PlayerOne { get; set; }
        public Move PlayerOneMove { get; set; }
        public Player PlayerTwo { get; set; }
        public Move PlayerTwoMove { get; set; }
        public Round Round { get; set; }        

        public GameMove()
        {

        }

        public ResponseJson Create(Dictionary<string, dynamic> parameters)
        {
            throw new NotImplementedException();
        }

        public ResponseJson Modify(Dictionary<string, dynamic> parameters)
        {
            throw new NotImplementedException();
        }

        public ResponseJson Get()
        {
            ResponseJson response = new ResponseJson { Code = -10, Message = "An exception has ocurred, please, try it later" };
            GetGameMovesModel getGameMoves = GetGameMovesModel.GetGamePlayersMove(IdGame);
            if (getGameMoves != null)
            {
                response = new ResponseJson { Code = 0, Message = "OK" };
                response.Json = Common.ToJson(getGameMoves);
            }
            return response;
        }

        public ResponseJson Get(Dictionary<string, dynamic> parameters)
        {
            throw new NotImplementedException();
        }

        public ResponseJson Create()
        {
            throw new NotImplementedException();
        }
    }
}
