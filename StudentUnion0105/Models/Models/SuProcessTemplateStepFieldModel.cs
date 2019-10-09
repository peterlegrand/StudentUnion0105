using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuProcessTemplateStepFieldModel
    {
        public int Id { get; set; }
        [Display(Name = "Step id")]
        public int StepId { get; set; }
        [Display(Name = "Field id")]
        public int FieldId { get; set; }
        [Display(Name = "Status id")]
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
