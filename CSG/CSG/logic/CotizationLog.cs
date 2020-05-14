using CSG.model;
using CSG.persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG.logic
{
    class CotizationLog
    {
        public void Create(Cotization cotization)
        {
            DAOFactory.GetCotizationDAO().Create(cotization);
        }
        public List<Cotization> Read_all()
        {
            return DAOFactory.GetCotizationDAO().Read_all();
        }
        public Cotization Read_once(string id)
        {
            return DAOFactory.GetCotizationDAO().Read_once(id);
        }
        public bool Read_once_exist(string id)
        {
            return DAOFactory.GetCotizationDAO().Read_once_exist(id);
        }
        public void Update(Cotization cotization)
        {
            DAOFactory.GetCotizationDAO().Update(cotization);
        }
        public void Delete(string id)
        {
            DAOFactory.GetCotizationDAO().Delete(id);
        }
    }
}
