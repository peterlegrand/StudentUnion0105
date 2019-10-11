using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IOrganizationTypeRepository
    {
        SuOrganizationTypeModel GetOrganizationType(int Id);
        IEnumerable<SuOrganizationTypeModel> GetAllOrganizationTypes();
        SuOrganizationTypeModel AddOrganizationType(SuOrganizationTypeModel suOrganizationType);
        SuOrganizationTypeModel UpdateOrganizationType(SuOrganizationTypeModel suOrganizationTypeChanges);
        SuOrganizationTypeModel DeleteOrganizationType(int Id);

    }
}
