using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace mallform.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime startMonth { get; set; }

        public DateTime endMonth { get; set; }

        public DateTime CreatedDate { get; set;
        }
        public string InvoiceStatus { get; set; }

        public string Discription { get; set; }

        public Rent Rent { get; set; }

        [Display(Name = "Total Amount ")]
        public int rentId { get; set; }
      
        



    }
}