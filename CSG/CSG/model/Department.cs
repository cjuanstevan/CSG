using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG.model
{
    class Department
    {
        private byte _id;
        private string _name;
        private string _demonym;

        public Department() { }

        public Department(byte id, string name, string demonym)
        {
            Id = id;
            Name = name;
            Demonym = demonym;
        }

        public byte Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Demonym { get => _demonym; set => _demonym = value; }
    }
}
