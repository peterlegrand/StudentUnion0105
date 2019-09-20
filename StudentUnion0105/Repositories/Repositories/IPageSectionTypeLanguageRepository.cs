using StudentUnion0105.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace StudentUnion0105.Repositories
{
    public  interface IPageSectionTypeLanguageRepository
    {
        SuPageSectionTypeLanguageModel GetPageSectionTypeLanguage(int Id);
        IEnumerable<SuPageSectionTypeLanguageModel> GetAllPageSectionTypeLanguages();
        SuPageSectionTypeLanguageModel AddPageSectionTypeLanguage(SuPageSectionTypeLanguageModel suPageSectionTypeLanguage);
        SuPageSectionTypeLanguageModel UpdatePageSectionTypeLanguage(SuPageSectionTypeLanguageModel suPageSectionTypeLanguageChanges);
        SuPageSectionTypeLanguageModel DeletePageSectionTypeLanguage(int Id);
    }
}
