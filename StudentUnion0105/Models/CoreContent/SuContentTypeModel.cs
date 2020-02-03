using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuContentTypeModel
    {
        public int Id { get; set; }
        public int ContentTypeGroupId { get; set; }

        public int ProcessTemplateId { get; set; }
        public string CreatorId { get; set; }
        public string ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<SuContentTypeLanguageModel> ContentTypeLanguages { get; set; }
        public virtual ICollection<SuContentModel> Contents { get; set; }
        public virtual ICollection<SuContentTypeClassificationModel> ContentTypeClassification { get; set; }
        [ForeignKey("ContentTypeGroupId")]
        public virtual SuContentTypeGroupModel ContentTypeGroup { get; set; }
    }
    public class SuContentTypeLanguageModel
    {
        public int Id { get; set; }
        public int ContentTypeId { get; set; }
        public int LanguageId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        [MaxLength(50)]
        public string MenuName { get; set; }
        [MaxLength(50)]
        public string MouseOver { get; set; }
        public string TitleName { get; set; }
        public string TitleDescription { get; set; }
        public string CreatorId { get; set; }
        public string ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("ContentTypeId")]
        public virtual SuContentTypeModel ContentType { get; set; }
        [ForeignKey("LanguageId")]
        public virtual SuLanguageModel Language { get; set; }

    }

    public class SuContentTypeClassificationModel
    {
        public int Id { get; set; }
        public int ContentTypeId { get; set; }
        public int ClassificationId { get; set; }
        public int StatusId { get; set; }
        [ForeignKey("ContentTypeId")]
        public virtual SuContentTypeModel ContentType { get; set; }
        [ForeignKey("ClassificationId")]
        public virtual SuClassificationModel Classification { get; set; }
        [ForeignKey("StatusId")]
        public virtual SuContentTypeClassificationStatusModel Status { get; set; }


    }

    public class SuContentTypeClassificationStatusModel
    {
        public int Id { get; set; }

        public virtual ICollection<SuContentTypeClassificationModel> ContentTypeClassification { get; set; }
        public virtual ICollection<SuContentTypeClassificationStatusLanguageModel> SuContentTypeClassificationStatusLanguageModel { get; set; }

    }
    public class SuContentTypeClassificationStatusLanguageModel
    {
        public int Id { get; set; }
        [Display(Name = "Content type id")]
        public int ContentTypeClassificationStatusId { get; set; }
        [Display(Name = "Content type language id")]
        public int LanguageId { get; set; }
        [Display(Name = "Content type name")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Display(Name = "Content type description")]
        public string Description { get; set; }
        [MaxLength(50)]
        [Display(Name = "Menu name")]
        public string MenuName { get; set; }
        [Display(Name = "Content type mouse over")]
        [MaxLength(50)]
        public string MouseOver { get; set; }
        public string CreatorId { get; set; }
        public string ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("ContentTypeClassificationStatusId")]
        public virtual SuContentTypeClassificationStatusModel ContentTypeClassificationStatus { get; set; }
        [ForeignKey("LanguageId")]
        public virtual SuLanguageModel Language { get; set; }
        


    }

}
