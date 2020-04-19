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
        private string _article_model;
        private string _article_serial;
        private ushort _article_warranty;

        //CONSTRUCTORES
        public Article()
        {

        }

        public Article(string article_code, string article_description, string article_model, string article_serial, ushort article_warranty)
        {
            Article_code = article_code;
            Article_description = article_description;
            Article_model = article_model;
            Article_serial = article_serial;
            Article_warranty = article_warranty;
        }


        //METODOS DE ACCESO PUBLICO DE LAS VARIABLES
        public string Article_code { get => _article_code; set => _article_code = value; }
        public string Article_description { get => _article_description; set => _article_description = value; }
        public string Article_model { get => _article_model; set => _article_model = value; }
        public string Article_serial { get => _article_serial; set => _article_serial = value; }
        public ushort Article_warranty { get => _article_warranty; set => _article_warranty = value; }
    }
}
