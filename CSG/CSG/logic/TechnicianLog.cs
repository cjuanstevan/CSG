using CSG.model;
using CSG.persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG.logic
{
    class TechnicianLog
    {
        public void Create(Technician technician)
        {
            DAOFactory.GetTechnicianDAO().Create(technician);
        }
        public List<Technician> ReadAll()
        {
            return DAOFactory.GetTechnicianDAO().Read_all();
        }

        public List<Technician> Read_all_like(string search)
        {
            return DAOFactory.GetTechnicianDAO().Read_all_like(search);
        }

        public bool Read_once_exist(string id)
        {
            return DAOFactory.GetTechnicianDAO().Read_once_exist(id);
        }

        public Technician Read_once(string id)
        {
            return DAOFactory.GetTechnicianDAO().Read_once(id);
        }

        public void Update(Technician technician)
        {
            DAOFactory.GetTechnicianDAO().Update(technician);
        }

        public void Delete(string id)
        {
            DAOFactory.GetTechnicianDAO().Delete(id);
        }
    }
}
