using StudentUnion0105.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Repositories
{
    public interface IProcessTemplateFlowConditionRepository
    {
        SuProcessTemplateFlowConditionModel GetProcessTemplateFlowCondition(int Id);
        IEnumerable<SuProcessTemplateFlowConditionModel> GetAllProcessTemplateFlowConditions();
        SuProcessTemplateFlowConditionModel AddProcessTemplateFlowCondition(SuProcessTemplateFlowConditionModel suProcessTemplateFlowCondition);
        SuProcessTemplateFlowConditionModel UpdateProcessTemplateFlowCondition(SuProcessTemplateFlowConditionModel suProcessTemplateFlowConditionChanges);
        SuProcessTemplateFlowConditionModel DeleteProcessTemplateFlowCondition(int Id);
    }
}
