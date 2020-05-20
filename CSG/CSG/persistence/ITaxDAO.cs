using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG.persistence
{
    interface ITaxDAO
    {
        decimal Read_once_value(string tax_id);
    }
}
