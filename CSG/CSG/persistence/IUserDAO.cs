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
        bool UserLogin(string user, string pass);
    }
}
