using CarDealership.Data.Factory;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            var model = VehicleRepositoryFactory.GetRepository().GetFeatured();
            return View(model);
        }
        public ActionResult Specials()
        {
            var model = VehicleRepositoryFactory.GetRepository().SpecialById().ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult Contact(Contacts contacts)
        {
            AccountRepositoryFactory.GetRepository().AddContact(contacts); 
            return View();
        }
    }
}