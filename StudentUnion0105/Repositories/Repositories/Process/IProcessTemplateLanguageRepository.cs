using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IProcessTemplateLanguageRepository
    {
        SuProcessTemplateLanguageModel GetProcessTemplateLanguage(int Id);
        IEnumerable<SuProcessTemplateLanguageModel> GetAllProcessTemplateLanguages();
        SuProcessTemplateLanguageModel AddProcessTemplateLanguage(SuProcessTemplateLanguageModel suProcessTemplateLanguage);
        SuProcessTemplateLanguageModel UpdateProcessTemplateLanguage(SuProcessTemplateLanguageModel suProcessTemplateLanguageChanges);
        SuProcessTemplateLanguageModel DeleteProcessTemplateLanguage(int Id);
    }
}
