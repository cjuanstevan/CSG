using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSG.persistence;
using CSG.model;

namespace CSG.logic
{
    class MunicipalityLog
    {
        public List<Municipality> Read_mnps_of_dpt(byte dpt_id)
        {
            return DAOFactory.GetMunicipalityDAO().Read_mnps_of_dpt(dpt_id);
        }
    }
}
