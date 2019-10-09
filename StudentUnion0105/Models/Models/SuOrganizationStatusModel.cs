using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuOrganizationStatusModel
    {
        public int Id { get; set; }
        [Display(Name = "Organization status name")]
        [MaxLength(50)]
        public string OrganizationStatusName { get; set; }
        public virtual ICollection<SuOrganizationModel> Organization { get; set; }

    }
}
