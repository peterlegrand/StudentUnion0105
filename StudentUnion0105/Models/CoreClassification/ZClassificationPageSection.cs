using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuClassificationPageSectionDeleteGetModel
    {
        [Key]
        public int OId { get; set; }
        public int PId { get; set; }
        public int Sequence { get; set; }
        public string SectionTypeName { get; set; }
        public bool ShowSectionTitleName { get; set; }
        public bool ShowSectionTitleDescription { get; set; }
        public bool ShowContentTypeTitleName { get; set; }
        public bool ShowContentTypeTitleDescription { get; set; }
        public int OneTwoColumns { get; set; }
        public string ContentTypeName { get; set; }
        public int SortById { get; set; }
        public int MaxContent { get; set; }
        public bool HasPaging { get; set; }
        public int LId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MouseOver { get; set; }
        public string MenuName { get; set; }
        public string TitleName { get; set; }
        public string TitleDescription { get; set; }
        public string Creator { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Modifier { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
    public class SuClassificationPageSectionEditGetModel
    {
        [Key]
        public int OId { get; set; }
        public int PId { get; set; }
        public int Sequence { get; set; }
        public int SectionTypeId { get; set; }
        public bool ShowSectionTitleName { get; set; }
        public bool ShowSectionTitleDescription { get; set; }
        public bool ShowContentTypeTitleName { get; set; }
        public bool ShowContentTypeTitleDescription { get; set; }
        public int OneTwoColumns { get; set; }
        public int ContentTypeId { get; set; }
        public int SortById { get; set; }
        public int MaxContent { get; set; }
        public bool HasPaging { get; set; }
        public int LId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MouseOver { get; set; }
        public string MenuName { get; set; }
        public string TitleName { get; set; }
        public string TitleDescription { get; set; }
        public string Creator { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Modifier { get; set; }
        public DateTime ModifiedDate { get; set; }
    }


    public class SuClassificationPageSectionEditGetWithListModel
    {
        public SuClassificationPageSectionEditGetModel ClassificationPageSection { get; set; }
        public List<SelectListItem> ContentTypeList { get; set; }
        public List<SelectListItem> SectionTypeList { get; set; }
    }

    public class SuClassificationPageSectionLanguageCreateGetModel
    {
        public int OId { get; set; }
        public int LanguageId { get; set; }
        [Key]
        public int LId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string MouseOver { get; set; }
        [Required]
        public string MenuName { get; set; }
        public string TitleName { get; set; }
        public string TitleDescription { get; set; }

    }
    public class SuClassificationPageSectionLanguageCreateGetWithListModel
    {
        public SuClassificationPageSectionLanguageCreateGetModel ObjectLanguage { get; set; }

        public List<SelectListItem> LanguageList { get; set; }

    }

    public class SuClassificationPageSectionLanguageEditGetModel
    {
        public int OId { get; set; }
        public string Creator { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Modifier { get; set; }
        public DateTime ModifiedDate { get; set; }
        [Key]
        public int LId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MouseOver { get; set; }
        public string MenuName { get; set; }
        public string Language { get; set; }
        public string TitleName { get; set; }
        public string TitleDescription { get; set; }

    }
}
