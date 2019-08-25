using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Models
{
    public class PurchasedViewModel
    {
        public Vehicle vehicles { get; set; }
        public Purchase purchases { get; set; }
        public IEnumerable<SelectListItem> States { get; set; }
    }
}