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
        private string _create_by;
        private DateTime _create_date;
        private string _update_by;
        private DateTime _update_date;


        public Technician()
        {

        }

        public Technician(string technician_id, string technician_name, string technician_contact, 
            string technician_alias, string technician_telephone, string technician_position, 
            string create_by, DateTime create_date, string update_by, DateTime update_date)
        {
            Technician_id = technician_id;
            Technician_name = technician_name;
            Technician_contact = technician_contact;
            Technician_alias = technician_alias;
            Technician_telephone = technician_telephone;
            Technician_position = technician_position;
            Create_by = create_by;
            Create_date = create_date;
            Update_by = update_by;
            Update_date = update_date;
        }

        public string Technician_id { get => _technician_id; set => _technician_id = value; }
        public string Technician_name { get => _technician_name; set => _technician_name = value; }
        public string Technician_contact { get => _technician_contact; set => _technician_contact = value; }
        public string Technician_alias { get => _technician_alias; set => _technician_alias = value; }
        public string Technician_telephone { get => _technician_telephone; set => _technician_telephone = value; }
        public string Technician_position { get => _technician_position; set => _technician_position = value; }
        public string Create_by { get => _create_by; set => _create_by = value; }
        public DateTime Create_date { get => _create_date; set => _create_date = value; }
        public string Update_by { get => _update_by; set => _update_by = value; }
        public DateTime Update_date { get => _update_date; set => _update_date = value; }
    }
}
