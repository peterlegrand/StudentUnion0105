using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuProcessTemplateFlowConditionEditGetModel
    {
        [Key]
        public int OId { get; set; }
        public int ProcessTemplateConditionTypeId { get; set; }
        public int? ComparisonOperatorId { get; set; }
        public int? ProcessTemplateFieldId { get; set; }
        public int? DataTypeId { get; set; }
        public int LId { get; set; }
        public int LanguageId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string MouseOver { get; set; }
        [Required]
        public string MenuName { get; set; }
        public string Creator { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Modifier { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime ProcessTemplateFlowConditionDate { get; set; }
        public int? ProcessTemplateFlowConditionInt { get; set; }
        public String ProcessTemplateFlowConditionString { get; set; }

    }
    public class SuProcessTemplateFlowConditionEditGetWithListModel
    {
        public SuProcessTemplateFlowConditionEditGetModel Condition { get; set; }
        public List<SelectListItem> ConditionTypeList { get; set; }
        public List<SelectListItem> ComparisonList { get; set; }
        public List<SelectListItem> FieldList { get; set; }
        public List<SelectListItem> DataTypeList { get; set; }

    }
}
