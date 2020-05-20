using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG.model
{
    class Cotization_refactionFK
    {
        private string _cotization_id;
        private string _refaction_code;
        private ushort _refaction_quantity;
        private decimal _refaction_amount;

        public Cotization_refactionFK()
        {

        }

        public Cotization_refactionFK(string cotization_id, string refaction_code, ushort refaction_quantity, decimal refaction_amount)
        {
            Cotization_id = cotization_id;
            Refaction_code = refaction_code;
            Refaction_quantity = refaction_quantity;
            Refaction_amount = refaction_amount;
        }

        public string Cotization_id { get => _cotization_id; set => _cotization_id = value; }
        public string Refaction_code { get => _refaction_code; set => _refaction_code = value; }
        public ushort Refaction_quantity { get => _refaction_quantity; set => _refaction_quantity = value; }
        public decimal Refaction_amount { get => _refaction_amount; set => _refaction_amount = value; }
    }
}
