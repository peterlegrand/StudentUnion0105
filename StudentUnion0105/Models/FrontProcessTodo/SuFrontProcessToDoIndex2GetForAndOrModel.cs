using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuFrontProcessToDoIndex2GetForAndOrModel
    {
        public int FlowId { get; set; }
        [Key]
        public int ConditionId { get; set; }
        public int ConditionTypeId { get; set; }
        public int ConditionFieldId { get; set; }
        public int ComparisonOperatorId { get; set; }
        public string ConditionString { get; set; }
        public int ConditionInt { get; set; }
        public DateTime ConditionDate { get; set; }


    }
}
