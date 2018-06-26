using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mallform.Models;
using mallform.ViewModel;

namespace mallform.ViewModel
{
    public class RentFormViewModel
    {
        public Rent Rent { get; set; }


        public IEnumerable<Tenant> Tenants { get; set; }
        public IEnumerable<Unit> Units { get; set; }

       
    }
}