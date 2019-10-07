using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuProcessTemplateStepFieldModel
    {
        public int Id { get; set; }
        public int StepId { get; set; }
        public int FieldId { get; set; }
        public int StatusId { get; set; }
        public int Sequence { get; set; }
        [ForeignKey("FieldId")]
        public virtual SuProcessTemplateFieldModel ProcessTemplateField { get; set; }
        [ForeignKey("StepId")]
        public virtual SuProcessTemplateStepModel ProcessTemplateStep { get; set; }
        [ForeignKey("StatusId")]
        public virtual SuProcessTemplateStepFieldStatusModel ProcessTemplateStepFieldStatus { get; set; }

    }
}
