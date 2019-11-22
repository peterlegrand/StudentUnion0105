using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuProcessTemplateFlowConditionModel
    {
        public int Id { get; set; }
        [Display(Name = "Process template flow id")]
        public int ProcessTemplateFlowId { get; set; }
        //[Display(Name = "Condition character")]
        //[MaxLength(1)]
        //public string ConditionCharacter { get; set; }
        //[Display(Name = "Condition type id")]
        public int ProcessTemplateConditionTypeId { get; set; }
        [Display(Name = "Field id")]
        public int? ProcessTemplateFieldId { get; set; }
        [Display(Name = "Comparison operator")]
        public int? ComparisonOperatorId { get; set; }
        public int? DataTypeId { get; set; }
        [Display(Name = "Condition string")]
        public string ProcessTemplateFlowConditionString { get; set; }
        [Display(Name = "Condition int")]
        public int? ProcessTemplateFlowConditionInt { get; set; }
        [Display(Name = "Condition date")]
        public DateTime? ProcessTemplateFlowConditionDate { get; set; }
        [ForeignKey("ProcessTemplateFlowId")]
        public virtual SuProcessTemplateFlowModel ProcessTemplateFlow { get; set; }
        [ForeignKey("ProcessTemplateConditionTypeId")]
        public virtual SuProcessTemplateFlowConditionTypeModel ProcessTemplateFlowConditionType { get; set; }
        public virtual ICollection<SuProcessTemplateFlowConditionLanguageModel> ProcessTemplateFlowConditionLanguages { get; set; }

    }
}
