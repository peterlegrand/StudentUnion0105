using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuFrontProcessIndexGetTemplateFlowConditionModel
    {
        [Key]
        public int OId { get; set; }
        public int ConditionTypeId { get; set; }
        public int ComparisonOperatorId { get; set; }
        public string ConditionString { get; set; }
        public int ConditionInt { get; set; }
    }
}
