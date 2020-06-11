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
        void Create(Cotization cotization);//ok
        List<Cotization> Read_all();//ok
        Cotization Read_once(string id);//ok
        bool Read_once_exist(string id);//ok
        void Update(Cotization cotization);//ok
        void UpdateExpirationDate(string id, DateTime expiration_date);
        void Delete(string id);//ok
    }
}
