using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Models
{
    public class SuOrganizationTypeLanguageModel
    {
        public int Id { get; set; }
        public int OrganizationTypeId { get; set; }
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MouseOver { get; set; }
        public Guid CreatorId { get; set; }
        public Guid ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual SuOrganizationTypeModel OrganizationType { get; set; }
        public virtual SuLanguageModel Language { get; set; }
        
    }
}
