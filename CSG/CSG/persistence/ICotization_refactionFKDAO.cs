using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSG.model;

namespace CSG.persistence
{
    interface ICotization_refactionFKDAO
    {
        void Create(Cotization_refactionFK cotization_refactionFK);//ok
        List<Cotization_refactionFK> Read_RefactionsOfCotization(string cotization_id);//ok
        bool RefactionsCotizations(string article_code);
        void Delete(string id, string code);//ok
    }
}
