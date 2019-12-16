using StudentUnion0105.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuClassificationPageSectionModel
    {
        private readonly SuDbContext context;

        public SuClassificationPageSectionModel(SuDbContext context)
        {
            this.context = context;
        }

        public int Id { get; set; }
        [Display(Name = "Classification page id")]
        public int ClassificationPageId { get; set; }
        public int Sequence { get; set; }
        [Display(Name = "Classification page section type id")]
        public int SectionTypeId { get; set; }
        [Display(Name = "Show section title")]
        public bool ShowSectionTitleName { get; set; }
        [Display(Name = "Show section title description")]
        public bool ShowSectionTitleDescription { get; set; }
        [Display(Name = "Show content type title")]
        public bool ShowContentTypeTitleName { get; set; }
        [Display(Name = "Show content type title description")]
        public bool ShowContentTypeTitleDescription { get; set; }
        [Display(Name = "One two columns")]
        public int OneTwoColumns { get; set; }
        [Display(Name = "Content type id")]
        public int? ContentTypeId { get; set; }
        [Display(Name = "Sort by id")]
        public int SortById { get; set; }
        [Display(Name = "Max content")]
        public int MaxContent { get; set; }
        [Display(Name = "Has paging")]
        public bool HasPaging { get; set; }
        [ForeignKey("ClassificationPageId")]
        public virtual SuClassificationPageModel ClassificationPage { get; set; }
        [ForeignKey("SectionTypeId")]
        public virtual SuPageSectionTypeModel PageSectionType { get; set; }
        [ForeignKey("ContentTypeId")]
        public virtual SuContentTypeModel ContentType { get; set; }

        public virtual ICollection<SuClassificationPageSectionLanguageModel> ClassificationPageSectionLanguages { get; set; }



    }
}
