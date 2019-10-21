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
