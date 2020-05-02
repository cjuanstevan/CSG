﻿using System;
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
    class Cotization_refactionFKDAO : ICotization_refactionFKDAO
    {
        OdbcCommand command;
        OdbcDataReader dataReader;
        public void Create(Cotization_refactionFK cotization_refactionFK)
        {
            try
            {
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Cotization_refactionFK_Create(?,?,?,?)}"
                };
                command.Parameters.Add("Cotization", OdbcType.VarChar, 50).Value = cotization_refactionFK.Cotization.Cotization_id;
                command.Parameters.Add("Refaction", OdbcType.VarChar, 50).Value = cotization_refactionFK.Refaction.Refaction_code;
                command.Parameters.Add("Quantity", OdbcType.Int).Value = cotization_refactionFK.Refaction_quantity;
                command.Parameters.Add("Amount", OdbcType.Decimal).Value = cotization_refactionFK.Refaction_amount;
                command.ExecuteNonQuery();
                Console.WriteLine("CREATE-> cotization: " + cotization_refactionFK.Cotization.Cotization_id + " | refaction: " + cotization_refactionFK.Refaction.Refaction_code);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en Cotization_refactionFKDAO->Create: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
        }

        public void Delete(string id, string code)
        {
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Cotization_refactionFK_Delete(?,?)}"
                };
                command.Parameters.Add("Cotization", OdbcType.VarChar, 50).Value = id;
                command.Parameters.Add("Refaction", OdbcType.VarChar, 50).Value = code;
                command.ExecuteNonQuery();
                Console.WriteLine("DELETE-> cotization: " + id + " | refaction: " + code);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en Cotization_refactionFKDAO->Delete: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
        }

        public List<Cotization_refactionFK> Read_RefactionsOfCotization(string cotization_id)
        {
            List<Cotization_refactionFK> cotization_Refactions = new List<Cotization_refactionFK>();
            try
            {
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Cotization_refactionFK_ReadRefactionsOfCotization(?)}"
                };
                command.Parameters.Add("CotizationId", OdbcType.VarChar, 50).Value = cotization_id;
                ICotizationDAO cotizationDAO = new CotizationDAO();
                IRefactionDAO refactionDAO = new RefactionDAO();
                //verificamos que exista la cotización
                if (cotizationDAO.Read_once_exist(cotization_id))
                {
                    //consultamos el objeto Cotization                    
                    Cotization cotization = cotizationDAO.Read_once(cotization_id);
                    //ejecutamos la lectura del DataReader
                    dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Cotization_refactionFK cotization_RefactionFK = new Cotization_refactionFK
                        {
                            Cotization = cotization
                        };
                        Refaction refaction = refactionDAO.Read_once(dataReader.GetString(0));
                        cotization_RefactionFK.Refaction = refaction;
                        cotization_RefactionFK.Refaction_quantity = ushort.Parse(dataReader.GetInt32(1).ToString());
                        cotization_RefactionFK.Refaction_amount = dataReader.GetDecimal(2);
                        cotization_Refactions.Add(cotization_RefactionFK);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en Cotization_refactionFKDAO->Read_RefactionsOfCotization: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
            return cotization_Refactions;
        }
    }
}