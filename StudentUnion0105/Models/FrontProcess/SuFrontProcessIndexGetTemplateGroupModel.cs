using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuFrontProcessIndexGetTemplateGroupModel
    {
        [Key]
        public int OId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<SuFrontProcessIndexGetTemplateModel> FrontProcessTemplates { get; set; }
    }
}
