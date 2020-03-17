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
    class ClientDAO : IClientDAO
    {
        OdbcCommand command;
        OdbcDataReader dataReader;
        public void Create(Client client)
        {
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.CreateClient(?,?,?,?,?,?,?,?,?,?,?)}",
                };
                command.Parameters.Add("", OdbcType.VarChar, 50, "Id").Value = client.Client_id;
                command.Parameters.Add("", OdbcType.VarChar, 50, "Name").Value = client.Client_name;
                command.Parameters.Add("", OdbcType.VarChar, 50, "Lastname1").Value = client.Client_lastname1;
                command.Parameters.Add("", OdbcType.VarChar, 50, "Lastname2").Value = client.Client_lastname2;
                command.Parameters.Add("", OdbcType.VarChar, 50, "Address").Value = client.Client_address;
                command.Parameters.Add("", OdbcType.VarChar, 50, "Location").Value = client.Client_location;
                command.Parameters.Add("", OdbcType.VarChar, 50, "City").Value = client.Client_city;
                command.Parameters.Add("", OdbcType.VarChar, 50, "Department").Value = client.Client_department;
                command.Parameters.Add("", OdbcType.VarChar, 50, "Tel1").Value = client.Client_tel1;
                command.Parameters.Add("", OdbcType.VarChar, 50, "Tel2").Value = client.Client_tel2;
                command.Parameters.Add("", OdbcType.VarChar, 50, "Email").Value = client.Client_email;
                if (command.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Cliente creado exitosamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se ha creado el cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

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
            throw new NotImplementedException();
        }

        public List<Client> Read_all()
        {
            throw new NotImplementedException();
        }

        public Client Read_once(string id)
        {
            Client client = new Client();
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.ReadClientById(?)}",
                };
                command.Parameters.Add("", OdbcType.VarChar, 50, "Id").Value = id;
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    //client = new Client(dataReader.GetString(0), dataReader.GetString(0), dataReader.GetString(0),)
                    client = new Client
                    {
                        Client_id = dataReader.GetString(0),
                        Client_name = dataReader.GetString(1),
                        Client_lastname1 = dataReader.GetString(2),
                        Client_lastname2 = dataReader.GetString(3),
                        Client_address = dataReader.GetString(4),
                        Client_location = dataReader.GetString(5),
                        Client_city = dataReader.GetString(6),
                        Client_department = dataReader.GetString(7),
                        Client_tel1 = dataReader.GetString(8),
                        Client_tel2 = dataReader.GetString(9),
                        Client_email = dataReader.GetString(10)
                    };
                }
                else
                {
                    client = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en ClientDAO->Create: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
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
                    CommandText = "{call csg.ReadClientById(?)}",
                };
                command.Parameters.Add("", OdbcType.VarChar, 50, "Id").Value = id;
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
            throw new NotImplementedException();
        }
    }
}
