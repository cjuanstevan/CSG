using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSG.model;

namespace CSG.persistence
{
    interface IRefactionDAO
    {
        void Create(Refaction refaction);
        List<Refaction> Read_all();
        Refaction Read_once(string code);
        void Update(Refaction refaction);
        void Delete(string code);
    }
}
