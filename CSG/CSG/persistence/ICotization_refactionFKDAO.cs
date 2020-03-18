using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSG.model;

namespace CSG.persistence
{
    interface ICotization_refactionFKDAO
    {
        void Create(Cotization_refactionFK cotization_refactionFK);
        List<Cotization_refactionFK> Read_all();
        Cotization_refactionFK Read_once(string id, string code);
        void Update(Cotization_refactionFK cotization_refactionFK);
        void Delete(string id, string code);
    }
}
