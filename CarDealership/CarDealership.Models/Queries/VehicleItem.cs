using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Queries
{
    public class VehicleItem
    {
        public int VehicleId { get; set; }
        public string Type { get; set; }
        public string BodyStyle { get; set; }
        public string Year { get; set; }
        public string Transmission { get; set; }
        public string Color { get; set; }
        public string Interior { get; set; }
        public string Miles { get; set; }
        public string Vin { get; set; }
        public decimal Price { get; set; }
        public decimal Msrp { get; set; }
        public string Description { get; set; }
        public bool Featured { get; set; }
        public string ImageFileName { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public int MakeId { get; set; }
        public int ModelId { get; set; }
    }
}
