using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuProcessTemplateFlowModel
    {
        public int Id { get; set; }
        public int ProcessTemplateId { get; set; }
        public int ProcessTemplateFromStepId { get; set; }
        public int ProcessTemplateToStepId { get; set; }
        [ForeignKey("ProcessTemplateId")]
        public virtual SuProcessTemplateModel ProcessTemplate { get; set; }
        public virtual ICollection<SuProcessTemplateFlowLanguageModel> ProcessTemplateFlowLanguages { get; set; }
        public virtual ICollection<SuProcessTemplateFlowConditionModel> ProcessTemplateFlowCondition { get; set; }

    }
}
