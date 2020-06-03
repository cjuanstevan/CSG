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
        //OdbcDataReader dataReader;
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
    }
}
