using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IUITermLanguageRepository
    {
        SuUITermLanguageModel GetTermLanguage(int Id);
        IEnumerable<SuUITermLanguageModel> GetAllTermLanguages();
        SuUITermLanguageModel AddTermLanguage(SuUITermLanguageModel SuTermLanguage);
        SuUITermLanguageModel UpdateTermLanguage(SuUITermLanguageModel SuTermLanguageChanges);
        SuUITermLanguageModel DeleteTermLanguage(int Id);

    }
}
