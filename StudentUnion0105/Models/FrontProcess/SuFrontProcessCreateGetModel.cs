using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuFrontProcessCreateGetModel
    {
        [Key]
        public int OId { get; set; }
        public int PId { get; set; }
        public int StepId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<SuFrontProcessCreateGetFieldModel> ProcessFields { get; set; }

    }
}
