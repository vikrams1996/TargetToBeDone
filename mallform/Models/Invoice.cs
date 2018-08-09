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

        [Display(Name = "Start Date")]
        public DateTime startMonth { get; set; }

        [Display(Name = "End Date")]
        public DateTime endMonth { get; set; }

        public DateTime CreatedDate { get; set;
        }
        public string InvoiceStatus { get; set; }

        public string Discription { get; set; }

        public Rent Rent { get; set; }

        public int rentId { get; set; }

        public int invoiceDiscount { get; set; }

        public int totalAmount { get; set; }

    }
}