using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuProcessTemplateGroupModel
    {
        public int Id { get; set; }
        public int Sequence { get; set; }
        public string CreatorId { get; set; }
        public string ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<SuProcessTemplateModel> ProcessTemplates { get; set; }
        public virtual ICollection<SuProcessTemplateGroupLanguageModel> ProcessTemplateGroupLanguages { get; set; }
    }
    public class SuProcessTemplateGroupLanguageModel
    {
        public int Id { get; set; }
        [Display(Name = "Process template group id")]
        public int ProcessTemplateGroupId { get; set; }
        [Display(Name = "Language id")]
        public int LanguageId { get; set; }
        [Display(Name = "Group name")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Display(Name = "Group description")]
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
    public class SuProcessTemplateGroupEditGetModel
    {
        public int Id { get; set; }
        public int Lid { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string MouseOver { get; set; }
        [Required]
        public string MenuName { get; set; }
        public string Creator { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Modifier { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
