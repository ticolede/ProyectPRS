using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Common
    {
        public static string ToJson(dynamic obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

    }
}
