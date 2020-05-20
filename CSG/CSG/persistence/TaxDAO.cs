using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSG.persistence
{
    class TaxDAO : ITaxDAO
    {
        OdbcCommand command;
        OdbcDataReader dataReader;
        public decimal Read_once_value(string tax_id)
        {
            decimal value = 0.00m;
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.Tax_ReadOnceValue(?)}"
                };
                command.Parameters.Add("Id", OdbcType.VarChar, 10).Value = tax_id;
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    value = dataReader.GetDecimal(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en TaxDAO->Read_once_value: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
            return value;
        }
    }
}
