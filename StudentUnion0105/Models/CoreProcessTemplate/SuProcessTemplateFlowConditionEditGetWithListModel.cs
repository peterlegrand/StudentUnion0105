using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuProcessTemplateFlowConditionEditGetWithListModel
    {
        public SuProcessTemplateFlowConditionEditGetModel Condition { get; set; }
        public List<SelectListItem> ConditionTypeList { get; set; }
        public List<SelectListItem> ComparisonList { get; set; }
        public List<SelectListItem> FieldList { get; set; }
        public List<SelectListItem> DataTypeList { get; set; }

    }
}
