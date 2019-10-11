using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface ILanguageRepository
    {
        SuLanguageModel GetLanguage(int ID);
        IEnumerable<SuLanguageModel> GetAllLanguages();

        SuLanguageModel UpdateLanguage(SuLanguageModel suLanguageChanges);

    }
}
