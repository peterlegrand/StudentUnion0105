using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuProcessTemplateModel
    {
        public int Id { get; set; }
        [Display(Name = "Process template group id")]
        public int ProcessTemplateGroupId { get; set; }
        public string CreatorId { get; set; }
        public string ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("ProcessTemplateGroupId")]
        public virtual SuProcessTemplateGroupModel ProcessTemplateGroup { get; set; }
    }
}
