using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuProcessTemplateStepModel
    {
        public int Id { get; set; }
        [Display(Name = "Process template id")]
        public int ProcessTemplateId { get; set; }
        public int ProcessTemplateStepTypeId { get; set; }
        [ForeignKey("ProcessTemplateId")]
        public virtual SuProcessTemplateModel ProcessTemplate { get; set; }
        [ForeignKey("ProcessTemplateStepTypeId")]
        public virtual SuProcessTemplateStepTypeModel ProcessTemplateStepType { get; set; }
        public virtual ICollection<SuProcessTemplateStepLanguageModel> ProcessTemplateStepLanguages { get; set; }
        public virtual ICollection<SuProcessTemplateStepFieldModel> ProcessTemplateStepFields { get; set; }

    }
}
