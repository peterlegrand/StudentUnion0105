using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IProcessTemplateGroupLanguageRepository
    {
        SuProcessTemplateGroupLanguageModel GetProcessTemplateGroupLanguage(int Id);
        IEnumerable<SuProcessTemplateGroupLanguageModel> GetAllProcessTemplateGroupLanguages();
        SuProcessTemplateGroupLanguageModel AddProcessTemplateGroupLanguage(SuProcessTemplateGroupLanguageModel suProcessTemplateGroupLanguage);
        SuProcessTemplateGroupLanguageModel UpdateProcessTemplateGroupLanguage(SuProcessTemplateGroupLanguageModel suProcessTemplateGroupLanguageChanges);
        SuProcessTemplateGroupLanguageModel DeleteProcessTemplateGroupLanguage(int Id);
    }
}
