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
        private string _replacementof;
        private byte _refaction_quantity;
        private string _refaction_amount;

        public Cotization_refactionFK()
        {

        }

        public Cotization_refactionFK(string cotization_id, string refaction_code, string replacementof, 
            byte refaction_quantity, string refaction_amount)
        {
            Cotization_id = cotization_id;
            Refaction_code = refaction_code;
            Replacementof = replacementof;
            Refaction_quantity = refaction_quantity;
            Refaction_amount = refaction_amount;
        }

        public string Cotization_id { get => _cotization_id; set => _cotization_id = value; }
        public string Refaction_code { get => _refaction_code; set => _refaction_code = value; }
        public string Replacementof { get => _replacementof; set => _replacementof = value; }
        public byte Refaction_quantity { get => _refaction_quantity; set => _refaction_quantity = value; }
        public string Refaction_amount { get => _refaction_amount; set => _refaction_amount = value; }
    }
}
