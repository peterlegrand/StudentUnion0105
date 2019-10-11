using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IClassificationLevelLanguageRepository
    {
        SuClassificationLevelLanguageModel GetClassificationLevelLanguage(int Id);
        IEnumerable<SuClassificationLevelLanguageModel> GetAllClassificationLevelLanguages();
        SuClassificationLevelLanguageModel AddClassificationLevelLanguage(SuClassificationLevelLanguageModel suClassificationLevelLanguage);
        SuClassificationLevelLanguageModel UpdateClassificationLevelLanguage(SuClassificationLevelLanguageModel suClassificationLevelLanguageChanges);
        SuClassificationLevelLanguageModel DeleteClassificationLevelLanguage(int Id);

    }
}
