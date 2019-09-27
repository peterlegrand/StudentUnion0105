namespace StudentUnion0105.Models
{
    public class SuPageSectionsViewModel
    {
        public int Id { get; set; }
        public int PageId { get; set; }
        public bool ShowSectionTitle { get; set; }
        public bool ShowSectionTitleDescription { get; set; }
        public bool ShowContentTypeTitle { get; set; }
        public bool ShowContentTypeDescription { get; set; }
        public int OneTwoColumns { get; set; }
        public int? ContentTypeId { get; set; }
        public int SortById { get; set; }
        public int MaxContent { get; set; }
        public bool HasPaging { get; set; }
        public string PageSectionTitle { get; set; }
        public string PageSectionDescription { get; set; }
        public bool IndexSection { get; set; }
    }
}
