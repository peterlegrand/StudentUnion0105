using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuClassificationValueModel
    {
        public int Id { get; set; }
        //        [Display(Name="SuClassificationLevelModel")]
        public virtual int ClassificationId { get; set; }
        public int? ParentValueId { get; set; }
        public DateTimeOffset? DateFrom { get; set; }
        public DateTimeOffset? DateTo { get; set; }
        public Guid CreatorId { get; set; }
        public Guid ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("ClassificationId")]
        public virtual SuClassificationModel Classification { get; set; }
        public virtual ICollection<SuClassificationValueLanguageModel> ClassificationValueLanguages { get; set; }
    }

}
