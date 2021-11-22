using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace part5csc471.Models
{
    public class PatientsViewModel
    {
        [Display(Name ="Search First Name")]
        public string SearchFirstName { get; set; }
        public IEnumerable<part5csc471.Entities.Patient> Patients { get; set; }
        public int Id { get; set; }
        public string FName { get; set; }
        public string MInitial { get; set; }
        public string LName { get; set; }
        public DateTime? Dob { get; set; }
        public int? Weight { get; set; }
    }
}
