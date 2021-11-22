using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace part5csc471.Models
{
    public class AllergiesViewModel
    {
        [Display(Name = "Search Allergy Name")]
        public string SearchAllergyname { get; set; }
        public IEnumerable<part5csc471.Entities.Allergy> Allergies { get; set; }
        public int Id { get; set; }
        public int? PatientId { get; set; }
        public string Allergyname { get; set; }
    }
}
