using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IClassificationValueLanguageRepository
    {
        SuClassificationValueLanguageModel GetClassificationValueLanguage(int Id);
        IEnumerable<SuClassificationValueLanguageModel> GetAllClassificationValueLanguages();
        SuClassificationValueLanguageModel AddClassificationValueLanguage(SuClassificationValueLanguageModel suClassificationValueLanguage);
        SuClassificationValueLanguageModel UpdateClassificationValueLanguage(SuClassificationValueLanguageModel suClassificationValueLanguageChanges);
        SuClassificationValueLanguageModel DeleteClassificationValueLanguage(int Id);

    }
}
