using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IUserRelationTypeLanguageRepository
    {
        SuUserRelationTypeLanguageModel GetUserRelationTypeLanguage(int Id);
        IEnumerable<SuUserRelationTypeLanguageModel> GetAllUserRelationTypeLanguages();
        SuUserRelationTypeLanguageModel AddUserRelationTypeLanguage(SuUserRelationTypeLanguageModel suUserRelationTypeLanguage);
        SuUserRelationTypeLanguageModel UpdateUserRelationTypeLanguage(SuUserRelationTypeLanguageModel suUserRelationTypeLanguageChanges);
        SuUserRelationTypeLanguageModel DeleteUserRelationTypeLanguage(int Id);

    }
}
