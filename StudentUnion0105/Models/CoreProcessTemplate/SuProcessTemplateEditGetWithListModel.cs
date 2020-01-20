using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuProcessTemplateEditGetWithListModel
    {
        public SuProcessTemplateEditGetModel ProcessTemplate { get; set; }
        public List<SelectListItem> GroupList { get; set; }

    }
}
