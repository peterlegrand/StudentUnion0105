using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuClassificationModel
    {
        public int Id { get; set; }
        public int ClassificationStatusId { get; set; }
        public int DefaultClassificationPageId { get; set; }
        public bool HasDropDown { get; set; }
        public int DropDownSequence { get; set; }
        public Guid CreatorId { get; set; }
        public Guid ModifierId { get; set; }
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
