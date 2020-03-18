using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG.model
{
    class Technician
    {
        private string _technician_id;
        private string _technician_name;
        private string _technician_contact;
        private string _technician_alias;
        private string _technician_telephone;
        private string _technician_position;


        public Technician()
        {

        }

        public Technician(string technician_id, string technician_name, string technician_contact, string technician_alias, string technician_telephone, string technician_position)
        {
            Technician_id = technician_id;
            Technician_name = technician_name;
            Technician_contact = technician_contact;
            Technician_alias = technician_alias;
            Technician_telephone = technician_telephone;
            Technician_position = technician_position;
        }

        public string Technician_id { get => _technician_id; set => _technician_id = value; }
        public string Technician_name { get => _technician_name; set => _technician_name = value; }
        public string Technician_contact { get => _technician_contact; set => _technician_contact = value; }
        public string Technician_alias { get => _technician_alias; set => _technician_alias = value; }
        public string Technician_telephone { get => _technician_telephone; set => _technician_telephone = value; }
        public string Technician_position { get => _technician_position; set => _technician_position = value; }
    }
}
