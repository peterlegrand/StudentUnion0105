using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Models
{
    public class SuOrganizationStatusModel
    {
        public int Id { get; set; }
        public string OrganizationStatusName { get; set; }
        public virtual ICollection<SuOrganizationModel> Organization { get; set; }

    }
}
