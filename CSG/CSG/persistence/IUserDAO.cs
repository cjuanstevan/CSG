﻿using CSG.model;
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
        string UserRecoveryAccount(string account, string token);
        void UserUpdate(User user);
    }
}
