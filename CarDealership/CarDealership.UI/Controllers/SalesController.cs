using CarDealership.Data.Factory;
using CarDealership.Models.Tables;
using CarDealership.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        [HttpGet]
        public ActionResult SalesIndex()
        {
            var model = new Vehicle();
            return View(model);
        }
        [HttpGet]
        public ActionResult PurchaseVehicle(int id)
        {
            var model = new PurchasedViewModel();

            var stateRepo = StateRepositoryFactory.GetRepository();
            var vehicleRepo = VehicleRepositoryFactory.GetRepository();

            model.States = new SelectList(stateRepo.GetAll(), "StateId", "StateName");
            model.vehicles = vehicleRepo.GetById(id);

            return View(model);
        }
        [HttpPost]
        public ActionResult PurchaseVehicle(Purchase purchase)
        {
            VehicleRepositoryFactory.GetRepository().Purchased(purchase);
            return RedirectToAction("SalesIndex");
        }
    }
}