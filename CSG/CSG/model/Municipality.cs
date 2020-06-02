using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG.model
{
    class Municipality
    {
        private short _id;
        private string _name;
        private Department _department;

        public Municipality() { }

        public Municipality(short id, string name, Department department)
        {
            Id = id;
            Name = name;
            Department = department;
        }

        public short Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        internal Department Department { get => _department; set => _department = value; }
    }
}
