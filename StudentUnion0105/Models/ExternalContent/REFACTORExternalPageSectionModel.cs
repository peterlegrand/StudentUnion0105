using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuExternalPageSectionModel
    {
        [Key]
        public int OId { get; set; }
        public int PId { get; set; }
        public int Sequence { get; set; }
        public int OneTwoColumns { get; set; }
        public bool ShowSectionTitleName { get; set; }
        public bool ShowSectionTitleDescription { get; set; }
        public bool ShowContentTypeTitle { get; set; }
        public bool ShowContentTypeDescription { get; set; }
        public string ContentTitleName { get; set; }
        public string ContentTitleDescription { get; set; }
        public int MaxContent { get; set; }
        public bool HasPaging { get; set; }
        public int LId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MouseOver { get; set; }
        public string MenuName { get; set; }
        public string TitleName { get; set; }
        public string TitleDescription { get; set; }
        [ForeignKey("PId")]
        public virtual SuExternalPageModel ExternalPage { get; set; }
        public virtual ICollection<SuExternalContentModel> ExternalContent { get; set; }
    }
}
