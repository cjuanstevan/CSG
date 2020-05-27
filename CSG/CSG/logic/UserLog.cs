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
        public bool UserLogin(string user, string pass)
        {
            return DAOFactory.GetUserDAO().UserLogin(user, pass);
        }
    }
}
