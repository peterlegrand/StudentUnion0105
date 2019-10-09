using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuClassificationValueLanguageModel
    {
        public int Id { get; set; }
        [Display(Name = "Classification value id")]
        public int ClassificationValueId { get; set; }
        [Display(Name = "Classification language id")]
        public int LanguageId { get; set; }
        [Display(Name = "Classification value name")]
        [MaxLength(50)]
        public string ClassificationValueName { get; set; }
        [Display(Name = "Classification value description")]
        public string ClassificationValueDescription { get; set; }
        [Display(Name = "Classification value drop down name")]
        [MaxLength(50)]
        public string ClassificationValueDropDownName { get; set; }
        [Display(Name = "Classification value menu name")]
        [MaxLength(50)]
        public string ClassificationValueMenuName { get; set; }
        [Display(Name = "Classification value mouse over")]
        [MaxLength(50)]
        public string ClassificationValueMouseOver { get; set; }
        [Display(Name = "Classification value page name")]
        [MaxLength(50)]
        public string ClassificationValuePageName { get; set; }
        [Display(Name = "Classification value page description")]
        public string ClassificationValuePageDescription { get; set; }
        [Display(Name = "Classification value header name")]
        [MaxLength(50)]
        public string ClassificationValueHeaderName { get; set; }
        [Display(Name = "Classification value header description")]
        public string ClassificationValueHeaderDescription { get; set; }
        [Display(Name = "Classification value topic name")]
        [MaxLength(50)]
        public string ClassificationValueTopicName { get; set; }
        public Guid CreatorId { get; set; }
        public Guid ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("ClassificationValueId")]
        public virtual SuClassificationValueModel ClassificationValue { get; set; }
        [ForeignKey("LanguageId")]
        public virtual SuLanguageModel Language { get; set; }
    }
}
