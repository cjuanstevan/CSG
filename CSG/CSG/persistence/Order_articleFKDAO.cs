using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSG.model;

namespace CSG.persistence
{
    class Order_articleFKDAO : IOrder_articleFKDAO
    {
        OdbcCommand command;
        OdbcDataReader dataReader;
        public void Create(Order_articleFK order_articleFK)
        {
            try
            {
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Order_articleFK_Create(?,?)}"
                };
                command.Parameters.Add("Order", OdbcType.VarChar, 50).Value = order_articleFK.Order.Order_number;
                command.Parameters.Add("Article", OdbcType.VarChar, 50).Value = order_articleFK.Article.Article_code;
                command.ExecuteNonQuery();
                Console.WriteLine("CREATE-> order: " + order_articleFK.Order.Order_number + " | article: " + order_articleFK.Article.Article_code);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en Order_articleFKDAO->Create: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
        }

        public void Delete(string number, string code)
        {
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Order_articleFK_Delete(?,?)}"
                };
                command.Parameters.Add("Order", OdbcType.VarChar, 50).Value = number;
                command.Parameters.Add("Article", OdbcType.VarChar, 50).Value = code;
                command.ExecuteNonQuery();
                Console.WriteLine("DELETE-> order: " + number + " | article: " + code);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en Order_articleFKDAO->Delete: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
        }

        public List<Order_articleFK> Read_ArticlesOfOrder(string order_number)
        {
            List<Order_articleFK> order_Articles = new List<Order_articleFK>();
            try
            {
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Order_articleFK_ReadArticlesOfOrder(?)}"
                };
                command.Parameters.Add("OrderNumber", OdbcType.VarChar, 50).Value = order_number;
                IOrderDAO orderDAO = new OrderDAO();
                IArticleDAO articleDAO = new ArticleDAO();
                //verificamos que exista la orden
                if (orderDAO.Read_once_exist(order_number))
                {
                    //consultamos el objeto Order                    
                    Order order = orderDAO.Read_once(order_number);
                    //ejecutamos la lectura del DataReader
                    dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Order_articleFK order_ArticleFK = new Order_articleFK
                        {
                            Order = order
                        };
                        Article article = articleDAO.Read_once(dataReader.GetString(0));
                        order_ArticleFK.Article = article;
                        order_Articles.Add(order_ArticleFK);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en Order_articleFKDAO->Read_ArticlesOfOrder: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
            return order_Articles;
        }
    }
}
