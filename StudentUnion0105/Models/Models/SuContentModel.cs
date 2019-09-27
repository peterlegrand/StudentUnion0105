using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuContentModel
    {
        public int Id { get; set; }
        public int ContentTypeId { get; set; }
        public int ContentStatusId { get; set; }
        public int LanguageId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int SecurityLevel { get; set; }
        public int OrganizationId { get; set; }
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
