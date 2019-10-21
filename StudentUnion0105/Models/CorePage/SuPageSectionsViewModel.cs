using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuPageSectionsViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Page id")]
        public int PageId { get; set; }
        [Display(Name = "Show section title")]
        public bool ShowSectionTitle { get; set; }
        [Display(Name = "Show title description")]
        public bool ShowSectionTitleDescription { get; set; }
        [Display(Name = "Show content type title")]
        public bool ShowContentTypeTitle { get; set; }
        [Display(Name = "Show content type title desciption")]
        public bool ShowContentTypeDescription { get; set; }
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
        [Display(Name = "Page section title")]
        [MaxLength(50)]
        public string Title { get; set; }
        [Display(Name = "Show section title description")]
        public string Description { get; set; }
        [Display(Name = "Index section")]
        public bool IndexSection { get; set; }
    }
}
