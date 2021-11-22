using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace part5csc471.Entities
{
    public partial class VaccinationSite
    {
        public VaccinationSite()
        {
            Billing = new HashSet<Billing>();
            Takes = new HashSet<Takes>();
        }
        [Required]
        public string Name { get; set; }
        [Required]
        public string AddrStreet { get; set; }
        [Required]
        public string AddrCity { get; set; }
        [Required]
        public string AddrState { get; set; }
        [Required]
        public string AddrZip { get; set; }

        public virtual ICollection<Billing> Billing { get; set; }
        public virtual ICollection<Takes> Takes { get; set; }
    }
}
