using StudentUnion0105.Models;
using System.Collections.Generic;

namespace StudentUnion0105.Repositories
{
    public interface IContentStatusRepository
    {
        SuContentStatusModel GetSuContentStatus(int Id);
        IEnumerable<SuContentStatusModel> GetAllContentStatus();


    }
}
