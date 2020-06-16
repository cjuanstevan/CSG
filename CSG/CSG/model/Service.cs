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
        private string _service_cost;
        private char _service_type;
        private string _create_by;
        private DateTime _create_date;
        private string _update_by;
        private DateTime _update_date;

        public Service()
        {

        }

        public Service(string service_code, string service_activity, string service_duration,
            string service_cost, char service_type)
        {
            Service_code = service_code;
            Service_activity = service_activity;
            Service_duration = service_duration;
            Service_cost = service_cost;
            Service_type = service_type;
        }

        public string Service_code { get => _service_code; set => _service_code = value; }
        public string Service_activity { get => _service_activity; set => _service_activity = value; }
        public string Service_duration { get => _service_duration; set => _service_duration = value; }
        public string Service_cost { get => _service_cost; set => _service_cost = value; }
        public char Service_type { get => _service_type; set => _service_type = value; }
        public string Create_by { get => _create_by; set => _create_by = value; }
        public DateTime Create_date { get => _create_date; set => _create_date = value; }
        public string Update_by { get => _update_by; set => _update_by = value; }
        public DateTime Update_date { get => _update_date; set => _update_date = value; }
    }
}
