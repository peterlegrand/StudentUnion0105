using StudentUnion0105.Models;
using System.Collections.Generic;


namespace StudentUnion0105.Repositories
{
    public interface IPageSectionLanguageRepository
    {
        SuPageSectionLanguageModel GetPageSectionLanguage(int Id);
        IEnumerable<SuPageSectionLanguageModel> GetAllPageSectionLanguages();
        SuPageSectionLanguageModel AddPageSectionLanguage(SuPageSectionLanguageModel suPageSectionLanguage);
        SuPageSectionLanguageModel UpdatePageSectionLanguage(SuPageSectionLanguageModel suPageSectionLanguageChanges);
        SuPageSectionLanguageModel DeletePageSectionLanguage(int Id);
    }
}
