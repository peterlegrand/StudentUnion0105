using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuProcessTemplateFieldTypeModel
    {
        public int Id { get; set; }
        public virtual ICollection<SuProcessTemplateFieldTypeLanguageModel> ProcessTemplateFieldTypeLanguages { get; set; }
        public virtual ICollection<SuProcessTemplateFieldModel> ProcessTemplateField { get; set; }
    }
    public class SuProcessTemplateFieldTypeLanguageModel
    {
        public int Id { get; set; }
        [Display(Name = "Field type id")]
        public int FieldTypeId { get; set; }
        [Display(Name = "Language id")]
        public int LanguageId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
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

        [ForeignKey("FieldTypeId")]
        public virtual SuProcessTemplateFieldTypeModel ProcessTemplateFieldType { get; set; }
        [ForeignKey("LanguageId")]
        public virtual SuLanguageModel Language { get; set; }

    }
}
