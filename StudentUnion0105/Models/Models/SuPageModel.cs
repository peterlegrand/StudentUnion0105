using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Models
{
    public class SuPageModel
    {
        public int Id { get; set; }
        public int PageStatusId { get; set; }
        public int PageTypeId { get; set; }
        public Guid CreatorId { get; set; }
        public Guid ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("PageStatusId")]
        public virtual SuPageStatusModel PageStatus { get; set; }
        [ForeignKey("PageTypeId")]
        public virtual SuPageTypeModel PageType { get; set; }
        public virtual ICollection<SuPageLanguageModel> PageLanguages { get; set; }
        public virtual ICollection<SuPageSectionModel> PageSections { get; set; }

    }
}
