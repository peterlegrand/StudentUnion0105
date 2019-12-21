using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuUserRelationTypeLanguageCreateGetWithListModel
    {
        public SuUserRelationTypeLanguageCreateGetModel UserRelationType { get; set; }

        public List<SelectListItem> LanguageList { get; set; }
    }
}