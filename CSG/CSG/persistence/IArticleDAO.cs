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
        void Create(Article article);//ok
        string BulkLoad(List<Article> articles);//ok
        List<Article> Read_all();//ok
        Article Read_once(string code);//ok
        bool Read_once_exist(string code);//ok
        void Update(Article article);//ok
        void Delete(string code);//ok

    }
}
