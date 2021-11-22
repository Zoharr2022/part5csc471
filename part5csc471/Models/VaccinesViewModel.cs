using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace part5csc471.Models
{
    public class VaccinesViewModel
    {
        [Display(Name = "Search Scient Name")]
        public string SearchScientName { get; set; }
        public IEnumerable<part5csc471.Entities.Vaccine> Vaccines { get; set; }
        public string ScientName { get; set; }
        public string Dissease { get; set; }
        public int? NoDoses { get; set; }
    }
}
