using System;
using System.Collections.Generic;

namespace StudentUnion0105.Models
{
    public class SuPageSectionTypeModel
    {
        public int Id { get; set; }
        public bool IndexSection { get; set; }
        public string CreatorId { get; set; }
        public string ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<SuPageSectionModel> PageSections { get; set; }
        public virtual ICollection<SuPageSectionTypeLanguageModel> PageSectionTypeLanguages { get; set; }

    }
}
