using CSG.model;
using CSG.persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG.logic
{
    class OrderArticleLog
    {
        public bool ArticlesOrders(string article_code)
        {
            return DAOFactory.GetOrder_ArticleFKDAO().ArticlesOrders(article_code);
        }
        public void Create(Order_articleFK order_articleFK)
        {
            DAOFactory.GetOrder_ArticleFKDAO().Create(order_articleFK);
        }
        public string Read_code_article_of_order(string order_number)
        {
            return DAOFactory.GetOrder_ArticleFKDAO().Read_code_article_of_order(order_number);
        }
        public List<Order_articleFK> Read_ArticlesOfOrder(string order_number)
        {
            return DAOFactory.GetOrder_ArticleFKDAO().Read_ArticlesOfOrder(order_number);
        }
        public void Delete(string number, string code)
        {
            DAOFactory.GetOrder_ArticleFKDAO().Delete(number, code);
        }
    }
}
