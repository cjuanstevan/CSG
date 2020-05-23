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

        public List<Cotization_refactionFK> Read_RefactionsOfCotization(string cotization_id)
        {
            return DAOFactory.GetCotization_RefactionFKDAO().Read_RefactionsOfCotization(cotization_id);
        }
    }
}
