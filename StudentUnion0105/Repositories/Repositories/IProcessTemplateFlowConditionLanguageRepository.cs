using StudentUnion0105.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Repositories
{
    public interface IProcessTemplateFlowConditionLanguageRepository
    {
        SuProcessTemplateFlowConditionLanguageModel GetProcessTemplateFlowConditionLanguage(int Id);
        IEnumerable<SuProcessTemplateFlowConditionLanguageModel> GetAllProcessTemplateFlowConditionLanguages();
        SuProcessTemplateFlowConditionLanguageModel AddProcessTemplateFlowConditionLanguage(SuProcessTemplateFlowConditionLanguageModel suProcessTemplateFlowConditionLanguage);
        SuProcessTemplateFlowConditionLanguageModel UpdateProcessTemplateFlowConditionLanguage(SuProcessTemplateFlowConditionLanguageModel suProcessTemplateFlowConditionLanguageChanges);
        SuProcessTemplateFlowConditionLanguageModel DeleteProcessTemplateFlowConditionLanguage(int Id);
    }
}
