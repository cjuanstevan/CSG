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
        void Create(Refaction refaction);//ok
        string BulkLoad(List<Refaction> refactions);
        List<Refaction> Read_all();//ok
        Refaction Read_once(string code);//ok
        bool Read_once_exist(string code);//ok
        void Update(Refaction refaction);//ok
        void Delete(string code);//ok
    }
}
