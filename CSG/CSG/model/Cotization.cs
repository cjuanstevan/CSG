﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG.model
{
    class Cotization
    {
        private string _cotization_id;
        private DateTime _cotization_generation_date;
        private DateTime _cotization_expiration_date;
        private byte _cotization_quantity;//cambiar a byte 0 a 255
        private string _cotization_comentarys;
        private decimal _cotization_subtotal;
        private decimal _cotization_discount;
        private decimal _cotization_iva;
        private decimal _cotization_total;
        private string _create_by;
        private DateTime _create_date;
        private string _update_by;
        private DateTime _update_date;

        public Cotization()
        {

        }

        public Cotization(string cotization_id, DateTime cotization_generation_date, 
            DateTime cotization_expiration_date, byte cotization_quantity, string cotization_comentarys, 
            decimal cotization_subtotal, decimal cotization_discount, decimal cotization_iva, 
            decimal cotization_total, string create_by, DateTime create_date, string update_by, 
            DateTime update_date)
        {
            Cotization_id = cotization_id;
            Cotization_generation_date = cotization_generation_date;
            Cotization_expiration_date = cotization_expiration_date;
            Cotization_quantity = cotization_quantity;
            Cotization_comentarys = cotization_comentarys;
            Cotization_subtotal = cotization_subtotal;
            Cotization_discount = cotization_discount;
            Cotization_iva = cotization_iva;
            Cotization_total = cotization_total;
            Create_by = create_by;
            Create_date = create_date;
            Update_by = update_by;
            Update_date = update_date;
        }

        public string Cotization_id { get => _cotization_id; set => _cotization_id = value; }
        public DateTime Cotization_generation_date { get => _cotization_generation_date; set => _cotization_generation_date = value; }
        public DateTime Cotization_expiration_date { get => _cotization_expiration_date; set => _cotization_expiration_date = value; }
        public byte Cotization_quantity { get => _cotization_quantity; set => _cotization_quantity = value; }
        public string Cotization_comentarys { get => _cotization_comentarys; set => _cotization_comentarys = value; }
        public decimal Cotization_subtotal { get => _cotization_subtotal; set => _cotization_subtotal = value; }
        public decimal Cotization_discount { get => _cotization_discount; set => _cotization_discount = value; }
        public decimal Cotization_iva { get => _cotization_iva; set => _cotization_iva = value; }
        public decimal Cotization_total { get => _cotization_total; set => _cotization_total = value; }
        public string Create_by { get => _create_by; set => _create_by = value; }
        public DateTime Create_date { get => _create_date; set => _create_date = value; }
        public string Update_by { get => _update_by; set => _update_by = value; }
        public DateTime Update_date { get => _update_date; set => _update_date = value; }
    }
}
