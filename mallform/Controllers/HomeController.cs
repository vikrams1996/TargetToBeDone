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
            if (User.IsInRole("CanManageLeaseStatus"))

                return View("Index",tenant);
                return View("ReadOnlyTenant",tenant);

            
        }

        public ActionResult unitList()
        {
            var unit = _Context.Unit.Include(f=>f.Floor).Include(s=>s.Shop).ToList();
            if (User.IsInRole("CanManageLeaseStatus"))
            return View("unitList",unit);
            return View("ReadOnlyUnit", unit);
        }

        public ActionResult leaseStatus()
        {
            var leaseStatus = _Context.Rent./*Include(s=>s.Shop).*/Include(t => t.Tenant).ToList();
            if (User.IsInRole("CanManageLeaseStatus"))
               
            return View("leaseStatus",leaseStatus);
            return View("ReadOnlyLease", leaseStatus);


        }

        public ActionResult invoiceList()
        {
            var invoice = _Context.Invoice.Include(r => r.Rent.Tenant).ToList();
            if (User.IsInRole("CanManageLeaseStatus"))
            return View("invoiceList",invoice);
            return View("ReadOnlyInvoice", invoice);
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