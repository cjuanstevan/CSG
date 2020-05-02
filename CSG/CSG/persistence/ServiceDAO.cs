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
    class ServiceDAO : IServiceDAO
    {
        OdbcCommand command;
        OdbcDataReader dataReader;

        public string BulkLoad(List<Service> services)
        {
            string reportT = "";
            string reportF = "";
            int counterT = 0;
            int counterF = 0;

            try
            {
                Database.Connect();
                foreach (var s in services)
                {
                    command = new OdbcCommand
                    {
                        Connection = Database.GetConn(),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "{call csg.Service_Create(?,?,?,?,?)}"
                    };
                    command.Parameters.Add("Code", OdbcType.VarChar, 50).Value = s.Service_code;
                    command.Parameters.Add("Activity", OdbcType.VarChar, 50).Value = s.Service_activity;
                    command.Parameters.Add("Duration", OdbcType.VarChar, 50).Value = s.Service_duration;
                    command.Parameters.Add("Cost", OdbcType.VarChar, 50).Value = s.Service_cost;
                    command.Parameters.Add("Type", OdbcType.Char, 1).Value = s.Service_type;
                    if (command.ExecuteNonQuery() > 0)
                    {
                        //registro quién se creó
                        reportT += "CODE: " + s.Service_code + " | ACTIVITY: " + s.Service_activity + Environment.NewLine;
                        //aumento el contador
                        counterT += 1;
                    }
                    else
                    {
                        //registro quién no se creó
                        reportF += "CODE: " + s.Service_code + " | ACTIVITY: " + s.Service_activity + Environment.NewLine;
                        //aumento el contador
                        counterF += 1;
                    }
                    //limpiamos el command (Probamos sin esto y veremos qué sucede)
                    //command.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en ServiceDAO->BulkLoad: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
            return "RESULTADO:" + Environment.NewLine +
                "Exitosos(" + counterT + "): " + Environment.NewLine +
                reportT + Environment.NewLine +
                "Fallidos(" + counterF + "): " + Environment.NewLine +
                reportF;
        }

        public void Create(Service service)
        {
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Service_Create(?,?,?,?,?)}"
                };
                command.Parameters.Add("Code", OdbcType.VarChar, 50).Value = service.Service_code;
                command.Parameters.Add("Activity", OdbcType.VarChar, 50).Value = service.Service_activity;
                command.Parameters.Add("Duration", OdbcType.VarChar, 50).Value = service.Service_duration;
                command.Parameters.Add("Cost", OdbcType.VarChar, 50).Value = service.Service_cost;
                command.Parameters.Add("Type", OdbcType.Char, 1).Value = service.Service_type;
                if (command.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Servicio creado exitosamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se ha creado el servicio", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en ServiceDAO->Create: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
        }

        public void Delete(string code)
        {
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Service_Delete(?)}"
                };
                command.Parameters.Add("Code", OdbcType.VarChar, 50).Value = code;
                if (command.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Servicio eliminado exitosamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se ha eliminado el servicio", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en ServiceDAO->Delete: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
        }

        public List<Service> Read_all()
        {
            List<Service> services = new List<Service>();
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Service_ReadAll}"
                };
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Service service = new Service
                    {
                        Service_code = dataReader.GetString(0),
                        Service_activity = dataReader.GetString(1),
                        Service_duration = dataReader.GetString(2),
                        Service_cost = dataReader.GetString(3),
                        Service_type = dataReader.GetChar(4)
                    };
                    services.Add(service);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en ServiceDAO->Read_all: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
            return services;
        }

        public List<Service> Read_all_like(string search)
        {
            List<Service> services = new List<Service>();
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Service_ReadAllLike(?)}"
                };
                command.Parameters.Add("Search", OdbcType.VarChar, 50).Value = search;
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Service service = new Service
                    {
                        Service_code = dataReader.GetString(0),
                        Service_activity = dataReader.GetString(1),
                        Service_duration = dataReader.GetString(2),
                        Service_cost = dataReader.GetString(3),
                        Service_type = dataReader.GetChar(4)
                    };
                    services.Add(service);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en ServiceDAO->Read_all_like: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
            return services;
        }

        public Service Read_once(string code)
        {
            Service service = new Service();
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Service_ReadOnce(?)}"
                };
                command.Parameters.Add("Code", OdbcType.VarChar, 50).Value = code;
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    service = new Service
                    {
                        Service_code = dataReader.GetString(0),
                        Service_activity = dataReader.GetString(1),
                        Service_duration = dataReader.GetString(2),
                        Service_cost = dataReader.GetString(3),
                        Service_type = dataReader.GetChar(4)
                    };
                }
                else
                {
                    service = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en ServiceDAO->Read_once: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
            return service;
        }

        public bool Read_once_exist(string code)
        {
            bool response = false;
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Service_ReadOnceExist(?)}",
                };
                command.Parameters.Add("Code", OdbcType.VarChar, 50).Value = code;
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    response = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en RefactionDAO->Read_once_exist: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
            return response;
        }

        public void Update(Service service)
        {
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Service_Update(?,?,?,?,?)}"
                };
                command.Parameters.Add("Code", OdbcType.VarChar, 50).Value = service.Service_code;
                command.Parameters.Add("Activity", OdbcType.VarChar, 50).Value = service.Service_activity;
                command.Parameters.Add("Duration", OdbcType.VarChar, 50).Value = service.Service_duration;
                command.Parameters.Add("Cost", OdbcType.VarChar, 50).Value = service.Service_cost;
                command.Parameters.Add("Type", OdbcType.Char, 1).Value = service.Service_type;
                if (command.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Servicio actualizado exitosamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se ha actualizado el servicio", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en ServiceDAO->Update: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
        }
    }
}
