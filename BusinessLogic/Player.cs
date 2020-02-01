using ModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Player : IService
    {
        public int Id { get; set; }
        public int IdGame { get; set; }
        public string Name { get; set; }
        public int WonGames { get; set; }
        public int LostGames { get; set; }
        public Player()
        {

        }

        public ResponseJson Create()
        {
            ResponseJson response = new ResponseJson { Code = -10, Message = "An exception has ocurred, please, try it later" };
            var newPlayer = NewPlayerModel.NewPlayer(Name, IdGame)[0];
            if (newPlayer != null)
            {
                response = new ResponseJson { Code = newPlayer.Code, Message = newPlayer.Message };
                response.Json = Common.ToJson(newPlayer);
            }
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
            List<GetPlayersModel> getPlayers = GetPlayersModel.GetPlayersGame();
            if (getPlayers != null)
            {
                response = new ResponseJson { Code = 0, Message = "OK" };
                response.Json = Common.ToJson(getPlayers);
            }
            return response;
        }

        public ResponseJson Get(Dictionary<string, dynamic> parameters)
        {
            throw new NotImplementedException();
        }
    }
}
