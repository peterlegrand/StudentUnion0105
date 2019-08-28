using StudentUnion0105.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Repositories
{
    interface IOrganizationTypeRepository
    {
        SuOrganizationTypeModel GetOrganizationType(int Id);
        IEnumerable<SuOrganizationTypeModel> GetAllOrganizationTypes();
        SuOrganizationTypeModel AddOrganizationType(SuOrganizationTypeModel suOrganizationType);
        SuOrganizationTypeModel UpdateOrganizationType(SuOrganizationTypeModel suOrganizationTypeChanges);
        SuOrganizationTypeModel DeleteOrganizationType(int Id);

    }
}
