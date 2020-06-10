using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSG.model;
using CSG.persistence;

namespace CSG.logic
{
    class CategoryLog
    {
        public Category Read_once(byte id)
        {
            return DAOFactory.GetCategoryDAO().Read_once(id);
        }
        public List<Category> Read_all()
        {
            return DAOFactory.GetCategoryDAO().Read_all();
        }
    }
}
