using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IProcessTemplateFieldLanguageRepository
    {
        SuProcessTemplateFieldLanguageModel GetProcessTemplateFieldLanguage(int Id);
        IEnumerable<SuProcessTemplateFieldLanguageModel> GetAllProcessTemplateFieldLanguages();
        SuProcessTemplateFieldLanguageModel AddProcessTemplateFieldLanguage(SuProcessTemplateFieldLanguageModel suProcessTemplateFieldLanguage);
        SuProcessTemplateFieldLanguageModel UpdateProcessTemplateFieldLanguage(SuProcessTemplateFieldLanguageModel suProcessTemplateFieldLanguageChanges);
        SuProcessTemplateFieldLanguageModel DeleteProcessTemplateFieldLanguage(int Id);
    }
}
