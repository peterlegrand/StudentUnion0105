using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuProcessTemplateFieldLanguageModel
    {
        public int Id { get; set; }
        public int ProcessTemplateFieldId { get; set; }
        public int LanguageId { get; set; }
        public string ProcessTemplateFieldName { get; set; }
        public string ProcessTemplateFieldDescription { get; set; }
        public string ProcessTemplateFieldMouseOver { get; set; }
        public Guid? CreatorId { get; set; }
        public Guid? ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("ProcessTemplateFieldId")]
        public virtual SuProcessTemplateFieldModel ProcessTemplateField { get; set; }

        [ForeignKey("LanguageId")]
        public virtual SuLanguageModel Language { get; set; }
    }
}
