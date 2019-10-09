using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuPageSectionModel
    {
        public int Id { get; set; }
        [Display(Name = "Page Id")]
        public int PageId { get; set; }
        public int Sequence { get; set; }
        [Display(Name = "Type")]
        public int PageSectionTypeId { get; set; }
        [Display(Name = "Show section title")]
        [MaxLength(50)]
        public bool ShowSectionTitle { get; set; }
        [Display(Name = "Show section description")]
        public bool ShowSectionTitleDescription { get; set; }
        [Display(Name = "Show content type title")]
        [MaxLength(50)]
        public bool ShowContentTypeTitle { get; set; }
        [Display(Name = "Show content type description")]
        public bool ShowContentTypeDescription { get; set; }
        [Display(Name = "1 or 2 columns")]
        public int OneTwoColumns { get; set; }
        [Display(Name = "Content type")]
        public int? ContentTypeId { get; set; }
        [Display(Name = "Sort by")]
        public int SortById { get; set; }
        [Display(Name = "Max. content")]
        public int MaxContent { get; set; }
        [Display(Name = "Has paging")]
        public bool HasPaging { get; set; }
        [ForeignKey("PageId")]
        public virtual SuPageModel Page { get; set; }
        [ForeignKey("PageSectionTypeId")]
        public virtual SuPageSectionTypeModel PageSectionType { get; set; }
        [ForeignKey("ContentTypeId")]
        public virtual SuContentTypeModel ContentType { get; set; }

        public virtual ICollection<SuPageSectionLanguageModel> PageSectionLanguages { get; set; }



    }
}
