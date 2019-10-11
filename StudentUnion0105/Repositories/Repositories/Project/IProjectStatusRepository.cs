using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IProjectStatusRepository
    {
        SuProjectStatusModel GetSuProjectStatus(int Id);
        IEnumerable<SuProjectStatusModel> GetAllProjectStatus();
    }
}
