using StudentUnion0105.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Repositories
{
    public interface IProjectRepository
    {
        SuProjectModel GetProject(int Id);
        IEnumerable<SuProjectModel> GetAllProjects();
        SuProjectModel AddProject(SuProjectModel suProject);
        SuProjectModel UpdateProject(SuProjectModel suProjectChanges);
        SuProjectModel DeleteProject(int Id);

    }
}
