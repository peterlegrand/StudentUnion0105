using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IUserProjectRepository
    {
        SuUserProjectModel GetUserProject(int Id);
        IEnumerable<SuUserProjectModel> GetAllUserProjects();
        SuUserProjectModel AddUserProject(SuUserProjectModel suUserProject);
        SuUserProjectModel UpdateUserProject(SuUserProjectModel suUserProjectChanges);
        SuUserProjectModel DeleteUserProject(int Id);
    }
}
