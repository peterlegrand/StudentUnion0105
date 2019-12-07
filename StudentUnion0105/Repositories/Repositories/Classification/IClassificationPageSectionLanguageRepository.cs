using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IClassificationPageSectionLanguageRepository
    {
        SuClassificationPageSectionLanguageModel GetClassificationPageSectionLanguage(int Id);
        IEnumerable<SuClassificationPageSectionLanguageModel> GetAllClassificationPageSectionLanguages();
        SuClassificationPageSectionLanguageModel AddClassificationPageSectionLanguage(SuClassificationPageSectionLanguageModel suClassificationPageSectionLanguage);
        SuClassificationPageSectionLanguageModel UpdateClassificationPageSectionLanguage(SuClassificationPageSectionLanguageModel suClassificationPageSectionLanguageChanges);
        SuClassificationPageSectionLanguageModel DeleteClassificationPageSectionLanguage(int Id);

    }
}
