using System;
using System.Collections.Generic;
using mallform.Models;

namespace mallform.ViewModel
{
    public class InvoiceViewModel
    {
        public DateTime CreatedDate
        {
            get; set;
        }
        public Invoice Invoice { get; set; }
        public Rent Rent { get; set; }
        public IEnumerable<Rent> Rents { get; set; }
     
    }
}