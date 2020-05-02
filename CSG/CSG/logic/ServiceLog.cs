using CSG.model;
using CSG.persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG.logic
{
    class ServiceLog
    {
        public void Create(Service service)
        {
            DAOFactory.GetServiceDAO().Create(service);
        }
        public List<Service> ReadAll()
        {
            return DAOFactory.GetServiceDAO().Read_all();
        }

        public List<Service> Read_all_like(string search)
        {
            return DAOFactory.GetServiceDAO().Read_all_like(search);
        }

        public bool Read_once_exist(string code)
        {
            return DAOFactory.GetServiceDAO().Read_once_exist(code);
        }

        public Service Read_once(string code)
        {
            return DAOFactory.GetServiceDAO().Read_once(code);
        }

        public void Update(Service service)
        {
            DAOFactory.GetServiceDAO().Update(service);
        }

        public void Delete(string code)
        {
            DAOFactory.GetServiceDAO().Delete(code);
        }
    }
}
