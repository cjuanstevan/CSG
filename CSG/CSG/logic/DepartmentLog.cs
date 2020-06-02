using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSG.persistence;

namespace CSG.logic
{
    class DepartmentLog
    {
        public List<string> Read_all_names()
        {
            return DAOFactory.GetDepartmentDAO().Read_all_names();
        }
    }
}
