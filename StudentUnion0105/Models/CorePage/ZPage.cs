using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuPageDeleteGetModel
    {
        public int Id { get; set; }
        public string Creator { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Modifier { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int LId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MouseOver { get; set; }
        public string MenuName { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string TitleName { get; set; }
        public string TitleDescription { get; set; }
        public bool ShowTitleName { get; set; }
        public bool ShowTitleDescription { get; set; }

    }
    public class SuPageEditGetModel
    {
        public int Id { get; set; }
        public int PageStatusId { get; set; }
        public int PageTypeId { get; set; }
        public bool ShowTitleName { get; set; }
        public bool ShowTitleDescription { get; set; }
        public int Lid { get; set; }
        public int LanguageId { get; set; }
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
        public string Creator { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Modifier { get; set; }
        public DateTime ModifiedDate { get; set; }


    }
    public class SuPageEditGetWithListModel
    {
        public SuPageEditGetModel Page { get; set; }
        public List<SelectListItem> StatusList { get; set; }
        public List<SelectListItem> TypeList { get; set; }

    }

    public class SuPageLanguageEditGetModel
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
