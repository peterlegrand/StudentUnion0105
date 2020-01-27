using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuClassificationValueModel
    {
        public int Id { get; set; }
        //        [Display(Name="SuClassificationLevelModel")]
        [Display(Name = "Classification id")]
        public virtual int ClassificationId { get; set; }
        [Display(Name = "Classification parent value id")]
        public int? ParentValueId { get; set; }
        [Display(Name = "Classification value date from")]
        public DateTimeOffset? DateFrom { get; set; }
        [Display(Name = "Classification value date to")]
        public DateTimeOffset? DateTo { get; set; }
        public string CreatorId { get; set; }
        public string ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("ClassificationId")]
        public virtual SuClassificationModel Classification { get; set; }
        public virtual ICollection<SuClassificationValueLanguageModel> ClassificationValueLanguages { get; set; }
    }

    public class SuClassificationValueLanguageModel
    {
        public int Id { get; set; }
        [Display(Name = "Classification value id")]
        public int ClassificationValueId { get; set; }
        [Display(Name = "Classification language id")]
        public int LanguageId { get; set; }
        [Display(Name = "Classification value name")]
        public string Name { get; set; }
        [Display(Name = "Classification value description")]
        public string Description { get; set; }
        [MaxLength(50)]
        [Display(Name = "Classification value menu name")]
        public string MenuName { get; set; }
        [MaxLength(50)]
        [Display(Name = "Classification value mouse over")]
        public string MouseOver { get; set; }
        [Display(Name = "Classification value drop down name")]
        public string DropDownName { get; set; }
        [Display(Name = "Classification value page name")]
        public string PageName { get; set; }
        [Display(Name = "Classification value page description")]
        public string PageDescription { get; set; }
        [Display(Name = "Classification value header name")]
        public string HeaderName { get; set; }
        [Display(Name = "Classification value header description")]
        public string HeaderDescription { get; set; }
        [Display(Name = "Classification value topic name")]
        public string TopicName { get; set; }
        public string CreatorId { get; set; }
        public string ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("ClassificationValueId")]
        public virtual SuClassificationValueModel ClassificationValue { get; set; }
        [ForeignKey("LanguageId")]
        public virtual SuLanguageModel Language { get; set; }
    }
}
