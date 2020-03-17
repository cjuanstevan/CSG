using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG.model
{
    class Order_articleFK
    {
        private Order _order;
        private Article _article;

        public Order_articleFK()
        {

        }

        public Order_articleFK(Order order, Article article)
        {
            Order = order;
            Article = article;
        }

        internal Order Order { get => _order; set => _order = value; }
        internal Article Article { get => _article; set => _article = value; }
    }
}
