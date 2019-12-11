using System;
using System.Collections.Generic;

namespace StudentUnion0105.Models
{
    public class SuProcessTemplateGroupModel
    {
        public int Id { get; set; }
        public int Sequence { get; set; }
        public string CreatorId { get; set; }
        public string ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<SuProcessTemplateModel> ProcessTemplates { get; set; }
        public virtual ICollection<SuProcessTemplateGroupLanguageModel> ProcessTemplateGroupLanguages { get; set; }
    }
}
