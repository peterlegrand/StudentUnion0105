using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IContentTypeLanguageRepository
    {
        SuContentTypeLanguageModel GetContentTypeLanguage(int Id);
        IEnumerable<SuContentTypeLanguageModel> GetAllContentTypeLanguages();
        SuContentTypeLanguageModel AddContentTypeLanguage(SuContentTypeLanguageModel suContentTypeLanguage);
        SuContentTypeLanguageModel UpdateContentTypeLanguage(SuContentTypeLanguageModel suContentTypeLanguageChanges);
        SuContentTypeLanguageModel DeleteContentTypeLanguage(int Id);

    }
}
