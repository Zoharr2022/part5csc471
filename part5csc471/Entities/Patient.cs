using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace part5csc471.Entities
{
    public partial class Patient
    {
        public Patient()
        {
            Allergy = new HashSet<Allergy>();
            Takes = new HashSet<Takes>();
        }

        public int Id { get; set; }
        [Required]
        public string FName { get; set; }
        public string MInitial { get; set; }
        [Required]
        public string LName { get; set; }
        public DateTime? Dob { get; set; }
        public int? Weight { get; set; }

        public virtual Insured Insured { get; set; }
        public virtual Uninsured Uninsured { get; set; }
        public virtual ICollection<Allergy> Allergy { get; set; }
        public virtual ICollection<Takes> Takes { get; set; }
    }
}
