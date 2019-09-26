using StudentUnion0105.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Repositories
{
    public interface IProcessTemplateFieldTypeLanguageRepository
    {
        SuProcessTemplateFieldTypeLanguageModel GetProcessTemplateFieldTypeLanguage(int Id);
        IEnumerable<SuProcessTemplateFieldTypeLanguageModel> GetAllProcessTemplateFieldTypeLanguages();
        SuProcessTemplateFieldTypeLanguageModel AddProcessTemplateFieldTypeLanguage(SuProcessTemplateFieldTypeLanguageModel suProcessTemplateFieldTypeLanguage);
        SuProcessTemplateFieldTypeLanguageModel UpdateProcessTemplateFieldTypeLanguage(SuProcessTemplateFieldTypeLanguageModel suProcessTemplateFieldTypeLanguageChanges);
        SuProcessTemplateFieldTypeLanguageModel DeleteProcessTemplateFieldTypeLanguage(int Id);
    }
}
