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
        void Create(Client client);//ok
        List<Client> Read_all();//ok
        Client Read_once(string id);//ok
        bool Read_once_exist(string id);//ok
        void Update(Client client);//ok
        void Delete(string id);//ok
    }
}
