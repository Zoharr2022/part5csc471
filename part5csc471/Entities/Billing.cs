using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace part5csc471.Entities
{
    public partial class Billing
    {
        public int Id { get; set; }
        public string SiteName { get; set; }
        public int? PatientId { get; set; }

        public virtual Uninsured Patient { get; set; }
        public virtual VaccinationSite SiteNameNavigation { get; set; }
    }
}
