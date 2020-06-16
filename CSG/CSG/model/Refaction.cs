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
        private string _create_by;
        private DateTime _create_date;
        private string _update_by;
        private DateTime _update_date;
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
        public string Create_by { get => _create_by; set => _create_by = value; }
        public DateTime Create_date { get => _create_date; set => _create_date = value; }
        public string Update_by { get => _update_by; set => _update_by = value; }
        public DateTime Update_date { get => _update_date; set => _update_date = value; }
    }
}
