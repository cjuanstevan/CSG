using CSG.persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG.logic
{
    class TaxLog
    {
        public decimal Read_once_value(string tax_id)
        {
            return DAOFactory.GetTaxDAO().Read_once_value(tax_id);
        }
    }
}
