using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Queries
{
    public class InventoryReport
    {
        public int Count { get; set; }
        public string Year { get; set; }
        public decimal StockValue { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
    }
}
