using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuClassificationStatusModel
    {
        public int Id { get; set; }
        [Display(Name = "Classification status name")]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<SuClassificationModel> Classifications { get; set; }
    }
}
