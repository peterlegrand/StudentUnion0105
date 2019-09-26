using StudentUnion0105.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Repositories
{
    public interface IProcessTemplateStepFieldRepository
    {
        SuProcessTemplateStepFieldModel GetProcessTemplateStepField(int Id);
        IEnumerable<SuProcessTemplateStepFieldModel> GetAllProcessTemplateStepFields();
        SuProcessTemplateStepFieldModel AddProcessTemplateStepField(SuProcessTemplateStepFieldModel suProcessTemplateStepField);
        SuProcessTemplateStepFieldModel UpdateProcessTemplateStepField(SuProcessTemplateStepFieldModel suProcessTemplateStepFieldChanges);
        SuProcessTemplateStepFieldModel DeleteProcessTemplateStepField(int Id);
    }
}
