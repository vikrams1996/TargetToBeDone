using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mallform.Models
{
    public class Unit
    {

        public int Id { get; set; }

        public string Size { get; set; }

        public Floor Floor { get; set; }
      public byte floorId { get; set; }
        public shop Shop { get; set; }

      public int shopId { get; set; }



    }
}