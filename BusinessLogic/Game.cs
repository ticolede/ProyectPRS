using ModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Game : IService
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Player PlayerOne { get; set; }
        public Player PlayerTwo { get; set; }
        public int Rounds { get; set; }
        public Player Winner { get; set; }
        public List<GameMove> Moves { get; set; }
        public Game()
        {

        }

        public ResponseJson CheckRoundMoves(int idRound)
        {
            ResponseJson response = new ResponseJson { Code = -10, Message = "An exception has ocurred, please, try it later" };
            CheckRoundMovesModel checkRoundMovesModel = CheckRoundMovesModel.CheckGameRoundMoves(Id, idRound)[0];
            if (checkRoundMovesModel != null)
            {
                response = new ResponseJson { Code = checkRoundMovesModel.Code, Message = checkRoundMovesModel.Message };
                response.Json = Common.ToJson(checkRoundMovesModel);
            }
            return response;
        }

        public ResponseJson Create()
        {
            ResponseJson response = new ResponseJson { Code = -10, Message = "An exception has ocurred, please, try it later" };
            bool newGameCreated = NewGameModel.NewGame();
            if (newGameCreated)
                response = new ResponseJson { Code = 0, Message = "OK" };

            return response;
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
            GetDetailScoreModel getDetailScore = GetDetailScoreModel.GetGameDetailScore(PlayerOne.Id);
            if (getDetailScore != null)
            {
                response = new ResponseJson { Code = 0, Message = "OK" };
                response.Json = Common.ToJson(getDetailScore);
            }
            return response;
        }

        public ResponseJson Get(Dictionary<string, dynamic> parameters)
        {
            throw new NotImplementedException();
        }
    }
}
