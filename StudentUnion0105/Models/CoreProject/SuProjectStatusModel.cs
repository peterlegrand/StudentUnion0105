using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuProjectStatusModel
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }

        public virtual ICollection<SuProjectModel> Projects { get; set; }

    }
}
