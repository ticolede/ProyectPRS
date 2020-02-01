using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using WcfProyectPRS;

namespace ProyectPRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : GenericController
    {

        [HttpGet("[action]")]
        [Route("api/[controller]")]
        public IEnumerable<ResponseJson> GetGameMoves(int idGame)
        {
            ResponseJson response = null;
            try
            {
                InitializeClient client = new InitializeClient(new InitializeClient.EndpointConfiguration());
                var task = client.GetGamePlayersMoveAsync(idGame);
                task.Wait();
                if (task.IsCompletedSuccessfully)
                    response = task.Result;
                else
                    response = new ResponseJson { Code = -1, Message = "Cannot get game´s detail" };
            }
            catch (Exception e)
            {
                response = new ResponseJson { Code = -10, Message = "An error has ocurred, please try it later" };
            }
            return ToEnumerable<ResponseJson>(response);
        }

        [HttpGet("[action]")]
        [Route("api/[controller]")]
        public IEnumerable<ResponseJson> GetDetailsScore(int idPlayer)
        {
            ResponseJson response = null;
            try
            {
                InitializeClient client = new InitializeClient(new InitializeClient.EndpointConfiguration());
                var task = client.GetGameDetailScoreAsync(idPlayer);
                task.Wait();
                if (task.IsCompletedSuccessfully)
                    response = task.Result;
                else
                    response = new ResponseJson { Code = -1, Message = "Cannot get game´s detail" };
            }
            catch (Exception e)
            {
                response = new ResponseJson { Code = -10, Message = "An error has ocurred, please try it later" };
            }
            return ToEnumerable<ResponseJson>(response);
        }

        [HttpGet("[action]")]
        [Route("api/[controller]")]
        public IEnumerable<ResponseJson> CheckRound(int idGame, int idRound)
        {
            ResponseJson response = null;
            try
            {
                InitializeClient client = new InitializeClient(new InitializeClient.EndpointConfiguration());
                var task = client.CheckRoundMovesAsync(idGame, idRound);
                task.Wait();
                if (task.IsCompletedSuccessfully)
                    response = task.Result;
                else
                    response = new ResponseJson { Code = -1, Message = "Cannot check the round" };
            }
            catch (Exception e)
            {
                response = new ResponseJson { Code = -10, Message = "An error has ocurred, please try it later" };
            }
            return ToEnumerable<ResponseJson>(response);
        }

        [HttpGet("[action]")]
        [Route("api/[controller]")]
        public IEnumerable<ResponseJson> StartGame(string playerOne, string playerTwo)
        {
            ResponseJson responseJson = null;
            GameControllerModel responsePlayerOne = null;
            GameControllerModel responsePlayerTwo = null;
            GameControllerResponse response = null;
            try
            {
                responsePlayerOne = InsertPlayer(playerOne);
                if (responsePlayerOne.Code == 0)
                {
                    responsePlayerTwo = InsertPlayer(playerOne, responsePlayerOne.IdGame);
                    responseJson = new ResponseJson { Code = responsePlayerTwo.Code, Message = responsePlayerTwo.Message };
                }
                response = new GameControllerResponse { IdGame = responsePlayerOne.IdGame, PlayerOne = responsePlayerOne.IdPlayer, PlayerTwo = responsePlayerTwo.IdPlayer, IdRound = responsePlayerOne.IdRound };
                responseJson.Json = ParseObjectToJson(response);
            }
            catch (Exception e)
            {
                responseJson = new ResponseJson { Code = -10, Message = "An error has ocurred, please try it later" };
            }
            return ToEnumerable<ResponseJson>(responseJson);
        }

        private GameControllerModel InsertPlayer(string player, int idGame = 0)
        {
            GameControllerModel response = null;
            try
            {
                InitializeClient client = new InitializeClient(new InitializeClient.EndpointConfiguration());
                var task = client.NewPlayerAsync(player, idGame);
                task.Wait();
                if (task.IsCompletedSuccessfully)
                {
                    ResponseJson responseJson = task.Result;
                    response = ParseJsonToObject<GameControllerModel>(responseJson.Json);
                }
                else
                    response = new GameControllerModel { Code = -1, Message = "Cannot get move´s list" };
            }
            catch (Exception e)
            {
                response = new GameControllerModel { Code = -10, Message = "An error has ocurred, please try it later" };
            }
            return response;
        }

        public class GameControllerModel
        {
            public int Code { get; set; }
            public string Message { get; set; }
            public int IdPlayer { get; set; }
            public int IdGame { get; set; }
            public int IdRound { get; set; }

            public GameControllerModel()
            {

            }
        }

        public class GameControllerResponse
        {
            public int PlayerOne { get; set; }
            public int PlayerTwo { get; set; }
            public int IdGame { get; set; }
            public int IdRound { get; set; }
            public GameControllerResponse()
            {

            }
        }

    }
}