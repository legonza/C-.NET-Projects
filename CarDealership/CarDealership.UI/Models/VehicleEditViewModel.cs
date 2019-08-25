using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Models
{
    public class VehicleEditViewModel
    {
        public Vehicle vehicle1 { get; set; }
        public IEnumerable<SelectListItem> Models { get; set; }
        public IEnumerable<SelectListItem> Make { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}