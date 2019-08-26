using StudentUnion0105.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Repositories
{
    public interface IClassificationLanguageRepository
    {
        SuClassificationLanguageModel GetClassificationLanguage(int Id);
        IEnumerable<SuClassificationLanguageModel> GetAllClassificationLanguages();
        SuClassificationLanguageModel AddClassificationLanguage(SuClassificationLanguageModel suClassificationLanguage);
        SuClassificationLanguageModel UpdateClassificationLanguage(SuClassificationLanguageModel suClassificationLanguageChanges);
        SuClassificationLanguageModel DeleteClassificationLanguage(int Id);

    }
}
