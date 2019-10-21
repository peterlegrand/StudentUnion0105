using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuProcessTemplateFlowConditionTypeModel
    {
        public int Id { get; set; }
        [Display(Name = "Condition type name")]
        [MaxLength(50)]
        public string Name { get; set; }
        public Guid CreatorId { get; set; }
        public Guid ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<SuProcessTemplateFlowConditionModel> ProcessTemplateFlowConditions { get; set; }
    }
}
