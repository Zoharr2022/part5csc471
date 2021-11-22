using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace part5csc471.Entities
{
    public partial class Takes
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        [Required]
        public string SiteName { get; set; }
        [Required]
        public string ScientName { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual Vaccine ScientNameNavigation { get; set; }
        public virtual VaccinationSite SiteNameNavigation { get; set; }
    }
}
