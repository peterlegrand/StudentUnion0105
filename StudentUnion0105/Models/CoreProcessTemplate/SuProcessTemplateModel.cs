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
        public bool ShowInPersonalCalendar { get; set; }
        public bool ShowInEventCalendar { get; set; }
        public string CreatorId { get; set; }
        public string ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("ProcessTemplateGroupId")]
        public virtual SuProcessTemplateGroupModel ProcessTemplateGroup { get; set; }
    }
    public class SuProcessTemplateLanguageModel
    {
        public int Id { get; set; }
        [Display(Name = "Process template id")]
        public int ProcessTemplateId { get; set; }
        [Display(Name = "Language id")]
        public int LanguageId { get; set; }
        [Display(Name = "Name")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Display(Name = "Description")]
        [MaxLength(50)]
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

        [ForeignKey("ProcessTemplateGroupId")]
        public virtual SuProcessTemplateGroupModel ProcessTemplateGroup { get; set; }
        [ForeignKey("LanguageId")]
        public virtual SuLanguageModel Language { get; set; }

    }
}
