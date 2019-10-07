using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IProcessTemplateStepFieldStatusRepository
    {
        SuProcessTemplateStepFieldStatusModel GetProcessTemplateStepFieldStatus(int Id);
        IEnumerable<SuProcessTemplateStepFieldStatusModel> GetAllProcessTemplateStepFieldStatus();
    }
}
