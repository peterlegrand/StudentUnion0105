using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuProcessTemplateStepLanguageModel
    {
        public int Id { get; set; }
        public int StepId { get; set; }
        public int LanguageId { get; set; }
        public string ProcessTemplateStepName { get; set; }
        public string ProcessTemplateStepDescription { get; set; }
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
