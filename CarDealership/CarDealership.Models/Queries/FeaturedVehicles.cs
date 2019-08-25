using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Queries
{
    public class FeaturedVehicles
    {
        public int VehicleId { get; set; }
        public string Year { get; set; }
        public int MakeId { get; set; }
        public string MakeName { get; set; }
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public decimal Price { get; set; }
        public string ImageFileName { get; set; }
    }
}
