using StudentUnion0105.SPModel;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IGetOrganizationStructureRepository
    {
        IEnumerable<SuGetOrganizationStructure> GetOrganizationStructure(int Id);
    }
}
