using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuProcessTemplateLanguageModel
    {
        public int Id { get; set; }
        public int ProcessTemplateId { get; set; }
        public int LanguageId { get; set; }
        public string ProcessTemplateName { get; set; }
        public string ProcessTemplateDescription { get; set; }
        public string ProcessTemplateMouseOver { get; set; }
        public Guid? CreatorId { get; set; }
        public Guid? ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("ProcessTemplateGroupId")]
        public virtual SuProcessTemplateGroupModel ProcessTemplateGroup { get; set; }
        [ForeignKey("LanguageId")]
        public virtual SuLanguageModel Language { get; set; }

    }
}
