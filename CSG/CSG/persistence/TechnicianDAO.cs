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
    class TechnicianDAO : ITechnicianDAO
    {
        OdbcCommand command;
        OdbcDataReader dataReader;

        public string BulkLoad(List<Technician> technicians)
        {
            string reportT = "";
            string reportF = "";
            int counterT = 0;
            int counterF = 0;

            try
            {
                Database.Connect();
                foreach (var t in technicians)
                {
                    command = new OdbcCommand
                    {
                        Connection = Database.GetConn(),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "{call csg.Technician_Create(?,?,?,?,?,?)}"
                    };
                    command.Parameters.Add("Id", OdbcType.VarChar, 50).Value = t.Technician_id;
                    command.Parameters.Add("Name", OdbcType.VarChar, 50).Value = t.Technician_name;
                    command.Parameters.Add("Contact", OdbcType.VarChar, 50).Value = t.Technician_contact;
                    command.Parameters.Add("Alias", OdbcType.VarChar, 50).Value = t.Technician_alias;
                    command.Parameters.Add("Telephone", OdbcType.VarChar, 50).Value = t.Technician_telephone;
                    command.Parameters.Add("Position", OdbcType.VarChar, 50).Value = t.Technician_position;
                    if (command.ExecuteNonQuery() > 0)
                    {
                        //registro quién se creó
                        reportT += "ID: " + t.Technician_id + " | NOMBRE: " + t.Technician_name + Environment.NewLine;
                        //aumento el contador
                        counterT += 1;
                    }
                    else
                    {
                        //registro quién no se creó
                        reportF += "ID: " + t.Technician_id + " | NOMBRE: " + t.Technician_name + Environment.NewLine;
                        //aumento el contador
                        counterF += 1;
                    }
                    //limpiamos el command (Probamos sin esto y veremos qué sucede)
                    //command.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en TechnicianDAO->BulkLoad: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void Create(Technician technician)
        {
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Technician_Create(?,?,?,?,?,?)}"
                };
                command.Parameters.Add("Id", OdbcType.VarChar, 50).Value = technician.Technician_id;
                command.Parameters.Add("Name", OdbcType.VarChar, 50).Value = technician.Technician_name;
                command.Parameters.Add("Contact", OdbcType.VarChar, 50).Value = technician.Technician_contact;
                command.Parameters.Add("Alias", OdbcType.VarChar, 50).Value = technician.Technician_alias;
                command.Parameters.Add("Telephone", OdbcType.VarChar, 50).Value = technician.Technician_telephone;
                command.Parameters.Add("Position", OdbcType.VarChar, 50).Value = technician.Technician_position;
                if (command.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Técnico creado exitosamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se ha creado el técnico", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en TechnicianDAO->Create: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    CommandText = "{call csg.Technician_Delete(?)}"
                };
                command.Parameters.Add("Id", OdbcType.VarChar, 50).Value = id;
                if (command.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Técnico eliminado exitosamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se ha eliminado el técnico", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en TechnicianDAO->Delete: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
        }

        public List<Technician> Read_all()
        {
            List<Technician> technicians = new List<Technician>();
            try
            {
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType =CommandType.StoredProcedure,
                    CommandText = "{call csg.Technician_ReadAll}"
                };
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Technician technician = new Technician
                    {
                        Technician_id = dataReader.GetString(0),
                        Technician_name = dataReader.GetString(1),
                        Technician_contact = dataReader.GetString(2),
                        Technician_alias = dataReader.GetString(3),
                        Technician_telephone = dataReader.GetString(4),
                        Technician_position = dataReader.GetString(5)
                    };
                    technicians.Add(technician);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Excepción controlada en TechnicianDAO->Read_all: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
            return technicians;
        }

        public Technician Read_once(string id)
        {
            Technician technician = new Technician();
            try
            {
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Technician_ReadOnce(?)}"
                };
                command.Parameters.Add("Id", OdbcType.VarChar, 50).Value = id;
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    technician = new Technician
                    {
                        Technician_id = dataReader.GetString(0),
                        Technician_name = dataReader.GetString(1),
                        Technician_contact = dataReader.GetString(2),
                        Technician_alias = dataReader.GetString(3),
                        Technician_telephone = dataReader.GetString(4),
                        Technician_position = dataReader.GetString(5)
                    };
                }
                else
                {
                    technician = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en TechnicianDAO->Read_once: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
            return technician;
        }

        public bool Read_once_exist(string id)
        {
            bool response = false;
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Technician_ReadOnceExist(?)}",
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
                MessageBox.Show("Excepción controlada en TechnicianDAO->Read_once_exist: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
            return response;
        }

        public void Update(Technician technician)
        {
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Technician_Update(?,?,?,?,?,?)}"
                };
                command.Parameters.Add("Id", OdbcType.VarChar, 50).Value = technician.Technician_id;
                command.Parameters.Add("Name", OdbcType.VarChar, 50).Value = technician.Technician_name;
                command.Parameters.Add("Contact", OdbcType.VarChar, 50).Value = technician.Technician_contact;
                command.Parameters.Add("Alias", OdbcType.VarChar, 50).Value = technician.Technician_alias;
                command.Parameters.Add("Telephone", OdbcType.VarChar, 50).Value = technician.Technician_telephone;
                command.Parameters.Add("Position", OdbcType.VarChar, 50).Value = technician.Technician_position;
                if (command.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Técnico actualizado exitosamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se ha actualizado el técnico", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en TechnicianDAO->Update: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
        }
    }
}
