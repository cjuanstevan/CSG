using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;

namespace CSG.persistence
{
    class DashboardDAO : IDashboardDAO
    {
        OdbcCommand command;
        OdbcDataReader dataReader;
        public string[] DashboardData()
        {
            string[] data = new string[2];
            try
            {
                Database.Connect();
                command = new OdbcCommand()
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.DashboardData(?,?)}"
                };
                OdbcParameter client_j = new OdbcParameter("@TotClientsJ", OdbcType.Int);
                client_j.Direction = ParameterDirection.Output;
                OdbcParameter client_n = new OdbcParameter("@TotClientsN", OdbcType.Int);
                client_n.Direction = ParameterDirection.Output;
                command.Parameters.Add(client_j);
                command.Parameters.Add(client_n);
                
                command.ExecuteNonQuery();
                data[0] = command.Parameters["@TotClientsJ"].Value.ToString();
                data[1] = command.Parameters["@TotClientsN"].Value.ToString();
                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                command.Dispose();
                Database.Disconnect();
            }
            return data;
        }

        public string[,] Dashboard_CategoryXarticle()
        {
            int cont = 0;
            string[,] data = null;
            try
            {
                Database.Connect();
                command = new OdbcCommand()
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Dashboard_CategoryXarticle}"
                };
                dataReader = command.ExecuteReader();
                data = new string[5, 2];
                while (dataReader.Read())
                {
                    data[cont, 0] = dataReader.GetString(0);
                    data[cont, 1] = dataReader.GetString(1);
                    cont++;
                }
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Articulo: " + data[i, 0] +
                        " | Cantidad: " + data[i, 1] + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("EXCEPCION: " + ex.Message + Environment.NewLine +
                    " | STACKTRACE: " + ex.StackTrace);
                throw;
            }
            finally
            {
                command.Dispose();
                Database.Disconnect();
            }
            return data;
        }

        public string[] Dashboard_Order()
        {
            string[] data = new string[5];

            try
            {
                Database.Connect();
                command = new OdbcCommand()
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Dashboard_Order(?,?,?,?,?)}"
                };
                OdbcParameter total_rec = new OdbcParameter("@TotRec", OdbcType.Int);
                total_rec.Direction = ParameterDirection.Output;
                OdbcParameter total_cot = new OdbcParameter("@TotCot", OdbcType.Int);
                total_cot.Direction = ParameterDirection.Output;
                OdbcParameter total_EE = new OdbcParameter("@TotEE", OdbcType.Int);
                total_EE.Direction = ParameterDirection.Output;
                OdbcParameter total_Cancel = new OdbcParameter("@TotCancel", OdbcType.Int);
                total_Cancel.Direction = ParameterDirection.Output;
                OdbcParameter total_Fact = new OdbcParameter("@TotFact", OdbcType.Int);
                total_Fact.Direction = ParameterDirection.Output;

                command.Parameters.Add(total_rec);
                command.Parameters.Add(total_cot);
                command.Parameters.Add(total_EE);
                command.Parameters.Add(total_Cancel);
                command.Parameters.Add(total_Fact);

                command.ExecuteNonQuery();

                data[0] = command.Parameters["@TotRec"].Value.ToString();
                data[1] = command.Parameters["@TotCot"].Value.ToString();
                data[2] = command.Parameters["@TotEE"].Value.ToString();
                data[3] = command.Parameters["@TotCancel"].Value.ToString();
                data[4] = command.Parameters["@TotFact"].Value.ToString();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                command.Dispose();
                Database.Disconnect();
            }

            return data;
        }

        public string[,] Dashboard_OrderArticleTop3()
        {
            int cont = 0;
            string[,] data = null;
            try
            {
                Database.Connect();
                command = new OdbcCommand()
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Dashboard_OrderArticleTop3}"
                };
                dataReader = command.ExecuteReader();
                data = new string[3, 2];
                while (dataReader.Read())
                {
                    data[cont, 0] = dataReader.GetString(0);
                    data[cont, 1] = dataReader.GetString(1);
                    cont++;
                }
                //for (int i = 0; i < 3; i++)
                //{
                //    Console.WriteLine("Articulo: " + data[i, 0] +
                //        " | Cantidad: " + data[i, 1] + Environment.NewLine);
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine("EXCEPCION: " + ex.Message + Environment.NewLine +
                    " | STACKTRACE: " + ex.StackTrace);
                throw;
            }
            finally
            {
                command.Dispose();
                Database.Disconnect();
            }
            return data;
        }
    }
}
