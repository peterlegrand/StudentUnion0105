using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuCountryModel
    {
        public int Id { get; set; }
        [Required]
        public string CountryName { get; set; }
        public string ForeignName { get; set; }

        public string ISO31662 { get; set; }
        public string ISO31663 { get; set; }
        public int ISO3166Num { get; set; }
        public string Region { get; set; }
    }
}
