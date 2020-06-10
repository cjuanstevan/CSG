using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG.model
{
    class Service
    {
        private string _service_code;
        private string _service_activity;
        private string _service_duration;
        private decimal _service_cost;
        private char _service_type;

        public Service()
        {

        }

        public Service(string service_code, string service_activity, string service_duration, decimal service_cost, char service_type)
        {
            _service_code = service_code;
            _service_activity = service_activity;
            _service_duration = service_duration;
            _service_cost = service_cost;
            _service_type = service_type;
        }

        public string Service_code { get => _service_code; set => _service_code = value; }
        public string Service_activity { get => _service_activity; set => _service_activity = value; }
        public string Service_duration { get => _service_duration; set => _service_duration = value; }
        public decimal Service_cost { get => _service_cost; set => _service_cost = value; }
        public char Service_type { get => _service_type; set => _service_type = value; }
    }
}
