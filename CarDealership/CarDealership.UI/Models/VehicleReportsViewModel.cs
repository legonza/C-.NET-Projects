using CarDealership.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class VehicleReportsViewModel
    {
        public IEnumerable<InventoryReport> NewVehicle { get; set; }
        public IEnumerable<InventoryReport> UsedVehicle { get; set; }
    }
}