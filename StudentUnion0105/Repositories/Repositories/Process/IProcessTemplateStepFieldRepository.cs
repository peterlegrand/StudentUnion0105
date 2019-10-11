using StudentUnion0105.Models;
using System.Collections.Generic;

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
