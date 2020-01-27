using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuOrganizationModel
    {
        public int Id { get; set; }
        [Display(Name = "Parent organization id")]
        public int? ParentOrganizationId { get; set; }
        [Display(Name = "Organization status id")]
        public int OrganizationStatusId { get; set; }
        [Display(Name = "Organization type id")]
        public int OrganizationTypeId { get; set; }
        public string CreatorId { get; set; }
        public string ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("ParentOrganizationId")]
        public virtual SuOrganizationModel ParentOrganization { get; set; }
        [ForeignKey("OrganizationStatusId")]
        public virtual SuOrganizationStatusModel OrganizationStatus { get; set; }
        [ForeignKey("OrganizationTypeId")]
        public virtual SuOrganizationTypeModel OrganizationType { get; set; }
        public virtual ICollection<SuOrganizationLanguageModel> OrganizationLanguages { get; set; }
        public virtual ICollection<SuOrganizationModel> ChildOrganizations { get; set; }

    }
    public class SuOrganizationLanguageModel
    {
        public int Id { get; set; }
        [Display(Name = "Organization id")]
        public int OrganizationId { get; set; }
        [Display(Name = "Language id")]
        public int LanguageId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        [MaxLength(50)]
        public string MouseOver { get; set; }
        [MaxLength(50)]
        [Display(Name = "Menu name")]
        public string MenuName { get; set; }
        public string CreatorId { get; set; }
        public string ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("OrganizationId")]
        public virtual SuOrganizationModel Organization { get; set; }
        [ForeignKey("LanguageId")]
        public virtual SuLanguageModel Language { get; set; }

    }
}
