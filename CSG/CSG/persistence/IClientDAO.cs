using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSG.model;


namespace CSG.persistence
{
    interface IClientDAO
    {
        void Create(Client client);
        List<Client> Read_all();
        Client Read_once(string id);
        bool Read_once_exist(string id);
        void Update(Client client);
        void Delete(string id);
    }
}
