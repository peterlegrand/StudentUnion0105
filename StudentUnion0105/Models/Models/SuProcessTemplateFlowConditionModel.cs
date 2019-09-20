using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Models.Models
{
    public class ProcessTemplateFlowCondition
    {
        public int Id { get; set; }
        public int ProcessTemplateFlowId { get; set; }
        public int ProcessTemplateFieldId { get; set; }
        public int ProcessTemplateConditionTypeId { get; set; }
        public string ProcessTemplateFlowConditionString { get; set; }
        public int ProcessTemplateFlowConditionInt { get; set; }
        public DateTime ProcessTemplateFlowConditionDate { get; set; }

    }
}
