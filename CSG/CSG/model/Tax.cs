using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG.model
{
    class Tax
    {
        private string _tax_id;
        private string _tax_name;
        private decimal _tax_value;

        public Tax()
        {
        }

        public Tax(string tax_id, string tax_name, decimal tax_value)
        {
            Tax_id = tax_id;
            Tax_name = tax_name;
            Tax_value = tax_value;
        }

        public string Tax_id { get => _tax_id; set => _tax_id = value; }
        public string Tax_name { get => _tax_name; set => _tax_name = value; }
        public decimal Tax_value { get => _tax_value; set => _tax_value = value; }
    }
}
