using part5csc471.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace part5csc471.Models
{
    public class TakesViewModel
    {
        [Display(Name = "Search Site Name")]
        public string SearchSiteName { get; set; }
        public IEnumerable<part5csc471.Entities.Takes> Takes { get; set; }
        public int Id { get; set; }
        public int? PatientId { get; set; }
        public string SiteName { get; set; }
        public string ScientName { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Vaccine ScientNameNavigation { get; set; }
        public virtual VaccinationSite SiteNameNavigation { get; set; }
    }
}
