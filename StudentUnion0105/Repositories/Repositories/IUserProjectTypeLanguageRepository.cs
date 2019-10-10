using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IUserProjectTypeLanguageRepository
    {
        SuUserProjectTypeLanguageModel GetUserProjectTypeLanguage(int Id);
        IEnumerable<SuUserProjectTypeLanguageModel> GetAllUserProjectTypeLanguages();
        SuUserProjectTypeLanguageModel AddUserProjectTypeLanguage(SuUserProjectTypeLanguageModel suUserProjectTypeLanguage);
        SuUserProjectTypeLanguageModel UpdateUserProjectTypeLanguage(SuUserProjectTypeLanguageModel suUserProjectTypeLanguageChanges);
        SuUserProjectTypeLanguageModel DeleteUserProjectTypeLanguage(int Id);

    }
}
