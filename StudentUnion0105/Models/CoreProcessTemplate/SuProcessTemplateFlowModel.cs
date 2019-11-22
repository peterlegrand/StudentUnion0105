using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuProcessTemplateFlowModel
    {
        public int Id { get; set; }
        [Display(Name = "Process template id")]
        public int ProcessTemplateId { get; set; }
        [Display(Name = "Process template from step id")]
        public int ProcessTemplateFromStepId { get; set; }
        [Display(Name = "Process template to step id")]
        public int ProcessTemplateToStepId { get; set; }
        [Display(Name = "Condition relation")]
        [MaxLength(50)]
        //public string ConditionRelation { get; set; }
        //[ForeignKey("ProcessTemplateId")]
        public virtual SuProcessTemplateModel ProcessTemplate { get; set; }
        public virtual ICollection<SuProcessTemplateFlowLanguageModel> ProcessTemplateFlowLanguages { get; set; }
        public virtual ICollection<SuProcessTemplateFlowConditionModel> ProcessTemplateFlowCondition { get; set; }

    }
}
