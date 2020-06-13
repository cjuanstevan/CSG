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
    class ClientDAO : IClientDAO
    {
        OdbcCommand command;
        OdbcDataReader dataReader;

        public string BulkLoad(List<Client> clients)
        {
            string reportT = "";
            string reportF = "";
            int counterT = 0;
            int counterF = 0;

            try
            {
                Database.Connect();
                foreach (var c in clients)
                {
                    command = new OdbcCommand
                    {
                        Connection = Database.GetConn(),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "{call csg.Client_Create(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)}"
                    };
                    command.Parameters.Add("Id", OdbcType.VarChar, 50).Value = c.Client_id;
                    command.Parameters.Add("Name", OdbcType.VarChar, 50).Value = c.Client_name;
                    command.Parameters.Add("Address", OdbcType.VarChar, 50).Value = c.Client_address;
                    command.Parameters.Add("Location", OdbcType.VarChar, 50).Value = c.Client_location;
                    command.Parameters.Add("City", OdbcType.VarChar, 50).Value = c.Client_city;
                    command.Parameters.Add("Department", OdbcType.VarChar, 50).Value = c.Client_department;
                    command.Parameters.Add("Tel1", OdbcType.VarChar, 50).Value = c.Client_tel1;
                    command.Parameters.Add("Tel2", OdbcType.VarChar, 50).Value = c.Client_tel2;
                    command.Parameters.Add("Email", OdbcType.VarChar, 50).Value = c.Client_email;

                    command.Parameters.Add("RUT", OdbcType.VarChar, 50).Value = null;
                    command.Parameters.Add("Rlegal", OdbcType.VarChar, 50).Value = null;
                    command.Parameters.Add("Admin", OdbcType.VarChar, 50).Value = null;
                    command.Parameters.Add("WSite", OdbcType.VarChar, 50).Value = null;
                    command.Parameters.Add("Postal", OdbcType.VarChar, 10).Value = null;
                    command.Parameters.Add("Fax", OdbcType.VarChar, 20).Value = null;
                    command.Parameters.Add("LEst", OdbcType.VarChar, 50).Value = null;
                    command.Parameters.Add("Type", OdbcType.NChar, 1).Value = 'j';

                    command.Parameters.Add("CreateBy", OdbcType.VarChar, 50).Value = "bulkload";
                    command.Parameters.Add("CreateDate", OdbcType.DateTime).Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.Parameters.Add("UpdateBy", OdbcType.VarChar, 50).Value = null;
                    command.Parameters.Add("UpdateDate", OdbcType.DateTime).Value = null;

                    if (command.ExecuteNonQuery() > 0)
                    {
                        //registro quién se creó
                        reportT += "ID: " + c.Client_id + " | NOMBRE: " + c.Client_name + " " + Environment.NewLine;
                        //aumento el contador
                        counterT += 1;
                    }
                    else
                    {
                        //registro quién no se creó
                        reportF += "ID: " + c.Client_id + " | NOMBRE: " + c.Client_name + " " + Environment.NewLine;
                        //aumento el contador
                        counterF += 1;
                    }
                    //limpiamos el command (Probamos sin esto y veremos qué sucede)
                    //command.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en ClientDAO->BulkLoad: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void Create(Client client)
        {
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Client_Create(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)}"
                };
                command.Parameters.Add("Id", OdbcType.VarChar, 50).Value = client.Client_id;
                command.Parameters.Add("Name", OdbcType.VarChar, 50).Value = client.Client_name;
                command.Parameters.Add("Address", OdbcType.VarChar, 50).Value = client.Client_address;
                command.Parameters.Add("Location", OdbcType.VarChar, 50).Value = client.Client_location;
                command.Parameters.Add("City", OdbcType.VarChar, 50).Value = client.Client_city;
                command.Parameters.Add("Department", OdbcType.VarChar, 50).Value = client.Client_department;
                command.Parameters.Add("Tel1", OdbcType.VarChar, 50).Value = client.Client_tel1;
                command.Parameters.Add("Tel2", OdbcType.VarChar, 50).Value = client.Client_tel2;
                command.Parameters.Add("Email", OdbcType.VarChar, 50).Value = client.Client_email;
                //Adds
                command.Parameters.Add("RUT", OdbcType.VarChar, 50).Value = client.Client_rut;
                command.Parameters.Add("Rlegal", OdbcType.VarChar, 50).Value = client.Client_rlegal;
                command.Parameters.Add("Admin", OdbcType.VarChar, 50).Value = client.Client_adm;
                command.Parameters.Add("WSite", OdbcType.VarChar, 50).Value = client.Client_website;
                command.Parameters.Add("Postal", OdbcType.VarChar, 10).Value = client.Client_postal;
                command.Parameters.Add("Fax", OdbcType.VarChar, 20).Value = client.Client_fax;
                command.Parameters.Add("LEst", OdbcType.VarChar, 50).Value = client.Client_lstructure;
                command.Parameters.Add("Type", OdbcType.NChar, 1).Value = client.Client_type;
                //Add2
                command.Parameters.Add("CreateBy", OdbcType.VarChar, 50).Value = UserCache.UserAccount;
                command.Parameters.Add("CreateDate", OdbcType.DateTime).Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                command.Parameters.Add("UpdateBy", OdbcType.VarChar, 50).Value = null;
                command.Parameters.Add("UpdateDate", OdbcType.DateTime).Value = null;
                //Ejecutamos el query
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en ClientDAO->Create: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    CommandText = "{call csg.Client_Delete(?)}"
                };
                command.Parameters.Add("Id", OdbcType.VarChar, 50).Value = id;
                if (command.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Cliente eliminado exitosamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se ha eliminado el cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción" + ex.StackTrace + " controlada en ClientDAO->Delete: " 
                    + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //catch (OdbcException ex)
            //{
            //    MessageBox.Show("Excepción controlada en ClientDAO->Delete: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            finally
            {
                Database.Disconnect();
            }
        }

        public bool EqualMailings(string client_email)
        {
            try
            {
                Database.Connect();
                command = new OdbcCommand()
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Client_EqualMailings(?)}"
                };
                command.Parameters.Add("ClientEmail", OdbcType.VarChar, 50).Value = client_email;
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    if (dataReader.GetInt32(0) > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en ClientDAO->EqualMailings: " + ex.Message, "Excepción",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            finally
            {
                Database.Disconnect();
            }
        }

        public List<Client> Read_all()
        {
            List<Client> clients = new List<Client>();
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Client_ReadAll}"
                };
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Client client = new Client
                    {
                        Client_id = dataReader.GetString(0),
                        Client_name = dataReader.GetString(1),
                        Client_address = dataReader.GetString(2),
                        Client_location = dataReader.GetString(3),
                        Client_city = dataReader.GetString(4),
                        Client_department = dataReader.GetString(5),
                        Client_tel1 = dataReader.GetString(6),
                        Client_tel2 = dataReader.GetString(7),
                        Client_email = dataReader.GetString(8),
                        Client_rut = dataReader.GetString(9),
                        Client_rlegal = dataReader.GetString(10),
                        Client_adm = dataReader.GetString(11),
                        Client_website = dataReader.GetString(12),
                        Client_postal = dataReader.GetString(13),
                        Client_fax = dataReader.GetString(14),
                        Client_lstructure = dataReader.GetString(15),
                        Client_type = dataReader.GetChar(16)
                    };
                    clients.Add(client);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en ClientDAO->Read_all: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
            return clients;
        }

        public List<Client> Read_all_like(string search)
        {
            List<Client> clients = new List<Client>();
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Client_ReadAllLike(?)}"
                };
                command.Parameters.Add("Search", OdbcType.VarChar, 50).Value = search;
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Client client = new Client
                    {
                        Client_id = dataReader.GetString(0),
                        Client_name = dataReader.GetString(1),
                        Client_address = dataReader.GetString(2),
                        Client_location = dataReader.GetString(3),
                        Client_city = dataReader.GetString(4),
                        Client_department = dataReader.GetString(5),
                        Client_tel1 = dataReader.GetString(6),
                        Client_tel2 = dataReader.GetString(7),
                        Client_email = dataReader.GetString(8),
                        Client_rut = dataReader.GetString(9),
                        Client_rlegal = dataReader.GetString(10),
                        Client_adm = dataReader.GetString(11),
                        Client_website = dataReader.GetString(12),
                        Client_postal = dataReader.GetString(13),
                        Client_fax = dataReader.GetString(14),
                        Client_lstructure = dataReader.GetString(15),
                        Client_type = dataReader.GetChar(16)
                    };
                    clients.Add(client);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en ClientDAO->Read_all_like: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
            return clients;
        }

        public Client Read_once(string id)
        {
            Client client = new Client();
            try
            {
                //Console.WriteLine("Conexion Cliente: " + Database.GetConn().State);
                if (!Database.GetConn().State.ToString().Equals("Open"))
                {
                    Database.Connect();
                }
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Client_ReadOnce(?)}"
                };
                command.Parameters.Add("Id", OdbcType.VarChar, 50).Value = id;
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    client = new Client
                    {
                        Client_id = dataReader.GetString(0),
                        Client_name = dataReader.GetString(1),
                        Client_address = dataReader.GetString(2),
                        Client_location = dataReader.GetString(3),
                        Client_city = dataReader.GetString(4),
                        Client_department = dataReader.GetString(5),
                        Client_tel1 = dataReader.GetString(6),
                        Client_tel2 = dataReader.GetString(7),
                        Client_email = dataReader.GetString(8),
                        Client_rut = dataReader.GetString(9),
                        Client_rlegal = dataReader.GetString(10),
                        Client_adm = dataReader.GetString(11),
                        Client_website = dataReader.GetString(12),
                        Client_postal = dataReader.GetString(13),
                        Client_fax = dataReader.GetString(14),
                        Client_lstructure = dataReader.GetString(15),
                        Client_type = dataReader.GetChar(16)
                    };
                }
                else
                {
                    client = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en ClientDAO->Read_once: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
                //Database.Connect();
            }
            return client;
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
                    CommandText = "{call csg.Client_ReadOnceExist(?)}",
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
                MessageBox.Show("Excepción controlada en ClientDAO->Read_once_exist: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
            return response;
        }

        public void Update(Client client)
        {
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure
                };
                if (client.Client_type.Equals('j'))
                {
                    Console.WriteLine("DAOCLiente->Actualiza J: " + client.Update_by);
                    command.CommandText = "{call csg.Client_UpdateJ(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)}";
                    command.Parameters.Add("Id", OdbcType.VarChar, 50).Value = client.Client_id;
                    command.Parameters.Add("Name", OdbcType.VarChar, 50).Value = client.Client_name;
                    command.Parameters.Add("Address", OdbcType.VarChar, 50).Value = client.Client_address;
                    command.Parameters.Add("Location", OdbcType.VarChar, 50).Value = client.Client_location;
                    command.Parameters.Add("City", OdbcType.VarChar, 50).Value = client.Client_city;
                    command.Parameters.Add("Department", OdbcType.VarChar, 50).Value = client.Client_department;
                    command.Parameters.Add("Tel1", OdbcType.VarChar, 50).Value = client.Client_tel1;
                    command.Parameters.Add("Tel2", OdbcType.VarChar, 50).Value = client.Client_tel2;
                    command.Parameters.Add("Email", OdbcType.VarChar, 50).Value = client.Client_email;
                    command.Parameters.Add("RUT", OdbcType.VarChar, 50).Value = client.Client_rut;
                    command.Parameters.Add("Rlegal", OdbcType.VarChar, 50).Value = client.Client_rlegal;
                    command.Parameters.Add("Admin", OdbcType.VarChar, 50).Value = client.Client_adm;
                    command.Parameters.Add("WSite", OdbcType.VarChar, 50).Value = client.Client_website;
                    command.Parameters.Add("Postal", OdbcType.VarChar, 10).Value = client.Client_postal;
                    command.Parameters.Add("Fax", OdbcType.VarChar, 20).Value = client.Client_fax;
                    command.Parameters.Add("LEst", OdbcType.VarChar, 5).Value = client.Client_lstructure;
                    //Add2
                    command.Parameters.Add("UpdateBy", OdbcType.VarChar, 50).Value = UserCache.UserAccount;
                    command.Parameters.Add("UpdateDate", OdbcType.DateTime).Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));


                }
                else if (client.Client_type.Equals('n'))
                {
                    command.CommandText = "{call csg.Client_UpdateN(?,?,?,?,?,?,?,?,?)}";
                    command.Parameters.Add("Id", OdbcType.VarChar, 50).Value = client.Client_id;
                    command.Parameters.Add("Name", OdbcType.VarChar, 50).Value = client.Client_name;
                    command.Parameters.Add("Address", OdbcType.VarChar, 50).Value = client.Client_address;
                    command.Parameters.Add("City", OdbcType.VarChar, 50).Value = client.Client_city;
                    command.Parameters.Add("Department", OdbcType.VarChar, 50).Value = client.Client_department;
                    command.Parameters.Add("Tel1", OdbcType.VarChar, 50).Value = client.Client_tel1;
                    command.Parameters.Add("Email", OdbcType.VarChar, 50).Value = client.Client_email;
                    //Add2
                    command.Parameters.Add("UpdateBy", OdbcType.VarChar, 50).Value = UserCache.UserAccount;
                    command.Parameters.Add("UpdateDate", OdbcType.DateTime).Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                command.ExecuteNonQuery();

                //if (command.ExecuteNonQuery() > 0)
                //{
                //    MessageBox.Show("Cliente actualizado exitosamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                //else
                //{
                //    MessageBox.Show("No se ha actualizado el cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en ClientDAO->Update: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
        }
    }
}
