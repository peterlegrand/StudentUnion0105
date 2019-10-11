using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IOrganizationLanguageRepository
    {
        SuOrganizationLanguageModel GetOrganizationLanguage(int Id);
        IEnumerable<SuOrganizationLanguageModel> GetAllOrganizationLanguages();
        SuOrganizationLanguageModel AddOrganizationLanguage(SuOrganizationLanguageModel suOrganizationLanguage);
        SuOrganizationLanguageModel UpdateOrganizationLanguage(SuOrganizationLanguageModel suOrganizationLanguageChanges);
        SuOrganizationLanguageModel DeleteOrganizationLanguage(int Id);
    }
}
