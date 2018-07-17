using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mallform.Models;
using mallform.ViewModel;
using System.Data.Entity;

namespace mallform.Controllers
{
    public class UnitController : Controller
    {
        public ApplicationDbContext _Context;

        public UnitController()
        {
            _Context = new ApplicationDbContext();

        }
        public ActionResult AddUnit() //GET UNITS 
        {
           
            var floors = _Context.Floor.ToList();
            var shops = _Context.Shop.ToList();
            var viewModel = new UnitFormViewModel
            {
                
                Floors = floors,
                Shops = shops
            };

            return View("AddUnit",viewModel);
        }

        //POST UNITS

        [HttpPost]
        public ActionResult Save( Unit Unit)
        {
          
            if (_Context.Unit.Any(u => u.Id != Unit.Id && u.shopId== Unit.shopId))
            {
                return Content("shop already occupied");
                   


            }
            if (Unit.Id == 0)
            {
                _Context.Unit.Add(Unit);
             
            }

           // if(Unit.Id > 0)
           // {
           //     ViewBag.Duplicate = "This Shop " + Unit.shopId + "is already in use";
          //  }

            else
            {
                var unitInDb = _Context.Unit.Single(c => c.Id == Unit.Id);

                unitInDb.Size = Unit.Size;
                unitInDb.floorId = Unit.floorId;
                unitInDb.shopId = Unit.shopId;
            }

            _Context.SaveChanges();

            return RedirectToAction("unitList", "Home");
        }






        [Authorize(Roles = "CanManageLeaseStatus")]
        public ActionResult Edit(int id)

        {
            var Unit = _Context.Unit.SingleOrDefault(u => u.Id == id);
            if (Unit == null)
                return HttpNotFound();
            var viewModel = new UnitFormViewModel
            {
                Unit=Unit,
               Floors=_Context.Floor.ToList(),
                Shops = _Context.Shop.ToList()


            };
            return View("EditUnit", viewModel);
        }


        //DELETE A UNIT
        [Authorize(Roles = "CanManageLeaseStatus")]
        public ActionResult Delete(int id)

        {

            _Context.Unit.Remove(_Context.Unit.Find(id));

            _Context.SaveChanges();

            return RedirectToAction("unitList", "Home");

        }





    }
}

   