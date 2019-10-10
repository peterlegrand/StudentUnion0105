using System;
using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuProcessTemplateGroupLanguageModel
    {
        public int Id { get; set; }
        [Display(Name = "Process template group id")]
        public int ProcessTemplateGroupId { get; set; }
        [Display(Name = "Language id")]
        public int LanguageId { get; set; }
        [Display(Name = "Group name")]
        [MaxLength(50)]
        public string ProcessTemplateGroupName { get; set; }
        [Display(Name = "Group description")]
        public string ProcessTemplateGroupDescription { get; set; }
        [Display(Name = "Mouse over")]
        [MaxLength(50)]
        public string ProcessTemplateGroupMouseOver { get; set; }
        public Guid? CreatorId { get; set; }
        public Guid? ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
