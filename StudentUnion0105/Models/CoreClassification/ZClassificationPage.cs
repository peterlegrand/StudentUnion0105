using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuClassificationPageDeleteGetModel
    {
        [Key]
        public int OId { get; set; }
        public int PId { get; set; }
        public int Status { get; set; }
        public bool ShowTitleName { get; set; }
        public bool ShowTitleDescription { get; set; }
        public string Creator { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Modifier { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int LId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MouseOver { get; set; }
        public string MenuName { get; set; }
        public string TitleName { get; set; }
        public string TitleDescription { get; set; }
    }

    public class SuClassificationPageEditGetModel
    {
        [Key]
        public int OId { get; set; }
        public int PId { get; set; }
        public int StatusId { get; set; }
        public bool ShowTitleName { get; set; }
        public bool ShowTitleDescription { get; set; }
        public string Creator { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Modifier { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int LId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MouseOver { get; set; }
        public string MenuName { get; set; }
        public string TitleName { get; set; }
        public string TitleDescription { get; set; }
    }

    public class SuClassificationPageEditGetWithListModel
    {
        public SuClassificationPageEditGetModel ClassificationPage { get; set; }
        public List<SelectListItem> StatusList { get; set; }
    }

    public class SuClassificationPageLanguageCreateGetModel
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

    public class SuClassificationPageLanguageCreateGetWithListModel
    {
        public SuClassificationPageLanguageCreateGetModel ObjectLanguage { get; set; }

        public List<SelectListItem> LanguageList { get; set; }

    }

    public class SuClassificationPageLanguageEditGetModel
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
