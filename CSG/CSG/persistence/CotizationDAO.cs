using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSG.cache;
using CSG.model;

namespace CSG.persistence
{
    class CotizationDAO : ICotizationDAO
    {
        OdbcCommand command;
        OdbcDataReader dataReader;
        public void Create(Cotization cotization)
        {
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Cotization_Create(?,?,?,?,?,?,?,?,?)}"
                };
                command.Parameters.Add("Id", OdbcType.VarChar, 50).Value = cotization.Cotization_id;
                //command.Parameters.Add("GenerationDate", OdbcType.DateTime).Value = null;
                //command.Parameters.Add("ExpirationDate", OdbcType.DateTime).Value = null;
                command.Parameters.Add("Quantity", OdbcType.SmallInt).Value = cotization.Cotization_quantity;
                command.Parameters.Add("Comentarys", OdbcType.VarChar, 1000).Value = cotization.Cotization_comentarys;
                command.Parameters.Add("Subtotal", OdbcType.VarChar, 14).Value = cotization.Cotization_subtotal;
                command.Parameters.Add("Discount", OdbcType.VarChar, 14).Value = cotization.Cotization_discount;
                command.Parameters.Add("Iva", OdbcType.VarChar, 14).Value = cotization.Cotization_iva;
                command.Parameters.Add("Total", OdbcType.VarChar, 14).Value = cotization.Cotization_total;
                command.Parameters.Add("CreateBy", OdbcType.VarChar, 50).Value = UserCache.UserCode;
                command.Parameters.Add("CreateDate", OdbcType.DateTime).Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                if (command.ExecuteNonQuery() > 0)
                {
                    Console.WriteLine("Cotización creada exitosamente");
                    //MessageBox.Show("Cotización creada exitosamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Console.WriteLine("No se ha creado la cotización");
                    //MessageBox.Show("No se ha creado la cotización", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en CotizationDAO->Create: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
        }

        public void Delete(string id)
        {
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Cotization_Delete(?)}"
                };
                command.Parameters.Add("Id", OdbcType.VarChar, 50).Value = id;
                if (command.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Cotización eliminada exitosamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se ha eliminado la cotización", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en CotizationDAO->Delete: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
        }

        public List<Cotization> Read_all()
        {
            List<Cotization> cotizations = new List<Cotization>();
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Cotization_ReadAll}"
                };
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Cotization cotization = new Cotization
                    {
                        Cotization_id = dataReader.GetString(0),
                        Cotization_generation_date = dataReader.GetDateTime(1),
                        Cotization_expiration_date = dataReader.GetDateTime(2),
                        Cotization_quantity = dataReader.GetByte(3),
                        Cotization_comentarys = dataReader.GetString(4),
                        Cotization_subtotal = dataReader.GetString(5),
                        Cotization_discount = dataReader.GetString(6),
                        Cotization_iva = dataReader.GetString(7),
                        Cotization_total = dataReader.GetString(8)
                    };
                    cotizations.Add(cotization);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en CotizationDAO->Read_all: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
            return cotizations;
        }

        public Cotization Read_once(string id)
        {
            Cotization cotization = new Cotization();
            try
            {
                //Console.WriteLine("Conexion Cotizacion: " + Database.GetConn().State);
                if (!Database.GetConn().State.ToString().Equals("Open"))
                {
                    Database.Connect();
                }
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Cotization_ReadOnce(?)}"
                };
                command.Parameters.Add("Id", OdbcType.VarChar, 50).Value = id;
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    cotization = new Cotization
                    {
                        Cotization_id = dataReader.GetString(0),
                        Cotization_generation_date = dataReader.GetDateTime(1),
                        Cotization_expiration_date = dataReader.GetDateTime(2),
                        Cotization_quantity = dataReader.GetByte(3),
                        Cotization_comentarys = dataReader.GetString(4),
                        Cotization_subtotal = dataReader.GetString(5),
                        Cotization_discount = dataReader.GetString(6),
                        Cotization_iva = dataReader.GetString(7),
                        Cotization_total = dataReader.GetString(8)
                    };
                }
                else
                {
                    cotization = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en CotizationDAO->Read_once: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
            return cotization;
        }

        public bool Read_once_exist(string id)
        {
            bool response = false;
            try
            {
                if (!Database.GetConn().State.ToString().Equals("Open"))
                {
                    Database.Connect();
                }
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Cotization_ReadOnceExist(?)}",
                };
                command.Parameters.Add("Id", OdbcType.VarChar, 50).Value = id;
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    response = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en CotizationDAO->Read_once_exist: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
            return response;
        }

        public void Update(Cotization cotization)
        {
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Cotization_Update(?,?,?,?,?,?,?,?,?,?,?)}"
                };
                command.Parameters.Add("Id", OdbcType.VarChar, 50).Value = cotization.Cotization_id;
                command.Parameters.Add("GenerationDate", OdbcType.DateTime).Value = cotization.Cotization_generation_date;
                command.Parameters.Add("ExpirationDate", OdbcType.DateTime).Value = null;
                command.Parameters.Add("Quantity", OdbcType.Int).Value = cotization.Cotization_quantity;
                command.Parameters.Add("Comentarys", OdbcType.VarChar, 1000).Value = cotization.Cotization_comentarys;
                command.Parameters.Add("Subtotal", OdbcType.VarChar, 14).Value = cotization.Cotization_subtotal;
                command.Parameters.Add("Discount", OdbcType.VarChar, 14).Value = cotization.Cotization_discount;
                command.Parameters.Add("Iva", OdbcType.VarChar, 14).Value = cotization.Cotization_iva;
                command.Parameters.Add("Total", OdbcType.VarChar, 14).Value = cotization.Cotization_total;
                //Add
                command.Parameters.Add("UpdateBy", OdbcType.VarChar, 50).Value = UserCache.UserCode;
                command.Parameters.Add("UpdateDate", OdbcType.DateTime).Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                if (command.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Cotización actualizada exitosamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se ha actualizado la cotización", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en CotizationDAO->Update: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
        }

        public void UpdateExpirationDate(string id, DateTime expiration_date)
        {
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Cotization_UpdateExpirationDate(?,?,?,?)}"
                };
                command.Parameters.Add("Id", OdbcType.VarChar, 50).Value = id;
                command.Parameters.Add("ExpirationDate", OdbcType.DateTime).Value = expiration_date;
                
                //Add
                command.Parameters.Add("UpdateBy", OdbcType.VarChar, 50).Value = UserCache.UserAccount;
                command.Parameters.Add("UpdateDate", OdbcType.DateTime).Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                if (command.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Cotización actualizada exitosamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se ha actualizado la cotización", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en CotizationDAO->Update: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
        }
    }
}
