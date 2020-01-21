using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentUnion0105.Models
{
    public class SuProcessTemplateStepTypeModel
    {
        public int Id { get; set; }
        public virtual ICollection<SuProcessTemplateStepModel> ProcessTemplateSteps { get; set; }

    }
}
