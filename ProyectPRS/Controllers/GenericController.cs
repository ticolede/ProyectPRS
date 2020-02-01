using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace ProyectPRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController : ControllerBase
    {
        public JObject ParseJsonToJObject(string json)
        {
            JObject jObject = JObject.Parse(json);
            return jObject;
        }

        public dynamic ParseJsonToObject<T>(string input)
        {
            if (input != null)
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(input);
            else return null;
        }

        public IEnumerable<T> ToEnumerable<T>(dynamic input)
        {
            List<T> list = new List<T>();
            list.Add(input);
            IEnumerable<T> en = list;
            return en;
        }

        public string ParseObjectToJson(dynamic input)
        {
            if (input != null)
                return Newtonsoft.Json.JsonConvert.SerializeObject(input);
            else return null;
        }
    }
}