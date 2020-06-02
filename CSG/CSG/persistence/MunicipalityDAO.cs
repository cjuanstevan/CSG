using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSG.model;

namespace CSG.persistence
{
    class MunicipalityDAO : IMunicipalityDAO
    {
        OdbcCommand command;
        OdbcDataReader dataReader;
        public List<Municipality> Read_mnps_of_dpt(byte dpt_id)
        {
            List<Municipality> municipalities = new List<Municipality>();
            try
            {
                Database.Connect();
                command = new OdbcCommand()
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Municipality_ReadMnpOfDpt(?)}"
                };
                command.Parameters.Add("DptId", OdbcType.TinyInt).Value = dpt_id;
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Municipality municipality = new Municipality()
                    {
                        Id = dataReader.GetInt16(0),
                        Name = dataReader.GetString(1)
                    };
                    municipalities.Add(municipality);
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcione en MunicipalityDAO->Read_mnps_of_dpt: " + ex.Message);
            }
            finally
            {
                Database.Disconnect();
            }
            return municipalities;
        }
    }
}
