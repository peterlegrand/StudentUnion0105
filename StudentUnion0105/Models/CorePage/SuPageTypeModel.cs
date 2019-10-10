using System;
using System.Collections.Generic;

namespace StudentUnion0105.Models
{
    public class SuPageTypeModel
    {
        public int Id { get; set; }
        public Guid CreatorId { get; set; }
        public Guid ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<SuPageModel> Pages { get; set; }
        public virtual ICollection<SuPageTypeLanguageModel> PageTypeLanguages { get; set; }

    }
}
