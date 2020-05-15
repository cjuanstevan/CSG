using CSG.model;
using CSG.persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG.logic
{
    class OrderLog
    {
        public void Create(Order order)
        {
            DAOFactory.GetOrderDAO().Create(order);
        }

        public List<Order> ReadAll()
        {
            return DAOFactory.GetOrderDAO().Read_all();
        }

        public List<Order> Read_all_like(string search)
        {
            return DAOFactory.GetOrderDAO().Read_all_like(search);
        }
        public uint Read_count()
        {
            return DAOFactory.GetOrderDAO().Read_count();
        }
        public bool Read_once_exist(string number)
        {
            return DAOFactory.GetOrderDAO().Read_once_exist(number);
        }

        public Order Read_once(string number)
        {
            return DAOFactory.GetOrderDAO().Read_once(number);
        }

        public void Update(Order order)
        {
            DAOFactory.GetOrderDAO().Update(order);
        }

        public void Delete(string number)
        {
            DAOFactory.GetOrderDAO().Delete(number);
        }
    }
}
