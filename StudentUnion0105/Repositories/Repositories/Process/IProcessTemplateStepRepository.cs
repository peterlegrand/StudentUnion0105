using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IProcessTemplateStepRepository
    {
        SuProcessTemplateStepModel GetProcessTemplateStep(int Id);
        IEnumerable<SuProcessTemplateStepModel> GetAllProcessTemplateSteps();
        SuProcessTemplateStepModel AddProcessTemplateStep(SuProcessTemplateStepModel suProcessTemplateStep);
        SuProcessTemplateStepModel UpdateProcessTemplateStep(SuProcessTemplateStepModel suProcessTemplateStepChanges);
        SuProcessTemplateStepModel DeleteProcessTemplateStep(int Id);
    }
}
