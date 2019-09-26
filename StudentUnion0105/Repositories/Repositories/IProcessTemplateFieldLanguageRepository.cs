using StudentUnion0105.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
