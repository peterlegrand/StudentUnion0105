using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IProcessTemplateFlowConditionTypeRepository
    {
        SuProcessTemplateFlowConditionTypeModel GetProcessTemplateFlowConditionType(int Id);
        IEnumerable<SuProcessTemplateFlowConditionTypeModel> GetAllProcessTemplateFlowConditionTypes();
        SuProcessTemplateFlowConditionTypeModel AddProcessTemplateFlowConditionType(SuProcessTemplateFlowConditionTypeModel suProcessTemplateFlowConditionType);
        SuProcessTemplateFlowConditionTypeModel UpdateProcessTemplateFlowConditionType(SuProcessTemplateFlowConditionTypeModel suProcessTemplateFlowConditionTypeChanges);
        SuProcessTemplateFlowConditionTypeModel DeleteProcessTemplateFlowConditionType(int Id);
    }
}
