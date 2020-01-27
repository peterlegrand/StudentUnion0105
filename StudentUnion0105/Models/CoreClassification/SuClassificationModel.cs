using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuClassificationModel
    {
        public int Id { get; set; }
        [Display(Name = "Classification status Id")]
        public int ClassificationStatusId { get; set; }
        [Display(Name = "Default classification page id")]
        public int DefaultClassificationPageId { get; set; }
        [Display(Name = "Has dropdown")]
        public bool HasDropDown { get; set; }
        [Display(Name = "Drop down sequence")]
        public int DropDownSequence { get; set; }
        public string CreatorId { get; set; }
        public string ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<SuClassificationLanguageModel> ClassificationLanguages { get; set; }
        [ForeignKey("ClassificationStatusId")]
        public virtual SuClassificationStatusModel ClassificationStatus { get; set; }
        public virtual ICollection<SuClassificationLevelModel> ClassificationLevels { get; set; }
        //        public virtual ICollection<SuClassificationValueModel> ClassificationValues { get; set; }
        public virtual ICollection<SuClassificationValueModel> ClassificationValues { get; set; }

        public virtual ICollection<SuContentTypeClassificationModel> ContentTypeClassification { get; set; }
    }
    public class SuClassificationLanguageModel
    {
        public int Id { get; set; }
        [Display(Name = "Classification Id")]
        public int ClassificationId { get; set; }
        [Display(Name = "Language Id")]
        public int LanguageId { get; set; }
        [Display(Name = "Classification name")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Display(Name = "Classification description")]
        public string Description { get; set; }
        [MaxLength(50)]
        [Display(Name = "Classification menu name")]
        public string MenuName { get; set; }
        [MaxLength(50)]
        [Display(Name = "Classification mouse over")]
        public string MouseOver { get; set; }
        public string CreatorId { get; set; }
        public string ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("ClassificationId")]
        public virtual SuClassificationModel Classification { get; set; }
        [ForeignKey("LanguageId")]
        public virtual SuLanguageModel Language { get; set; }
    }
}
