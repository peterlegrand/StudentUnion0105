﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Models
{
    public class SuClassificationValueModel
    {
        public int Id { get; set; }
      public int ClassificationLevelId { get; set; }
        public int ParentValueId { get; set; }
        public DateTimeOffset DateFrom { get; set; }
        public DateTimeOffset DateTo { get; set; }
        public Guid CreatorId { get; set; }
        public Guid ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual SuClassificationLevelModel ClassificationLevel { get; set; }
        public virtual ICollection<SuClassificationValueLanguageModel> ClassificationValueLanguages { get; set; }
    }
    //        public virtual SuClassificationModel Classification { get; set; }

    //      public int ClassificationId { get; set; }

}
