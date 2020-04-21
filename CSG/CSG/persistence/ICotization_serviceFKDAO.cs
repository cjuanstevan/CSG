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
        void Create(Cotization_serviceFK cotization_serviceFK);//ok
        List<Cotization_serviceFK> Read_ServicesOfCotization(string cotization_id);//ok
        void Delete(string id, string code);//ok
    }
}
