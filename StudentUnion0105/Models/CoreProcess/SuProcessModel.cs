using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuProcessModel
    {
        public int Id { get; set; }
        public int ProcessTemplateId { get; set; }
        public int StepId { get; set; }
        public string CreatorId { get; set; }
        public string ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("ProcessTemplateId")]
        public virtual SuProcessTemplateModel ProcessTemplate { get; set; }
        public virtual ICollection<SuProcessTemplateFieldModel> ProcessTemplateField { get; set; }

    }
    public class SuMultiProcessModel
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public List<SuProcessModel> Processes { get; set; }
    }
}
