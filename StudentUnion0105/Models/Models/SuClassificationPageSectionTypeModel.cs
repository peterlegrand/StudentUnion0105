﻿using System;
using System.Collections.Generic;

namespace StudentUnion0105.Models
{
    public class SuClassificationPageSectionTypeModel
    {
        public int Id { get; set; }
        public Guid CreatorId { get; set; }
        public Guid ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<SuClassificationPageSectionModel> ClassificationPageSections { get; set; }
        public virtual ICollection<SuClassificationPageSectionTypeLanguageModel> ClassificationPageSectionTypeLanguages { get; set; }

    }
}
