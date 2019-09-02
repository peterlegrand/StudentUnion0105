using StudentUnion0105.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
