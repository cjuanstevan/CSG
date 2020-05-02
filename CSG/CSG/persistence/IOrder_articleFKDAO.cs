﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSG.model;

namespace CSG.persistence
{
    interface IOrder_articleFKDAO
    {
        void Create(Order_articleFK order_articleFK);//ok
        List<Order_articleFK> Read_ArticlesOfOrder(string order_number);//ok
        void Delete(string number, string code);//ok
    }
}