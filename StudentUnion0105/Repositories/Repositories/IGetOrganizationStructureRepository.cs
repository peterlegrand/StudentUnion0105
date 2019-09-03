using StudentUnion0105.SPModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Repositories
{
    public interface IGetOrganizationStructureRepository
    {
        IEnumerable<SuGetOrganizationStructure> GetOrganizationStructure(int Id);
    }
}
