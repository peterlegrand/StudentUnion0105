using System;
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
    public class SuProcessTemplateStepLanguageModel
    {
        public int Id { get; set; }
        [Display(Name = "Step id")]
        public int StepId { get; set; }
        [Display(Name = "Language id")]
        public int LanguageId { get; set; }
        [Display(Name = "Step name")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Display(Name = "Step description")]
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
        [ForeignKey("StepId")]
        public virtual SuProcessTemplateStepModel ProcessTemplateStep { get; set; }
        [ForeignKey("LanguageId")]
        public virtual SuLanguageModel Language { get; set; }
    }
}
