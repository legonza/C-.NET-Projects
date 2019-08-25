using CarDealership.Data.Factory;
using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    public class VehicleController : Controller
    {
        [HttpGet]
        public ActionResult NewVehicles()
        {
            var model = new Vehicle();
            return View(model);
        }
        [HttpGet]
        public ActionResult UsedVehicles()
        {
            var model = new Vehicle();
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var repo = VehicleRepositoryFactory.GetRepository();
            var model = repo.GetDetails(id);
            return View(model);
        }
    }
}