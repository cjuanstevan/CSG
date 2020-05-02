using CSG.model;
using CSG.persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG.logic
{
    class RefactionLog
    {
        public void Create(Refaction refaction)
        {
            DAOFactory.GetRefactionDAO().Create(refaction);
        }
        public List<Refaction> ReadAll()
        {
            return DAOFactory.GetRefactionDAO().Read_all();
        }
        public List<Refaction> Read_all_like(string search)
        {
            return DAOFactory.GetRefactionDAO().Read_all_like(search);
        }
        public bool Read_once_exist(string code)
        {
            return DAOFactory.GetRefactionDAO().Read_once_exist(code);
        }
        public Refaction Read_once(string code)
        {
            return DAOFactory.GetRefactionDAO().Read_once(code);
        }

        public void Update(Refaction refaction)
        {
            DAOFactory.GetRefactionDAO().Update(refaction);
        }

        public void Delete(string code)
        {
            DAOFactory.GetRefactionDAO().Delete(code);
        }
    }
}
