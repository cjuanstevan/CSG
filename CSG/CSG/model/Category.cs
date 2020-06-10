using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG.model
{
    class Category
    {
        private byte _category_id;
        private string _category_name;

        public Category() { }

        public Category(byte category_id, string category_name)
        {
            Category_id = category_id;
            Category_name = category_name;
        }

        public byte Category_id { get => _category_id; set => _category_id = value; }
        public string Category_name { get => _category_name; set => _category_name = value; }
    }
}
