using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Queries
{
    public class AdminVehicleSearchParameters
    {
        public decimal? AdminMinPrice { get; set; }
        public decimal? AdminMaxPrice { get; set; }
        public string AdminMinYear { get; set; }
        public string AdminMaxYear { get; set; }
        public string AdminMakeName { get; set; }
        public string AdminModelName { get; set; }
        public string AdminYear { get; set; }
    }
}
