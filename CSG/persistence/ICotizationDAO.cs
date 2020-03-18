using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSG.model;

namespace CSG.persistence
{
    interface ICotizationDAO
    {
        void Create(Cotization cotization);
        List<Cotization> Read_all();
        Cotization Read_once(string id);
        void Update(Cotization cotization);
        void Delete(string id);
    }
}
