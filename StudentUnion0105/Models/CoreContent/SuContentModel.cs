using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuContentModel
    {
        public int Id { get; set; }
        [Display(Name = "Content type id")]
        public int ContentTypeId { get; set; }
        [Display(Name = "Content status id")]
        public int ContentStatusId { get; set; }
        [Display(Name = "Content language id")]
        public int LanguageId { get; set; }
        [Display(Name = "Content title")]
        [MaxLength(50)]
        public string Title { get; set; }
        [Display(Name = "Content description")]
        public string Description { get; set; }
        [Display(Name = "content security level")]
        public int SecurityLevel { get; set; }
        [Display(Name = "Content organization id")]
        public int OrganizationId { get; set; }
        [Display(Name = "Content project id")]
        public int? ProjectId { get; set; }
        public Guid? CreatorId { get; set; }
        public Guid? ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("ContentTypeId")]
        public virtual SuContentTypeModel ContentType { get; set; }
        [ForeignKey("ContentStatusId")]
        public virtual SuContentStatusModel ContentStatus { get; set; }
        [ForeignKey("LanguageId")]
        public virtual SuLanguageModel Language { get; set; }
        [ForeignKey("OrganizationId")]
        public virtual SuOrganizationModel Organizaton { get; set; }
        [ForeignKey("ProjectId")]
        public virtual SuProjectModel Project { get; set; }
        [ForeignKey("SecurityLevel")]
        public virtual SuSecurityLevelModel SecurityLevelObject { get; set; }
        public virtual ICollection<SuContentClassificationValueModel> ContentClassificationValues { get; set; }
    }
}
