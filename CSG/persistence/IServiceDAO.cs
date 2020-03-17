using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSG.model;

namespace CSG.persistence
{
    interface IServiceDAO
    {
        void Create(Service service);
        List<Service> Read_all();
        Service Read_once(string code);
        void Update(Service service);
        void Delete(string code);
    }
}
