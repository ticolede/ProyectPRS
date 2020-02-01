using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ServiceExe
    {
        private IService _service { get; set; }
        public ServiceExe(IService s)
        {
            _service = s;
        }

        public ResponseJson Get()
        {
            return _service.Get();
        }

        public ResponseJson Get(Dictionary<string, dynamic> parameters)
        {
            return _service.Get(parameters);
        }

        public ResponseJson Create(Dictionary<string, dynamic> parameters)
        {
            return _service.Create(parameters);
        }

        public ResponseJson Create()
        {
            return _service.Create();
        }

        public ResponseJson Modify(Dictionary<string, dynamic> parameters)
        {
            return _service.Modify(parameters);
        }
    }
}
