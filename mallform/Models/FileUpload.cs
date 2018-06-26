using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mallform.Models
{
    public class FileUpload
    {     
            public int ID { get; set; }
            public string length { get; set; }
    
           public Rent Rent { get; set; }

           public int rentId { get; set; }
     
        
        
    }
}