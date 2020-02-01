using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Round : IService
    {
        public int Id { get; set; }
        public int RoundNumber { get; set; }
        public Player RoundWinner { get; set; }
        public Round()
        {

        }

        public ResponseJson Create(Dictionary<string, dynamic> parameters)
        {
            throw new NotImplementedException();
        }

        public ResponseJson Create()
        {
            throw new NotImplementedException();
        }

        public ResponseJson Modify(Dictionary<string, dynamic> parameters)
        {
            throw new NotImplementedException();
        }

        public ResponseJson Get()
        {
            throw new NotImplementedException();
        }

        public ResponseJson Get(Dictionary<string, dynamic> parameters)
        {
            throw new NotImplementedException();
        }
    }
}
