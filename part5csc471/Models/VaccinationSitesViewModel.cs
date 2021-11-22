using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace part5csc471.Models
{
    public class VaccinationSitesViewModel
    {
        [Display(Name = "Search Name")]
        public string SearchName { get; set; }
        public IEnumerable<part5csc471.Entities.VaccinationSite> VaccinationSites { get; set; }
        public string Name { get; set; }
        public string AddrStreet { get; set; }
        public string AddrCity { get; set; }
        public string AddrState { get; set; }
        public string AddrZip { get; set; }
    }
}
