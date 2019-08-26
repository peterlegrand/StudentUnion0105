using StudentUnion0105.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
