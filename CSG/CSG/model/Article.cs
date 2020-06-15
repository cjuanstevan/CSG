using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG.model
{
    class Article
    {
        //VARIABLES DE CLASE
        private string _article_code;
        private string _article_description;
        private int _article_warranty;//cambiar a byte
        private byte _category;
        private string _create_by;
        private DateTime _create_date;
        private string _update_by;
        private DateTime _update_date;

        //static
        public static string _code_static { get; set; }


        //CONSTRUCTORES
        public Article()
        {

        }

        public Article(string article_code, string article_description, int article_warranty,byte category)
        {
            Article_code = article_code;
            Article_description = article_description;
            Article_warranty = article_warranty;
            Category = category;
        }

        public string Article_code { get => _article_code; set => _article_code = value; }
        public string Article_description { get => _article_description; set => _article_description = value; }
        public int Article_warranty { get => _article_warranty; set => _article_warranty = value; }
        internal byte Category { get => _category; set => _category = value; }
        public string Create_by { get => _create_by; set => _create_by = value; }
        public DateTime Create_date { get => _create_date; set => _create_date = value; }
        public string Update_by { get => _update_by; set => _update_by = value; }
        public DateTime Update_date { get => _update_date; set => _update_date = value; }
        
    }
}
