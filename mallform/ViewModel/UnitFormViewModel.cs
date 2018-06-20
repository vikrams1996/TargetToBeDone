using System.Collections.Generic;
using mallform.Models;
using System.ComponentModel.DataAnnotations;

namespace mallform.ViewModel
{
    public class UnitFormViewModel
    {

        public IEnumerable<Floor> Floors { get; set; }

    
        public Unit Unit { get; set; }


        public IEnumerable<shop> Shops { get; set; }

    }
}