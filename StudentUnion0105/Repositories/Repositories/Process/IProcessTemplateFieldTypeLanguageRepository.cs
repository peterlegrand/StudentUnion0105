using StudentUnion0105.Models;
using System.Collections.Generic;

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
