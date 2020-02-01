using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
   public class LogModel
    {
        public static void Log(string service,string input,string output)
        {
            Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();
            parameters.Add(nameof(service), service);
            parameters.Add(nameof(input), input);
            parameters.Add(nameof(output), output);
            LogDA.Log(parameters);
        }

        public static void LogError(string exception)
        {
            Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();
            parameters.Add(nameof(exception), exception);           
            LogDA.LogError(parameters);
        }
    }
}
