using StudentUnion0105.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
