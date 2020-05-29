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
                        UserCache.UserPass = dataReader.GetString(4);
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
            string user;
            string alias;
            string pass;
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
                    user = dataReader.GetString(1);
                    userMail = dataReader.GetString(2);
                    pass = dataReader.GetString(3);
                    //string body =
                    //    "<html><head></head>" +
                    //    "<body>" +
                    //    "<p>Señor(a) " + userName +
                    //    "<br>ha solictado recuperar su cuenta:<br>" +
                    //    "<b>Usuario: </b>" + user +
                    //    "<b>Contraseña: </b>" + pass +
                    //    "</p>" +
                    //    "</body></html>";

                    var mailservice = new mailservices.SystemSupportMail();
                    mailservice.SendRecoveryMail(username: userName, user: user, pass: pass,
                        subject: "Recuperación de cuenta Control de Servicios y Garantías", to: userMail);
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

        public void UserUpdate(User user)
        {
            try
            {
                Database.Connect();
                command = new OdbcCommand()
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.User_Update(?,?,?,?)}"
                };
                command.Parameters.Add("UserDef", OdbcType.NVarChar, 50).Value = user.User_definition;
                command.Parameters.Add("UserEmail", OdbcType.NVarChar, 50).Value = user.User_email;
                command.Parameters.Add("UserPass", OdbcType.NVarChar, 200).Value = user.User_password;
                command.Parameters.Add("UserCode", OdbcType.NVarChar, 20).Value = user.User_code;
                if (command.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Usuario actualizado");
                }
                else
                {
                    MessageBox.Show("Usuario no actualizado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción controlada en UserDAO->UserUpdate: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Database.Disconnect();
            }
        }
    }
}
