using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace mallform.Models
{
    public class Rent
    {


        public int Id { get; set; }

        [Display(Name = "Issue Date")]
        [DataType(DataType.Date)]
        public DateTime startDate { get; set; }

        [Display(Name = "Last Date")]
        [DataType(DataType.Date)]
        public DateTime endDate { get; set; }


        public string Amount { get; set; }
       
        public Unit Unit { get; set; }
        

        [Display(Name = "Unit Size")]
        public int unitId { get; set; }
       
        public Tenant Tenant { get; set; }
       
        [Display(Name = "Tenant ")]
        public int tenantId { get; set; }

        [Required]
        [Display(Name = "Lease Status ")]
        public string leaseStatus { get; set; }

       
      

       

    }
}