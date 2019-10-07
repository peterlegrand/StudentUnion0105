using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IProcessTemplateFlowConditionTypeLanguageRepository
    {
        SuProcessTemplateFlowConditionTypeLanguageModel GetProcessTemplateFlowConditionTypeLanguage(int Id);
        IEnumerable<SuProcessTemplateFlowConditionTypeLanguageModel> GetAllProcessTemplateFlowConditionTypeLanguages();
        SuProcessTemplateFlowConditionTypeLanguageModel AddProcessTemplateFlowConditionTypeLanguage(SuProcessTemplateFlowConditionTypeLanguageModel suProcessTemplateFlowConditionTypeLanguage);
        SuProcessTemplateFlowConditionTypeLanguageModel UpdateProcessTemplateFlowConditionTypeLanguage(SuProcessTemplateFlowConditionTypeLanguageModel suProcessTemplateFlowConditionTypeLanguageChanges);
        SuProcessTemplateFlowConditionTypeLanguageModel DeleteProcessTemplateFlowConditionTypeLanguage(int Id);
    }
}
