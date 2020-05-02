using CSG.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSG.persistence;

namespace CSG.logic
{
    class ClientLog
    {
        public void Create(Client client)
        {
            DAOFactory.GetClientDAO().Create(client);
        }

        public List<Client> ReadAll()
        {
            return DAOFactory.GetClientDAO().Read_all();
        }

        public List<Client> Read_all_like(string search)
        {
            return DAOFactory.GetClientDAO().Read_all_like(search);
        }

        public bool Read_once_exist(string id)
        {
            return DAOFactory.GetClientDAO().Read_once_exist(id);
        }

        public Client Read_once(string id)
        {
            return DAOFactory.GetClientDAO().Read_once(id);
        }

        public void Update(Client client)
        {
            DAOFactory.GetClientDAO().Update(client);
        }

        public void Delete(string id)
        {
            DAOFactory.GetClientDAO().Delete(id);
        }
    }
}
