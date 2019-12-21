using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuPageSectionEditGetModel
    {
        [Key]
        public int OId { get; set; }
        public int ContentTypeId { get; set; }
        public bool HasPaging { get; set; }
        public bool MaxContent { get; set; }
        public int OneTwoColumns { get; set; }
        public int PageSectionTypeId { get; set; }
        public int Sequence { get; set; }
        public bool ShowContentTypeTitle { get; set; }
        public bool ShowContentTypeDescription { get; set; }
        public bool ShowSectionTitleName { get; set; }
        public bool ShowSectionTitleDescription { get; set; }
        public int SortById { get; set; }
        public string Creator { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Modifier { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int LId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MouseOver { get; set; }
        public string MenuName { get; set; }
        public string titleName { get; set; }
        public string TitleDescription { get; set; }
    }
}
