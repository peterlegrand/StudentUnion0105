using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuProcessTemplateFieldEditGetWithListModel
    {
        public SuProcessTemplateFieldEditGetModel ProcessTemplateField { get; set; }

        public List<SelectListItem> FieldTypeList { get; set; }
    }
}