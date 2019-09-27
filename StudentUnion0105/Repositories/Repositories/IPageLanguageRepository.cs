using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IPageLanguageRepository
    {
        SuPageLanguageModel GetPageLanguage(int Id);
        IEnumerable<SuPageLanguageModel> GetAllPageLanguages();
        SuPageLanguageModel AddPageLanguage(SuPageLanguageModel suPageLanguage);
        SuPageLanguageModel UpdatePageLanguage(SuPageLanguageModel suPageLanguageChanges);
        SuPageLanguageModel DeletePageLanguage(int Id);
    }
}
