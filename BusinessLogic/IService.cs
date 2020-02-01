using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IService
    {
        ResponseJson Create(Dictionary<string, dynamic> parameters);
        ResponseJson Create();
        ResponseJson Modify(Dictionary<string, dynamic> parameters);
        ResponseJson Get();
        ResponseJson Get(Dictionary<string, dynamic> parameters);
    }
}
