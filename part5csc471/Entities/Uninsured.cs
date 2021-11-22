using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace part5csc471.Entities
{
    public partial class Uninsured
    {
        public Uninsured()
        {
            Billing = new HashSet<Billing>();
        }

        public int PatientId { get; set; }
        public string PmtMethod { get; set; }
        public string AddrStreet { get; set; }
        public string AddrCity { get; set; }
        public string AddrState { get; set; }
        public string AddrZip { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual ICollection<Billing> Billing { get; set; }
    }
}
