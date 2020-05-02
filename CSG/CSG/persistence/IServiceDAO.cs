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
        void Create(Service service);//ok
        string BulkLoad(List<Service> services);
        List<Service> Read_all();//ok
        List<Service> Read_all_like(string search);
        Service Read_once(string code);//ok
        bool Read_once_exist(string code);//ok
        void Update(Service service);//ok
        void Delete(string code);//ok
        
    }
}
