using ModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
   public class Log
    {
        public static void Logs(string service,string input,string output)
        {
            LogModel.Log(service, input, output);
        }

        public static void LogError(string exception)
        {
            LogModel.LogError(exception);
        }
    }
}
