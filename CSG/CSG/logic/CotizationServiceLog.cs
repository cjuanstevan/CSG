using CSG.model;
using CSG.persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG.logic
{
    class CotizationServiceLog
    {
        public void Create(Cotization_serviceFK cotization_ServiceFK)
        {
            DAOFactory.GetCotization_ServiceFKDAO().Create(cotization_ServiceFK);
        }

        public List<Cotization_serviceFK> Read_ServicesOfCotization(string cotization_id)
        {
            return DAOFactory.GetCotization_ServiceFKDAO().Read_ServicesOfCotization(cotization_id);
        }

        public bool ServicesCotizations(string service_code)
        {
            return DAOFactory.GetCotization_ServiceFKDAO().ServicesCotizations(service_code);
        }


    }
}
