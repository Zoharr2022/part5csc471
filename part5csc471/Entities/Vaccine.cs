using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace part5csc471.Entities
{
    public partial class Vaccine
    {
        public Vaccine()
        {
            Lot = new HashSet<Lot>();
            Takes = new HashSet<Takes>();
        }
        [Required]
        public string ScientName { get; set; }
        [Required]
        public string Dissease { get; set; }
        public int? NoDoses { get; set; }

        public virtual ICollection<Lot> Lot { get; set; }
        public virtual ICollection<Takes> Takes { get; set; }
    }
}
