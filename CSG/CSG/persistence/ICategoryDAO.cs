using CSG.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG.persistence
{
    interface ICategoryDAO
    {
        Category Read_once(byte id);
        List<Category> Read_all();
    }
}
