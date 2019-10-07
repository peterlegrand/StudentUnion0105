using System;
using System.Collections.Generic;

namespace StudentUnion0105.Models
{
    public class SuProcessTemplateFlowConditionTypeModel
    {
        public int Id { get; set; }
        public Guid? CreatorId { get; set; }
        public Guid? ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<SuProcessTemplateFlowConditionModel> ProcessTemplateFlowConditions { get; set; }
        public virtual ICollection<SuProcessTemplateFlowConditionTypeLanguageModel> ProcessTemplateFlowConditionTypeLanguages { get; set; }
    }
}
