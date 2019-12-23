using System;
using System.Collections.Generic;

namespace StudentUnion0105.Models
{
    public class SuProcessTemplateFieldTypeModel
    {
        public int Id { get; set; }
        public virtual ICollection<SuProcessTemplateFieldTypeLanguageModel> ProcessTemplateFieldTypeLanguages { get; set; }
        public virtual ICollection<SuProcessTemplateFieldModel> ProcessTemplateField { get; set; }
    }
}
