using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mallform.Models;
using mallform.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace mallform.ViewModel
{
    public class TenantFormViewModel
    {

        [Required]
       [StringLength(50)]
        public string shopName { get; set; }
        
        [Required]
        [StringLength(50)]
        public string brandName { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]

        public string mobileNo { get; set; }

        [StringLength(50)]
        [Required]
        public string panNo { get; set; }

    
        public Tenant Tenant { get; set; }



    }
}