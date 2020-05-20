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

        public Cotization_serviceFK()
        {

        }

        public Cotization_serviceFK(string cotization_id, string service_code)
        {
            Cotization_id = cotization_id;
            Service_code = service_code;
        }

        public string Cotization_id { get => _cotization_id; set => _cotization_id = value; }
        public string Service_code { get => _service_code; set => _service_code = value; }
    }
}
