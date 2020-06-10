using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG.model
{
    class Cotization_serviceFK
    {
        private string _cotization_id;
        private string _service_code;
        private string _actionof;
        private byte _service_quantity;
        private decimal _service_amount;

        public Cotization_serviceFK()
        {

        }
        public Cotization_serviceFK(string cotization_id, string service_code, string actionof, byte service_quantity, decimal service_amount)
        {
            Cotization_id = cotization_id;
            Service_code = service_code;
            Actionof = actionof;
            Service_quantity = service_quantity;
            Service_amount = service_amount;
        }

        public string Cotization_id { get => _cotization_id; set => _cotization_id = value; }
        public string Service_code { get => _service_code; set => _service_code = value; }
        public string Actionof { get => _actionof; set => _actionof = value; }
        public byte Service_quantity { get => _service_quantity; set => _service_quantity = value; }
        public decimal Service_amount { get => _service_amount; set => _service_amount = value; }
        
    }
}
