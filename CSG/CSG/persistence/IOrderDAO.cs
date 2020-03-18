using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSG.model;

namespace CSG.persistence
{
    interface IOrderDAO
    {
        void Create(Order order);
        List<Order> Read_all();
        Order Read_once(string number);
        void Update(Order order);
        void Delete(string number);
    }
}
