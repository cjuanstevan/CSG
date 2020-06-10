using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG.model
{
    class Order_articleFK
    {
        private string _order_number;
        private string _article_code;
        private string _model;
        private string _especification;
        private string _serial;

        public Order_articleFK()
        {

        }

        public Order_articleFK(string order_number, string article_code, string model, 
            string especification, string serial)
        {
            Order_number = order_number;
            Article_code = article_code;
            Model = model;
            Especification = especification;
            Serial = serial;
        }

        public string Order_number { get => _order_number; set => _order_number = value; }
        public string Article_code { get => _article_code; set => _article_code = value; }
        public string Model { get => _model; set => _model = value; }
        public string Especification { get => _especification; set => _especification = value; }
        public string Serial { get => _serial; set => _serial = value; }
    }
}
