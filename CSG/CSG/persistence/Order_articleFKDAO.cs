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
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Order_articleFK_Create(?,?,?,?,?)}"
                };
                command.Parameters.Add("Order", OdbcType.VarChar, 50).Value = order_articleFK.Order_number;
                command.Parameters.Add("Article", OdbcType.VarChar, 50).Value = order_articleFK.Article_code;
                //Agregar 3 campos por si es tanque o hidro
                command.Parameters.Add("Model", OdbcType.VarChar, 50).Value = order_articleFK.Model;
                command.Parameters.Add("Esp", OdbcType.VarChar, 50).Value = order_articleFK.Especification;
                command.Parameters.Add("Serial", OdbcType.VarChar, 50).Value = order_articleFK.Serial;
                command.ExecuteNonQuery();
                Console.WriteLine("CREATE-> order: " + order_articleFK.Order_number + " | article: " + order_articleFK.Article_code);
                
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
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Order_articleFK_ReadArticlesOfOrder(?)}"
                };
                command.Parameters.Add("OrderNumber", OdbcType.VarChar, 50).Value = order_number;
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Order_articleFK order_ArticleFK = new Order_articleFK
                    {
                        Order_number = order_number,
                        Article_code = dataReader.GetString(0),
                        Model = dataReader.GetString(1),
                        Especification = dataReader.GetString(2),
                        Serial = dataReader.GetString(3)
                    };
                    order_Articles.Add(order_ArticleFK);
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

        public string Read_code_article_of_order(string order_number)
        {
            string code = "";
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Order_articleFK_ReadCodeArticleOfOrder(?)}"
                };
                command.Parameters.Add("OrderNumber", OdbcType.VarChar, 50).Value = order_number;
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    code = dataReader.GetString(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en Order_articleFKDAO->Read_code_article_of_order: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
            return code;
        }
    }
}
