using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IProcessTemplateFlowLanguageRepository
    {
        SuProcessTemplateFlowLanguageModel GetProcessTemplateFlowLanguage(int Id);
        IEnumerable<SuProcessTemplateFlowLanguageModel> GetAllProcessTemplateFlowLanguages();
        SuProcessTemplateFlowLanguageModel AddProcessTemplateFlowLanguage(SuProcessTemplateFlowLanguageModel suProcessTemplateFlowLanguage);
        SuProcessTemplateFlowLanguageModel UpdateProcessTemplateFlowLanguage(SuProcessTemplateFlowLanguageModel suProcessTemplateFlowLanguageChanges);
        SuProcessTemplateFlowLanguageModel DeleteProcessTemplateFlowLanguage(int Id);
    }
}
