using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace part5csc471.Entities
{
    public partial class Allergy
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        [Required]
        public string Allergyname { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
