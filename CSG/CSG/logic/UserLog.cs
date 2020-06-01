using CSG.model;
using CSG.persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG.logic
{
    class UserLog
    {
        public bool UserLogin(byte[] cipheruser, byte[] cipherpass,
            byte[] Key, byte[] IV)
        {
            return DAOFactory.GetUserDAO().UserLogin(cipheruser, cipherpass,
            Key, IV);
        }
        public string UserRecoveryAccount(byte[] ciphertoken, byte[] cipheraccuont,
            byte[] Key, byte[] IV)
        {
            return DAOFactory.GetUserDAO().UserRecoveryAccount(ciphertoken, cipheraccuont, Key, IV);
        }
        public void UserUpdate(User user)
        {
            DAOFactory.GetUserDAO().UserUpdate(user);
        }
        public void UserUpdatePass(byte[] cipherpass, byte[] ciphercode, byte[] Key, byte[] IV)
        {
            DAOFactory.GetUserDAO().UserUpdatePass(cipherpass, ciphercode, Key, IV);
        }
    }
}
