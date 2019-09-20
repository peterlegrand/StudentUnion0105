using StudentUnion0105.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace StudentUnion0105.Repositories
{
    public  interface IPageSectionLanguageRepository
    {
        SuPageSectionLanguageModel GetPageSectionLanguage(int Id);
        IEnumerable<SuPageSectionLanguageModel> GetAllPageSectionLanguages();
        SuPageSectionLanguageModel AddPageSectionLanguage(SuPageSectionLanguageModel suPageSectionLanguage);
        SuPageSectionLanguageModel UpdatePageSectionLanguage(SuPageSectionLanguageModel suPageSectionLanguageChanges);
        SuPageSectionLanguageModel DeletePageSectionLanguage(int Id);
    }
}
