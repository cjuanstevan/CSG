using CSG.model;
using CSG.persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG.logic
{
    class ArticleLog
    {
        public void Create(Article article)
        {
            DAOFactory.GetArticleDAO().Create(article);
        }
        public List<Article> ReadAll()
        {
            return DAOFactory.GetArticleDAO().Read_all();
        }
        public List<Article> Read_all_like(string search)
        {
            return DAOFactory.GetArticleDAO().Read_all_like(search);
        }
        public bool Read_once_exist(string code)
        {
            return DAOFactory.GetArticleDAO().Read_once_exist(code);
        }
        public Article Read_once(string code)
        {
            return DAOFactory.GetArticleDAO().Read_once(code);
        }
        public void Update(Article article)
        {
            DAOFactory.GetArticleDAO().Update(article);
        }
        public void Delete(string code)
        {
            DAOFactory.GetArticleDAO().Delete(code);
        }
    }
}
