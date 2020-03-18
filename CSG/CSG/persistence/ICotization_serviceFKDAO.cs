using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSG.model;

namespace CSG.persistence
{
    interface ICotization_serviceFKDAO
    {
        void Create(Cotization_serviceFK cotization_serviceFK);
        List<Cotization_serviceFK> Read_all();
        Cotization_serviceFK Read_once(string id, string code);
        void Update(Cotization_serviceFK cotization_serviceFK);
        void Delete(string id, string code);
    }
}
