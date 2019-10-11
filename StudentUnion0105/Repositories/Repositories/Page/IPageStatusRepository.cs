using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IPageStatusRepository
    {
        SuPageStatusModel GetSuPageStatus(int Id);
        IEnumerable<SuPageStatusModel> GetAllPageStatus();
    }
}
