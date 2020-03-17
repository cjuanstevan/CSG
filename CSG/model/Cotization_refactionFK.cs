using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG.model
{
    class Cotization_refactionFK
    {
        private Cotization _cotization;
        private Refaction _refaction;
        private ushort _refaction_quantity;
        private decimal _refaction_amount;

        public Cotization_refactionFK()
        {

        }

        public Cotization_refactionFK(Cotization cotization, Refaction refaction, ushort refaction_quantity, decimal refaction_amount)
        {
            _cotization = cotization;
            _refaction = refaction;
            _refaction_quantity = refaction_quantity;
            _refaction_amount = refaction_amount;
        }

        public ushort Refaction_quantity { get => _refaction_quantity; set => _refaction_quantity = value; }
        public decimal Refaction_amount { get => _refaction_amount; set => _refaction_amount = value; }
        internal Cotization Cotization { get => _cotization; set => _cotization = value; }
        internal Refaction Refaction { get => _refaction; set => _refaction = value; }
    }
}
