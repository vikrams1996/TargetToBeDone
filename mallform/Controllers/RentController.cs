using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using mallform.Models;
using mallform.ViewModel;
using System.IO;

namespace mallform.Controllers
{
    public class RentController : Controller
    {
        private ApplicationDbContext _Context;

        public RentController()
        {
            _Context = new ApplicationDbContext();
        }
        //GET VALUES FROM THE DATABASE
        public ActionResult leaseUnit()
        {

            var tenants = _Context.Tenant.ToList();
            var units = _Context.Unit.ToList();
          

            var viewModel = new RentFormViewModel
            {
                Tenants = tenants,
                Units = units
             

            };

            return View("leaseUnit", viewModel);
        }


        [HttpPost]
        public ActionResult Save(Rent Rent , FileUpload upload, HttpPostedFileBase file)
        {

            if (Rent.Id == 0)
                _Context.Rent.Add(Rent);

            else
            {
                var rentInDb = _Context.Rent.Single(c => c.Id == Rent.Id);

                rentInDb.tenantId = Rent.tenantId;
                rentInDb.unitId = Rent.unitId;
                rentInDb.startDate = Rent.startDate;
                rentInDb.endDate = Rent.endDate;
                rentInDb.Amount = Rent.Amount;
                rentInDb.leaseStatus = Rent.leaseStatus;
                
            }

                _Context.SaveChanges();
           
            var rent = _Context.Rent.Single(r => r.Id == Rent.Id);

            var up = Request.Files["file"];
            if (up.ContentLength > 0) {



                var fileName = Path.GetFileName(file.FileName);
                var guid = Guid.NewGuid().ToString();
                var path = Path.Combine(Server.MapPath("~/uploads"), guid + fileName);
                file.SaveAs(path);
                string fl = path.Substring(path.LastIndexOf("\\"));
                string[] split = fl.Split('\\');
                string newpath = split[1];
                string imagepath = "~/uploads/" + newpath;
                upload.length = imagepath;
                upload.Rent = rent;
                _Context.FileUpload.Add(upload);
                _Context.SaveChanges();

            }
            return RedirectToAction("leaseStatus", "Home");
        }



      
    

        public ActionResult Edit(int id)

        {
            var Rent = _Context.Rent.SingleOrDefault(r => r.Id == id);
            if (Rent == null)
                return HttpNotFound();
            var viewModel = new RentFormViewModel
            {
                Tenants = _Context.Tenant.ToList(),
                Units = _Context.Unit.ToList(),
                Rent = Rent

            };
            return View("editLease", viewModel);
        }

        public ActionResult Delete(int id)
        {
            _Context.Rent.Remove(_Context.Rent.Find(id));

            _Context.SaveChanges();

            return RedirectToAction("leaseStatus", "Home");
        }

    }      
}