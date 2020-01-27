using System;
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
    public class SuProcessTemplateFlowLanguageModel
    {
        public int Id { get; set; }
        [Display(Name = "Flow id")]
        public int FlowId { get; set; }
        [Display(Name = "Language id")]
        public int LanguageId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Mouse over")]
        [MaxLength(50)]
        public string MouseOver { get; set; }
        [MaxLength(50)]
        [Display(Name = "Menu name")]
        public string MenuName { get; set; }
        public string CreatorId { get; set; }
        public string ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("FlowId")]
        public virtual SuProcessTemplateFlowModel ProcessTemplateFlow { get; set; }
        [ForeignKey("LanguageId")]
        public virtual SuLanguageModel Language { get; set; }

    }
}
