using StudentUnion0105.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
