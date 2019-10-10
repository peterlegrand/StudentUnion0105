using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IUserOrganizationTypeLanguageRepository
    {
        SuUserOrganizationTypeLanguageModel GetUserOrganizationTypeLanguage(int Id);
        IEnumerable<SuUserOrganizationTypeLanguageModel> GetAllUserOrganizationTypeLanguages();
        SuUserOrganizationTypeLanguageModel AddUserOrganizationTypeLanguage(SuUserOrganizationTypeLanguageModel suUserOrganizationTypeLanguage);
        SuUserOrganizationTypeLanguageModel UpdateUserOrganizationTypeLanguage(SuUserOrganizationTypeLanguageModel suUserOrganizationTypeLanguageChanges);
        SuUserOrganizationTypeLanguageModel DeleteUserOrganizationTypeLanguage(int Id);

    }
}
