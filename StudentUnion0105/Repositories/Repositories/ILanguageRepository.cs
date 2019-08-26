using StudentUnion0105.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Repositories
{
    public interface ILanguageRepository
    {
        SuLanguageModel GetSuLanguage(int ID);
        IEnumerable<SuLanguageModel> GetAllLanguages();

        SuLanguageModel UpdateLanguage(SuLanguageModel suLanguageChanges);

    }
}
