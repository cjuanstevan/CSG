﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG.model
{
    class Order
    {
        private string _order_number;
        private DateTime _order_reception_date;
        private DateTime _order_end_date;
        private string _order_type;
        private string _order_invoice;
        private DateTime _order_sale_date;
        private string _order_state;
        private string _order_comentarys;
        private string _order_report_client;
        private Technician _technician;
        private Client _client;
        private Cotization _cotization;
        private string _create_by;
        private DateTime _create_date;
        private string _update_by;
        private DateTime _update_date;

        //static vars
        private static string _order_number_st;

        public Order()
        {

        }

        public Order(string order_number, DateTime order_reception_date, DateTime order_end_date, string order_type,
            string order_invoice, DateTime order_sale_date, string order_state, string order_comentarys,
            string order_report_client, Technician technician, Client client, Cotization cotization, string create_by,
            DateTime create_date, string update_by, DateTime update_date)
        {
            Order_number = order_number;
            Order_reception_date = order_reception_date;
            Order_end_date = order_end_date;
            Order_type = order_type;
            Order_invoice = order_invoice;
            Order_sale_date = order_sale_date;
            Order_state = order_state;
            Order_comentarys = order_comentarys;
            Order_report_client = order_report_client;
            Technician = technician;
            Client = client;
            Cotization = cotization;
            Create_by = create_by;
            Create_date = create_date;
            Update_by = update_by;
            Update_date = update_date;
        }

        public string Order_number { get => _order_number; set => _order_number = value; }
        public DateTime Order_reception_date { get => _order_reception_date; set => _order_reception_date = value; }
        public DateTime Order_end_date { get => _order_end_date; set => _order_end_date = value; }
        public string Order_type { get => _order_type; set => _order_type = value; }
        public string Order_invoice { get => _order_invoice; set => _order_invoice = value; }
        public DateTime Order_sale_date { get => _order_sale_date; set => _order_sale_date = value; }
        public string Order_state { get => _order_state; set => _order_state = value; }
        public string Order_comentarys { get => _order_comentarys; set => _order_comentarys = value; }
        public string Order_report_client { get => _order_report_client; set => _order_report_client = value; }
        internal Technician Technician { get => _technician; set => _technician = value; }
        internal Client Client { get => _client; set => _client = value; }
        internal Cotization Cotization { get => _cotization; set => _cotization = value; }
        public string Create_by { get => _create_by; set => _create_by = value; }
        public DateTime Create_date { get => _create_date; set => _create_date = value; }
        public string Update_by { get => _update_by; set => _update_by = value; }
        public DateTime Update_date { get => _update_date; set => _update_date = value; }
        public static string Order_number_st { get => _order_number_st; set => _order_number_st = value; }
    }
}
