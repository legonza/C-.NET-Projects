using CarDealership.Data.Factory;
using CarDealership.Models.Queries;
using CarDealership.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult ReportMenu()
        {
            return View();
        }
        public ActionResult InventoryReport()
        {
            var model = new VehicleReportsViewModel();
            var newReport = VehicleRepositoryFactory.GetRepository().Reports("new");
            var usedReport = VehicleRepositoryFactory.GetRepository().Reports("used");
            model.NewVehicle = newReport;
            model.UsedVehicle = usedReport;
            return View(model);
        }
    }
}