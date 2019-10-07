using System.Collections.Generic;

namespace StudentUnion0105.Models
{
    public class SuProcessTemplateStepFieldStatusModel
    {
        public int Id { get; set; }

        public string StatusName { get; set; }

        public virtual ICollection<SuContentModel> SuProcessTemplateStepFieldModel { get; set; }
    }
}
