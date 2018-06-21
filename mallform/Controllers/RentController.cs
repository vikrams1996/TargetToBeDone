using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mallform.Controllers
{
    public class RentController : Controller
    {
        // GET: Rent/leaseUnit
        public ActionResult leaseUnit()
        {
            return View();
        }
    }
}