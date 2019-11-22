using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuFrontProcessIndexGetTemplateModel
    {
        [Key]
        public int OId { get; set; }
        public int PId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("PId")]
        public virtual SuFrontProcessIndexGetTemplateGroupModel FrontProcessTemplateGroup { get; set; }
    }
}
