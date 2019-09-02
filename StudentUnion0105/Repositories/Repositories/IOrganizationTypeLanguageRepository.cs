using StudentUnion0105.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
