using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
