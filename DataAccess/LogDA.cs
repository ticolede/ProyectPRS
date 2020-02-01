using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
   public class LogDA
    {
        public static bool Log(Dictionary<string, dynamic> parameters)
        {
            try
            {
                return Connector.ExecuteDUI("LogInOut", parameters, true);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static bool LogError(Dictionary<string, dynamic> parameters)
        {
            try
            {
                return Connector.ExecuteDUI("LogErrors", parameters, true);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
