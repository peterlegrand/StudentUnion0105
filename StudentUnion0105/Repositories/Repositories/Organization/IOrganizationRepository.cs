using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IOrganizationRepository
    {
        SuOrganizationModel GetOrganization(int Id);
        IEnumerable<SuOrganizationModel> GetAllOrganizations();
        SuOrganizationModel AddOrganization(SuOrganizationModel suOrganization);
        SuOrganizationModel UpdateOrganization(SuOrganizationModel suOrganizationChanges);
        SuOrganizationModel DeleteOrganization(int Id);

    }
}
