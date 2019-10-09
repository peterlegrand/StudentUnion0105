using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuClassificationPageStatusModel
    {
        public int Id { get; set; }
        [Display(Name = "Page status name")]
        [MaxLength(50)]
        public string ClassificationPageStatusName { get; set; }
        public virtual ICollection<SuClassificationPageModel> ClassificationPages { get; set; }

    }
}
