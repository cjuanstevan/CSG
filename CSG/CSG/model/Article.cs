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
        private string _article_esp;
        private string _article_serial;
        private int _article_warranty;//cambiar a byte
        private byte _category;
        private string _create_by;
        private DateTime _create_date;
        private string _update_by;
        private DateTime _update_date;


        //CONSTRUCTORES
        public Article()
        {

        }

        public Article(string article_code, string article_description, string article_model, string article_esp,
            string article_serial, int article_warranty,byte category, string create_by, DateTime create_date, 
            string update_by, DateTime update_date)
        {
            Article_code = article_code;
            Article_description = article_description;
            Article_model = article_model;
            Article_esp = article_esp;
            Article_serial = article_serial;
            Article_warranty = article_warranty;
            Category = category;
            Create_by = create_by;
            Create_date = create_date;
            Update_by = update_by;
            Update_date = update_date;
        }

        public string Article_code { get => _article_code; set => _article_code = value; }
        public string Article_description { get => _article_description; set => _article_description = value; }
        public string Article_model { get => _article_model; set => _article_model = value; }
        public string Article_serial { get => _article_serial; set => _article_serial = value; }
        public int Article_warranty { get => _article_warranty; set => _article_warranty = value; }
        internal byte Category { get => _category; set => _category = value; }
        public string Create_by { get => _create_by; set => _create_by = value; }
        public DateTime Create_date { get => _create_date; set => _create_date = value; }
        public string Update_by { get => _update_by; set => _update_by = value; }
        public DateTime Update_date { get => _update_date; set => _update_date = value; }
        public string Article_esp { get => _article_esp; set => _article_esp = value; }
    }
}
