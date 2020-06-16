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
    class Cotization_serviceFKDAO : ICotization_serviceFKDAO
    {
        OdbcCommand command;
        OdbcDataReader dataReader;
        public void Create(Cotization_serviceFK cotization_serviceFK)
        {
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Cotization_serviceFK_Create(?,?,?,?,?)}"
                };
                command.Parameters.Add("CotizationId", OdbcType.VarChar, 50).Value = cotization_serviceFK.Cotization_id;
                command.Parameters.Add("ServiceCode", OdbcType.VarChar, 50).Value = cotization_serviceFK.Service_code;
                //Adds
                command.Parameters.Add("ActionOf", OdbcType.VarChar, 50).Value = cotization_serviceFK.Actionof;
                command.Parameters.Add("Quantity", OdbcType.TinyInt).Value = cotization_serviceFK.Service_quantity;
                command.Parameters.Add("Amount", OdbcType.VarChar, 14).Value = cotization_serviceFK.Service_amount;

                command.ExecuteNonQuery();
                Console.WriteLine("CREATE-> cotization: " + cotization_serviceFK.Cotization_id + " | service: " + cotization_serviceFK.Service_code);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en Cotization_serviceFKDAO->Create: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
        }

        public void Delete(string cotization_id, string service_code)
        {
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Cotization_serviceFK_Delete(?,?)}"
                };
                command.Parameters.Add("Cotization", OdbcType.VarChar, 50).Value = cotization_id;
                command.Parameters.Add("Service", OdbcType.VarChar, 50).Value = service_code;
                command.ExecuteNonQuery();
                Console.WriteLine("DELETE-> cotization: " + cotization_id + " | service: " + service_code);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en Cotization_serviceFKDAO->Delete: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
        }

        public List<Cotization_serviceFK> Read_ServicesOfCotization(string cotization_id)
        {
            List<Cotization_serviceFK> cotization_Services = new List<Cotization_serviceFK>();
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
                    CommandText = "{call csg.Cotization_serviceFK_ReadServicesOfCotization(?)}"
                };
                command.Parameters.Add("CotizationId", OdbcType.VarChar, 50).Value = cotization_id;
                //ejecutamos la lectura del DataReader
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Cotization_serviceFK cotization_ServiceFK = new Cotization_serviceFK
                    {
                        Cotization_id = cotization_id,
                        Service_code= dataReader.GetString(0),
                        Service_quantity = dataReader.GetByte(1),
                        Service_amount = dataReader.GetString(2)
                    };
                    cotization_Services.Add(cotization_ServiceFK);
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en Cotization_serviceFKDAO->Read_ServicesOfCotization: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
            return cotization_Services;
        }

        public bool ServicesCotizations(string service_code)
        {
            bool request = true;
            try
            {
                Database.Connect();
                command = new OdbcCommand()
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Cotization_serviceFK_ServicesCotization(?)}"
                };
                command.Parameters.Add("@ServiceCode", OdbcType.VarChar, 50).Value = service_code;
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    if (dataReader.GetInt32(0) > 0)
                    {
                        request = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en Cotization_serviceFKDAO->ServicesCotizations: "
                    + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            finally
            {
                Database.Disconnect();
            }
            return request;
        }
    }
}
