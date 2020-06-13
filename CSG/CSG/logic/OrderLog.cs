using CSG.model;
using CSG.persistence;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG.logic
{
    class OrderLog
    {
        public int ClientOrders(string client_id)
        {
            return DAOFactory.GetOrderDAO().ClientOrders(client_id);
        }
        public void Create(Order order)
        {
            DAOFactory.GetOrderDAO().Create(order);
        }

        public List<Order> ReadAll()
        {
            return DAOFactory.GetOrderDAO().Read_all();
        }
        public List<Order> Read_all_DateReception(DateTime DateI, DateTime DateF)
        {
            return DAOFactory.GetOrderDAO().Read_all_DateReception(DateI, DateF);
        }
        public List<Order> Read_all_like_client(string id)
        {
            return DAOFactory.GetOrderDAO().Read_all_like_client(id);
        }
        public List<Order> Read_all_like_client_daterange(string id, DateTime DateI, DateTime DateF)
        {
            return DAOFactory.GetOrderDAO().Read_all_like_client_daterange(id, DateI, DateF);
        }
        public List<Order> Read_all_like_number(string number)
        {
            return DAOFactory.GetOrderDAO().Read_all_like_number(number);
        }
        public List<Order> Read_all_like_number_daterange(string number, DateTime DateI, DateTime DateF)
        {
            return DAOFactory.GetOrderDAO().Read_all_like_number_daterange(number, DateI, DateF);
        }
        public List<Order> Read_all_like_technician(string id)
        {
            return DAOFactory.GetOrderDAO().Read_all_like_technician(id);
        }
        public List<Order> Read_all_like_technician_daterange(string id, DateTime DateI, DateTime DateF)
        {
            return DAOFactory.GetOrderDAO().Read_all_like_technician_daterange(id, DateI, DateF);
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

        public void UpdateState(string number, string state)
        {
            DAOFactory.GetOrderDAO().UpdateState(number, state);
        }
        public void UpdateComentarys(string number, string comentarys)
        {
            DAOFactory.GetOrderDAO().UpdateComentarys(number, comentarys);
        }
        public void Delete(string number)
        {
            DAOFactory.GetOrderDAO().Delete(number);
        }
    }
}
