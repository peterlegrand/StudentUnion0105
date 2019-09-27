using System.Collections.Generic;
using static StudentUnion0105.SPModel.GetProjectStructure;

namespace StudentUnion0105.Repositories
{
    public interface IGetProjectStructureRepository
    {
        IEnumerable<SuGetProjectStructure> GetProjectStructure(int Id);
    }
}
