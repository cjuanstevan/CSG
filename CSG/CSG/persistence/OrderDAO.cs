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
    class OrderDAO : IOrderDAO
    {
        OdbcCommand command;
        OdbcDataReader dataReader;
        public void Create(Order order)
        {
            try
            {

                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Order_Create(?,?,?,?,?,?,?,?,?,?,?,?)}"
                };
                command.Parameters.Add("@Number", OdbcType.VarChar, 50).Value = order.Order_number;
                command.Parameters.Add("@ReceptionDate", OdbcType.DateTime).Value = order.Order_reception_date;
                command.Parameters.Add("@EndDate", OdbcType.DateTime).Value = null;
                command.Parameters.Add("@Type", OdbcType.VarChar, 20).Value = order.Order_type;
                command.Parameters.Add("@Invoice", OdbcType.VarChar, 20).Value = order.Order_invoice;
                if (order.Order_invoice.Equals(""))
                {
                    command.Parameters.Add("@SaleDate", OdbcType.Date).Value = null;
                }
                else
                {
                    command.Parameters.Add("@SaleDate", OdbcType.Date).Value = order.Order_sale_date.Date;
                }
                command.Parameters.Add("@State", OdbcType.VarChar, 20).Value = "Revision";
                command.Parameters.Add("@Comentarys", OdbcType.VarChar, 200).Value = null;
                command.Parameters.Add("@ReportClient", OdbcType.VarChar, 200).Value = order.Order_report_client;
                command.Parameters.Add("@Technician", OdbcType.VarChar, 50).Value = order.Technician.Technician_id;
                command.Parameters.Add("@Client", OdbcType.VarChar, 50).Value = order.Client.Client_id;
                command.Parameters.Add("@Cotization", OdbcType.VarChar, 50).Value = order.Cotization.Cotization_id; //"CT-RL5";
                if (command.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Orden creada exitosamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se ha creado la orden", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en OrderDAO->Create: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
        }

        public void Delete(string number)
        {
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Orden_Delete(?)}"
                };
                command.Parameters.Add("Number", OdbcType.VarChar, 50).Value = number;
                if (command.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Orden eliminada exitosamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se ha eliminado la orden", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en OrderDAO->Delete: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
        }

        public List<Order> Read_all()
        {
            List<Order> orders = new List<Order>();
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Order_ReadAll}"
                };
                dataReader = command.ExecuteReader();
                //Console.WriteLine("Lecturas: " + dataReader.RecordsAffected);
                int cont = 0;
                while (dataReader.Read())
                {
                    //Database.Connect();
                    Order order = new Order
                    {
                        Order_number = dataReader.GetString(0),
                        Order_reception_date = dataReader.GetDateTime(1),
                        Order_end_date = dataReader.GetDateTime(2),
                        Order_type = dataReader.GetString(3),
                        Order_invoice = dataReader.GetString(4),
                        Order_sale_date = dataReader.GetDate(5),
                        Order_state = dataReader.GetString(6),
                        Order_comentarys = dataReader.GetString(7),
                        Order_report_client = dataReader.GetString(8)
                    };
                    string t = dataReader.GetString(9);
                    string c = dataReader.GetString(10);
                    string ct = dataReader.GetString(11);
                    //cont += 1;
                    //ITechnicianDAO technicianDAO = new TechnicianDAO();
                    //Technician technician = technicianDAO.Read_once(t);
                    //Database.Connect();
                    //order.Technician = technician;
                    //IClientDAO clientDAO = new ClientDAO();
                    //Client client = clientDAO.Read_once(c);
                    //Database.Connect();
                    //order.Client = client;
                    //ICotizationDAO cotizationDAO = new CotizationDAO();
                    //Cotization cotization = cotizationDAO.Read_once(ct);
                    //Database.Connect();
                    //order.Cotization = cotization;
                    orders.Add(order);
                }
                Console.WriteLine("Cantidad: " + cont);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en OrderDAO->Read_all: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
            
            return orders;
        }

        public List<Order> Read_all_like(string search)
        {
            throw new NotImplementedException();
        }

        public uint Read_count()
        {
            uint count = 0;
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Order_ReadCount}"
                };
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    count = uint.Parse(dataReader.GetInt32(0).ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en OrderDAO->Read_count: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
            return count;
        }

        public Order Read_once(string number)
        {
            Order order = new Order();
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Order_ReadOnce(?)}"
                };
                command.Parameters.Add("Number", OdbcType.VarChar, 50).Value = number;
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    order = new Order
                    {
                        Order_number = dataReader.GetString(0),
                        Order_reception_date = dataReader.GetDateTime(1),
                        //Order_end_date = dataReader.GetDateTime(2),
                        Order_type = dataReader.GetString(3),
                        Order_invoice = dataReader.GetString(4),
                        //Order_sale_date = dataReader.GetDate(5),
                        Order_state = dataReader.GetString(6),
                        //Order_comentarys = dataReader.GetString(7),
                        Order_report_client = dataReader.GetString(8)
                    };
                    string t = dataReader.GetString(9);
                    string c = dataReader.GetString(10);
                    string ct = dataReader.GetString(11);
                    Database.Disconnect();
                    ITechnicianDAO technicianDAO = new TechnicianDAO();
                    Technician technician = technicianDAO.Read_once(t);
                    order.Technician = technician;
                    IClientDAO clientDAO = new ClientDAO();
                    Client client = clientDAO.Read_once(c);
                    order.Client = client;
                    ICotizationDAO cotizationDAO = new CotizationDAO();
                    Cotization cotization = cotizationDAO.Read_once(ct);
                    order.Cotization = cotization;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en OrderDAO->Read_once: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
            return order;
        }

        public bool Read_once_exist(string number)
        {
            bool response = false;
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Order_ReadOnceExist(?)}",
                };
                command.Parameters.Add("Number", OdbcType.VarChar, 50).Value = number;
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    response = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en OrderDAO->Read_once_exist: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
            return response;
        }

        public void Update(Order order)
        {
            try
            {
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Order_Update(?,?,?,?,?,?,?,?,?,?,?,?)}"
                };
                command.Parameters.Add("Number", OdbcType.VarChar, 50).Value = order.Order_number;
                command.Parameters.Add("ReceptionDate", OdbcType.DateTime).Value = order.Order_reception_date;
                command.Parameters.Add("EndDate", OdbcType.DateTime).Value = order.Order_end_date;
                command.Parameters.Add("Type", OdbcType.VarChar, 20).Value = order.Order_type;
                command.Parameters.Add("Invoice", OdbcType.VarChar, 20).Value = order.Order_invoice;
                command.Parameters.Add("SaleDate", OdbcType.Date).Value = order.Order_sale_date;
                command.Parameters.Add("State", OdbcType.VarChar, 20).Value = order.Order_state;
                command.Parameters.Add("Comentarys", OdbcType.VarChar, 200).Value = order.Order_comentarys;
                command.Parameters.Add("ReportClient", OdbcType.VarChar, 200).Value = order.Order_report_client;
                command.Parameters.Add("Technician", OdbcType.VarChar, 50).Value = order.Technician.Technician_id;
                command.Parameters.Add("Client", OdbcType.VarChar, 50).Value = order.Client.Client_id;
                command.Parameters.Add("Cotization", OdbcType.VarChar, 50).Value = order.Cotization.Cotization_id;
                if (command.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Orden actualizada exitosamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se ha actualizado la orden", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en OrdenDAO->Update: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
        }
    }
}
