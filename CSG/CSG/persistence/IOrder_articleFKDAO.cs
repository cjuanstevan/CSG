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
        bool ArticlesOrders(string article_code);
        void Create(Order_articleFK order_articleFK);//ok
        string Read_code_article_of_order(string order_number);
        Order_articleFK Read_ArticleOfOrder(string order_number);//1 objeto
        List<Order_articleFK> Read_ArticlesOfOrder(string order_number);//ok 1 lista de objetos
        void Delete(string number, string code);//ok
    }
}
