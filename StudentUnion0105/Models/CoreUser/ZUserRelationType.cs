using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuUserRelationTypeIndexGetModel
    {
        [Key]
        public int OId { get; set; }
        public string FromIsOfToName { get; set; }
        public string ToIsOfFromName { get; set; }
        public string FromIsOfToDescription { get; set; }
        public string ToIsOfFromDescription { get; set; }
        public string FromIsOfToMouseOver { get; set; }
        public string ToIsOfFromMouseOver { get; set; }
        public string FromIsOfToMenuName { get; set; }
        public string ToIsOfFromMenuName { get; set; }
    }
    public class SuUserRelationTypeLanguageCreateGetModel
    {
        public int OId { get; set; }
        public int LanguageId { get; set; }
        [Key]
        public int LId { get; set; }
        public string FromIsOfToName { get; set; }
        public string ToIsOfFromName { get; set; }
        [Required]
        public string FromIsOfToDescription { get; set; }
        [Required]
        public string ToIsOfFromDescription { get; set; }
        public string FromIsOfToMouseOver { get; set; }
        [Required]
        public string ToIsOfFromMouseOver { get; set; }
        [Required]
        public string FromIsOfToMenuName { get; set; }
        [Required]
        public string ToIsOfFromMenuName { get; set; }
    }
    public class SuUserRelationTypeLanguageCreateGetWithListModel
    {
        public SuUserRelationTypeLanguageCreateGetModel UserRelationType { get; set; }

        public List<SelectListItem> LanguageList { get; set; }
    }
    public class SuUserRelationTypeLanguageDeleteGetModel
    {
        [Key]
        public int LId { get; set; }
        public string FromIsOfToName { get; set; }
        public string ToIsOfFromName { get; set; }
        [Required]
        public string FromIsOfToDescription { get; set; }
        [Required]
        public string ToIsOfFromDescription { get; set; }
        public string FromIsOfToMouseOver { get; set; }
        [Required]
        public string ToIsOfFromMouseOver { get; set; }
        [Required]
        public string FromIsOfToMenuName { get; set; }
        [Required]
        public string ToIsOfFromMenuName { get; set; }
        public string Language { get; set; }
        public string Creator { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Modifier { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
    public class SuUserRelationTypeLanguageEditGetModel
    {
        public int OId { get; set; }
        public string Creator { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Modifier { get; set; }
        public DateTime ModifiedDate { get; set; }
        [Key]
        public int LId { get; set; }
        public string FromIsOfToName { get; set; }
        public string ToIsOfFromName { get; set; }
        [Required]
        public string FromIsOfToDescription { get; set; }
        [Required]
        public string ToIsOfFromDescription { get; set; }
        public string FromIsOfToMouseOver { get; set; }
        [Required]
        public string ToIsOfFromMouseOver { get; set; }
        [Required]
        public string FromIsOfToMenuName { get; set; }
        [Required]
        public string ToIsOfFromMenuName { get; set; }
        public string Language { get; set; }
    }
    public class SuUserRelationTypeLanguageIndexGetModel
    {
        public int OId { get; set; }
        [Key]
        public int LId { get; set; }
        public string FromIsOfToName { get; set; }
        public string ToIsOfFromName { get; set; }
        [Required]
        public string FromIsOfToDescription { get; set; }
        [Required]
        public string ToIsOfFromDescription { get; set; }
        public string FromIsOfToMouseOver { get; set; }
        [Required]
        public string ToIsOfFromMouseOver { get; set; }
        [Required]
        public string FromIsOfToMenuName { get; set; }
        [Required]
        public string ToIsOfFromMenuName { get; set; }
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
    }
}