using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG.model
{
    class Cotization_serviceFK
    {
        private Cotization _cotization;
        private Service _service;

        public Cotization_serviceFK()
        {

        }

        public Cotization_serviceFK(Cotization cotization, Service service)
        {
            _cotization = cotization;
            _service = service;
        }

        internal Cotization Cotization { get => _cotization; set => _cotization = value; }
        internal Service Service { get => _service; set => _service = value; }
    }
}
