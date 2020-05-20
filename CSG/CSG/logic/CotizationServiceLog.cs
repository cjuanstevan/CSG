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


    }
}
