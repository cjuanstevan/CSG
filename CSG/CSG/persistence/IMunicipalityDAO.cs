using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSG.model;

namespace CSG.persistence
{
    interface IMunicipalityDAO
    {
        List<Municipality> Read_mnps_of_dpt(byte dpt_id);
    }
}
