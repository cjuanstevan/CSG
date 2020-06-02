using CSG.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG.persistence
{
    class DepartmentDAO : IDepartmentDAO
    {
        OdbcCommand command;
        OdbcDataReader dataReader;
        public List<string> Read_all_names()
        {
            List<string> departments_name = new List<string>();
            try
            {
                Database.Connect();
                command = new OdbcCommand()
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Department_ReadAllNames}"
                };
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    departments_name.Add(dataReader.GetString(0));
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcione en DepartmentDAO->Read_all_names: " + ex.Message);
            }
            finally
            {
                Database.Disconnect();
            }
            return departments_name;
        }
    }
}
