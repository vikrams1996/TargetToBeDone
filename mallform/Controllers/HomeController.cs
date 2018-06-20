using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using mallform.Models;
using mallform.ViewModel;


namespace mallform.Controllers
{

    public class HomeController : Controller
    {
        private ApplicationDbContext _Context;
        public HomeController()
        {
            _Context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var tenant = _Context.Tenant;

            return View(tenant);
        }

        public ActionResult unitList()
        {
            var unit = _Context.Unit.Include(f=>f.Floor).Include(s=>s.Shop).ToList();

            return View(unit);
        }

       
        



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}