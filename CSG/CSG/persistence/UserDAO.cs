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
    class UserDAO : IUserDAO
    {
        OdbcCommand command;
        OdbcDataReader dataReader;
        public bool UserLogin(string user, string pass)
        {
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.User_Login(?)}"
                };
                command.Parameters.Add("Account", OdbcType.NVarChar, 50).Value = user;
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    if (pass.Equals(dataReader.GetString(4)))
                    {
                        //Almacenar la variables de sesión
                        return true;                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en UserDAO->UserLogin: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
            return false;
        }
    }
}
