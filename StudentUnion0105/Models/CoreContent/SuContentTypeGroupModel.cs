using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuContentTypeGroupModel
    {
        public int Id { get; set; }
        public int Sequence { get; set; }
        public string CreatorId { get; set; }
        public string ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<SuContentTypeModel> ContentType { get; set; }
        public virtual ICollection<SuContentTypeGroupLanguageModel> ContentTypeGroupLanguages { get; set; }
    }
    public class SuContentTypeGroupLanguageModel
    {
        public int Id { get; set; }
        [Display(Name = "Process template group id")]
        public int ContentTypeGroupId { get; set; }
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
        [ForeignKey("ContentTypeGroupId")]
        public virtual SuContentTypeGroupModel ContentTypeGroup { get; set; }
        [ForeignKey("LanguageId")]
        public virtual SuLanguageModel Language { get; set; }
    }


}
