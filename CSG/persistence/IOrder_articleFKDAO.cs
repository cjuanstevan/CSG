using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSG.model;

namespace CSG.persistence
{
    interface IOrder_articleFKDAO
    {
        void Create(Order_articleFK order_articleFK);
        List<Order_articleFK> Read_all();
        Order_articleFK Read_once(string number, string code);
        void Update(Order_articleFK order_articleFK);
        void Delete(string number, string code);
    }
}
