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
        string BulkLoad(List<Client> clients);//ok
        List<Client> Read_all();//ok
        List<Client> Read_all_like(string search);//ok
        Client Read_once(string id);//ok
        bool Read_once_exist(string id);//ok
        void Update(Client client);//ok
        void Delete(string id);//ok
        bool EqualMailings(string client_email);
    }
}
