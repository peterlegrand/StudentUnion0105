using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Models
{
    public class SuPageSectionTypeModel
    {
        public int Id { get; set; }
        public Guid CreatorId { get; set; }
        public Guid ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IndexSection { get; set; }

        public virtual ICollection<SuPageSectionModel> PageSections { get; set; }
        public virtual ICollection<SuPageSectionTypeLanguageModel> PageSectionTypeLanguages { get; set; }

    }
}
