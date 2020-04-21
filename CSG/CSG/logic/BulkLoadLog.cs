using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSG.persistence;
using CSG.model;

namespace CSG.logic
{
    class BulkLoadLog
    {
        public string BulkLoadArticle(List<Article> articles)
        {
           return DAOFactory.GetArticleDAO().BulkLoad(articles);
        }
    }
}
