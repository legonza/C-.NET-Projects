using CarDealership.Data.Factory;
using CarDealership.Models.Tables;
using CarDealership.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace CarDealership.UI.Controllers
{
    public class AdminController : Controller
    {
        private string GetUserId()
        {
            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var user = userMgr.FindByName(User.Identity.Name);
            return user.Id;
        }
        // GET: Admin
        [HttpGet]
        public ActionResult AdminVehicleList()
        {
            var model = new Vehicle();
            return View(model);
        }
        [HttpGet]
        //[Authorize]
        [AllowAnonymous]
        public ActionResult AddVehicle()
        {
            var model = new VehicleAddViewModel();
            var make = MakeRepositoryFactory.GetRepository();
            var models = ModelRepositoryFactory.GetRepository();

            model.Make = new SelectList(make.GetAll(), "MakeId", "MakeName");
            model.Models = new SelectList(models.GetAll(), "ModelId", "ModelName");
            model.vehicle1 = new Vehicle();
            return View(model);
        }
        //[Authorize]
        [AllowAnonymous]
        [HttpPost]
        public ActionResult AddVehicle(VehicleAddViewModel model)
        {
            var make = MakeRepositoryFactory.GetRepository();
            var models = ModelRepositoryFactory.GetRepository();

            model.Make = new SelectList(make.GetAll(), "MakeId", "MakeName");
            model.Models = new SelectList(models.GetAll(), "ModelId", "ModelName");

            if (ModelState.IsValid)
            {
                model.vehicle1.IsSold = false;

                
                var repo = VehicleRepositoryFactory.GetRepository();
                try
                {
                    if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                    {
                        var savepath = Server.MapPath("~/Images");

                        string fileName = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                        string extension = Path.GetExtension(model.ImageUpload.FileName);

                        var filePath = Path.Combine(savepath, fileName + extension);

                        int counter = 1;
                        while (System.IO.File.Exists(filePath))
                        {
                            filePath = Path.Combine(savepath, fileName + counter.ToString() + extension);
                            counter++;
                        }

                        model.ImageUpload.SaveAs(filePath);
                        model.vehicle1.ImageFileName = Path.GetFileName(filePath);
                    }
                    repo.Insert(model.vehicle1);
                    return RedirectToAction("EditVehicle", new { id = model.vehicle1.VehicleId });
                }
                
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                model.vehicle1 = new Vehicle();
                return View(model);
            }
            
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult EditVehicle(int id)
        {
            var model = new VehicleEditViewModel();

            var makeRepo = MakeRepositoryFactory.GetRepository();
            var modelsRepo = ModelRepositoryFactory.GetRepository();
            var vehicleRepo = VehicleRepositoryFactory.GetRepository();

            model.Make = new SelectList(makeRepo.GetAll(), "MakeId", "MakeName");
            model.Models = new SelectList(modelsRepo.GetAll(), "ModelId", "ModelName");
            model.vehicle1 = vehicleRepo.GetById(id);

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult EditVehicle(VehicleEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var repo = VehicleRepositoryFactory.GetRepository();

                try
                {
                    
                    var oldVehicle = repo.GetById(model.vehicle1.VehicleId);

                    if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                    {
                        var savepath = Server.MapPath("~/Images");

                        string fileName = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                        string extension = Path.GetExtension(model.ImageUpload.FileName);

                        var filePath = Path.Combine(savepath, fileName + extension);

                        int counter = 1;
                        while (System.IO.File.Exists(filePath))
                        {
                            filePath = Path.Combine(savepath, fileName + counter.ToString() + extension);
                            counter++;
                        }

                        model.ImageUpload.SaveAs(filePath);
                        model.vehicle1.ImageFileName = Path.GetFileName(filePath);

                        // delete old file
                        var oldPath = Path.Combine(savepath, oldVehicle.ImageFileName);
                        if (System.IO.File.Exists(oldPath))
                        {
                            System.IO.File.Delete(oldPath);
                        }
                    }
                    else
                    {
                        // they did not replace the old file, so keep the old file name
                        model.vehicle1.ImageFileName = oldVehicle.ImageFileName;
                    }

                    repo.Update(model.vehicle1);

                    return RedirectToAction("EditVehicle", new { id = model.vehicle1.VehicleId });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                var makeRepo = MakeRepositoryFactory.GetRepository();
                var modelsRepo = ModelRepositoryFactory.GetRepository();
                var vehicleRepo = VehicleRepositoryFactory.GetRepository();

                model.Make = new SelectList(makeRepo.GetAll(), "MakeId", "MakeName");
                model.Models = new SelectList(modelsRepo.GetAll(), "ModelId", "ModelName");
                model.vehicle1 = new Vehicle();

                return View(model);
            }
        }

        [HttpPost]
        public ActionResult DeleteVehicle(int vehicleId)
        {
            VehicleRepositoryFactory.GetRepository().Delete(vehicleId);
            return RedirectToAction("AdminVehicleList");
        }
        [HttpGet]
        public ActionResult UserList()
        {
            var model = AccountRepositoryFactory.GetRepository().GetUsers().ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult SpecialList()
        {
            var model = VehicleRepositoryFactory.GetRepository().SpecialById().ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult SpecialList(string title, string description)
        {
            Specials special = new Specials();
            special.Title = title;
            special.Description = description;
            VehicleRepositoryFactory.GetRepository().InsertSpecial(special);
            VehicleRepositoryFactory.GetRepository().SpecialById().ToList();
            return RedirectToAction("SpecialList");
        }
        [HttpPost]
        public ActionResult DeleteSpecial(int specialId)
        {
            VehicleRepositoryFactory.GetRepository().DeleteSpecial(specialId);
            return RedirectToAction("SpecialList");
        }
        [HttpGet]
        public ActionResult MakesList()
        {
            var model = MakeRepositoryFactory.GetRepository().GetAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult ModelList()
        {
            var model = ModelRepositoryFactory.GetRepository().GetAll();
            return View(model);
        }
    }
}