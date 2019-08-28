using System;
using System.Collections.Generic;

namespace StudentUnion0105.Models
{
    public class SuClassificationLevelModel
    {
        public int Id { get; set; }
        public int ClassificationId { get; set; }
        public int Sequence { get; set; }
        public bool DateLevel { get; set; }
        public bool OnTheFly { get; set; }
        public bool Alphabetically { get; set; }
        public bool CanLink { get; set; }
        public bool InDropDown { get; set; }
        public Guid CreatorId { get; set; }
        public Guid ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual SuClassificationModel Classification { get; set; }
        public virtual ICollection<SuClassificationLevelLanguageModel> ClassificationLevelLanguages { get; set; }
        public virtual ICollection<SuClassificationValueModel> ClassificationValues { get; set; } 
    }
}
