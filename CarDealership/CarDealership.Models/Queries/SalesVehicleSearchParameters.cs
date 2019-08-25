using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Queries
{
    public class SalesVehicleSearchParameters
    {
        public decimal? SalesMinPrice { get; set; }
        public decimal? SalesMaxPrice { get; set; }
        public string SalesMinYear { get; set; }
        public string SalesMaxYear { get; set; }
        public string SalesMakeName { get; set; }
        public string SalesModelName { get; set; }
        public string SalesYear { get; set; }
    }
}
