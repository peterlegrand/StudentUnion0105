using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface ISecurityLevelRepository
    {
        SuSecurityLevelModel GetSuSecurityLevel(int Id);
        IEnumerable<SuSecurityLevelModel> GetAllSecurityLevel();


    }
}
