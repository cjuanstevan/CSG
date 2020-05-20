using CSG.model;
using CSG.persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG.logic
{
    class CotizationRefactionLog
    {
        public void Create(Cotization_refactionFK cotization_RefactionFK)
        {
            DAOFactory.GetCotization_RefactionFKDAO().Create(cotization_RefactionFK);
        }
    }
}
