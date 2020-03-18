using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSG.model;

namespace CSG.persistence
{
    interface ITechnicianDAO
    {
        void Create(Technician technician);
        List<Technician> Read_all();
        Technician Read_once(string id);
        void Update(Technician technician);
        void Delete(string id);
    }
}
