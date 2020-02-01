using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BusinessLogic;
namespace WcfProyectPRS
{
    public class Initialize : IInitialize
    {
        public ResponseJson CheckRoundMoves(int idGame, int idRound)
        {
            Game game = new Game { Id = idGame };
            return game.CheckRoundMoves(idRound);
        }

        public ResponseJson NewGame()
        {
            ServiceExe service = new ServiceExe(new Game());
            return service.Create();
        }

        public ResponseJson GetGameDetailScore(int idPlayer)
        {
            Game game = new Game { PlayerOne = new Player { Id = idPlayer } };
            ServiceExe service = new ServiceExe(game);
            return service.Get();
        }

        public ResponseJson GetGamePlayersMove(int idGame)
        {
            GameMove gameMove = new GameMove { IdGame = idGame };
            ServiceExe service = new ServiceExe(gameMove);
            return service.Get();
        }

        public ResponseJson GetMoves()
        {
            ServiceExe service = new ServiceExe(new Move());
            return service.Get();
        }

        public ResponseJson NewMove(int idGame, int idMove, int idPlayer, int idRound)
        {
            Move newMove = new Move { IdGame = idGame, Id = idMove, IdPlayer = idPlayer, IdRound = idRound };
            ServiceExe service = new ServiceExe(newMove);
            return service.Create();
        }

        public ResponseJson NewPlayer(string player, int idGame)
        {
            Player newPlayer = new Player { Name = player, IdGame = idGame };
            ServiceExe service = new ServiceExe(newPlayer);
            return service.Create();
        }

        public ResponseJson GetPlayersGame()
        {
            ServiceExe service = new ServiceExe(new Player());
            return service.Get();
        }

        public ResponseJson Logs(string service,string input,string output)
        {
            Log.Logs(service, input, output);
            return new ResponseJson { Code = 0, Message = "OK" };
        }

        public ResponseJson LogError(string exception)
        {
            Log.LogError(exception);
            return new ResponseJson { Code = 0, Message = "OK" };
        }
    }
}
