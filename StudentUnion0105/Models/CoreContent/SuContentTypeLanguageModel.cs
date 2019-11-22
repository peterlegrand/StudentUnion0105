using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuContentTypeLanguageModel
    {
        public int Id { get; set; }
        [Display(Name = "Content type id")]
        public int ContentTypeId { get; set; }
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
        public string TitleName { get; set; }
        public string TitleDescription { get; set; }
        public Guid CreatorId { get; set; }
        public Guid ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("ContentTypeId")]
        public virtual SuContentTypeModel ContentType { get; set; }
        [ForeignKey("LanguageId")]
        public virtual SuLanguageModel Language { get; set; }

    }
}
