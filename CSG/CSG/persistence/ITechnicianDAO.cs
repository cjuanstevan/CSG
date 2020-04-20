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
        void Create(Technician technician);//ok
        List<Technician> Read_all();//ok
        Technician Read_once(string id);//ok
        bool Read_once_exist(string id);//ok
        void Update(Technician technician);//ok
        void Delete(string id);//ok
    }
}
