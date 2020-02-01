using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WcfProyectPRS;

namespace ProyectPRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoveController : GenericController
    {
        [HttpGet("[action]")]
        [Route("api/[controller]")]
        public IEnumerable<ResponseJson> GetMoves()
        {
            ResponseJson response = null;
            try
            {
                InitializeClient client = new InitializeClient(new InitializeClient.EndpointConfiguration());
                var task = client.GetMovesAsync();
                task.Wait();
                if (task.IsCompletedSuccessfully)
                    response = task.Result;
                else
                    response = new ResponseJson { Code = -1, Message = "Cannot get move´s list" };
            }
            catch (Exception e)
            {
                response = new ResponseJson { Code = -10, Message = "An error has ocurred, please try it later" };
            }
            return ToEnumerable<ResponseJson>(response);
        }

        [HttpGet("[action]")]
        [Route("api/[controller]")]
        public IEnumerable<ResponseJson> NewMove(int idGame, int idMove, int idPlayer, int idRound)
        {
            ResponseJson response = null;
            try
            {
                InitializeClient client = new InitializeClient(new InitializeClient.EndpointConfiguration());
                var task = client.NewMoveAsync(idGame, idMove, idPlayer, idRound);
                task.Wait();
                if (task.IsCompletedSuccessfully)
                    response = task.Result;
                else
                    response = new ResponseJson { Code = -1, Message = "Cannot insert move" };
            }
            catch (Exception e)
            {
                response = new ResponseJson { Code = -10, Message = "An error has ocurred, please try it later" };
            }
            return ToEnumerable<ResponseJson>(response);
        }

    }
}
