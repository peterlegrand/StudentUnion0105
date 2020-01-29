using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuObjectLanguageEditGetModel
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
        public int LanguageId { get; set; }

    }

    public class SuContentTypeLanguageEditGetModel : SuObjectLanguageEditGetModel
    {
        public string TitleName { get; set; }
        public string TitleDesciption { get; set; }
    }

    public class SuObjectLanguageEditGetWitLanguageListModel
    {
        public SuObjectLanguageEditGetModel SuObject { get; set; }
        //public List<SuClassificationStatusModel> Status { get; set; }
        public IEnumerable<SelectListItem> LanguageList { get; set; }
    }
    public class SuContentTypeLanguageEditGetWitLanguageListModel
    {
        public SuContentTypeLanguageEditGetModel ContentType { get; set; }
        //public List<SuClassificationStatusModel> Status { get; set; }
        public IEnumerable<SelectListItem> LanguageList { get; set; }
    }
}