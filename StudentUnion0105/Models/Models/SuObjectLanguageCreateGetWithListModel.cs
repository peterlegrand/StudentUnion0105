using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuObjectLanguageCreateGetWithListModel
    {
        public SuObjectLanguageCreateGetModel ObjectLanguage { get; set; }

        public List<SelectListItem> LanguageList { get; set; }
    }
}