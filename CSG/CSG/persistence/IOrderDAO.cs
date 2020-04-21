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
        void Create(Order order);//ok
        List<Order> Read_all();//ok
        Order Read_once(string number);//ok
        bool Read_once_exist(string number);//ok
        void Update(Order order);//ok
        void Delete(string number);//ok
    }
}
