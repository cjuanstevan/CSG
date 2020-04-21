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
    class RefactionDAO : IRefactionDAO
    {
        OdbcCommand command;
        OdbcDataReader dataReader;
        public void Create(Refaction refaction)
        {
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Refaction_Create(?,?,?)}"
                };
                command.Parameters.Add("Code", OdbcType.VarChar, 50).Value = refaction.Refaction_code;
                command.Parameters.Add("Description", OdbcType.VarChar, 50).Value = refaction.Refaction_description;
                command.Parameters.Add("UnitPrice", OdbcType.Decimal).Value = refaction.Refaction_unit_price;
                if (command.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Repuesto creado exitosamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se ha creado el repuesto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en RefactionDAO->Create: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    CommandText = "{call csg.Refaction_Delete(?)}"
                };
                command.Parameters.Add("Code", OdbcType.VarChar, 50).Value = code;
                if (command.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Repuesto eliminado exitosamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se ha eliminado el repuesto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en RefactionDAO->Delete: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
        }

        public List<Refaction> Read_all()
        {
            List<Refaction> refactions = new List<Refaction>();
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Refaction_ReadAll}"
                };
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Refaction refaction = new Refaction
                    {
                        Refaction_code = dataReader.GetString(0),
                        Refaction_description = dataReader.GetString(1),
                        Refaction_unit_price = dataReader.GetDecimal(2)
                    };
                    refactions.Add(refaction);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en RefactionDAO->Read_all: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
            return refactions;
        }

        public Refaction Read_once(string code)
        {
            Refaction refaction = new Refaction();
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Refaction_ReadOnce(?)}"
                };
                command.Parameters.Add("Code", OdbcType.VarChar, 50).Value = code;
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    refaction = new Refaction
                    {
                        Refaction_code = dataReader.GetString(0),
                        Refaction_description = dataReader.GetString(1),
                        Refaction_unit_price = dataReader.GetDecimal(2)
                    };
                }
                else
                {
                    refaction = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en RefactionDAO->Read_once: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
            return refaction;
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
                    CommandText = "{call csg.Refaction_ReadOnceExist(?)}",
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

        public void Update(Refaction refaction)
        {
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Refaction_Update(?,?,?)}"
                };
                command.Parameters.Add("Code", OdbcType.VarChar, 50).Value = refaction.Refaction_code;
                command.Parameters.Add("Description", OdbcType.VarChar, 50).Value = refaction.Refaction_description;
                command.Parameters.Add("UnitPrice", OdbcType.Decimal).Value = refaction.Refaction_unit_price;
                if (command.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Repuesto actualizado exitosamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se ha actualizado el repuesto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en RefactionDAO->Update: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
        }
    }
}
