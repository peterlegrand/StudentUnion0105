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
    }
}
