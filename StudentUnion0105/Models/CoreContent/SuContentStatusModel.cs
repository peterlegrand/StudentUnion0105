using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuContentStatusModel
    {
        public int Id { get; set; }
        [Display(Name = "Content status name")]
        [MaxLength(50)]

        public string Name { get; set; }

        public virtual ICollection<SuContentModel> Contents { get; set; }
    }
}
