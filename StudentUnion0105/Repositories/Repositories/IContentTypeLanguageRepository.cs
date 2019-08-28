using StudentUnion0105.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Repositories
{
    interface IContentTypeLanguageRepository
    {
        SuContentTypeLanguageModel GetContentTypeLanguage(int Id);
        IEnumerable<SuContentTypeLanguageModel> GetAllContentTypeLanguages();
        SuContentTypeLanguageModel AddContentTypeLanguage(SuContentTypeLanguageModel suContentTypeLanguage);
        SuContentTypeLanguageModel UpdateContentTypeLanguage(SuContentTypeLanguageModel suContentTypeLanguageChanges);
        SuContentTypeLanguageModel DeleteContentTypeLanguage(int Id);

    }
}
