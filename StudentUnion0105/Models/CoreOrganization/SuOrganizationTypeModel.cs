using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuOrganizationTypeModel
    {
        public int Id { get; set; }
        public string CreatorId { get; set; }
        public string ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<SuOrganizationModel> Organizations { get; set; }
        public virtual ICollection<SuOrganizationTypeLanguageModel> OrganizationTypeLanguages { get; set; }

    }
    public class SuOrganizationTypeLanguageModel
    {
        public int Id { get; set; }
        [Display(Name = "Organization type id")]
        public int OrganizationTypeId { get; set; }
        [Display(Name = "Language Id")]
        public int LanguageId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Mouse over")]
        [MaxLength(50)]
        public string MouseOver { get; set; }
        [MaxLength(50)]
        [Display(Name = "Menu name")]
        public string MenuName { get; set; }
        public string CreatorId { get; set; }
        public string ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("OrganizationTypeId")]
        public virtual SuOrganizationTypeModel OrganizationType { get; set; }
        [ForeignKey("LanguageId")]
        public virtual SuLanguageModel Language { get; set; }

    }
}
