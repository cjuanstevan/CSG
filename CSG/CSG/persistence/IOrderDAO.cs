using System;
using System.Collections;
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
        ArrayList Read_all_numbers();//ok
        List<Order> Read_all();//ok
        List<Order> Read_all_DateReception(DateTime DateI, DateTime DateF);//ok
        List<Order> Read_all_like_client(string id);//ok
        List<Order> Read_all_like_client_daterange(string id, DateTime DateI, DateTime DateF);//ok
        List<Order> Read_all_like_number(string number);//ok
        List<Order> Read_all_like_number_daterange(string number, DateTime DateI, DateTime DateF);//ok
        List<Order> Read_all_like_technician(string id);//ok
        List<Order> Read_all_like_technician_daterange(string id, DateTime DateI, DateTime DateF);//ok
        Order Read_once(string number);//ok
        bool Read_once_exist(string number);//ok
        uint Read_count();
        void Update(Order order);//ok
        void Delete(string number);//ok
        List<Order> Read_all_like(string search);
    }
}
