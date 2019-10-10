using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuProcessTemplateStepLanguageModel
    {
        public int Id { get; set; }
        [Display(Name = "Step id")]
        public int StepId { get; set; }
        [Display(Name = "Language id")]
        public int LanguageId { get; set; }
        [Display(Name = "Step name")]
        [MaxLength(50)]
        public string ProcessTemplateStepName { get; set; }
        [Display(Name = "Step description")]
        public string ProcessTemplateStepDescription { get; set; }
        [Display(Name = "Mouse over")]
        [MaxLength(50)]
        public string ProcessTemplateStepMouseOver { get; set; }
        public Guid? CreatorId { get; set; }
        public Guid? ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("StepId")]
        public virtual SuProcessTemplateStepModel ProcessTemplateStep { get; set; }
        [ForeignKey("LanguageId")]
        public virtual SuLanguageModel Language { get; set; }
    }
}
