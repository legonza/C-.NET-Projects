using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Tables
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string StreetOne { get; set; }
        public string StreetTwo { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string Phone { get; set; }
        public string PaymentOption { get; set; }
        public decimal PurchasePrice { get; set; }
        public string StateId { get; set; }
        public int VehicleId { get; set; }
    }
}
