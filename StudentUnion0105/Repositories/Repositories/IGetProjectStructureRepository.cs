using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static StudentUnion0105.SPModel.GetProjectStructure;

namespace StudentUnion0105.Repositories
{
    public interface IGetProjectStructureRepository
    {
        IEnumerable<SuGetProjectStructure> GetProjectStructure(int Id);
    }
}
