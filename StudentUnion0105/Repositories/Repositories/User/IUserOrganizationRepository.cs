using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IUserOrganizationRepository
    {
        SuUserOrganizationModel GetUserOrganization(int Id);
        IEnumerable<SuUserOrganizationModel> GetAllUserOrganizations();
        SuUserOrganizationModel AddUserOrganization(SuUserOrganizationModel suUserOrganization);
        SuUserOrganizationModel UpdateUserOrganization(SuUserOrganizationModel suUserOrganizationChanges);
        SuUserOrganizationModel DeleteUserOrganization(int Id);
    }
}
