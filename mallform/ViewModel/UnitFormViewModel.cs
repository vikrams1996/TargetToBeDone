using System.Collections.Generic;
using mallform.Models;
using System.ComponentModel.DataAnnotations;

namespace mallform.ViewModel
{
    public class UnitFormViewModel
    {
        [Required]
        public IEnumerable<Floor> Floors { get; set; }

        [Required]
        public Unit Unit { get; set; }

        [Required]
        public IEnumerable<shop> Shops { get; set; }

    }
}