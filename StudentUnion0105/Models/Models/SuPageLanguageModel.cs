using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Models
{
    public class SuPageLanguageModel
    {
        public int Id { get; set; }
        public int PageId { get; set; }
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MouseOver { get; set; }
        public string PageTitle { get; set; }
        public string PageDescription { get; set; }
        public Guid CreatorId { get; set; }
        public Guid ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual SuPageModel Page { get; set; }
        public virtual SuLanguageModel Language { get; set; }

    }
}
