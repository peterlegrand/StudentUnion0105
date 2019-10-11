using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IPageTypeLanguageRepository
    {
        SuPageTypeLanguageModel GetPageTypeLanguage(int Id);
        IEnumerable<SuPageTypeLanguageModel> GetAllPageTypeLanguages();
        SuPageTypeLanguageModel AddPageTypeLanguage(SuPageTypeLanguageModel suPageTypeLanguage);
        SuPageTypeLanguageModel UpdatePageTypeLanguage(SuPageTypeLanguageModel suPageTypeLanguageChanges);
        SuPageTypeLanguageModel DeletePageTypeLanguage(int Id);

    }
}
