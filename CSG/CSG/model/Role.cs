using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG.model
{
    class Role
    {
        private string _role_id;
        private string _role_definition;
        private byte _role_level;
        private char _role_prefix;
        private string _role_permissions;

        public Role()
        {
        }

        public Role(string role_id, string role_definition, byte role_level, char role_prefix, string role_permissions)
        {
            Role_id = role_id;
            Role_definition = role_definition;
            Role_level = role_level;
            Role_prefix = role_prefix;
            Role_permissions = role_permissions;
        }

        public string Role_id { get => _role_id; set => _role_id = value; }
        public string Role_definition { get => _role_definition; set => _role_definition = value; }
        public byte Role_level { get => _role_level; set => _role_level = value; }
        public char Role_prefix { get => _role_prefix; set => _role_prefix = value; }
        public string Role_permissions { get => _role_permissions; set => _role_permissions = value; }
    }
}
