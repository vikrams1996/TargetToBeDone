using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mallform.Models;
namespace mallform.Dtos
{
    public class RentDto
    {

        public int Id { get; set; }      
        public DateTime startDate { get; set; }    
        public DateTime endDate { get; set; }
        public string Amount { get; set; }   
        public int unitId { get; set; }
        public int tenantId { get; set; }
        public string leaseStatus { get; set; }



    }
}