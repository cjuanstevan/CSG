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
        List<Article> Read_all();
        Article Read_once(string code);
        void Update(Article article);
        void Delete(string code);

    }
}
