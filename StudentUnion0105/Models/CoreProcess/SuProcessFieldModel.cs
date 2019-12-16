using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuProcessFieldModel
    {
        public int Id { get; set; }
        public int ProcessId { get; set; }
        public int ProcessTemplateFieldId { get; set; }
        public string StringValue { get; set; }
        public int IntValue { get; set; }
        public DateTime DateTimeValue { get; set; }
        [ForeignKey("ProcessTemplateFieldId")]
        public virtual SuProcessTemplateFieldModel ProcessTemplateField { get; set; }
        [ForeignKey("ProcessId")]
        public virtual SuProcessModel Process { get; set; }
    }
}
