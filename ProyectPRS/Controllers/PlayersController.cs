using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WcfProyectPRS;

namespace ProyectPRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : GenericController
    {
        [HttpGet("[action]")]
        [Route("api/[controller]")]
        public IEnumerable<ResponseJson> GetPlayers()
        {
            ResponseJson response = null;
            try
            {
                InitializeClient client = new InitializeClient(new InitializeClient.EndpointConfiguration());
                var task = client.GetPlayersGameAsync();
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