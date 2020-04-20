using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSG.model;

namespace CSG.persistence
{
    interface IArticleDAO
    {
        void Create(Article article);
        string BulkLoad(List<Article> articles);
        List<Article> Read_all();
        Article Read_once(string code);
        bool Read_once_exist(string code);
        void Update(Article article);
        void Delete(string code);

    }
}
