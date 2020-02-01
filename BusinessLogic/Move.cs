using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary;
namespace BusinessLogic
{
    public class Move : IService
    {
        public int Id { get; set; }
        public int IdGame { get; set; }
        public int IdPlayer { get; set; }
        public int IdRound { get; set; }
        public string Description { get; set; }
        public Move LosedAgainst { get; set; }
        public Move WinsAgainst { get; set; }
        public Move()
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
            ResponseJson response = new ResponseJson { Code = -10, Message = "An exception has ocurred, please try it later." };
            List<Move> list = new List<Move>();
            List<GetMovesModel> moves = GetMovesModel.GetMoves();
            if (moves.Count > 0)
            {
                response = new ResponseJson { Code = 0, Message = "OK" };
                foreach (GetMovesModel m in moves)
                {
                    Move move = new Move { Id = m.Id, Description = m.Description, LosedAgainst = new Move { Id = m.LosedAgainst }, WinsAgainst = new Move { Id = m.WinsAgainst } };
                    list.Add(move);
                }
                response.Json = Common.ToJson(list);
            }
            return response;
        }

        public ResponseJson Get(Dictionary<string, dynamic> parameters)
        {
            throw new NotImplementedException();
        }

        public ResponseJson Create()
        {
            ResponseJson response = new ResponseJson { Code = -10, Message = "An exception has ocurred, please, try it later" };
            bool newGameCreated = NewMoveModel.NewMove(IdGame,Id,IdPlayer,IdRound);
            if (newGameCreated)
                response = new ResponseJson { Code = 0, Message = "OK" };

            return response;
        }
    }
}
