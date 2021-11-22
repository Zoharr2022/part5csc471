using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace part5csc471.Entities
{
    public partial class Insured
    {
        public int PatientId { get; set; }
        public string Company { get; set; }
        public int? CoPay { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
