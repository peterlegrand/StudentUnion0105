using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IClassificationPageLanguageRepository
    {
        SuClassificationPageLanguageModel GetClassificationPageLanguage(int Id);
        IEnumerable<SuClassificationPageLanguageModel> GetAllClassificationPageLanguages();
        SuClassificationPageLanguageModel AddClassificationPageLanguage(SuClassificationPageLanguageModel suClassificationPageLanguage);
        SuClassificationPageLanguageModel UpdateClassificationPageLanguage(SuClassificationPageLanguageModel suClassificationPageLanguageChanges);
        SuClassificationPageLanguageModel DeleteClassificationPageLanguage(int Id);

    }
}
