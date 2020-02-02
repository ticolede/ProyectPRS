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
            InitializeClient client = new InitializeClient(new InitializeClient.EndpointConfiguration());
            try
            {
                var task = client.GetGamePlayersMoveAsync(idGame);
                task.Wait();
                if (task.IsCompletedSuccessfully)
                    response = task.Result;
                else
                    response = new ResponseJson { Code = -1, Message = "Cannot get game´s detail" };
            }
            catch (Exception e)
            {
                client.LogErrorAsync(e.StackTrace);
                response = new ResponseJson { Code = -10, Message = "An error has ocurred, please try it later" };
            }
            finally
            {
                client.LogsAsync("GetGameMoves", "{'idGame':'" + idGame + "'}", ParseObjectToJson(response));
            }
            return ToEnumerable<ResponseJson>(response);
        }

        [HttpGet("[action]")]
        [Route("api/[controller]")]
        public IEnumerable<ResponseJson> GetDetailsScore(int idPlayer)
        {
            ResponseJson response = null;
            InitializeClient client = new InitializeClient(new InitializeClient.EndpointConfiguration());
            try
            {
                var task = client.GetGameDetailScoreAsync(idPlayer);
                task.Wait();
                if (task.IsCompletedSuccessfully)
                    response = task.Result;
                else
                    response = new ResponseJson { Code = -1, Message = "Cannot get game´s detail" };
            }
            catch (Exception e)
            {
                client.LogErrorAsync(e.StackTrace);
                response = new ResponseJson { Code = -10, Message = "An error has ocurred, please try it later" };
            }
            finally
            {
                client.LogsAsync("GetDetailsScore", "{'idPlayer':'" + idPlayer + "'}", ParseObjectToJson(response));
            }
            return ToEnumerable<ResponseJson>(response);
        }

        [HttpGet("[action]")]
        [Route("api/[controller]")]
        public IEnumerable<ResponseJson> CheckRound(int idGame, int idRound)
        {
            ResponseJson response = null;
            InitializeClient client = new InitializeClient(new InitializeClient.EndpointConfiguration());
            try
            {
                var task = client.CheckRoundMovesAsync(idGame, idRound);
                task.Wait();
                if (task.IsCompletedSuccessfully)
                    response = task.Result;
                else
                    response = new ResponseJson { Code = -1, Message = "Cannot check the round" };
            }
            catch (Exception e)
            {
                client.LogErrorAsync(e.StackTrace);
                response = new ResponseJson { Code = -10, Message = "An error has ocurred, please try it later" };
            }
            finally
            {
                client.LogsAsync("CheckRound", "{'idGame':'" + idGame + "','idRound':'" + idRound + "'}", ParseObjectToJson(response));
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
            InitializeClient client = new InitializeClient(new InitializeClient.EndpointConfiguration());
            try
            {
                responsePlayerOne = InsertPlayer(playerOne, client);
                if (responsePlayerOne.Code == 0)
                {
                    responsePlayerTwo = InsertPlayer(playerTwo, client, responsePlayerOne.IdGame);
                    responseJson = new ResponseJson { Code = responsePlayerTwo.Code, Message = responsePlayerTwo.Message };
                }
                response = new GameControllerResponse { IdGame = responsePlayerOne.IdGame, PlayerOne = responsePlayerOne.IdPlayer, PlayerTwo = responsePlayerTwo.IdPlayer, IdRound = responsePlayerOne.IdRound };
                responseJson.Json = ParseObjectToJson(response);
            }
            catch (Exception e)
            {
                client.LogErrorAsync(e.StackTrace);
                responseJson = new ResponseJson { Code = -10, Message = "An error has ocurred, please try it later" };
            }
            finally
            {
                client.LogsAsync("StartGame", "{'playerOne':'" + playerOne + "','playerTwo':'" + playerTwo + "'}", ParseObjectToJson(response));
            }
            return ToEnumerable<ResponseJson>(responseJson);
        }

        private GameControllerModel InsertPlayer(string player, InitializeClient client, int idGame = 0)
        {
            GameControllerModel response = null;
            try
            {
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
                client.LogErrorAsync(e.StackTrace);
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