using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG.model
{
    class Refaction
    {
        private string _refaction_code;
        private string _refaction_description;
        private decimal _refaction_unit_price;

        public Refaction()
        {

        }

        public Refaction(string refaction_code, string refaction_description, decimal refaction_unit_price)
        {
            _refaction_code = refaction_code;
            _refaction_description = refaction_description;
            _refaction_unit_price = refaction_unit_price;
        }

        public string Refaction_code { get => _refaction_code; set => _refaction_code = value; }
        public string Refaction_description { get => _refaction_description; set => _refaction_description = value; }
        public decimal Refaction_unit_price { get => _refaction_unit_price; set => _refaction_unit_price = value; }
    }
}
