using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG.model
{
    class User
    {
        private string _user_code;
        private string _user_definition;
        private string _user_account;
        private string _user_email;
        private string _user_password;
        private string _user_tokens;
        private Role _role;

        public User()
        {
        }

        public User(string user_code, string user_definition, string user_account, string user_email, string user_password, string user_tokens, Role role)
        {
            User_code = user_code;
            User_definition = user_definition;
            User_account = user_account;
            User_email = user_email;
            User_password = user_password;
            User_tokens = user_tokens;
            Role = role;
        }

        public string User_code { get => _user_code; set => _user_code = value; }
        public string User_definition { get => _user_definition; set => _user_definition = value; }
        public string User_account { get => _user_account; set => _user_account = value; }
        public string User_email { get => _user_email; set => _user_email = value; }
        public string User_password { get => _user_password; set => _user_password = value; }
        public string User_tokens { get => _user_tokens; set => _user_tokens = value; }
        internal Role Role { get => _role; set => _role = value; }
    }
}
