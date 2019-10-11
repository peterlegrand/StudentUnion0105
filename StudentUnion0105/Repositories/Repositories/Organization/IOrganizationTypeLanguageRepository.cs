using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IOrganizationTypeLanguageRepository
    {
        SuOrganizationTypeLanguageModel GetOrganizationTypeLanguage(int Id);
        IEnumerable<SuOrganizationTypeLanguageModel> GetAllOrganizationTypeLanguages();
        SuOrganizationTypeLanguageModel AddOrganizationTypeLanguage(SuOrganizationTypeLanguageModel suOrganizationTypeLanguage);
        SuOrganizationTypeLanguageModel UpdateOrganizationTypeLanguage(SuOrganizationTypeLanguageModel suOrganizationTypeLanguageChanges);
        SuOrganizationTypeLanguageModel DeleteOrganizationTypeLanguage(int Id);

    }
}
