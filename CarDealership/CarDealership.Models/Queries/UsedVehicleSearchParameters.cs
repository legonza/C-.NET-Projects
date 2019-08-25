using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Queries
{
    public class UsedVehicleSearchParameters
    {
        public decimal? UsedMinPrice { get; set; }
        public decimal? UsedMaxPrice { get; set; }
        public string UsedMinYear { get; set; }
        public string UsedMaxYear { get; set; }
        public string UsedMakeName { get; set; }
        public string UsedModelName { get; set; }
        public string UsedYear { get; set; }
    }
}
