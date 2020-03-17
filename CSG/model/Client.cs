using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG.model
{
    class Client
    {
        //Variables
        private string _client_id;
        private string _client_name;
        private string _client_lastname1;
        private string _client_lastname2;
        private string _client_address;
        private string _client_location;
        private string _client_city;
        private string _client_department;
        private string _client_tel1;
        private string _client_tel2;
        private string _client_email;


        public Client()
        {

        }

        public Client(string client_id, string client_name, string client_lastname1, string client_lastname2, string client_address, string client_location, string client_city, string client_department, string client_tel1, string client_tel2, string client_email)
        {
            Client_id = client_id;
            Client_name = client_name;
            Client_lastname1 = client_lastname1;
            Client_lastname2 = client_lastname2;
            Client_address = client_address;
            Client_location = client_location;
            Client_city = client_city;
            Client_department = client_department;
            Client_tel1 = client_tel1;
            Client_tel2 = client_tel2;
            Client_email = client_email;
        }

        public string Client_id { get => _client_id; set => _client_id = value; }
        public string Client_name { get => _client_name; set => _client_name = value; }
        public string Client_lastname1 { get => _client_lastname1; set => _client_lastname1 = value; }
        public string Client_lastname2 { get => _client_lastname2; set => _client_lastname2 = value; }
        public string Client_address { get => _client_address; set => _client_address = value; }
        public string Client_location { get => _client_location; set => _client_location = value; }
        public string Client_city { get => _client_city; set => _client_city = value; }
        public string Client_department { get => _client_department; set => _client_department = value; }
        public string Client_tel1 { get => _client_tel1; set => _client_tel1 = value; }
        public string Client_tel2 { get => _client_tel2; set => _client_tel2 = value; }
        public string Client_email { get => _client_email; set => _client_email = value; }
    }
}
