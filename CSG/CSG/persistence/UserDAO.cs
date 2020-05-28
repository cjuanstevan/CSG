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
                command.Parameters.Add("Account", OdbcType.VarChar, 50).Value = user;
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    if (pass.Equals(dataReader.GetString(4)))
                    {
                        //Almacenar la variables de sesión
                        UserCache.UserCode = dataReader.GetString(0);
                        UserCache.UserDefinition = dataReader.GetString(1);
                        UserCache.UserAccount = dataReader.GetString(2);
                        UserCache.UserEmail = dataReader.GetString(3);
                        UserCache.UserRol = dataReader.GetString(6);
                        UserCache.UserRolDefinition = dataReader.GetString(8);
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

        public string UserRecoveryAccount(string account, string token)
        {
            string userName;
            string userMail;
            //string request = "";

            Database.Connect();
            command = new OdbcCommand
            {
                Connection = Database.GetConn(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "{call csg.User_RecoveryAccount(?)}"
            };
            command.Parameters.Add("Account", OdbcType.VarChar, 50).Value = account;
            dataReader = command.ExecuteReader();
            //Console.WriteLine("Read(): " + dataReader.Read() + " | HasRows: " + dataReader.HasRows);
            if (dataReader.Read())
            {
                //Validamos que el token coincida
                if (token.Equals(dataReader.GetString(4)))
                {
                    userName = dataReader.GetString(0);
                    userMail = dataReader.GetString(2);
                    string body =
                        "<html><head></head>" +
                        "<body>" +
                        "<p>Señor(a) " + userName +
                        "<br>ha solictado recuperar su cuenta:<br>" +
                        "<b>Usuario: </b>" + dataReader.GetString(1) +
                        "<b>Contraseña: </b>" + dataReader.GetString(3) +
                        "</p>" +
                        "</body></html>";

                    var mailservice = new mailservices.SystemSupportMail();
                    mailservice.SendRecoveryMail(subject: "CSG: Recuperación de cuenta",
                        body: body, to: userMail);
                    Database.Disconnect();
                    return "s,Por favor revisa tu cuenta de correo " + userMail;
                }
                else
                {
                    Database.Disconnect();
                    return "f,No coincide el token";
                }
                
            }
            else
            {
                Database.Disconnect();
                return "f,Lo sentimos, no existe una cuenta con ese nombre de usuario o" +
                    " correo electrónico";
            }
            
        }
    }
}
