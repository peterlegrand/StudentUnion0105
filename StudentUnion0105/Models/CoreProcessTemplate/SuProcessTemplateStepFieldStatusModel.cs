using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuProcessTemplateStepFieldStatusModel
    {
        public int Id { get; set; }
        [Display(Name = "Status name")]
        [MaxLength(50)]

        public string Name { get; set; }

        public virtual ICollection<SuContentModel> SuProcessTemplateStepFieldModel { get; set; }
    }
}
