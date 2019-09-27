using System.Collections.Generic;

namespace StudentUnion0105.Models
{
    public class SuOrganizationStatusModel
    {
        public int Id { get; set; }
        public string OrganizationStatusName { get; set; }
        public virtual ICollection<SuOrganizationModel> Organization { get; set; }

    }
}
