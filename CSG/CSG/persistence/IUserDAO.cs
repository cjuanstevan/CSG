using CSG.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG.persistence
{
    interface IUserDAO
    {
        bool UserLogin(byte[] cipheruser, byte[] cipherpass,
            byte[] Key, byte[] IV);
        string UserRecoveryAccount(byte[] ciphertoken, byte[] cipheraccuont,
            byte[] Key, byte[] IV);
        void UserUpdate(User user);
        void UserUpdatePass(byte[] cipherpass, byte[] ciphercode,
            byte[] Key, byte[] IV);
    }
}
