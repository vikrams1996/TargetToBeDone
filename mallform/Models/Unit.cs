﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace mallform.Models
{
    public class Unit
    {

        public int Id { get; set; }

        [Required]
       
        public string Size { get; set; }

        public Floor Floor { get; set; }

        [Display(Name ="Mall Floor")]
        public byte floorId { get; set; }
        public shop Shop { get; set; }

      
        public int shopId { get; set; }



    }
}