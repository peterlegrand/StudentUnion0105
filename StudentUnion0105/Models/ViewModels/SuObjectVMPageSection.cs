using StudentUnion0105.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.ViewModels
{
    public class SuObjectVMPageSection : SuObjectVM
    {
        [Display(Name = "Show title")]
        public bool ShowSectionTitle { get; set; }
        [Display(Name = "Show description")]
        public bool ShowSectionDescription { get; set; }
        [Display(Name = "Show content type title")]
        public bool ShowContentTypeTitle { get; set; }
        [Display(Name = "Show content type description")]
        public bool ShowContentTypeTitleDescription { get; set; }
        [Display(Name = "Title")]
        public string PageSectionTitle { get; set; }
        [Display(Name = "Description")]
        public string PageSectionTitleDescription { get; set; }
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

    }
}
