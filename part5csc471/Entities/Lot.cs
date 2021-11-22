using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace part5csc471.Entities
{
    public partial class Lot
    {
        public int Id { get; set; }
        public string ScientName { get; set; }
        public int? Number { get; set; }
        public string MfrPlace { get; set; }
        public DateTime? Expiration { get; set; }

        public virtual Vaccine ScientNameNavigation { get; set; }
    }
}
