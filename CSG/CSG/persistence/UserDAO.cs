using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using CSG.cache;
using CSG.model;

namespace CSG.persistence
{
    class UserDAO : IUserDAO
    {
        OdbcCommand command;
        OdbcDataReader dataReader;
        public bool UserLogin(byte[] cipheruser, byte[] cipherpass,
            byte[] Key, byte[] IV)
        {
            var rsa = new cryptography.SystemSupportRSA();
            try
            {
                Database.Connect();
                command = new OdbcCommand
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.User_Login(?)}"
                };
                command.Parameters.Add("Account", OdbcType.VarChar, 50).Value = rsa.DecryptStringFromBytes_Aes(cipheruser, Key, IV);
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    UserCache.UserUseToken = dataReader.GetChar(8);
                    Console.WriteLine("Usa token: " + UserCache.UserUseToken);
                    if (rsa.GetMd5Hash(rsa.DecryptStringFromBytes_Aes(cipherpass, Key, IV)).Equals(dataReader.GetString(4)) &&
                        UserCache.UserUseToken.Equals('N'))
                    {
                        Console.WriteLine("Entra con password");
                        //Almacenar la variables de sesión
                        UserCache.UserCode = dataReader.GetString(0);
                        UserCache.UserDefinition = dataReader.GetString(1);
                        UserCache.UserAccount = dataReader.GetString(2);
                        UserCache.UserPass = dataReader.GetString(4);
                        UserCache.UserEmail = dataReader.GetString(3);
                        UserCache.UserRol = dataReader.GetString(6);
                        UserCache.UserRolDefinition = dataReader.GetString(10);
                        return true;
                    }
                    //SI utiliza token esta en 'S'
                    else if (rsa.DecryptStringFromBytes_Aes(cipherpass, Key, IV).Equals(dataReader.GetString(5)) &&
                        UserCache.UserUseToken.Equals('S'))
                    {
                        Console.WriteLine("Entra con token");
                        //Almacenar la variables de sesión
                        UserCache.UserCode = dataReader.GetString(0);
                        UserCache.UserDefinition = dataReader.GetString(1);
                        UserCache.UserAccount = dataReader.GetString(2);
                        UserCache.UserPass = dataReader.GetString(4);
                        UserCache.UserEmail = dataReader.GetString(3);
                        UserCache.UserRol = dataReader.GetString(6);
                        UserCache.UserRolDefinition = dataReader.GetString(10);
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

        public string UserRecoveryAccount(byte[] ciphertoken, byte[] cipheraccuont,
            byte[] Key, byte[] IV)
        {
            var rsa = new cryptography.SystemSupportRSA();
            string userName;
            string userMail;
            string user;
            string alias;
            string pass;
            string current_token;
            //string request = "";

            Database.Connect();
            command = new OdbcCommand
            {
                Connection = Database.GetConn(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "{call csg.User_RecoveryAccount(?)}"
            };
            command.Parameters.Add("Account", OdbcType.VarChar, 50).Value = rsa.DecryptStringFromBytes_Aes(cipheraccuont, Key, IV);
            
            
            dataReader = command.ExecuteReader();
            //Console.WriteLine("Read(): " + dataReader.Read() + " | HasRows: " + dataReader.HasRows);
            if (dataReader.Read())
            {
                //Validamos que el token vigente coincida
                if (rsa.DecryptStringFromBytes_Aes(ciphertoken, Key, IV).Equals(dataReader.GetString(3)))
                {
                    userName = dataReader.GetString(0);
                    user = dataReader.GetString(1);
                    userMail = dataReader.GetString(2);
                    string code = dataReader.GetString(4);
                    Database.Disconnect();
                    //Creamos el nuevo token
                    string new_token = rsa.GetMd5Hash(user + DateTime.Now.Ticks.ToString());
                    //Actualizamos el token y pasamos el usetoken a SI
                    UpdateUserToken(new_token, code);
                    var mailservice = new mailservices.SystemSupportMail();
                    mailservice.SendRecoveryMail(username: userName, user: user, token: new_token,
                        subject: "Recuperación de cuenta Control de Servicios y Garantías", to: userMail);
                    
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

        private bool UpdateUserToken(string token, string code)
        {
            try
            {
                Database.Connect();
                command = new OdbcCommand()
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.User_UpdateToken(?,?)}"
                };
                command.Parameters.Add("Token", OdbcType.VarChar, 200).Value = token;
                command.Parameters.Add("Code", OdbcType.VarChar, 20).Value = code;
                if (command.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Database.Disconnect();
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
                    UserCache.UserDefinition = user.User_definition;
                    UserCache.UserEmail = user.User_email;
                    UserCache.UserPass = user.User_password;
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

        public void UserUpdatePass(byte[] cipherpass, byte[] ciphercode, byte[] Key, byte[] IV)
        {
            var rsa = new cryptography.SystemSupportRSA();
            try
            {
                Database.Connect();
                command = new OdbcCommand()
                {
                    Connection = Database.GetConn(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "{call csg.User_UpdatePass(?,?)}"
                };
                command.Parameters.Add("Pass", OdbcType.VarChar, 200).Value = rsa.GetMd5Hash(rsa.DecryptStringFromBytes_Aes(cipherpass, Key, IV));
                command.Parameters.Add("Code", OdbcType.VarChar, 20).Value = rsa.DecryptStringFromBytes_Aes(ciphercode, Key, IV);
                if (command.ExecuteNonQuery() > 0)
                {
                    //return true;
                    UserCache.UserPass = rsa.GetMd5Hash(rsa.DecryptStringFromBytes_Aes(cipherpass, Key, IV));
                    Console.WriteLine("Actualizó password a " + UserCache.UserPass);
                }
                else
                {
                    //return false;
                    Console.WriteLine("NO actualizó password");
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Database.Disconnect();
            }
        }
    }
}
