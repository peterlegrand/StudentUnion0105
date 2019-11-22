using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuDDCountryModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
